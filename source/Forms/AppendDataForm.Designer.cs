﻿namespace MySQL.ForExcel
{
  partial class AppendDataForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnAppend = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnAutoMap = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.lblManuallyAdjustMappingMainSub = new System.Windows.Forms.Label();
      this.btnUnmap = new System.Windows.Forms.Button();
      this.grdToTable = new MySQL.ForExcel.MultiHeaderDataGridView();
      this.chkFirstRowHeaders = new System.Windows.Forms.CheckBox();
      this.grdPreviewData = new System.Windows.Forms.DataGridView();
      this.lblChooseColumnMappingMainSub = new System.Windows.Forms.Label();
      this.lblChooseColumnMappingMain = new System.Windows.Forms.Label();
      this.picChooseColumnMapping = new System.Windows.Forms.PictureBox();
      this.lblManuallyAdjustMappingMain = new System.Windows.Forms.Label();
      this.picManuallyAdjustMapping = new System.Windows.Forms.PictureBox();
      this.lblExportData = new System.Windows.Forms.Label();
      this.picColorMapMapped = new System.Windows.Forms.PictureBox();
      this.lblColorMapMapped = new System.Windows.Forms.Label();
      this.picColorMapUnmapped = new System.Windows.Forms.PictureBox();
      this.lblColorMapUnmapped = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lblMappingMethod = new System.Windows.Forms.Label();
      this.cmbMappingMethod = new System.Windows.Forms.ComboBox();
      this.btnAdvanced = new System.Windows.Forms.Button();
      this.btnStoreMapping = new System.Windows.Forms.Button();
      this.contentAreaPanel.SuspendLayout();
      this.commandAreaPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grdPreviewData)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picChooseColumnMapping)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picManuallyAdjustMapping)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picColorMapMapped)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picColorMapUnmapped)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // contentAreaPanel
      // 
      this.contentAreaPanel.BackColor = System.Drawing.SystemColors.Window;
      this.contentAreaPanel.Controls.Add(this.cmbMappingMethod);
      this.contentAreaPanel.Controls.Add(this.lblMappingMethod);
      this.contentAreaPanel.Controls.Add(this.pictureBox1);
      this.contentAreaPanel.Controls.Add(this.picColorMapMapped);
      this.contentAreaPanel.Controls.Add(this.lblColorMapMapped);
      this.contentAreaPanel.Controls.Add(this.picColorMapUnmapped);
      this.contentAreaPanel.Controls.Add(this.lblColorMapUnmapped);
      this.contentAreaPanel.Controls.Add(this.lblExportData);
      this.contentAreaPanel.Controls.Add(this.btnAutoMap);
      this.contentAreaPanel.Controls.Add(this.btnRemove);
      this.contentAreaPanel.Controls.Add(this.lblManuallyAdjustMappingMainSub);
      this.contentAreaPanel.Controls.Add(this.btnUnmap);
      this.contentAreaPanel.Controls.Add(this.grdToTable);
      this.contentAreaPanel.Controls.Add(this.chkFirstRowHeaders);
      this.contentAreaPanel.Controls.Add(this.grdPreviewData);
      this.contentAreaPanel.Controls.Add(this.lblChooseColumnMappingMainSub);
      this.contentAreaPanel.Controls.Add(this.lblChooseColumnMappingMain);
      this.contentAreaPanel.Controls.Add(this.picChooseColumnMapping);
      this.contentAreaPanel.Controls.Add(this.lblManuallyAdjustMappingMain);
      this.contentAreaPanel.Controls.Add(this.picManuallyAdjustMapping);
      this.contentAreaPanel.Size = new System.Drawing.Size(844, 550);
      // 
      // commandAreaPanel
      // 
      this.commandAreaPanel.Controls.Add(this.btnStoreMapping);
      this.commandAreaPanel.Controls.Add(this.btnAdvanced);
      this.commandAreaPanel.Controls.Add(this.btnAppend);
      this.commandAreaPanel.Controls.Add(this.btnCancel);
      this.commandAreaPanel.Location = new System.Drawing.Point(0, 551);
      this.commandAreaPanel.Size = new System.Drawing.Size(844, 45);
      // 
      // btnAppend
      // 
      this.btnAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAppend.Location = new System.Drawing.Point(678, 12);
      this.btnAppend.Name = "btnAppend";
      this.btnAppend.Size = new System.Drawing.Size(75, 23);
      this.btnAppend.TabIndex = 2;
      this.btnAppend.Text = "Append";
      this.btnAppend.UseVisualStyleBackColor = true;
      this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(759, 12);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnAutoMap
      // 
      this.btnAutoMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAutoMap.Location = new System.Drawing.Point(522, 516);
      this.btnAutoMap.Name = "btnAutoMap";
      this.btnAutoMap.Size = new System.Drawing.Size(120, 23);
      this.btnAutoMap.TabIndex = 13;
      this.btnAutoMap.Text = "Auto-Map All";
      this.btnAutoMap.UseVisualStyleBackColor = true;
      this.btnAutoMap.Visible = false;
      this.btnAutoMap.Click += new System.EventHandler(this.btnAutoMap_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRemove.Location = new System.Drawing.Point(396, 516);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(120, 23);
      this.btnRemove.TabIndex = 12;
      this.btnRemove.Text = "Remove Column";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Visible = false;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // lblManuallyAdjustMappingMainSub
      // 
      this.lblManuallyAdjustMappingMainSub.AutoSize = true;
      this.lblManuallyAdjustMappingMainSub.BackColor = System.Drawing.Color.Transparent;
      this.lblManuallyAdjustMappingMainSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblManuallyAdjustMappingMainSub.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblManuallyAdjustMappingMainSub.Location = new System.Drawing.Point(470, 73);
      this.lblManuallyAdjustMappingMainSub.Name = "lblManuallyAdjustMappingMainSub";
      this.lblManuallyAdjustMappingMainSub.Size = new System.Drawing.Size(298, 45);
      this.lblManuallyAdjustMappingMainSub.TabIndex = 6;
      this.lblManuallyAdjustMappingMainSub.Text = "Manually change the column mapping if needed. Click\r\na column in the upper table " +
    "with the mouse and drag it\r\nonto a column in the lower table.";
      // 
      // btnUnmap
      // 
      this.btnUnmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUnmap.Location = new System.Drawing.Point(648, 516);
      this.btnUnmap.Name = "btnUnmap";
      this.btnUnmap.Size = new System.Drawing.Size(120, 23);
      this.btnUnmap.TabIndex = 14;
      this.btnUnmap.Text = "Unmap Column";
      this.btnUnmap.UseVisualStyleBackColor = true;
      this.btnUnmap.Visible = false;
      this.btnUnmap.Click += new System.EventHandler(this.btnUnmap_Click);
      // 
      // grdToTable
      // 
      this.grdToTable.AllowUserToAddRows = false;
      this.grdToTable.AllowUserToDeleteRows = false;
      this.grdToTable.AllowUserToResizeColumns = false;
      this.grdToTable.AllowUserToResizeRows = false;
      this.grdToTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grdToTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.grdToTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      this.grdToTable.DataSource = null;
      this.grdToTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.grdToTable.GridAllowsDrop = true;
      this.grdToTable.Location = new System.Drawing.Point(82, 360);
      this.grdToTable.MultiSelect = false;
      this.grdToTable.Name = "grdToTable";
      this.grdToTable.ReadOnly = true;
      this.grdToTable.RowHeadersVisible = false;
      this.grdToTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
      this.grdToTable.Size = new System.Drawing.Size(686, 150);
      this.grdToTable.TabIndex = 9;
      this.grdToTable.SelectionChanged += new System.EventHandler(this.grdToTable_SelectionChanged);
      this.grdToTable.GridDragOver += new System.Windows.Forms.DragEventHandler(this.grdToTable_GridDragOver);
      this.grdToTable.GridDragDrop += new System.Windows.Forms.DragEventHandler(this.grdToTable_GridDragDrop);
      // 
      // chkFirstRowHeaders
      // 
      this.chkFirstRowHeaders.AutoSize = true;
      this.chkFirstRowHeaders.BackColor = System.Drawing.Color.Transparent;
      this.chkFirstRowHeaders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkFirstRowHeaders.Location = new System.Drawing.Point(82, 157);
      this.chkFirstRowHeaders.Name = "chkFirstRowHeaders";
      this.chkFirstRowHeaders.Size = new System.Drawing.Size(210, 19);
      this.chkFirstRowHeaders.TabIndex = 7;
      this.chkFirstRowHeaders.Text = "First Row Contains Column Names";
      this.chkFirstRowHeaders.UseVisualStyleBackColor = false;
      this.chkFirstRowHeaders.CheckedChanged += new System.EventHandler(this.chkFirstRowHeaders_CheckedChanged);
      // 
      // grdPreviewData
      // 
      this.grdPreviewData.AllowUserToAddRows = false;
      this.grdPreviewData.AllowUserToDeleteRows = false;
      this.grdPreviewData.AllowUserToResizeColumns = false;
      this.grdPreviewData.AllowUserToResizeRows = false;
      this.grdPreviewData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grdPreviewData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.grdPreviewData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.grdPreviewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.grdPreviewData.DefaultCellStyle = dataGridViewCellStyle2;
      this.grdPreviewData.Location = new System.Drawing.Point(82, 182);
      this.grdPreviewData.Name = "grdPreviewData";
      this.grdPreviewData.ReadOnly = true;
      this.grdPreviewData.RowHeadersVisible = false;
      this.grdPreviewData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.grdPreviewData.Size = new System.Drawing.Size(686, 150);
      this.grdPreviewData.TabIndex = 8;
      this.grdPreviewData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdPreviewData_DataBindingComplete);
      this.grdPreviewData.SelectionChanged += new System.EventHandler(this.grdPreviewData_SelectionChanged);
      this.grdPreviewData.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdPreviewData_GiveFeedback);
      this.grdPreviewData.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.grdPreviewData_QueryContinueDrag);
      this.grdPreviewData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPreviewData_MouseDown);
      this.grdPreviewData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdPreviewData_MouseMove);
      this.grdPreviewData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdPreviewData_MouseUp);
      // 
      // lblChooseColumnMappingMainSub
      // 
      this.lblChooseColumnMappingMainSub.AutoSize = true;
      this.lblChooseColumnMappingMainSub.BackColor = System.Drawing.Color.Transparent;
      this.lblChooseColumnMappingMainSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblChooseColumnMappingMainSub.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblChooseColumnMappingMainSub.Location = new System.Drawing.Point(79, 73);
      this.lblChooseColumnMappingMainSub.Name = "lblChooseColumnMappingMainSub";
      this.lblChooseColumnMappingMainSub.Size = new System.Drawing.Size(264, 30);
      this.lblChooseColumnMappingMainSub.TabIndex = 2;
      this.lblChooseColumnMappingMainSub.Text = "Select how the Excel columns should be mapped\r\nto the MySQL table columns.";
      // 
      // lblChooseColumnMappingMain
      // 
      this.lblChooseColumnMappingMain.AutoSize = true;
      this.lblChooseColumnMappingMain.BackColor = System.Drawing.Color.Transparent;
      this.lblChooseColumnMappingMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblChooseColumnMappingMain.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblChooseColumnMappingMain.Location = new System.Drawing.Point(79, 53);
      this.lblChooseColumnMappingMain.Name = "lblChooseColumnMappingMain";
      this.lblChooseColumnMappingMain.Size = new System.Drawing.Size(221, 17);
      this.lblChooseColumnMappingMain.TabIndex = 1;
      this.lblChooseColumnMappingMain.Text = "1. Choose Column Mapping Method";
      // 
      // picChooseColumnMapping
      // 
      this.picChooseColumnMapping.BackColor = System.Drawing.Color.Transparent;
      this.picChooseColumnMapping.Image = global::MySQL.ForExcel.Properties.Resources.MySQLforExcel_AppendDlg_ColumnMapping_32x32;
      this.picChooseColumnMapping.Location = new System.Drawing.Point(41, 59);
      this.picChooseColumnMapping.Name = "picChooseColumnMapping";
      this.picChooseColumnMapping.Size = new System.Drawing.Size(32, 32);
      this.picChooseColumnMapping.TabIndex = 36;
      this.picChooseColumnMapping.TabStop = false;
      // 
      // lblManuallyAdjustMappingMain
      // 
      this.lblManuallyAdjustMappingMain.AutoSize = true;
      this.lblManuallyAdjustMappingMain.BackColor = System.Drawing.Color.Transparent;
      this.lblManuallyAdjustMappingMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblManuallyAdjustMappingMain.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblManuallyAdjustMappingMain.Location = new System.Drawing.Point(470, 54);
      this.lblManuallyAdjustMappingMain.Name = "lblManuallyAdjustMappingMain";
      this.lblManuallyAdjustMappingMain.Size = new System.Drawing.Size(219, 17);
      this.lblManuallyAdjustMappingMain.TabIndex = 5;
      this.lblManuallyAdjustMappingMain.Text = "2. Manually Adjust Column Mapping";
      // 
      // picManuallyAdjustMapping
      // 
      this.picManuallyAdjustMapping.BackColor = System.Drawing.Color.Transparent;
      this.picManuallyAdjustMapping.Image = global::MySQL.ForExcel.Properties.Resources.MySQLforExcel_AppendDlg_ManualColumnMapping_32x32;
      this.picManuallyAdjustMapping.Location = new System.Drawing.Point(432, 60);
      this.picManuallyAdjustMapping.Name = "picManuallyAdjustMapping";
      this.picManuallyAdjustMapping.Size = new System.Drawing.Size(32, 32);
      this.picManuallyAdjustMapping.TabIndex = 30;
      this.picManuallyAdjustMapping.TabStop = false;
      // 
      // lblExportData
      // 
      this.lblExportData.AutoSize = true;
      this.lblExportData.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblExportData.ForeColor = System.Drawing.Color.Navy;
      this.lblExportData.Location = new System.Drawing.Point(17, 17);
      this.lblExportData.Name = "lblExportData";
      this.lblExportData.Size = new System.Drawing.Size(207, 20);
      this.lblExportData.TabIndex = 0;
      this.lblExportData.Text = "Append Data to MySQL Table";
      // 
      // picColorMapMapped
      // 
      this.picColorMapMapped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.picColorMapMapped.BackColor = System.Drawing.Color.LightGreen;
      this.picColorMapMapped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picColorMapMapped.Location = new System.Drawing.Point(229, 516);
      this.picColorMapMapped.Name = "picColorMapMapped";
      this.picColorMapMapped.Size = new System.Drawing.Size(15, 15);
      this.picColorMapMapped.TabIndex = 41;
      this.picColorMapMapped.TabStop = false;
      // 
      // lblColorMapMapped
      // 
      this.lblColorMapMapped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblColorMapMapped.AutoSize = true;
      this.lblColorMapMapped.BackColor = System.Drawing.Color.Transparent;
      this.lblColorMapMapped.Location = new System.Drawing.Point(244, 516);
      this.lblColorMapMapped.Name = "lblColorMapMapped";
      this.lblColorMapMapped.Size = new System.Drawing.Size(89, 13);
      this.lblColorMapMapped.TabIndex = 11;
      this.lblColorMapMapped.Text = "Mapped Columns";
      // 
      // picColorMapUnmapped
      // 
      this.picColorMapUnmapped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.picColorMapUnmapped.BackColor = System.Drawing.Color.OrangeRed;
      this.picColorMapUnmapped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picColorMapUnmapped.Location = new System.Drawing.Point(82, 516);
      this.picColorMapUnmapped.Name = "picColorMapUnmapped";
      this.picColorMapUnmapped.Size = new System.Drawing.Size(15, 15);
      this.picColorMapUnmapped.TabIndex = 40;
      this.picColorMapUnmapped.TabStop = false;
      // 
      // lblColorMapUnmapped
      // 
      this.lblColorMapUnmapped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblColorMapUnmapped.AutoSize = true;
      this.lblColorMapUnmapped.BackColor = System.Drawing.Color.Transparent;
      this.lblColorMapUnmapped.Location = new System.Drawing.Point(97, 516);
      this.lblColorMapUnmapped.Name = "lblColorMapUnmapped";
      this.lblColorMapUnmapped.Size = new System.Drawing.Size(102, 13);
      this.lblColorMapUnmapped.TabIndex = 10;
      this.lblColorMapUnmapped.Text = "Unmapped Columns";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::MySQL.ForExcel.Properties.Resources.MySQLforExcel_AppendDlg_Arrow_Down;
      this.pictureBox1.Location = new System.Drawing.Point(414, 340);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(17, 11);
      this.pictureBox1.TabIndex = 42;
      this.pictureBox1.TabStop = false;
      // 
      // lblMappingMethod
      // 
      this.lblMappingMethod.AutoSize = true;
      this.lblMappingMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMappingMethod.Location = new System.Drawing.Point(79, 115);
      this.lblMappingMethod.Name = "lblMappingMethod";
      this.lblMappingMethod.Size = new System.Drawing.Size(103, 15);
      this.lblMappingMethod.TabIndex = 3;
      this.lblMappingMethod.Text = "Mapping Method:";
      // 
      // cmbMappingMethod
      // 
      this.cmbMappingMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbMappingMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbMappingMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbMappingMethod.FormattingEnabled = true;
      this.cmbMappingMethod.Location = new System.Drawing.Point(188, 112);
      this.cmbMappingMethod.Name = "cmbMappingMethod";
      this.cmbMappingMethod.Size = new System.Drawing.Size(155, 23);
      this.cmbMappingMethod.TabIndex = 4;
      this.cmbMappingMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMappingMethod_SelectedIndexChanged);
      // 
      // btnAdvanced
      // 
      this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAdvanced.Location = new System.Drawing.Point(12, 12);
      this.btnAdvanced.Name = "btnAdvanced";
      this.btnAdvanced.Size = new System.Drawing.Size(131, 23);
      this.btnAdvanced.TabIndex = 0;
      this.btnAdvanced.Text = "Advanced Options...";
      this.btnAdvanced.UseVisualStyleBackColor = true;
      this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
      // 
      // btnStoreMapping
      // 
      this.btnStoreMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnStoreMapping.Location = new System.Drawing.Point(572, 12);
      this.btnStoreMapping.Name = "btnStoreMapping";
      this.btnStoreMapping.Size = new System.Drawing.Size(100, 23);
      this.btnStoreMapping.TabIndex = 1;
      this.btnStoreMapping.Text = "Store Mapping";
      this.btnStoreMapping.UseVisualStyleBackColor = true;
      this.btnStoreMapping.Click += new System.EventHandler(this.btnStoreMapping_Click);
      // 
      // AppendDataForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(844, 597);
      this.CommandAreaHeight = 45;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.MainInstructionLocation = new System.Drawing.Point(11, 16);
      this.MinimumSize = new System.Drawing.Size(860, 635);
      this.Name = "AppendDataForm";
      this.Text = "Append Data";
      this.contentAreaPanel.ResumeLayout(false);
      this.contentAreaPanel.PerformLayout();
      this.commandAreaPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grdPreviewData)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picChooseColumnMapping)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picManuallyAdjustMapping)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picColorMapMapped)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picColorMapUnmapped)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnAppend;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnAutoMap;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Label lblManuallyAdjustMappingMainSub;
    private System.Windows.Forms.Button btnUnmap;
    private MultiHeaderDataGridView grdToTable;
    private System.Windows.Forms.CheckBox chkFirstRowHeaders;
    private System.Windows.Forms.DataGridView grdPreviewData;
    private System.Windows.Forms.Label lblChooseColumnMappingMainSub;
    private System.Windows.Forms.Label lblChooseColumnMappingMain;
    private System.Windows.Forms.PictureBox picChooseColumnMapping;
    private System.Windows.Forms.Label lblManuallyAdjustMappingMain;
    private System.Windows.Forms.PictureBox picManuallyAdjustMapping;
    private System.Windows.Forms.Label lblExportData;
    private System.Windows.Forms.PictureBox picColorMapMapped;
    private System.Windows.Forms.Label lblColorMapMapped;
    private System.Windows.Forms.PictureBox picColorMapUnmapped;
    private System.Windows.Forms.Label lblColorMapUnmapped;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ComboBox cmbMappingMethod;
    private System.Windows.Forms.Label lblMappingMethod;
    private System.Windows.Forms.Button btnAdvanced;
    private System.Windows.Forms.Button btnStoreMapping;
  }
}