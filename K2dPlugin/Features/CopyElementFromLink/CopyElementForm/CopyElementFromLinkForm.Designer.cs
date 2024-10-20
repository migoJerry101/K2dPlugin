namespace K2dPlugin.Features.CopyElementFromLink.CopyElementForm
{
    partial class CopyElementFromLinkForm
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.LinkGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CopyElementBtn = new System.Windows.Forms.Button();
            this.LinkProjectComboBox = new System.Windows.Forms.ComboBox();
            this.LinkLabel = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.AddPropertyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            this.eventLog1.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLog1_EntryWritten);
            // 
            // LinkGridView
            // 
            this.LinkGridView.AllowUserToAddRows = false;
            this.LinkGridView.AllowUserToDeleteRows = false;
            this.LinkGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LinkGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.ElementName,
            this.ProjectName});
            this.LinkGridView.Location = new System.Drawing.Point(32, 121);
            this.LinkGridView.Name = "LinkGridView";
            this.LinkGridView.Size = new System.Drawing.Size(356, 181);
            this.LinkGridView.TabIndex = 0;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Select.Width = 50;
            // 
            // ElementName
            // 
            this.ElementName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ElementName.HeaderText = "Element Name";
            this.ElementName.Name = "ElementName";
            this.ElementName.ReadOnly = true;
            // 
            // ProjectName
            // 
            this.ProjectName.HeaderText = "Project Name";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Visible = false;
            // 
            // CopyElementBtn
            // 
            this.CopyElementBtn.Location = new System.Drawing.Point(32, 343);
            this.CopyElementBtn.Name = "CopyElementBtn";
            this.CopyElementBtn.Size = new System.Drawing.Size(103, 41);
            this.CopyElementBtn.TabIndex = 4;
            this.CopyElementBtn.Text = "Copy";
            this.CopyElementBtn.UseVisualStyleBackColor = true;
            this.CopyElementBtn.Click += new System.EventHandler(this.CopyElementBtn_Click);
            // 
            // LinkProjectComboBox
            // 
            this.LinkProjectComboBox.FormattingEnabled = true;
            this.LinkProjectComboBox.Location = new System.Drawing.Point(139, 32);
            this.LinkProjectComboBox.Name = "LinkProjectComboBox";
            this.LinkProjectComboBox.Size = new System.Drawing.Size(249, 21);
            this.LinkProjectComboBox.TabIndex = 5;
            this.LinkProjectComboBox.SelectedIndexChanged += new System.EventHandler(this.LinkProjectComboBox_SelectedIndexChanged);
            // 
            // LinkLabel
            // 
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.Location = new System.Drawing.Point(29, 35);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(96, 13);
            this.LinkLabel.TabIndex = 6;
            this.LinkLabel.Text = "Select Project Link";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(285, 343);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(103, 41);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SelectAllCheckBox
            // 
            this.SelectAllCheckBox.AutoSize = true;
            this.SelectAllCheckBox.Location = new System.Drawing.Point(32, 80);
            this.SelectAllCheckBox.Name = "SelectAllCheckBox";
            this.SelectAllCheckBox.Size = new System.Drawing.Size(70, 17);
            this.SelectAllCheckBox.TabIndex = 8;
            this.SelectAllCheckBox.Text = "Select All";
            this.SelectAllCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllCheckBox_CheckedChanged);
            // 
            // AddPropertyBtn
            // 
            this.AddPropertyBtn.Location = new System.Drawing.Point(32, 415);
            this.AddPropertyBtn.Name = "AddPropertyBtn";
            this.AddPropertyBtn.Size = new System.Drawing.Size(356, 41);
            this.AddPropertyBtn.TabIndex = 9;
            this.AddPropertyBtn.Text = "Add Property";
            this.AddPropertyBtn.UseVisualStyleBackColor = true;
            this.AddPropertyBtn.Click += new System.EventHandler(this.AddPropertyBtn_Click);
            // 
            // CopyElementFromLinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 482);
            this.Controls.Add(this.AddPropertyBtn);
            this.Controls.Add(this.SelectAllCheckBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.LinkLabel);
            this.Controls.Add(this.LinkProjectComboBox);
            this.Controls.Add(this.CopyElementBtn);
            this.Controls.Add(this.LinkGridView);
            this.Name = "CopyElementFromLinkForm";
            this.Text = "Copy Element From Link V1.0";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.DataGridView LinkGridView;
        private System.Windows.Forms.Button CopyElementBtn;
        private System.Windows.Forms.ComboBox LinkProjectComboBox;
        private System.Windows.Forms.Label LinkLabel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox SelectAllCheckBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.Button AddPropertyBtn;
    }
}