﻿// Copyright (c) 2013, 2014, Oracle and/or its affiliates. All rights reserved.
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

using System;
using System.Xml.Serialization;
using MySQL.ForExcel.Forms;
using MySQL.ForExcel.Interfaces;

namespace MySQL.ForExcel.Classes
{
  /// <summary>
  /// This class contains all the information required to connect to the database and sync changes to the Table being edited.
  /// </summary>
  [Serializable]
  public class EditConnectionInfo : IConnectionInfo
  {
    #region Fields

    /// <summary>
    /// Flag indicating whether the <seealso cref="Dispose"/> method has already been called.
    /// </summary>
    private bool _disposed;

    /// <summary>
    /// The <see cref="EditDataDialog"/> related to this object.
    /// </summary>
    private EditDataDialog _editDialog;

    #endregion Fields

    /// <summary>
    /// DO NOT REMOVE. Default constructor required for serialization-deserialization.
    /// </summary>
    public EditConnectionInfo()
    {
      _editDialog = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EditConnectionInfo"/> class.
    /// </summary>
    /// <param name="workbookGuid">Guid of the workbook used.</param>
    /// <param name="workbookFilePath">The workbook full path name.</param>
    /// <param name="wbConnectionId">Workbench Connection id to recover the information required to connect to the MySQL database.</param>
    /// <param name="schema">Name of the Schema used by the <see cref="EditConnectionInfo"/> object.</param>
    /// <param name="table">Name of the table used by the <see cref="EditConnectionInfo"/> object.</param>
    public EditConnectionInfo(string workbookGuid, string workbookFilePath, string wbConnectionId, string schema, string table)
    {
      _disposed = false;
      _editDialog = null;
      ConnectionId = wbConnectionId;
      SchemaName = schema;
      TableName = table;
      WorkbookGuid = workbookGuid;
      WorkbookFilePath = workbookFilePath;
    }

    #region Properties

    /// <summary>
    /// Gets or sets the connection identifier the <see cref="EditConnectionInfo" /> object works with.
    /// </summary>
    [XmlAttribute]
    public string ConnectionId { get; set; }

    /// <summary>
    /// Gets or sets the active <see cref="EditDataDialog"/> form the <see cref="EditConnectionInfo" /> object works with.
    /// </summary>
    [XmlIgnore]
    public EditDataDialog EditDialog
    {
      get
      {
        return _editDialog;
      }

      set
      {
        _editDialog = value;
        if (_editDialog == null)
        {
          return;
        }

        EditDialog.Closed -= EditDialog_Closed;
        EditDialog.Closed += EditDialog_Closed;
      }
    }

    /// <summary>
    /// Gets or sets the last date and time the information from this object was saved.
    /// </summary>
    [XmlAttribute]
    public DateTime LastAccess { get; set; }

    /// <summary>
    /// Gets or sets the name of the schema the connection works with.
    /// </summary>
    [XmlAttribute]
    public string SchemaName { get; set; }

    /// <summary>
    /// Gets or sets the table name the connection works with.
    /// </summary>
    [XmlAttribute]
    public string TableName { get; set; }

    /// <summary>
    /// Gets or sets the workbook guid the <see cref="EditConnectionInfo" /> object works with.
    /// </summary>
    [XmlAttribute]
    public string WorkbookGuid { get; set; }

    /// <summary>
    /// Gets or sets the workbook full path name.
    /// </summary>
    [XmlAttribute]
    public string WorkbookFilePath { get; set; }

    #endregion Properties

    /// <summary>
    /// Releases all resources used by the <see cref="EditConnectionInfo"/> class
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases all resources used by the <see cref="EditConnectionInfo"/> class
    /// </summary>
    /// <param name="disposing">If true this is called by Dispose(), otherwise it is called by the finalizer</param>
    protected virtual void Dispose(bool disposing)
    {
      if (_disposed)
      {
        return;
      }

      // Free managed resources
      if (disposing)
      {
        if (_editDialog != null)
        {
          // This event will handle the cleanup.
          _editDialog.Close();
        }
      }

      // Add class finalizer if unmanaged resources are added to the class
      // Free unmanaged resources if there are any
      _disposed = true;
    }

    /// <summary>
    /// Handles the <see cref="EditDataDialog.Closed"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void EditDialog_Closed(object sender, EventArgs e)
    {
      if (_editDialog == null)
      {
        return;
      }

      _editDialog.Closed -= EditDialog_Closed;
      _editDialog = null;
    }
  }
}