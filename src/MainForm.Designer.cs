namespace rawhid
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.m_ToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ConnectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_SettingsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TxDataGridView = new System.Windows.Forms.DataGridView();
            this.m_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_report = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_shortcut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LogDataGridView = new System.Windows.Forms.DataGridView();
            this.m_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.m_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.m_ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_ToolStripStatusString = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_ToolStripStatusIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_ToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.m_StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ToolStrip
            // 
            this.m_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.m_ToolStripComboBox,
            this.ConnectToolStripButton,
            this.toolStripSeparator6,
            this.AddToolStripButton,
            this.EditToolStripButton,
            this.RemoveToolStripButton,
            this.toolStripSeparator2,
            this.OpenToolStripButton,
            this.SaveToolStripButton,
            this.m_SettingsToolStripButton,
            this.toolStripSeparator1,
            this.InfoToolStripButton});
            this.m_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.m_ToolStrip.Name = "m_ToolStrip";
            this.m_ToolStrip.Size = new System.Drawing.Size(634, 25);
            this.m_ToolStrip.TabIndex = 1;
            this.m_ToolStrip.Text = "toolStrip";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel1.Text = "Device:";
            // 
            // m_ToolStripComboBox
            // 
            this.m_ToolStripComboBox.AutoSize = false;
            this.m_ToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_ToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_ToolStripComboBox.Margin = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.m_ToolStripComboBox.Name = "m_ToolStripComboBox";
            this.m_ToolStripComboBox.Size = new System.Drawing.Size(300, 23);
            // 
            // ConnectToolStripButton
            // 
            this.ConnectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConnectToolStripButton.Image = global::rawhid.Properties.Resources.Connect;
            this.ConnectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectToolStripButton.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.ConnectToolStripButton.Name = "ConnectToolStripButton";
            this.ConnectToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.ConnectToolStripButton.Text = "Connect";
            this.ConnectToolStripButton.Click += new System.EventHandler(this.ConnectToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 24);
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripButton.Image = global::rawhid.Properties.Resources.add_16x16;
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.AddToolStripButton.Text = "Start";
            this.AddToolStripButton.ToolTipText = "Add";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // EditToolStripButton
            // 
            this.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStripButton.Image = global::rawhid.Properties.Resources.edit_16x16;
            this.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditToolStripButton.Name = "EditToolStripButton";
            this.EditToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EditToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.EditToolStripButton.Text = "Start";
            this.EditToolStripButton.ToolTipText = "Edit";
            this.EditToolStripButton.Click += new System.EventHandler(this.EditToolStripButton_Click);
            // 
            // RemoveToolStripButton
            // 
            this.RemoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveToolStripButton.Image = global::rawhid.Properties.Resources.trash_16x16;
            this.RemoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveToolStripButton.Name = "RemoveToolStripButton";
            this.RemoveToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RemoveToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.RemoveToolStripButton.Text = "Start";
            this.RemoveToolStripButton.ToolTipText = "Remove";
            this.RemoveToolStripButton.Click += new System.EventHandler(this.RemoveToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
            // 
            // OpenToolStripButton
            // 
            this.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenToolStripButton.Image = global::rawhid.Properties.Resources.Open;
            this.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenToolStripButton.Name = "OpenToolStripButton";
            this.OpenToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OpenToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.OpenToolStripButton.Text = "Open";
            this.OpenToolStripButton.ToolTipText = "Open";
            this.OpenToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
            // 
            // SaveToolStripButton
            // 
            this.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripButton.Image = global::rawhid.Properties.Resources.Save;
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SaveToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.SaveToolStripButton.Text = "Save";
            this.SaveToolStripButton.ToolTipText = "Save";
            this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // m_SettingsToolStripButton
            // 
            this.m_SettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_SettingsToolStripButton.Image = global::rawhid.Properties.Resources.Settings;
            this.m_SettingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_SettingsToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.m_SettingsToolStripButton.Name = "m_SettingsToolStripButton";
            this.m_SettingsToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_SettingsToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.m_SettingsToolStripButton.Text = "Start";
            this.m_SettingsToolStripButton.ToolTipText = "Settings";
            this.m_SettingsToolStripButton.Click += new System.EventHandler(this.SettingsToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // InfoToolStripButton
            // 
            this.InfoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoToolStripButton.Image = global::rawhid.Properties.Resources.info;
            this.InfoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoToolStripButton.Margin = new System.Windows.Forms.Padding(2);
            this.InfoToolStripButton.Name = "InfoToolStripButton";
            this.InfoToolStripButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoToolStripButton.Size = new System.Drawing.Size(24, 21);
            this.InfoToolStripButton.Text = "Info";
            this.InfoToolStripButton.ToolTipText = "Info";
            this.InfoToolStripButton.Click += new System.EventHandler(this.InfoToolStripButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 361);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TxDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LogDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(628, 300);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 0;
            // 
            // TxDataGridView
            // 
            this.TxDataGridView.AllowUserToAddRows = false;
            this.TxDataGridView.AllowUserToDeleteRows = false;
            this.TxDataGridView.AllowUserToResizeColumns = false;
            this.TxDataGridView.AllowUserToResizeRows = false;
            this.TxDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TxDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TxDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TxDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TxDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TxDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_name,
            this.m_report,
            this.m_desc,
            this.m_shortcut,
            this.m_button});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TxDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.TxDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxDataGridView.EnableHeadersVisualStyles = false;
            this.TxDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.TxDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TxDataGridView.Name = "TxDataGridView";
            this.TxDataGridView.RowHeadersVisible = false;
            this.TxDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.TxDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TxDataGridView.Size = new System.Drawing.Size(628, 182);
            this.TxDataGridView.TabIndex = 0;
            this.TxDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TxDataGridView_CellMouseDoubleClick);
            this.TxDataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxDataGridView_KeyUp);
            // 
            // m_name
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_name.HeaderText = "Name";
            this.m_name.Name = "m_name";
            this.m_name.ReadOnly = true;
            this.m_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_report
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_report.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_report.HeaderText = "Report";
            this.m_report.Name = "m_report";
            this.m_report.ReadOnly = true;
            this.m_report.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.m_report.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_report.Width = 50;
            // 
            // m_desc
            // 
            this.m_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.m_desc.HeaderText = "Description";
            this.m_desc.Name = "m_desc";
            this.m_desc.ReadOnly = true;
            this.m_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_shortcut
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_shortcut.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_shortcut.HeaderText = "Shortcut Key";
            this.m_shortcut.Name = "m_shortcut";
            this.m_shortcut.ReadOnly = true;
            this.m_shortcut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.m_shortcut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_button
            // 
            this.m_button.HeaderText = "Button";
            this.m_button.Name = "m_button";
            this.m_button.ReadOnly = true;
            this.m_button.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.m_button.Text = "Send";
            this.m_button.UseColumnTextForButtonValue = true;
            this.m_button.Width = 60;
            // 
            // LogDataGridView
            // 
            this.LogDataGridView.AllowUserToAddRows = false;
            this.LogDataGridView.AllowUserToDeleteRows = false;
            this.LogDataGridView.AllowUserToResizeColumns = false;
            this.LogDataGridView.AllowUserToResizeRows = false;
            this.LogDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LogDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LogDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.LogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_time,
            this.m_dir,
            this.dataGridViewTextBoxColumn1,
            this.m_data});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LogDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.LogDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogDataGridView.EnableHeadersVisualStyles = false;
            this.LogDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.LogDataGridView.Location = new System.Drawing.Point(0, 0);
            this.LogDataGridView.Name = "LogDataGridView";
            this.LogDataGridView.RowHeadersVisible = false;
            this.LogDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogDataGridView.Size = new System.Drawing.Size(628, 114);
            this.LogDataGridView.TabIndex = 0;
            this.LogDataGridView.SelectionChanged += new System.EventHandler(this.LogDataGridView_SelectionChanged);
            // 
            // m_time
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_time.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_time.HeaderText = "N";
            this.m_time.Name = "m_time";
            this.m_time.ReadOnly = true;
            this.m_time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.m_time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_time.Width = 50;
            // 
            // m_dir
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dir.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dir.HeaderText = "-";
            this.m_dir.MinimumWidth = 25;
            this.m_dir.Name = "m_dir";
            this.m_dir.ReadOnly = true;
            this.m_dir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dir.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "Report";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // m_data
            // 
            this.m_data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.m_data.HeaderText = "Data";
            this.m_data.Name = "m_data";
            this.m_data.ReadOnly = true;
            this.m_data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LogTextBox);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 306);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 55);
            this.panel1.TabIndex = 1;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LogTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(565, 55);
            this.LogTextBox.TabIndex = 1;
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(568, 0);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(60, 55);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // m_StatusStrip
            // 
            this.m_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripStatusLabel,
            this.m_ToolStripStatusString,
            this.m_ToolStripStatusIcon});
            this.m_StatusStrip.Location = new System.Drawing.Point(0, 386);
            this.m_StatusStrip.Name = "m_StatusStrip";
            this.m_StatusStrip.ShowItemToolTips = true;
            this.m_StatusStrip.Size = new System.Drawing.Size(634, 25);
            this.m_StatusStrip.TabIndex = 0;
            this.m_StatusStrip.Text = "statusStrip";
            // 
            // m_ToolStripStatusLabel
            // 
            this.m_ToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 2, 2);
            this.m_ToolStripStatusLabel.Name = "m_ToolStripStatusLabel";
            this.m_ToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.m_ToolStripStatusLabel.Size = new System.Drawing.Size(54, 20);
            this.m_ToolStripStatusLabel.Text = "Status: ";
            // 
            // m_ToolStripStatusString
            // 
            this.m_ToolStripStatusString.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.m_ToolStripStatusString.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.m_ToolStripStatusString.Name = "m_ToolStripStatusString";
            this.m_ToolStripStatusString.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.m_ToolStripStatusString.Size = new System.Drawing.Size(488, 20);
            this.m_ToolStripStatusString.Spring = true;
            this.m_ToolStripStatusString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_ToolStripStatusIcon
            // 
            this.m_ToolStripStatusIcon.AutoToolTip = true;
            this.m_ToolStripStatusIcon.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.m_ToolStripStatusIcon.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.m_ToolStripStatusIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_ToolStripStatusIcon.Image = global::rawhid.Properties.Resources.USB_Disable;
            this.m_ToolStripStatusIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_ToolStripStatusIcon.Margin = new System.Windows.Forms.Padding(10, 3, 4, 2);
            this.m_ToolStripStatusIcon.Name = "m_ToolStripStatusIcon";
            this.m_ToolStripStatusIcon.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.m_ToolStripStatusIcon.Size = new System.Drawing.Size(30, 20);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.m_ToolStrip);
            this.Controls.Add(this.m_StatusStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RawHID GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.m_ToolStrip.ResumeLayout(false);
            this.m_ToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_StatusStrip.ResumeLayout(false);
            this.m_StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip m_ToolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.DataGridView LogDataGridView;
        private System.Windows.Forms.StatusStrip m_StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel m_ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel m_ToolStripStatusString;
        private System.Windows.Forms.ToolStripStatusLabel m_ToolStripStatusIcon;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox m_ToolStripComboBox;
        private System.Windows.Forms.ToolStripButton ConnectToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.ToolStripButton EditToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_SettingsToolStripButton;
        private System.Windows.Forms.ToolStripButton RemoveToolStripButton;
        private System.Windows.Forms.DataGridView TxDataGridView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton InfoToolStripButton;
        private System.Windows.Forms.ToolStripButton OpenToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_report;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_shortcut;
        private System.Windows.Forms.DataGridViewButtonColumn m_button;
    }
}

