using System.Windows.Forms;

namespace K2dPlugin.Features.PipeSum.Form
{
    partial class PipeSumForm
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
            this.components = new System.ComponentModel.Container();
            this.PipeSumTab = new System.Windows.Forms.TabControl();
            this.SanitaryTab = new System.Windows.Forms.TabPage();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.PipeSizeLabel = new System.Windows.Forms.Label();
            this.PipeSizeComboBox = new System.Windows.Forms.ComboBox();
            this.SanitationTotalSelectedLabel = new System.Windows.Forms.Label();
            this.SanitaryResetTxtBtn = new System.Windows.Forms.Button();
            this.SanitationSelectTxtBtn = new System.Windows.Forms.Button();
            this.SanitationGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PipeSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SanitaionMaxUnitLabel = new System.Windows.Forms.Label();
            this.SanitationFixtureConnectionLabel = new System.Windows.Forms.Label();
            this.FixtureConnectionBox = new System.Windows.Forms.TextBox();
            this.SanitationOverrideBtn = new System.Windows.Forms.Button();
            this.SanitaionPipeSystemLabel = new System.Windows.Forms.Label();
            this.SanitationComboBox = new System.Windows.Forms.ComboBox();
            this.WaterTab = new System.Windows.Forms.TabPage();
            this.WaterMaxUnit = new System.Windows.Forms.Label();
            this.WaterApplyBtn = new System.Windows.Forms.Button();
            this.WaterPipeSizeLabel = new System.Windows.Forms.Label();
            this.WaterPipeSizeComboBox = new System.Windows.Forms.ComboBox();
            this.WaterOverrideBtn = new System.Windows.Forms.Button();
            this.PsiPerFootLabel = new System.Windows.Forms.Label();
            this.PsiPerFootComboBox = new System.Windows.Forms.ComboBox();
            this.WaterTotalSelectedLabel = new System.Windows.Forms.Label();
            this.WaterRestBtn = new System.Windows.Forms.Button();
            this.WaterSelectBtn = new System.Windows.Forms.Button();
            this.FlushSettingsLabel = new System.Windows.Forms.Label();
            this.FlushSettingComboBox = new System.Windows.Forms.ComboBox();
            this.WaterSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.HotRadioBtn = new System.Windows.Forms.RadioButton();
            this.ColdRadioBtn = new System.Windows.Forms.RadioButton();
            this.WaterDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaterMeterialGroupBox = new System.Windows.Forms.GroupBox();
            this.PexRadioBtn = new System.Windows.Forms.RadioButton();
            this.CpvcRadioBtn = new System.Windows.Forms.RadioButton();
            this.CopperRadioBtn = new System.Windows.Forms.RadioButton();
            this.GasTab = new System.Windows.Forms.TabPage();
            this.GasMaxLabel = new System.Windows.Forms.Label();
            this.WaterLenthLabel = new System.Windows.Forms.Label();
            this.GasTotalLengthLabel = new System.Windows.Forms.Label();
            this.GasReset = new System.Windows.Forms.Button();
            this.GasSelectBtn = new System.Windows.Forms.Button();
            this.GasApplyBtn = new System.Windows.Forms.Button();
            this.GasPipeSizelabel = new System.Windows.Forms.Label();
            this.GasDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GasLengthComboBox = new System.Windows.Forms.ComboBox();
            this.PressureBox = new System.Windows.Forms.GroupBox();
            this.RadioBtnPressureMed = new System.Windows.Forms.RadioButton();
            this.LowPressureGasRadioBtn = new System.Windows.Forms.RadioButton();
            this.StormDrainTab = new System.Windows.Forms.TabPage();
            this.StormDrainMaxLabel = new System.Windows.Forms.Label();
            this.GroupBoxStormDrain = new System.Windows.Forms.GroupBox();
            this.StormDrainRadioBtn3Hr = new System.Windows.Forms.RadioButton();
            this.StormDrainRadioBtn2Hr = new System.Windows.Forms.RadioButton();
            this.StormDrainRadioBtn1Hr = new System.Windows.Forms.RadioButton();
            this.StormDrainTotalSelectedLabel = new System.Windows.Forms.Label();
            this.StormDrainResetBtn = new System.Windows.Forms.Button();
            this.StormDrainSelectBtn = new System.Windows.Forms.Button();
            this.StormDrainGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StormDrainApplyBtn = new System.Windows.Forms.Button();
            this.StormDrainOverrideBtn = new System.Windows.Forms.Button();
            this.StormDrainSizeComboBox = new System.Windows.Forms.ComboBox();
            this.StormDrainPipeSizeLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PipeSumCloseBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PipeSumTab.SuspendLayout();
            this.SanitaryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanitationGridView)).BeginInit();
            this.WaterTab.SuspendLayout();
            this.WaterSystemGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaterDataGrid)).BeginInit();
            this.WaterMeterialGroupBox.SuspendLayout();
            this.GasTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GasDataGrid)).BeginInit();
            this.PressureBox.SuspendLayout();
            this.StormDrainTab.SuspendLayout();
            this.GroupBoxStormDrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StormDrainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // PipeSumTab
            // 
            this.PipeSumTab.Controls.Add(this.SanitaryTab);
            this.PipeSumTab.Controls.Add(this.WaterTab);
            this.PipeSumTab.Controls.Add(this.GasTab);
            this.PipeSumTab.Controls.Add(this.StormDrainTab);
            this.PipeSumTab.Location = new System.Drawing.Point(27, 25);
            this.PipeSumTab.Name = "PipeSumTab";
            this.PipeSumTab.SelectedIndex = 0;
            this.PipeSumTab.Size = new System.Drawing.Size(631, 393);
            this.PipeSumTab.TabIndex = 0;
            this.PipeSumTab.Click += new System.EventHandler(this.PipeSum_SelectedIndexChanged);
            // 
            // SanitaryTab
            // 
            this.SanitaryTab.Controls.Add(this.ApplyBtn);
            this.SanitaryTab.Controls.Add(this.PipeSizeLabel);
            this.SanitaryTab.Controls.Add(this.PipeSizeComboBox);
            this.SanitaryTab.Controls.Add(this.SanitationTotalSelectedLabel);
            this.SanitaryTab.Controls.Add(this.SanitaryResetTxtBtn);
            this.SanitaryTab.Controls.Add(this.SanitationSelectTxtBtn);
            this.SanitaryTab.Controls.Add(this.SanitationGridView);
            this.SanitaryTab.Controls.Add(this.SanitaionMaxUnitLabel);
            this.SanitaryTab.Controls.Add(this.SanitationFixtureConnectionLabel);
            this.SanitaryTab.Controls.Add(this.FixtureConnectionBox);
            this.SanitaryTab.Controls.Add(this.SanitationOverrideBtn);
            this.SanitaryTab.Controls.Add(this.SanitaionPipeSystemLabel);
            this.SanitaryTab.Controls.Add(this.SanitationComboBox);
            this.SanitaryTab.Location = new System.Drawing.Point(4, 22);
            this.SanitaryTab.Name = "SanitaryTab";
            this.SanitaryTab.Padding = new System.Windows.Forms.Padding(3);
            this.SanitaryTab.Size = new System.Drawing.Size(623, 367);
            this.SanitaryTab.TabIndex = 0;
            this.SanitaryTab.Text = "Sanitary";
            this.SanitaryTab.UseVisualStyleBackColor = true;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.BackColor = System.Drawing.Color.Transparent;
            this.ApplyBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ApplyBtn.Location = new System.Drawing.Point(85, 302);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(113, 37);
            this.ApplyBtn.TabIndex = 16;
            this.ApplyBtn.Text = "Apply Update";
            this.ApplyBtn.UseVisualStyleBackColor = false;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // PipeSizeLabel
            // 
            this.PipeSizeLabel.AutoSize = true;
            this.PipeSizeLabel.Location = new System.Drawing.Point(30, 142);
            this.PipeSizeLabel.Name = "PipeSizeLabel";
            this.PipeSizeLabel.Size = new System.Drawing.Size(55, 13);
            this.PipeSizeLabel.TabIndex = 15;
            this.PipeSizeLabel.Text = "PipeSize: ";
            // 
            // PipeSizeComboBox
            // 
            this.PipeSizeComboBox.FormattingEnabled = true;
            this.PipeSizeComboBox.Location = new System.Drawing.Point(134, 139);
            this.PipeSizeComboBox.Name = "PipeSizeComboBox";
            this.PipeSizeComboBox.Size = new System.Drawing.Size(125, 21);
            this.PipeSizeComboBox.TabIndex = 14;
            this.PipeSizeComboBox.Text = "Select Override Size";
            this.PipeSizeComboBox.Visible = false;
            this.PipeSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.PipeSizeComboBox_SelectedIndexChanged);
            // 
            // SanitationTotalSelectedLabel
            // 
            this.SanitationTotalSelectedLabel.AutoSize = true;
            this.SanitationTotalSelectedLabel.Location = new System.Drawing.Point(308, 239);
            this.SanitationTotalSelectedLabel.Name = "SanitationTotalSelectedLabel";
            this.SanitationTotalSelectedLabel.Size = new System.Drawing.Size(84, 13);
            this.SanitationTotalSelectedLabel.TabIndex = 13;
            this.SanitationTotalSelectedLabel.Text = "Total Selected: ";
            // 
            // SanitaryResetTxtBtn
            // 
            this.SanitaryResetTxtBtn.Location = new System.Drawing.Point(467, 290);
            this.SanitaryResetTxtBtn.Name = "SanitaryResetTxtBtn";
            this.SanitaryResetTxtBtn.Size = new System.Drawing.Size(106, 28);
            this.SanitaryResetTxtBtn.TabIndex = 12;
            this.SanitaryResetTxtBtn.Text = "Reset";
            this.SanitaryResetTxtBtn.UseVisualStyleBackColor = true;
            this.SanitaryResetTxtBtn.Click += new System.EventHandler(this.SanitaryResetTxtBtn_Click);
            // 
            // SanitationSelectTxtBtn
            // 
            this.SanitationSelectTxtBtn.Location = new System.Drawing.Point(306, 290);
            this.SanitationSelectTxtBtn.Name = "SanitationSelectTxtBtn";
            this.SanitationSelectTxtBtn.Size = new System.Drawing.Size(106, 28);
            this.SanitationSelectTxtBtn.TabIndex = 11;
            this.SanitationSelectTxtBtn.Text = "Select Text";
            this.SanitationSelectTxtBtn.UseVisualStyleBackColor = true;
            this.SanitationSelectTxtBtn.Click += new System.EventHandler(this.SanitationSelectTxtBtn_Click);
            // 
            // SanitationGridView
            // 
            this.SanitationGridView.AllowUserToAddRows = false;
            this.SanitationGridView.AllowUserToDeleteRows = false;
            this.SanitationGridView.AllowUserToResizeColumns = false;
            this.SanitationGridView.AllowUserToResizeRows = false;
            this.SanitationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SanitationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SanitationGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Count,
            this.PipeSize,
            this.Units});
            this.SanitationGridView.GridColor = System.Drawing.SystemColors.Control;
            this.SanitationGridView.Location = new System.Drawing.Point(322, 37);
            this.SanitationGridView.Name = "SanitationGridView";
            this.SanitationGridView.ReadOnly = true;
            this.SanitationGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SanitationGridView.Size = new System.Drawing.Size(239, 166);
            this.SanitationGridView.TabIndex = 10;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 42;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.Frozen = true;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Count.Width = 64;
            // 
            // PipeSize
            // 
            this.PipeSize.DataPropertyName = "PipeSize";
            this.PipeSize.Frozen = true;
            this.PipeSize.HeaderText = "PipeSize";
            this.PipeSize.Name = "PipeSize";
            this.PipeSize.ReadOnly = true;
            this.PipeSize.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PipeSize.Width = 74;
            // 
            // Units
            // 
            this.Units.DataPropertyName = "Units";
            this.Units.HeaderText = "Units";
            this.Units.Name = "Units";
            this.Units.ReadOnly = true;
            this.Units.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Units.Width = 59;
            // 
            // SanitaionMaxUnitLabel
            // 
            this.SanitaionMaxUnitLabel.AutoSize = true;
            this.SanitaionMaxUnitLabel.Location = new System.Drawing.Point(30, 246);
            this.SanitaionMaxUnitLabel.Name = "SanitaionMaxUnitLabel";
            this.SanitaionMaxUnitLabel.Size = new System.Drawing.Size(59, 13);
            this.SanitaionMaxUnitLabel.TabIndex = 8;
            this.SanitaionMaxUnitLabel.Text = "Max Unit: ";
            // 
            // SanitationFixtureConnectionLabel
            // 
            this.SanitationFixtureConnectionLabel.AutoSize = true;
            this.SanitationFixtureConnectionLabel.Location = new System.Drawing.Point(30, 96);
            this.SanitationFixtureConnectionLabel.Name = "SanitationFixtureConnectionLabel";
            this.SanitationFixtureConnectionLabel.Size = new System.Drawing.Size(108, 13);
            this.SanitationFixtureConnectionLabel.TabIndex = 3;
            this.SanitationFixtureConnectionLabel.Text = "Fixture Connection:";
            // 
            // FixtureConnectionBox
            // 
            this.FixtureConnectionBox.Enabled = false;
            this.FixtureConnectionBox.Location = new System.Drawing.Point(159, 93);
            this.FixtureConnectionBox.Name = "FixtureConnectionBox";
            this.FixtureConnectionBox.Size = new System.Drawing.Size(100, 22);
            this.FixtureConnectionBox.TabIndex = 7;
            // 
            // SanitationOverrideBtn
            // 
            this.SanitationOverrideBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.SanitationOverrideBtn.Location = new System.Drawing.Point(33, 181);
            this.SanitationOverrideBtn.Name = "SanitationOverrideBtn";
            this.SanitationOverrideBtn.Size = new System.Drawing.Size(81, 29);
            this.SanitationOverrideBtn.TabIndex = 6;
            this.SanitationOverrideBtn.Text = "Override";
            this.SanitationOverrideBtn.UseVisualStyleBackColor = true;
            this.SanitationOverrideBtn.Click += new System.EventHandler(this.SanitationOverrideBtn_Click);
            // 
            // SanitaionPipeSystemLabel
            // 
            this.SanitaionPipeSystemLabel.AutoSize = true;
            this.SanitaionPipeSystemLabel.Location = new System.Drawing.Point(30, 24);
            this.SanitaionPipeSystemLabel.Name = "SanitaionPipeSystemLabel";
            this.SanitaionPipeSystemLabel.Size = new System.Drawing.Size(70, 13);
            this.SanitaionPipeSystemLabel.TabIndex = 4;
            this.SanitaionPipeSystemLabel.Text = "Pipe System:";
            // 
            // SanitationComboBox
            // 
            this.SanitationComboBox.FormattingEnabled = true;
            this.SanitationComboBox.Location = new System.Drawing.Point(33, 44);
            this.SanitationComboBox.Name = "SanitationComboBox";
            this.SanitationComboBox.Size = new System.Drawing.Size(226, 21);
            this.SanitationComboBox.TabIndex = 2;
            this.SanitationComboBox.Text = "Select Pipe System";
            this.SanitationComboBox.SelectedIndexChanged += new System.EventHandler(this.SanitationComboBox_SelectedIndexChanged);
            // 
            // WaterTab
            // 
            this.WaterTab.Controls.Add(this.WaterMaxUnit);
            this.WaterTab.Controls.Add(this.WaterApplyBtn);
            this.WaterTab.Controls.Add(this.WaterPipeSizeLabel);
            this.WaterTab.Controls.Add(this.WaterPipeSizeComboBox);
            this.WaterTab.Controls.Add(this.WaterOverrideBtn);
            this.WaterTab.Controls.Add(this.PsiPerFootLabel);
            this.WaterTab.Controls.Add(this.PsiPerFootComboBox);
            this.WaterTab.Controls.Add(this.WaterTotalSelectedLabel);
            this.WaterTab.Controls.Add(this.WaterRestBtn);
            this.WaterTab.Controls.Add(this.WaterSelectBtn);
            this.WaterTab.Controls.Add(this.FlushSettingsLabel);
            this.WaterTab.Controls.Add(this.FlushSettingComboBox);
            this.WaterTab.Controls.Add(this.WaterSystemGroupBox);
            this.WaterTab.Controls.Add(this.WaterDataGrid);
            this.WaterTab.Controls.Add(this.WaterMeterialGroupBox);
            this.WaterTab.Location = new System.Drawing.Point(4, 22);
            this.WaterTab.Name = "WaterTab";
            this.WaterTab.Padding = new System.Windows.Forms.Padding(3);
            this.WaterTab.Size = new System.Drawing.Size(623, 367);
            this.WaterTab.TabIndex = 1;
            this.WaterTab.Text = "Water";
            this.WaterTab.UseVisualStyleBackColor = true;
            // 
            // WaterMaxUnit
            // 
            this.WaterMaxUnit.AutoSize = true;
            this.WaterMaxUnit.Location = new System.Drawing.Point(31, 286);
            this.WaterMaxUnit.Name = "WaterMaxUnit";
            this.WaterMaxUnit.Size = new System.Drawing.Size(59, 13);
            this.WaterMaxUnit.TabIndex = 38;
            this.WaterMaxUnit.Text = "Max Unit: ";
            // 
            // WaterApplyBtn
            // 
            this.WaterApplyBtn.BackColor = System.Drawing.Color.Transparent;
            this.WaterApplyBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.WaterApplyBtn.Location = new System.Drawing.Point(85, 319);
            this.WaterApplyBtn.Name = "WaterApplyBtn";
            this.WaterApplyBtn.Size = new System.Drawing.Size(113, 37);
            this.WaterApplyBtn.TabIndex = 37;
            this.WaterApplyBtn.Text = "Apply Update";
            this.WaterApplyBtn.UseVisualStyleBackColor = false;
            this.WaterApplyBtn.Click += new System.EventHandler(this.WaterApplyBtn_Click);
            // 
            // WaterPipeSizeLabel
            // 
            this.WaterPipeSizeLabel.AutoSize = true;
            this.WaterPipeSizeLabel.Location = new System.Drawing.Point(21, 210);
            this.WaterPipeSizeLabel.Name = "WaterPipeSizeLabel";
            this.WaterPipeSizeLabel.Size = new System.Drawing.Size(58, 13);
            this.WaterPipeSizeLabel.TabIndex = 36;
            this.WaterPipeSizeLabel.Text = "Pipe Size: ";
            // 
            // WaterPipeSizeComboBox
            // 
            this.WaterPipeSizeComboBox.FormattingEnabled = true;
            this.WaterPipeSizeComboBox.Location = new System.Drawing.Point(157, 207);
            this.WaterPipeSizeComboBox.Name = "WaterPipeSizeComboBox";
            this.WaterPipeSizeComboBox.Size = new System.Drawing.Size(129, 21);
            this.WaterPipeSizeComboBox.TabIndex = 35;
            this.WaterPipeSizeComboBox.Text = "Select Size";
            this.WaterPipeSizeComboBox.Visible = false;
            this.WaterPipeSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.WaterPipeSizeComboBox_SelectedIndexChanged);
            // 
            // WaterOverrideBtn
            // 
            this.WaterOverrideBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.WaterOverrideBtn.Location = new System.Drawing.Point(24, 233);
            this.WaterOverrideBtn.Name = "WaterOverrideBtn";
            this.WaterOverrideBtn.Size = new System.Drawing.Size(81, 29);
            this.WaterOverrideBtn.TabIndex = 33;
            this.WaterOverrideBtn.Text = "Override";
            this.WaterOverrideBtn.UseVisualStyleBackColor = true;
            this.WaterOverrideBtn.Click += new System.EventHandler(this.WaterOverrideBtn_Click);
            // 
            // PsiPerFootLabel
            // 
            this.PsiPerFootLabel.AutoSize = true;
            this.PsiPerFootLabel.Location = new System.Drawing.Point(145, 141);
            this.PsiPerFootLabel.Name = "PsiPerFootLabel";
            this.PsiPerFootLabel.Size = new System.Drawing.Size(53, 13);
            this.PsiPerFootLabel.TabIndex = 32;
            this.PsiPerFootLabel.Text = "PSI/Foot:";
            // 
            // PsiPerFootComboBox
            // 
            this.PsiPerFootComboBox.FormattingEnabled = true;
            this.PsiPerFootComboBox.Location = new System.Drawing.Point(157, 169);
            this.PsiPerFootComboBox.Name = "PsiPerFootComboBox";
            this.PsiPerFootComboBox.Size = new System.Drawing.Size(135, 21);
            this.PsiPerFootComboBox.TabIndex = 31;
            this.PsiPerFootComboBox.Text = "2";
            this.PsiPerFootComboBox.SelectedIndexChanged += new System.EventHandler(this.PsiPerFootComboBox_SelectedIndexChanged);
            // 
            // WaterTotalSelectedLabel
            // 
            this.WaterTotalSelectedLabel.AutoSize = true;
            this.WaterTotalSelectedLabel.Location = new System.Drawing.Point(332, 233);
            this.WaterTotalSelectedLabel.Name = "WaterTotalSelectedLabel";
            this.WaterTotalSelectedLabel.Size = new System.Drawing.Size(84, 13);
            this.WaterTotalSelectedLabel.TabIndex = 30;
            this.WaterTotalSelectedLabel.Text = "Total Selected: ";
            // 
            // WaterRestBtn
            // 
            this.WaterRestBtn.Location = new System.Drawing.Point(471, 286);
            this.WaterRestBtn.Name = "WaterRestBtn";
            this.WaterRestBtn.Size = new System.Drawing.Size(106, 28);
            this.WaterRestBtn.TabIndex = 29;
            this.WaterRestBtn.Text = "Reset";
            this.WaterRestBtn.UseVisualStyleBackColor = true;
            this.WaterRestBtn.Click += new System.EventHandler(this.WaterRestBtn_Click);
            // 
            // WaterSelectBtn
            // 
            this.WaterSelectBtn.Location = new System.Drawing.Point(310, 286);
            this.WaterSelectBtn.Name = "WaterSelectBtn";
            this.WaterSelectBtn.Size = new System.Drawing.Size(106, 28);
            this.WaterSelectBtn.TabIndex = 28;
            this.WaterSelectBtn.Text = "Select Text";
            this.WaterSelectBtn.UseVisualStyleBackColor = true;
            this.WaterSelectBtn.Click += new System.EventHandler(this.WaterSelectBtn_Click);
            // 
            // FlushSettingsLabel
            // 
            this.FlushSettingsLabel.AutoSize = true;
            this.FlushSettingsLabel.Location = new System.Drawing.Point(21, 141);
            this.FlushSettingsLabel.Name = "FlushSettingsLabel";
            this.FlushSettingsLabel.Size = new System.Drawing.Size(78, 13);
            this.FlushSettingsLabel.TabIndex = 27;
            this.FlushSettingsLabel.Text = "Flush Setting:";
            // 
            // FlushSettingComboBox
            // 
            this.FlushSettingComboBox.FormattingEnabled = true;
            this.FlushSettingComboBox.Location = new System.Drawing.Point(20, 169);
            this.FlushSettingComboBox.Name = "FlushSettingComboBox";
            this.FlushSettingComboBox.Size = new System.Drawing.Size(114, 21);
            this.FlushSettingComboBox.TabIndex = 26;
            this.FlushSettingComboBox.Text = "Flush Tank";
            this.FlushSettingComboBox.SelectedIndexChanged += new System.EventHandler(this.FlushSettingComboBox_SelectedIndexChanged);
            // 
            // WaterSystemGroupBox
            // 
            this.WaterSystemGroupBox.Controls.Add(this.HotRadioBtn);
            this.WaterSystemGroupBox.Controls.Add(this.ColdRadioBtn);
            this.WaterSystemGroupBox.Location = new System.Drawing.Point(24, 75);
            this.WaterSystemGroupBox.Name = "WaterSystemGroupBox";
            this.WaterSystemGroupBox.Size = new System.Drawing.Size(268, 53);
            this.WaterSystemGroupBox.TabIndex = 25;
            this.WaterSystemGroupBox.TabStop = false;
            this.WaterSystemGroupBox.Text = "System";
            // 
            // HotRadioBtn
            // 
            this.HotRadioBtn.AutoSize = true;
            this.HotRadioBtn.Location = new System.Drawing.Point(155, 21);
            this.HotRadioBtn.Name = "HotRadioBtn";
            this.HotRadioBtn.Size = new System.Drawing.Size(44, 17);
            this.HotRadioBtn.TabIndex = 2;
            this.HotRadioBtn.TabStop = true;
            this.HotRadioBtn.Text = "Hot";
            this.HotRadioBtn.UseVisualStyleBackColor = true;
            this.HotRadioBtn.CheckedChanged += new System.EventHandler(this.HotRadioBtn_CheckedChanged);
            // 
            // ColdRadioBtn
            // 
            this.ColdRadioBtn.AutoSize = true;
            this.ColdRadioBtn.Checked = true;
            this.ColdRadioBtn.Location = new System.Drawing.Point(47, 21);
            this.ColdRadioBtn.Name = "ColdRadioBtn";
            this.ColdRadioBtn.Size = new System.Drawing.Size(49, 17);
            this.ColdRadioBtn.TabIndex = 0;
            this.ColdRadioBtn.TabStop = true;
            this.ColdRadioBtn.Text = "Cold";
            this.ColdRadioBtn.UseVisualStyleBackColor = true;
            this.ColdRadioBtn.CheckedChanged += new System.EventHandler(this.ColdRadioBtn_CheckedChanged);
            // 
            // WaterDataGrid
            // 
            this.WaterDataGrid.AllowUserToAddRows = false;
            this.WaterDataGrid.AllowUserToDeleteRows = false;
            this.WaterDataGrid.AllowUserToResizeColumns = false;
            this.WaterDataGrid.AllowUserToResizeRows = false;
            this.WaterDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.WaterDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WaterDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.WaterDataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.WaterDataGrid.Location = new System.Drawing.Point(338, 37);
            this.WaterDataGrid.Name = "WaterDataGrid";
            this.WaterDataGrid.ReadOnly = true;
            this.WaterDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.WaterDataGrid.Size = new System.Drawing.Size(239, 166);
            this.WaterDataGrid.TabIndex = 24;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "Id";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 42;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn10.Frozen = true;
            this.dataGridViewTextBoxColumn10.HeaderText = "Count";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.Width = 64;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PipeSize";
            this.dataGridViewTextBoxColumn11.Frozen = true;
            this.dataGridViewTextBoxColumn11.HeaderText = "PipeSize";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn11.Width = 74;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Units";
            this.dataGridViewTextBoxColumn12.HeaderText = "Units";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.Width = 59;
            // 
            // WaterMeterialGroupBox
            // 
            this.WaterMeterialGroupBox.Controls.Add(this.PexRadioBtn);
            this.WaterMeterialGroupBox.Controls.Add(this.CpvcRadioBtn);
            this.WaterMeterialGroupBox.Controls.Add(this.CopperRadioBtn);
            this.WaterMeterialGroupBox.Location = new System.Drawing.Point(24, 16);
            this.WaterMeterialGroupBox.Name = "WaterMeterialGroupBox";
            this.WaterMeterialGroupBox.Size = new System.Drawing.Size(268, 53);
            this.WaterMeterialGroupBox.TabIndex = 23;
            this.WaterMeterialGroupBox.TabStop = false;
            this.WaterMeterialGroupBox.Text = "Material";
            // 
            // PexRadioBtn
            // 
            this.PexRadioBtn.AutoSize = true;
            this.PexRadioBtn.Location = new System.Drawing.Point(187, 21);
            this.PexRadioBtn.Name = "PexRadioBtn";
            this.PexRadioBtn.Size = new System.Drawing.Size(43, 17);
            this.PexRadioBtn.TabIndex = 2;
            this.PexRadioBtn.TabStop = true;
            this.PexRadioBtn.Text = "PEX";
            this.PexRadioBtn.UseVisualStyleBackColor = true;
            this.PexRadioBtn.CheckedChanged += new System.EventHandler(this.PexRadioBtn_CheckedChanged);
            // 
            // CpvcRadioBtn
            // 
            this.CpvcRadioBtn.AutoSize = true;
            this.CpvcRadioBtn.Location = new System.Drawing.Point(107, 22);
            this.CpvcRadioBtn.Name = "CpvcRadioBtn";
            this.CpvcRadioBtn.Size = new System.Drawing.Size(52, 17);
            this.CpvcRadioBtn.TabIndex = 1;
            this.CpvcRadioBtn.TabStop = true;
            this.CpvcRadioBtn.Text = "CPVC";
            this.CpvcRadioBtn.UseVisualStyleBackColor = true;
            this.CpvcRadioBtn.CheckedChanged += new System.EventHandler(this.CpvcRadioBtn_CheckedChanged);
            // 
            // CopperRadioBtn
            // 
            this.CopperRadioBtn.AutoSize = true;
            this.CopperRadioBtn.Checked = true;
            this.CopperRadioBtn.Location = new System.Drawing.Point(26, 22);
            this.CopperRadioBtn.Name = "CopperRadioBtn";
            this.CopperRadioBtn.Size = new System.Drawing.Size(63, 17);
            this.CopperRadioBtn.TabIndex = 0;
            this.CopperRadioBtn.TabStop = true;
            this.CopperRadioBtn.Text = "Copper";
            this.CopperRadioBtn.UseVisualStyleBackColor = true;
            this.CopperRadioBtn.CheckedChanged += new System.EventHandler(this.CopperRadioBtn_CheckedChanged);
            // 
            // GasTab
            // 
            this.GasTab.Controls.Add(this.GasMaxLabel);
            this.GasTab.Controls.Add(this.WaterLenthLabel);
            this.GasTab.Controls.Add(this.GasTotalLengthLabel);
            this.GasTab.Controls.Add(this.GasReset);
            this.GasTab.Controls.Add(this.GasSelectBtn);
            this.GasTab.Controls.Add(this.GasApplyBtn);
            this.GasTab.Controls.Add(this.GasPipeSizelabel);
            this.GasTab.Controls.Add(this.GasDataGrid);
            this.GasTab.Controls.Add(this.GasLengthComboBox);
            this.GasTab.Controls.Add(this.PressureBox);
            this.GasTab.Location = new System.Drawing.Point(4, 22);
            this.GasTab.Name = "GasTab";
            this.GasTab.Padding = new System.Windows.Forms.Padding(3);
            this.GasTab.Size = new System.Drawing.Size(623, 367);
            this.GasTab.TabIndex = 2;
            this.GasTab.Text = "Gas";
            this.GasTab.UseVisualStyleBackColor = true;
            // 
            // GasMaxLabel
            // 
            this.GasMaxLabel.AutoSize = true;
            this.GasMaxLabel.Location = new System.Drawing.Point(29, 262);
            this.GasMaxLabel.Name = "GasMaxLabel";
            this.GasMaxLabel.Size = new System.Drawing.Size(59, 13);
            this.GasMaxLabel.TabIndex = 39;
            this.GasMaxLabel.Text = "Max Unit: ";
            // 
            // WaterLenthLabel
            // 
            this.WaterLenthLabel.AutoSize = true;
            this.WaterLenthLabel.Location = new System.Drawing.Point(29, 110);
            this.WaterLenthLabel.Name = "WaterLenthLabel";
            this.WaterLenthLabel.Size = new System.Drawing.Size(49, 13);
            this.WaterLenthLabel.TabIndex = 29;
            this.WaterLenthLabel.Text = "Length: ";
            // 
            // GasTotalLengthLabel
            // 
            this.GasTotalLengthLabel.AutoSize = true;
            this.GasTotalLengthLabel.Location = new System.Drawing.Point(308, 262);
            this.GasTotalLengthLabel.Name = "GasTotalLengthLabel";
            this.GasTotalLengthLabel.Size = new System.Drawing.Size(77, 13);
            this.GasTotalLengthLabel.TabIndex = 27;
            this.GasTotalLengthLabel.Text = "Total Length: ";
            // 
            // GasReset
            // 
            this.GasReset.Location = new System.Drawing.Point(467, 313);
            this.GasReset.Name = "GasReset";
            this.GasReset.Size = new System.Drawing.Size(106, 28);
            this.GasReset.TabIndex = 26;
            this.GasReset.Text = "Reset";
            this.GasReset.UseVisualStyleBackColor = true;
            this.GasReset.Click += new System.EventHandler(this.GasReset_Click);
            // 
            // GasSelectBtn
            // 
            this.GasSelectBtn.Location = new System.Drawing.Point(306, 313);
            this.GasSelectBtn.Name = "GasSelectBtn";
            this.GasSelectBtn.Size = new System.Drawing.Size(106, 28);
            this.GasSelectBtn.TabIndex = 25;
            this.GasSelectBtn.Text = "Select Text";
            this.GasSelectBtn.UseVisualStyleBackColor = true;
            this.GasSelectBtn.Click += new System.EventHandler(this.GasSelectBtn_Click);
            // 
            // GasApplyBtn
            // 
            this.GasApplyBtn.BackColor = System.Drawing.Color.Transparent;
            this.GasApplyBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.GasApplyBtn.Location = new System.Drawing.Point(82, 309);
            this.GasApplyBtn.Name = "GasApplyBtn";
            this.GasApplyBtn.Size = new System.Drawing.Size(113, 37);
            this.GasApplyBtn.TabIndex = 24;
            this.GasApplyBtn.Text = "Apply Update";
            this.GasApplyBtn.UseVisualStyleBackColor = false;
            this.GasApplyBtn.Click += new System.EventHandler(this.GasApplyBtn_Click);
            // 
            // GasPipeSizelabel
            // 
            this.GasPipeSizelabel.AutoSize = true;
            this.GasPipeSizelabel.Location = new System.Drawing.Point(29, 204);
            this.GasPipeSizelabel.Name = "GasPipeSizelabel";
            this.GasPipeSizelabel.Size = new System.Drawing.Size(55, 13);
            this.GasPipeSizelabel.TabIndex = 22;
            this.GasPipeSizelabel.Text = "PipeSize: ";
            // 
            // GasDataGrid
            // 
            this.GasDataGrid.AllowUserToAddRows = false;
            this.GasDataGrid.AllowUserToDeleteRows = false;
            this.GasDataGrid.AllowUserToResizeColumns = false;
            this.GasDataGrid.AllowUserToResizeRows = false;
            this.GasDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GasDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GasDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.GasDataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.GasDataGrid.Location = new System.Drawing.Point(323, 36);
            this.GasDataGrid.Name = "GasDataGrid";
            this.GasDataGrid.ReadOnly = true;
            this.GasDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GasDataGrid.Size = new System.Drawing.Size(235, 166);
            this.GasDataGrid.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 42;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Count";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 64;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PipeSize";
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "PipeSize";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 74;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Length";
            this.dataGridViewTextBoxColumn8.HeaderText = "Length";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 68;
            // 
            // GasLengthComboBox
            // 
            this.GasLengthComboBox.FormattingEnabled = true;
            this.GasLengthComboBox.Location = new System.Drawing.Point(32, 135);
            this.GasLengthComboBox.Name = "GasLengthComboBox";
            this.GasLengthComboBox.Size = new System.Drawing.Size(200, 21);
            this.GasLengthComboBox.TabIndex = 3;
            this.GasLengthComboBox.Text = "Select Length";
            this.GasLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.GasLengthComboBox_SelectedIndexChanged);
            // 
            // PressureBox
            // 
            this.PressureBox.Controls.Add(this.RadioBtnPressureMed);
            this.PressureBox.Controls.Add(this.LowPressureGasRadioBtn);
            this.PressureBox.Location = new System.Drawing.Point(32, 36);
            this.PressureBox.Name = "PressureBox";
            this.PressureBox.Size = new System.Drawing.Size(200, 53);
            this.PressureBox.TabIndex = 2;
            this.PressureBox.TabStop = false;
            this.PressureBox.Text = "Pressure";
            // 
            // RadioBtnPressureMed
            // 
            this.RadioBtnPressureMed.AutoSize = true;
            this.RadioBtnPressureMed.Location = new System.Drawing.Point(113, 22);
            this.RadioBtnPressureMed.Name = "RadioBtnPressureMed";
            this.RadioBtnPressureMed.Size = new System.Drawing.Size(48, 17);
            this.RadioBtnPressureMed.TabIndex = 1;
            this.RadioBtnPressureMed.Text = "Med";
            this.RadioBtnPressureMed.UseVisualStyleBackColor = true;
            this.RadioBtnPressureMed.CheckedChanged += new System.EventHandler(this.RadioBtnPressureMed_CheckedChanged);
            // 
            // LowPressureGasRadioBtn
            // 
            this.LowPressureGasRadioBtn.AutoSize = true;
            this.LowPressureGasRadioBtn.Location = new System.Drawing.Point(28, 22);
            this.LowPressureGasRadioBtn.Name = "LowPressureGasRadioBtn";
            this.LowPressureGasRadioBtn.Size = new System.Drawing.Size(46, 17);
            this.LowPressureGasRadioBtn.TabIndex = 0;
            this.LowPressureGasRadioBtn.Text = "Low";
            this.LowPressureGasRadioBtn.UseVisualStyleBackColor = true;
            this.LowPressureGasRadioBtn.CheckedChanged += new System.EventHandler(this.LowPressureGasRadioBtn_CheckedChanged);
            // 
            // StormDrainTab
            // 
            this.StormDrainTab.Controls.Add(this.StormDrainMaxLabel);
            this.StormDrainTab.Controls.Add(this.GroupBoxStormDrain);
            this.StormDrainTab.Controls.Add(this.StormDrainTotalSelectedLabel);
            this.StormDrainTab.Controls.Add(this.StormDrainResetBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainSelectBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainGridView);
            this.StormDrainTab.Controls.Add(this.StormDrainApplyBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainOverrideBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainSizeComboBox);
            this.StormDrainTab.Controls.Add(this.StormDrainPipeSizeLabel);
            this.StormDrainTab.Location = new System.Drawing.Point(4, 22);
            this.StormDrainTab.Name = "StormDrainTab";
            this.StormDrainTab.Padding = new System.Windows.Forms.Padding(3);
            this.StormDrainTab.Size = new System.Drawing.Size(623, 367);
            this.StormDrainTab.TabIndex = 3;
            this.StormDrainTab.Text = "Storm Drain";
            this.StormDrainTab.UseVisualStyleBackColor = true;
            // 
            // StormDrainMaxLabel
            // 
            this.StormDrainMaxLabel.AutoSize = true;
            this.StormDrainMaxLabel.Location = new System.Drawing.Point(32, 226);
            this.StormDrainMaxLabel.Name = "StormDrainMaxLabel";
            this.StormDrainMaxLabel.Size = new System.Drawing.Size(59, 13);
            this.StormDrainMaxLabel.TabIndex = 24;
            this.StormDrainMaxLabel.Text = "Max Unit: ";
            // 
            // GroupBoxStormDrain
            // 
            this.GroupBoxStormDrain.Controls.Add(this.StormDrainRadioBtn3Hr);
            this.GroupBoxStormDrain.Controls.Add(this.StormDrainRadioBtn2Hr);
            this.GroupBoxStormDrain.Controls.Add(this.StormDrainRadioBtn1Hr);
            this.GroupBoxStormDrain.Location = new System.Drawing.Point(35, 37);
            this.GroupBoxStormDrain.Name = "GroupBoxStormDrain";
            this.GroupBoxStormDrain.Size = new System.Drawing.Size(259, 53);
            this.GroupBoxStormDrain.TabIndex = 22;
            this.GroupBoxStormDrain.TabStop = false;
            this.GroupBoxStormDrain.Text = "Rate";
            // 
            // StormDrainRadioBtn3Hr
            // 
            this.StormDrainRadioBtn3Hr.AutoSize = true;
            this.StormDrainRadioBtn3Hr.Checked = true;
            this.StormDrainRadioBtn3Hr.Location = new System.Drawing.Point(187, 21);
            this.StormDrainRadioBtn3Hr.Name = "StormDrainRadioBtn3Hr";
            this.StormDrainRadioBtn3Hr.Size = new System.Drawing.Size(51, 17);
            this.StormDrainRadioBtn3Hr.TabIndex = 2;
            this.StormDrainRadioBtn3Hr.TabStop = true;
            this.StormDrainRadioBtn3Hr.Text = "3\"/Hr";
            this.StormDrainRadioBtn3Hr.UseVisualStyleBackColor = true;
            this.StormDrainRadioBtn3Hr.CheckedChanged += new System.EventHandler(this.StormDrainRadioBtn3Hr_CheckedChanged);
            // 
            // StormDrainRadioBtn2Hr
            // 
            this.StormDrainRadioBtn2Hr.AutoSize = true;
            this.StormDrainRadioBtn2Hr.Location = new System.Drawing.Point(107, 22);
            this.StormDrainRadioBtn2Hr.Name = "StormDrainRadioBtn2Hr";
            this.StormDrainRadioBtn2Hr.Size = new System.Drawing.Size(51, 17);
            this.StormDrainRadioBtn2Hr.TabIndex = 1;
            this.StormDrainRadioBtn2Hr.TabStop = true;
            this.StormDrainRadioBtn2Hr.Text = "2\"/Hr";
            this.StormDrainRadioBtn2Hr.UseVisualStyleBackColor = true;
            this.StormDrainRadioBtn2Hr.CheckedChanged += new System.EventHandler(this.StormDrainRadioBtn2Hr_CheckedChanged);
            // 
            // StormDrainRadioBtn1Hr
            // 
            this.StormDrainRadioBtn1Hr.AutoSize = true;
            this.StormDrainRadioBtn1Hr.Location = new System.Drawing.Point(26, 22);
            this.StormDrainRadioBtn1Hr.Name = "StormDrainRadioBtn1Hr";
            this.StormDrainRadioBtn1Hr.Size = new System.Drawing.Size(51, 17);
            this.StormDrainRadioBtn1Hr.TabIndex = 0;
            this.StormDrainRadioBtn1Hr.TabStop = true;
            this.StormDrainRadioBtn1Hr.Text = "1\"/Hr";
            this.StormDrainRadioBtn1Hr.UseVisualStyleBackColor = true;
            this.StormDrainRadioBtn1Hr.CheckedChanged += new System.EventHandler(this.StormDrainRadioBtn1Hr_CheckedChanged);
            // 
            // StormDrainTotalSelectedLabel
            // 
            this.StormDrainTotalSelectedLabel.AutoSize = true;
            this.StormDrainTotalSelectedLabel.Location = new System.Drawing.Point(308, 255);
            this.StormDrainTotalSelectedLabel.Name = "StormDrainTotalSelectedLabel";
            this.StormDrainTotalSelectedLabel.Size = new System.Drawing.Size(64, 13);
            this.StormDrainTotalSelectedLabel.TabIndex = 21;
            this.StormDrainTotalSelectedLabel.Text = "Total Area: ";
            // 
            // StormDrainResetBtn
            // 
            this.StormDrainResetBtn.Location = new System.Drawing.Point(467, 306);
            this.StormDrainResetBtn.Name = "StormDrainResetBtn";
            this.StormDrainResetBtn.Size = new System.Drawing.Size(106, 28);
            this.StormDrainResetBtn.TabIndex = 20;
            this.StormDrainResetBtn.Text = "Reset";
            this.StormDrainResetBtn.UseVisualStyleBackColor = true;
            this.StormDrainResetBtn.Click += new System.EventHandler(this.StormDrainResetBtn_Click);
            // 
            // StormDrainSelectBtn
            // 
            this.StormDrainSelectBtn.Location = new System.Drawing.Point(306, 306);
            this.StormDrainSelectBtn.Name = "StormDrainSelectBtn";
            this.StormDrainSelectBtn.Size = new System.Drawing.Size(106, 28);
            this.StormDrainSelectBtn.TabIndex = 19;
            this.StormDrainSelectBtn.Text = "Select Text";
            this.StormDrainSelectBtn.UseVisualStyleBackColor = true;
            this.StormDrainSelectBtn.Click += new System.EventHandler(this.StormDrainSelectBtn_Click);
            // 
            // StormDrainGridView
            // 
            this.StormDrainGridView.AllowUserToAddRows = false;
            this.StormDrainGridView.AllowUserToDeleteRows = false;
            this.StormDrainGridView.AllowUserToResizeColumns = false;
            this.StormDrainGridView.AllowUserToResizeRows = false;
            this.StormDrainGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.StormDrainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StormDrainGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.StormDrainGridView.GridColor = System.Drawing.SystemColors.Control;
            this.StormDrainGridView.Location = new System.Drawing.Point(322, 37);
            this.StormDrainGridView.Name = "StormDrainGridView";
            this.StormDrainGridView.ReadOnly = true;
            this.StormDrainGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.StormDrainGridView.Size = new System.Drawing.Size(235, 166);
            this.StormDrainGridView.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 42;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 64;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PipeSize";
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "PipeSize";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 74;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Area";
            this.dataGridViewTextBoxColumn4.HeaderText = "Area";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // StormDrainApplyBtn
            // 
            this.StormDrainApplyBtn.BackColor = System.Drawing.Color.Transparent;
            this.StormDrainApplyBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.StormDrainApplyBtn.Location = new System.Drawing.Point(80, 302);
            this.StormDrainApplyBtn.Name = "StormDrainApplyBtn";
            this.StormDrainApplyBtn.Size = new System.Drawing.Size(113, 37);
            this.StormDrainApplyBtn.TabIndex = 17;
            this.StormDrainApplyBtn.Text = "Apply Update";
            this.StormDrainApplyBtn.UseVisualStyleBackColor = false;
            this.StormDrainApplyBtn.Click += new System.EventHandler(this.StormDrainApplyBtn_Click);
            // 
            // StormDrainOverrideBtn
            // 
            this.StormDrainOverrideBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.StormDrainOverrideBtn.Location = new System.Drawing.Point(35, 162);
            this.StormDrainOverrideBtn.Name = "StormDrainOverrideBtn";
            this.StormDrainOverrideBtn.Size = new System.Drawing.Size(101, 29);
            this.StormDrainOverrideBtn.TabIndex = 7;
            this.StormDrainOverrideBtn.Text = "Override";
            this.StormDrainOverrideBtn.UseVisualStyleBackColor = true;
            this.StormDrainOverrideBtn.Click += new System.EventHandler(this.StormDrainOverrideBtn_Click);
            // 
            // StormDrainSizeComboBox
            // 
            this.StormDrainSizeComboBox.FormattingEnabled = true;
            this.StormDrainSizeComboBox.Location = new System.Drawing.Point(156, 115);
            this.StormDrainSizeComboBox.Name = "StormDrainSizeComboBox";
            this.StormDrainSizeComboBox.Size = new System.Drawing.Size(138, 21);
            this.StormDrainSizeComboBox.TabIndex = 3;
            this.StormDrainSizeComboBox.Text = "Select Override Size";
            this.StormDrainSizeComboBox.Visible = false;
            this.StormDrainSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.StormDrainSizeComboBox_SelectedIndexChanged);
            // 
            // StormDrainPipeSizeLabel
            // 
            this.StormDrainPipeSizeLabel.AutoSize = true;
            this.StormDrainPipeSizeLabel.Location = new System.Drawing.Point(32, 115);
            this.StormDrainPipeSizeLabel.Name = "StormDrainPipeSizeLabel";
            this.StormDrainPipeSizeLabel.Size = new System.Drawing.Size(58, 13);
            this.StormDrainPipeSizeLabel.TabIndex = 2;
            this.StormDrainPipeSizeLabel.Text = "Pipe Size: ";
            // 
            // PipeSumCloseBtn
            // 
            this.PipeSumCloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PipeSumCloseBtn.Location = new System.Drawing.Point(297, 433);
            this.PipeSumCloseBtn.Name = "PipeSumCloseBtn";
            this.PipeSumCloseBtn.Size = new System.Drawing.Size(91, 29);
            this.PipeSumCloseBtn.TabIndex = 1;
            this.PipeSumCloseBtn.Text = "Close";
            this.PipeSumCloseBtn.UseVisualStyleBackColor = true;
            this.PipeSumCloseBtn.Click += new System.EventHandler(this.PipeSumCloseBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PipeSumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.PipeSumCloseBtn;
            this.ClientSize = new System.Drawing.Size(697, 474);
            this.Controls.Add(this.PipeSumCloseBtn);
            this.Controls.Add(this.PipeSumTab);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PipeSumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PipeSumForm";
            this.Load += new System.EventHandler(this.PipeSumForm_Load);
            this.PipeSumTab.ResumeLayout(false);
            this.SanitaryTab.ResumeLayout(false);
            this.SanitaryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanitationGridView)).EndInit();
            this.WaterTab.ResumeLayout(false);
            this.WaterTab.PerformLayout();
            this.WaterSystemGroupBox.ResumeLayout(false);
            this.WaterSystemGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaterDataGrid)).EndInit();
            this.WaterMeterialGroupBox.ResumeLayout(false);
            this.WaterMeterialGroupBox.PerformLayout();
            this.GasTab.ResumeLayout(false);
            this.GasTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GasDataGrid)).EndInit();
            this.PressureBox.ResumeLayout(false);
            this.PressureBox.PerformLayout();
            this.StormDrainTab.ResumeLayout(false);
            this.StormDrainTab.PerformLayout();
            this.GroupBoxStormDrain.ResumeLayout(false);
            this.GroupBoxStormDrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StormDrainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PipeSumTab;
        private System.Windows.Forms.TabPage SanitaryTab;
        private System.Windows.Forms.TabPage WaterTab;
        private System.Windows.Forms.TabPage GasTab;
        private System.Windows.Forms.TabPage StormDrainTab;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button PipeSumCloseBtn;
        private System.Windows.Forms.GroupBox PressureBox;
        private System.Windows.Forms.RadioButton RadioBtnPressureMed;
        private System.Windows.Forms.RadioButton LowPressureGasRadioBtn;
        private System.Windows.Forms.ComboBox GasLengthComboBox;
        private System.Windows.Forms.ComboBox SanitationComboBox;
        private System.Windows.Forms.Label SanitaionPipeSystemLabel;
        private System.Windows.Forms.Button SanitationOverrideBtn;
        private System.Windows.Forms.TextBox FixtureConnectionBox;
        private System.Windows.Forms.Label SanitaionMaxUnitLabel;
        private System.Windows.Forms.Label SanitationFixtureConnectionLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView SanitationGridView;
        private System.Windows.Forms.Button SanitationSelectTxtBtn;
        private System.Windows.Forms.Button SanitaryResetTxtBtn;
        private System.Windows.Forms.Label SanitationTotalSelectedLabel;
        private System.Windows.Forms.Label PipeSizeLabel;
        private System.Windows.Forms.ComboBox PipeSizeComboBox;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Label StormDrainPipeSizeLabel;
        private System.Windows.Forms.Button StormDrainResetBtn;
        private System.Windows.Forms.Button StormDrainSelectBtn;
        private System.Windows.Forms.DataGridView StormDrainGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button StormDrainApplyBtn;
        private System.Windows.Forms.Button StormDrainOverrideBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn PipeSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private GroupBox GroupBoxStormDrain;
        private RadioButton StormDrainRadioBtn2Hr;
        private RadioButton StormDrainRadioBtn1Hr;
        private RadioButton StormDrainRadioBtn3Hr;
        private Label StormDrainMaxLabel;
        private DataGridView GasDataGrid;
        private Label GasPipeSizelabel;
        private Label GasTotalLengthLabel;
        private Button GasReset;
        private Button GasSelectBtn;
        private Button GasApplyBtn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Label StormDrainTotalSelectedLabel;
        private ComboBox StormDrainSizeComboBox;
        private GroupBox WaterMeterialGroupBox;
        private RadioButton PexRadioBtn;
        private RadioButton CpvcRadioBtn;
        private RadioButton CopperRadioBtn;
        private GroupBox WaterSystemGroupBox;
        private RadioButton HotRadioBtn;
        private RadioButton ColdRadioBtn;
        private DataGridView WaterDataGrid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Label FlushSettingsLabel;
        private ComboBox FlushSettingComboBox;
        private Button WaterApplyBtn;
        private Label WaterPipeSizeLabel;
        private ComboBox WaterPipeSizeComboBox;
        private Button WaterOverrideBtn;
        private Label PsiPerFootLabel;
        private ComboBox PsiPerFootComboBox;
        private Label WaterTotalSelectedLabel;
        private Button WaterRestBtn;
        private Button WaterSelectBtn;
        private Label WaterLenthLabel;
        private Label WaterMaxUnit;
        private Label GasMaxLabel;
    }
}