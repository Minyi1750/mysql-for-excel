﻿// Copyright (c) 2012-2013, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License as
// published by the Free Software Foundation; version 2 of the
// License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301  USA

namespace MySQL.ForExcel
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Data;
  using System.Drawing;
  using System.Runtime.InteropServices;
  using System.Text;
  using System.Windows.Forms;
  using MySQL.Utility;
  using MySQL.Utility.Forms;
  using Excel = Microsoft.Office.Interop.Excel;

  /// <summary>
  /// Provides a minimalistic floating interface used for editing sessions against MySQL tables.
  /// </summary>
  public partial class EditDataDialog : AutoStyleableBaseForm
  {
    #region Constants

    /// <summary>
    /// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window.
    /// </summary>
    private const int HWND_NOTOPMOST = -2;

    /// <summary>
    /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
    /// </summary>
    private const int HWND_TOPMOST = -1;

    /// <summary>
    /// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
    /// </summary>
    private const int SW_SHOWNOACTIVATE = 4;

    /// <summary>
    /// Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
    /// </summary>
    private const uint SWP_NOACTIVATE = 0x0010;

    #endregion Constants

    #region Fields

    /// <summary>
    /// A point object used as a placeholder to track where the mouse has been pressed.
    /// </summary>
    private Point _mouseDownPoint;

    /// <summary>
    /// The query string assembled to perform operations against the MySQL table (UPDATE, INSERT, DELETE).
    /// </summary>
    private string _queryString;

    /// <summary>
    /// Flag indicating whether the editing session is in process of undoing changes done
    /// </summary>
    private bool _undoingChanges;

    #endregion Fields

    /// <summary>
    /// Initializes a new instance of the <see cref="EditDataDialog"/> class.
    /// </summary>
    /// <param name="parentTaskPane">The <see cref="ExcelAddInPane"/> from which the <see cref="EditDataDialog"/> is called.</param>
    /// <param name="parentWindow">The parent window assigned to the <see cref="EditDataDialog"/> to be opened as a dialog.</param>
    /// <param name="wbConnection">The connection to a MySQL server instance selected by users.</param>
    /// <param name="originalEditDataRange">The Excel cells range containing the MySQL table's data being edited.</param>
    /// <param name="importTable">The table containing the data imported from the MySQL table that will be edited.</param>
    /// <param name="editingWorksheet">The Excel worksheet tied to the current editing session.</param>
    public EditDataDialog(ExcelAddInPane parentTaskPane, IWin32Window parentWindow, MySqlWorkbenchConnection wbConnection, Excel.Range originalEditDataRange, DataTable importTable, Excel.Worksheet editingWorksheet)
    {
      _mouseDownPoint = Point.Empty;
      _undoingChanges = false;

      InitializeComponent();

      WorksheetProtectionKey = Guid.NewGuid().ToString();
      ParentTaskPane = parentTaskPane;
      ParentWindow = parentWindow;
      WBConnection = wbConnection;
      EditDataRange = originalEditDataRange;
      _queryString = importTable.ExtendedProperties["QueryString"].ToString();
      string tableName = importTable.TableName;
      if (importTable.ExtendedProperties.ContainsKey("TableName") && !string.IsNullOrEmpty(importTable.ExtendedProperties["TableName"].ToString()))
      {
        tableName = importTable.ExtendedProperties["TableName"].ToString();
      }

      EditMySQLDataTable = new MySQLDataTable(tableName, importTable, wbConnection);
      if (importTable.ExtendedProperties.ContainsKey("QueryString") && !string.IsNullOrEmpty(importTable.ExtendedProperties["QueryString"].ToString()))
      {
        EditMySQLDataTable.SelectQuery = importTable.ExtendedProperties["QueryString"].ToString();
      }

      EditingWorksheet = editingWorksheet;
      EditingWorksheet.SelectionChange += new Excel.DocEvents_SelectionChangeEventHandler(EditingWorksheet_SelectionChange);
      ResetToolTip();
      EditingColsQuantity = editingWorksheet.UsedRange.Columns.Count;
      EditingRowsQuantity = 0;
      Opacity = 0.60;
      AddNewRowToEditingRange(false);
      RangesAndAddressesList = new List<RangeAndAddress>();
    }

    #region Properties

    /// <summary>
    /// Gets the Excel cells range containing the MySQL table's data being edited.
    /// </summary>
    public Excel.Range EditDataRange { get; private set; }

    /// <summary>
    /// Gets the number of columns in the current editing session.
    /// </summary>
    public long EditingColsQuantity { get; private set; }

    /// <summary>
    /// Gets the number of rows in the current editing session.
    /// </summary>
    public long EditingRowsQuantity { get; private set; }

    /// <summary>
    /// Gets the name of the MySQL table whose data is being edited.
    /// </summary>
    public string EditingTableName
    {
      get
      {
        return EditMySQLDataTable != null ? EditMySQLDataTable.TableName : null;
      }
    }

    /// <summary>
    /// Gets the Excel worksheet tied to the current editing session.
    /// </summary>
    public Excel.Worksheet EditingWorksheet { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the Excel worksheet tied to the current editing session still exists.
    /// </summary>
    public bool EditingWorksheetExists
    {
      get
      {
        bool exists = false;
        if (EditingWorksheet != null)
        {
          try
          {
            Excel.Workbook wb = EditingWorksheet.Parent as Excel.Workbook;
            exists = true;
          }
          catch
          {
            exists = false;
          }
        }

        return exists;
      }
    }

    /// <summary>
    /// Gets the <see cref="MySQLDataTable"/> whose data is being edited.
    /// </summary>
    public MySQLDataTable EditMySQLDataTable { get; private set; }

    /// <summary>
    /// Gets the <see cref="ExcelAddInPane"/> from which the <see cref="EditDataDialog"/> is called.
    /// </summary>
    public ExcelAddInPane ParentTaskPane { get; private set; }

    /// <summary>
    /// Gets the parent window assigned to the <see cref="EditDataDialog"/> to be opened as a dialog.
    /// </summary>
    public IWin32Window ParentWindow { get; private set; }

    /// <summary>
    /// Gets a list of <see cref="RangeAndAddress"/> objects containing information about the Excel cells being edited.
    /// </summary>
    public List<RangeAndAddress> RangesAndAddressesList { get; private set; }

    /// <summary>
    /// Gets a value indicating whether uncommited data exists in the editing session.
    /// </summary>
    public bool UncommitedDataExists
    {
      get
      {
        return RangesAndAddressesList != null ? RangesAndAddressesList.Count > 0 : false;
      }
    }

    /// <summary>
    /// Gets the connection to a MySQL server instance selected by users.
    /// </summary>
    public MySqlWorkbenchConnection WBConnection { get; private set; }

    /// <summary>
    /// Gets the name of the Excel workbook that contains the worksheet tied to the current editing session.
    /// </summary>
    public string WorkbookName
    {
      get
      {
        try
        {
          return (EditingWorksheet.Parent as Excel.Workbook).Name;
        }
        catch
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Gets the name of the Excel worksheet tied to the current editing session.
    /// </summary>
    public string WorksheetName
    {
      get
      {
        try
        {
          return EditingWorksheet.Name;
        }
        catch
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Gets the GUID used as a key to protect the editing Excel worksheet.
    /// </summary>
    public string WorksheetProtectionKey { get; private set; }

    #endregion Properties

    /// <summary>
    /// Shows the dialog as the topmost window without placing the focus on it (i.e. leaving the focus on the parent window).
    /// </summary>
    public void ShowInactiveTopmost()
    {
      ShowWindow(Handle, SW_SHOWNOACTIVATE);
      SetWindowPos(Handle.ToInt32(), HWND_NOTOPMOST, Left, Top, Width, Height, SWP_NOACTIVATE);
    }

    /// <summary>
    /// Raises the Closing event.
    /// </summary>
    /// <param name="e">A <see cref="CancelEventArgs"/> that contains the event data.</param>
    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      ParentTaskPane.RefreshDbObjectPanelActionLabelsEnabledStatus(EditingTableName, false);
      if (EditingWorksheetExists)
      {
        EditingWorksheet.Unprotect(WorksheetProtectionKey);
        EditingWorksheet.UsedRange.Interior.ColorIndex = Excel.XlColorIndex.xlColorIndexNone;
      }

      ActiveEditDialogContainer editContainer = ParentTaskPane.ActiveEditDialogsList.Find(ac => ac.EditDialog.Equals(this));
      if (editContainer != null)
      {
        ParentTaskPane.ActiveEditDialogsList.Remove(editContainer);
      }

      Dispose();
    }

    /// <summary>
    /// Raises the MouseDown event.
    /// </summary>
    /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      GenericMouseDown(this, e);
    }

    /// <summary>
    /// Raises the MouseMove event.
    /// </summary>
    /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      GenericMouseMove(this, e);
    }

    /// <summary>
    /// Raises the MouseUp event.
    /// </summary>
    /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      GenericMouseUp(this, e);
    }

    /// <summary>
    /// Paints the background of the control.
    /// </summary>
    /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
    protected override void OnPaintBackground(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
      Pen pen = new Pen(Color.White, 3f);
      e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 2, this.Height - 2);
      pen.Width = 1f;
      e.Graphics.DrawLine(pen, 0, 25, this.Width, 25);
      pen.Dispose();
    }

    /// <summary>
    /// Changes the size, position, and Z-order of child, pop-up, and top-level windows.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="hWndInsertAfter">Identifies the CWnd object that will precede (be higher than) this CWnd object in the Z-order.</param>
    /// <param name="X">Specifies the new position of the left side of the window.</param>
    /// <param name="Y">Specifies the new position of the top of the window.</param>
    /// <param name="cx">Specifies the new width of the window.</param>
    /// <param name="cy">Specifies the new height of the window.</param>
    /// <param name="uFlags">Specifies sizing and positioning options.</param>
    /// <returns><c>true</c> if the function is successful; <c>false</c> otherwise.</returns>
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    /// <summary>
    /// Sets the specified window's show state.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="nCmdShow">Controls how the window is to be shown.</param>
    /// <returns><c>true</c> if the window was previously visible, <c>false</c> if the window was previously hidden.</returns>
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary>
    /// Adds a new row at the bottom of the Excel editing range.
    /// </summary>
    /// <param name="clearColoringOfOldNewRow">Flag indicating whether the previous row that was placeholder for new rows is cleared of its formatting.</param>
    /// <returns>An Excel range containing just the newly added row.</returns>
    private Excel.Range AddNewRowToEditingRange(bool clearColoringOfOldNewRow)
    {
      EditingWorksheet.UnprotectEditingWorksheet(EditingWorksheet_Change, WorksheetProtectionKey);
      Excel.Range rowRange = EditDataRange.AddNewRow(clearColoringOfOldNewRow);
      EditingWorksheet.ProtectEditingWorksheet(EditingWorksheet_Change, WorksheetProtectionKey, EditDataRange);
      return rowRange;
    }

    /// <summary>
    /// Event delegate method called when the <see cref="AutoCommitCheckBox"/> checked property value changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void AutoCommitCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      CommitChangesButton.Enabled = !AutoCommitCheckBox.Checked && UncommitedDataExists;
    }

    /// <summary>
    /// Event delegate method called when the <see cref="CommitChangesButton"/> is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void CommitChangesButton_Click(object sender, EventArgs e)
    {
      PushDataChanges();
    }

    /// <summary>
    /// Event delegate method called when the <see cref="EditDataDialog"/> window is activated.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void EditDataDialog_Activated(object sender, EventArgs e)
    {
      ResetToolTip();
    }

    /// <summary>
    /// Event delegate method called when the <see cref="EditDataDialog"/> window is shown for the first time.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void EditDataDialog_Shown(object sender, EventArgs e)
    {
      //// Need to call the ShowInactiveTopmost method when the form is shown in order to make it topmost and
      //// to avoid that the controls inside it activate so focus remains on excel cells.
      ShowInactiveTopmost();
    }

    /// <summary>
    /// Event delegate method fired when any value in a cell within the <see cref="EditingWorksheet"/> changes.
    /// </summary>
    /// <remarks>
    /// This method is used to record any changes done by users to the data and prepare corresponding changes within a data table object
    /// that later will generate queries to commit the data changes to the MySQL server.
    /// </remarks>
    /// <param name="Target"></param>
    private void EditingWorksheet_Change(Excel.Range Target)
    {
      if (_undoingChanges)
      {
        return;
      }

      bool rowWasDeleted = EditingWorksheet.UsedRange.Rows.Count < EditingRowsQuantity && Target.Columns.Count == EditingWorksheet.Columns.Count;
      bool undoChanges = false;
      string operationSummary = null;
      string operationDetails = null;

      Excel.Range intersectRange = EditDataRange.IntersectWith(Target);
      if (intersectRange == null || intersectRange.Count == 0)
      {
        if (rowWasDeleted)
        {
          //// The row for insertions is attempted to be deleted, we need to undo
          undoChanges = true;
          operationSummary = Properties.Resources.EditDataDeleteLastRowNotPermittedErrorTitle;
          operationDetails = Properties.Resources.EditDataDeleteLastRowNotPermittedErrorDetail;
        }
        else
        {
          //// It is a modification and outside the permitted range
          undoChanges = true;
          operationSummary = Properties.Resources.EditDataOutsideEditingRangeNotPermittedErrorTitle;
          operationDetails = Properties.Resources.EditDataOutsideEditingRangeNotPermittedErrorDetail;
        }
      }

      if (undoChanges)
      {
        MiscUtilities.ShowCustomizedErrorDialog(operationSummary, operationDetails, true);
        UndoChanges();
        if (rowWasDeleted)
        {
          int changedRangesQty = RangesAndAddressesList.RefreshAddressesOfStoredRanges();
          EditDataRange = EditingWorksheet.UsedRange;
        }

        return;
      }

      //// Substract from the Excel indexes since they start at 1, ExcelRow is subtracted by 2 if we imported headers.
      Excel.Range startCell = (intersectRange.Item[1, 1] as Excel.Range);
      int startDataTableRow = startCell.Row - 2;
      int startDataTableCol = startCell.Column - 1;

      //// Detect if a row was deleted and if so flag it for deletion
      if (rowWasDeleted)
      {
        List<int> skipDeletedRowsList = new List<int>();
        foreach (Excel.Range deletedRow in Target.Rows)
        {
          startDataTableRow = deletedRow.Row - 2;
          startDataTableRow = EditMySQLDataTable.SearchRowIndexNotDeleted(startDataTableRow, skipDeletedRowsList, EditDataRange.Rows.Count);
          DataRow dr = EditMySQLDataTable.Rows[startDataTableRow];
          dr.Delete();
          skipDeletedRowsList.Add(startDataTableRow);
          RangeAndAddress addedRA = RangesAndAddressesList.Find(ra => ra.Modification == RangeAndAddress.RangeModification.Added && ra.ExcelRow == deletedRow.Row);
          if (addedRA != null)
          {
            RangesAndAddressesList.Remove(addedRA);
          }
          else if (!RangesAndAddressesList.Exists(ra => ra.Modification == RangeAndAddress.RangeModification.Deleted && ra.Address == deletedRow.Address))
          {
            RangesAndAddressesList.Add(new RangeAndAddress(RangeAndAddress.RangeModification.Deleted, deletedRow, deletedRow.Address, (int)deletedRow.Interior.Color, deletedRow.Row, dr));
          }
        }

        for (int rangeIdx = 0; rangeIdx < RangesAndAddressesList.Count; rangeIdx++)
        {
          bool removeFromList = false;
          RangeAndAddress ra = RangesAndAddressesList[rangeIdx];
          if (ra.Modification == RangeAndAddress.RangeModification.Deleted)
          {
            continue;
          }

          try
          {
            ra.Address = ra.Range.Address;
          }
          catch
          {
            removeFromList = true;
          }

          if (removeFromList)
          {
            RangesAndAddressesList.Remove(ra);
            rangeIdx--;
          }
        }

        int changedRangesQty = RangesAndAddressesList.RefreshAddressesOfStoredRanges();
        EditingRowsQuantity = EditDataRange.Rows.Count;
      }
      else
      {
        //// The change was a modification of cell values
        MySQLDataColumn currCol = null;
        try
        {
          for (int rowIdx = 1; rowIdx <= intersectRange.Rows.Count; rowIdx++)
          {
            for (int colIdx = 1; colIdx <= intersectRange.Columns.Count; colIdx++)
            {
              Excel.Range cell = intersectRange.Cells[rowIdx, colIdx] as Excel.Range;

              //// Detect if a data row has been added by the user and if so flag it for addition
              if (cell.Row == EditDataRange.Rows.Count)
              {
                if (cell.Value == null)
                {
                  continue;
                }

                Excel.Range insertingRowRange = AddNewRowToEditingRange(true);
                DataRow newRow = EditMySQLDataTable.NewRow();
                EditMySQLDataTable.Rows.Add(newRow);
                if (!RangesAndAddressesList.Exists(ra => ra.Modification == RangeAndAddress.RangeModification.Added && ra.Address == insertingRowRange.Address))
                {
                  RangesAndAddressesList.Add(new RangeAndAddress(RangeAndAddress.RangeModification.Added, insertingRowRange, insertingRowRange.Address, (int)insertingRowRange.Interior.Color, insertingRowRange.Row, newRow));
                }

                insertingRowRange.Interior.Color = ExcelUtilities.UncommittedCellsOLEColor;
              }

              int absRow = startDataTableRow + rowIdx - 1;
              absRow = EditMySQLDataTable.SearchRowIndexNotDeleted(absRow, null, EditDataRange.Rows.Count);
              int absCol = startDataTableCol + colIdx - 1;

              currCol = EditMySQLDataTable.GetColumnAtIndex(absCol);
              object insertingValue = DBNull.Value;
              if (cell.Value != null)
              {
                insertingValue = DataTypeUtilities.GetInsertingValueForColumnType(cell.Value, currCol, false);
              }

              if (EditMySQLDataTable.Rows[absRow].RowState != DataRowState.Added)
              {
                if (DataTypeUtilities.ExcelValueEqualsDataTableValue(EditMySQLDataTable.Rows[absRow][absCol, DataRowVersion.Original], insertingValue))
                {
                  var existingRA = RangesAndAddressesList.Find(ra => ra.Modification == RangeAndAddress.RangeModification.Updated && ra.Address == cell.Address);
                  if (existingRA != null)
                  {
                    cell.SetInteriorColor(existingRA.RangeColor == ExcelUtilities.EmptyCellsOLEColor ? 0 : existingRA.RangeColor);
                    RangesAndAddressesList.RemoveAll(ra => ra.Modification == RangeAndAddress.RangeModification.Updated && ra.Address == cell.Address);
                    EditMySQLDataTable.Rows[absRow][absCol] = insertingValue;
                    int changedColsQty = EditMySQLDataTable.GetChangedColumns(EditMySQLDataTable.Rows[absRow]).Count;
                    if (changedColsQty == 0)
                    {
                      EditMySQLDataTable.Rows[absRow].RejectChanges();
                    }
                  }

                  continue;
                }

                //// Need to set the value before coloring the cell in case there is an invalid value it does not reach the coloring code
                DataRow dr = EditMySQLDataTable.Rows[absRow];
                dr[absCol] = insertingValue;
                if (!RangesAndAddressesList.Exists(ra => ra.Modification == RangeAndAddress.RangeModification.Updated && ra.Address == cell.Address))
                {
                  RangesAndAddressesList.Add(new RangeAndAddress(RangeAndAddress.RangeModification.Updated, cell, cell.Address, (int)cell.Interior.Color, cell.Row, dr));
                }
              }
              else
              {
                EditMySQLDataTable.Rows[absRow][absCol] = insertingValue;
              }

              cell.Interior.Color = ExcelUtilities.UncommittedCellsOLEColor;
            }
          }
        }
        catch (ArgumentException argEx)
        {
          undoChanges = true;
          operationSummary = string.Format(Properties.Resources.EditDataInvalidValueError, currCol != null ? currCol.MySQLDataType : "Unknown");
          operationDetails = argEx.Message;
        }
        catch (Exception ex)
        {
          undoChanges = true;
          operationSummary = Properties.Resources.EditDataCellModificationError;
          operationDetails = ex.Message;
          MySQLSourceTrace.WriteAppErrorToLog(ex);
        }
        finally
        {
          if (undoChanges)
          {
            MiscUtilities.ShowCustomizedErrorDialog(operationSummary, operationDetails, true);
            UndoChanges();
          }
        }
      }

      CommitChangesButton.Enabled = !AutoCommitCheckBox.Checked && UncommitedDataExists;
      if (AutoCommitCheckBox.Checked && UncommitedDataExists)
      {
        PushDataChanges();
      }
    }

    /// <summary>
    /// Event delegate method fired when the Excel cells selection changes within the <see cref="EditingWorksheet"/>.
    /// </summary>
    /// <param name="Target"></param>
    private void EditingWorksheet_SelectionChange(Excel.Range Target)
    {
      Excel.Range intersectRange = EditDataRange.IntersectWith(Target);
      if (intersectRange == null || intersectRange.Count == 0)
      {
        Hide();
      }
      else
      {
        ShowInactiveTopmost();
      }
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="ExitEditModeToolStripMenuItem"/> is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void ExitEditModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Event delegate method fired when a mouse button is pressed down.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void GenericMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        _mouseDownPoint = new Point(e.X, e.Y);
      }
    }

    /// <summary>
    /// Event delegate method fired when the mouse is moved.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void GenericMouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (_mouseDownPoint.IsEmpty)
        {
          return;
        }

        Location = new Point(Location.X + (e.X - _mouseDownPoint.X), Location.Y + (e.Y - _mouseDownPoint.Y));
      }
    }

    /// <summary>
    /// Event delegate method fired when a mouse button is up.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void GenericMouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        _mouseDownPoint = Point.Empty;
      }
    }

    /// <summary>
    /// Pushes the data changes currently done in the Excel worksheet to attempt to commit them to the MySQL server.
    /// </summary>
    /// <returns><c>true</c> if the transaction was committed successfully to the database, <c>false</c> otherwise.</returns>
    private bool PushDataChanges()
    {
      bool success = true;
      bool warningsFound = false;
      bool errorsFound = false;
      bool autoCommitOn = AutoCommitCheckBox.Checked;

      int warningsCount = 0;
      StringBuilder operationSummary = new StringBuilder();
      operationSummary.AppendFormat(Properties.Resources.EditedDataForTable, EditingTableName);
      string sqlQuery = string.Empty;
      StringBuilder operationDetails = new StringBuilder();
      StringBuilder warningDetails = new StringBuilder();
      this.Cursor = Cursors.WaitCursor;

      operationDetails.AppendFormat(Properties.Resources.EditDataCommittingText,
                                    EditMySQLDataTable.DeletingOperations,
                                    EditMySQLDataTable.InsertingOperations,
                                    EditMySQLDataTable.UpdatingOperations);
      PushResultsDataTable resultsDT = EditMySQLDataTable.PushData();
      operationDetails.Append(Environment.NewLine);
      foreach (DataRow operationRow in resultsDT.Rows)
      {
        sqlQuery = operationRow["QueryText"].ToString();
        if (sqlQuery.Length > 0)
        {
          operationDetails.Append(Environment.NewLine);
          operationDetails.AppendFormat("{0:000}: {1}",
                                        (int)operationRow["OperationIndex"],
                                        sqlQuery);
        }

        string operationResult = operationRow["OperationResult"].ToString();
        switch (operationResult)
        {
          case "Warning":
            warningsFound = true;
            warningDetails.Append(Environment.NewLine);
            warningDetails.Append(operationRow["ResultText"].ToString());
            warningsCount++;
            break;

          case "Error":
            errorsFound = true;
            operationDetails.Append(Environment.NewLine);
            operationDetails.Append(Environment.NewLine);
            operationDetails.Append(operationRow["ResultText"].ToString());
            break;
        }

        if (errorsFound)
        {
          success = false;
          break;
        }
      }

      if (warningsFound)
      {
        operationDetails.Append(Environment.NewLine);
        operationDetails.Append(Environment.NewLine);
        operationDetails.AppendFormat(Properties.Resources.EditDataCommittedWarningsFound, warningsCount);
        operationDetails.Append(Environment.NewLine);
        operationDetails.Append(warningDetails.ToString());
      }

      operationDetails.Append(Environment.NewLine);
      operationDetails.Append(Environment.NewLine);
      operationDetails.AppendFormat(Properties.Resources.EditDataCommittedText,
                                    resultsDT.DeletedOperations,
                                    resultsDT.InsertedOperations,
                                    resultsDT.UpdatedOperations);
      RangesAndAddressesList.SetInteriorColorToCommmited(success);

      foreach (DataRow dr in EditMySQLDataTable.Rows)
      {
        dr.ClearErrors();
      }

      InfoDialog.InfoType operationsType;
      if (!errorsFound)
      {
        if (warningsFound)
        {
          operationSummary.Append(Properties.Resources.EditedDataCommittedWarning);
          operationsType = InfoDialog.InfoType.Warning;
        }
        else
        {
          operationSummary.Append(Properties.Resources.EditedDataCommittedSucess);
          operationsType = InfoDialog.InfoType.Success;
        }
      }
      else
      {
        operationSummary.AppendFormat(Properties.Resources.EditedDataCommittedError);
        operationsType = InfoDialog.InfoType.Error;
      }

      if (!autoCommitOn || warningsFound || errorsFound)
      {
        MiscUtilities.ShowCustomizedInfoDialog(operationsType, operationSummary.ToString(), operationDetails.ToString(), false);
      }

      CommitChangesButton.Enabled = UncommitedDataExists && !autoCommitOn;
      Cursor = Cursors.Default;

      return !errorsFound;
    }

    /// <summary>
    /// Resets the tooltip shown in the <see cref="EditDataDialog"/> to show information on its corresponding editing session.
    /// </summary>
    private void ResetToolTip()
    {
      DialogToolTip.SetToolTip(this, string.Format(Properties.Resources.EditDataFormTooltipText, Environment.NewLine, WBConnection.Schema, EditingTableName, WorkbookName, WorksheetName));
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="RevertDataButton"/> is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void RevertDataButton_Click(object sender, EventArgs e)
    {
      EditDataRevertDialog revertDialog = new EditDataRevertDialog(!AutoCommitCheckBox.Checked && UncommitedDataExists);
      DialogResult dr = revertDialog.ShowDialog();
      if (dr == DialogResult.Cancel)
      {
        return;
      }

      RevertDataChanges(revertDialog.SelectedAction == EditDataRevertDialog.EditUndoAction.RefreshData);
    }

    /// <summary>
    /// Reverts the changes done to Excel cell values after the last commit.
    /// </summary>
    /// <param name="refreshFromDB">Flag indicating if instead of reverting the data back to the way it was when the editing session started, it is pulled to have the most recent version of it.</param>
    private void RevertDataChanges(bool refreshFromDB)
    {
      Exception exception = null;
      EditMySQLDataTable.RevertData(refreshFromDB, out exception);
      if (exception != null)
      {
        MiscUtilities.ShowCustomizedErrorDialog(refreshFromDB ? Properties.Resources.EditDataRefreshErrorText : Properties.Resources.EditDataRevertErrorText, exception.Message);
      }

      EditingWorksheet.UnprotectEditingWorksheet(EditingWorksheet_Change, WorksheetProtectionKey);
      EditDataRange.Clear();
      Excel.Range topLeftCell = EditDataRange.Cells[1, 1];
      topLeftCell.Select();
      EditDataRange = ParentTaskPane.ImportDataTableToExcelAtGivenCell(EditMySQLDataTable, true, topLeftCell);
      if (refreshFromDB)
      {
        EditDataRange.SetInteriorColor(0);
        RangesAndAddressesList.Clear();
      }
      else
      {
        RangesAndAddressesList.SetInteriorColor(0);
      }

      CommitChangesButton.Enabled = false;
      AddNewRowToEditingRange(false);
    }

    /// <summary>
    /// Undoes changes in the <see cref="EditingWorksheet"/> only.
    /// </summary>
    private void UndoChanges()
    {
      _undoingChanges = true;
      try
      {
        EditingWorksheet.Application.Undo();
      }
      catch (Exception ex)
      {
        MySQLSourceTrace.WriteAppErrorToLog(ex);
      }

      _undoingChanges = false;
    }
  }
}