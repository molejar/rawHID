namespace rawhid
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OkButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.PropertyGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 478);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(4, 5);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(643, 391);
            this.PropertyGrid.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OkButton);
            this.panel1.Controls.Add(this.DefaultButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 406);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 67);
            this.panel1.TabIndex = 1;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Image = global::rawhid.Properties.Resources.ok_16x16;
            this.OkButton.Location = new System.Drawing.Point(416, 17);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(112, 37);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = " Save";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DefaultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultButton.Image = global::rawhid.Properties.Resources.Refresh;
            this.DefaultButton.Location = new System.Drawing.Point(106, 17);
            this.DefaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(112, 37);
            this.DefaultButton.TabIndex = 1;
            this.DefaultButton.Text = "Default";
            this.DefaultButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Image = global::rawhid.Properties.Resources.delete_16x16;
            this.CancelButton.Location = new System.Drawing.Point(261, 17);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 37);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = " Cancel";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 478);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(664, 508);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Button CancelButton;
    }
}