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
            this.SanitaitonTab = new System.Windows.Forms.TabPage();
            this.SanitationHeadLocation = new System.Windows.Forms.GroupBox();
            this.RIghtArrowLocation = new System.Windows.Forms.RadioButton();
            this.LeftArrowLocation = new System.Windows.Forms.RadioButton();
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
            this.GasTab = new System.Windows.Forms.TabPage();
            this.GasLengthComboBox = new System.Windows.Forms.ComboBox();
            this.PressureBox = new System.Windows.Forms.GroupBox();
            this.RadioBtnPressureMed = new System.Windows.Forms.RadioButton();
            this.RadioBtnPressureLow = new System.Windows.Forms.RadioButton();
            this.StormDrainTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.StormDrainOverrideBtn = new System.Windows.Forms.Button();
            this.StormDrainSizeComboBox = new System.Windows.Forms.ComboBox();
            this.StormDrainPipeSizeLabel = new System.Windows.Forms.Label();
            this.AreaSelectedTextBox = new System.Windows.Forms.TextBox();
            this.SelectedAreaLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PipeSumCloseBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PipeSumTab.SuspendLayout();
            this.SanitaitonTab.SuspendLayout();
            this.SanitationHeadLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanitationGridView)).BeginInit();
            this.GasTab.SuspendLayout();
            this.PressureBox.SuspendLayout();
            this.StormDrainTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StormDrainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // PipeSumTab
            // 
            this.PipeSumTab.Controls.Add(this.SanitaitonTab);
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
            // SanitaitonTab
            // 
            this.SanitaitonTab.Controls.Add(this.SanitationHeadLocation);
            this.SanitaitonTab.Controls.Add(this.ApplyBtn);
            this.SanitaitonTab.Controls.Add(this.PipeSizeLabel);
            this.SanitaitonTab.Controls.Add(this.PipeSizeComboBox);
            this.SanitaitonTab.Controls.Add(this.SanitationTotalSelectedLabel);
            this.SanitaitonTab.Controls.Add(this.SanitaryResetTxtBtn);
            this.SanitaitonTab.Controls.Add(this.SanitationSelectTxtBtn);
            this.SanitaitonTab.Controls.Add(this.SanitationGridView);
            this.SanitaitonTab.Controls.Add(this.SanitaionMaxUnitLabel);
            this.SanitaitonTab.Controls.Add(this.SanitationFixtureConnectionLabel);
            this.SanitaitonTab.Controls.Add(this.FixtureConnectionBox);
            this.SanitaitonTab.Controls.Add(this.SanitationOverrideBtn);
            this.SanitaitonTab.Controls.Add(this.SanitaionPipeSystemLabel);
            this.SanitaitonTab.Controls.Add(this.SanitationComboBox);
            this.SanitaitonTab.Location = new System.Drawing.Point(4, 22);
            this.SanitaitonTab.Name = "SanitaitonTab";
            this.SanitaitonTab.Padding = new System.Windows.Forms.Padding(3);
            this.SanitaitonTab.Size = new System.Drawing.Size(623, 367);
            this.SanitaitonTab.TabIndex = 0;
            this.SanitaitonTab.Text = "Sanitation";
            this.SanitaitonTab.UseVisualStyleBackColor = true;
            // 
            // SanitationHeadLocation
            // 
            this.SanitationHeadLocation.Controls.Add(this.RIghtArrowLocation);
            this.SanitationHeadLocation.Controls.Add(this.LeftArrowLocation);
            this.SanitationHeadLocation.Location = new System.Drawing.Point(33, 220);
            this.SanitationHeadLocation.Name = "SanitationHeadLocation";
            this.SanitationHeadLocation.Size = new System.Drawing.Size(200, 53);
            this.SanitationHeadLocation.TabIndex = 17;
            this.SanitationHeadLocation.TabStop = false;
            this.SanitationHeadLocation.Text = "Leader Location";
            // 
            // RIghtArrowLocation
            // 
            this.RIghtArrowLocation.AutoSize = true;
            this.RIghtArrowLocation.Location = new System.Drawing.Point(112, 22);
            this.RIghtArrowLocation.Name = "RIghtArrowLocation";
            this.RIghtArrowLocation.Size = new System.Drawing.Size(53, 17);
            this.RIghtArrowLocation.TabIndex = 1;
            this.RIghtArrowLocation.TabStop = true;
            this.RIghtArrowLocation.Text = "Right";
            this.RIghtArrowLocation.UseVisualStyleBackColor = true;
            this.RIghtArrowLocation.CheckedChanged += new System.EventHandler(this.RIghtArrowLocation_CheckedChanged);
            // 
            // LeftArrowLocation
            // 
            this.LeftArrowLocation.AutoSize = true;
            this.LeftArrowLocation.Location = new System.Drawing.Point(28, 22);
            this.LeftArrowLocation.Name = "LeftArrowLocation";
            this.LeftArrowLocation.Size = new System.Drawing.Size(44, 17);
            this.LeftArrowLocation.TabIndex = 0;
            this.LeftArrowLocation.TabStop = true;
            this.LeftArrowLocation.Text = "Left";
            this.LeftArrowLocation.UseVisualStyleBackColor = true;
            this.LeftArrowLocation.CheckedChanged += new System.EventHandler(this.LeftArrowLocation_CheckedChanged);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.BackColor = System.Drawing.Color.Transparent;
            this.ApplyBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ApplyBtn.Location = new System.Drawing.Point(81, 290);
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
            this.PipeSizeLabel.Location = new System.Drawing.Point(30, 126);
            this.PipeSizeLabel.Name = "PipeSizeLabel";
            this.PipeSizeLabel.Size = new System.Drawing.Size(55, 13);
            this.PipeSizeLabel.TabIndex = 15;
            this.PipeSizeLabel.Text = "PipeSize: ";
            // 
            // PipeSizeComboBox
            // 
            this.PipeSizeComboBox.FormattingEnabled = true;
            this.PipeSizeComboBox.Location = new System.Drawing.Point(33, 150);
            this.PipeSizeComboBox.Name = "PipeSizeComboBox";
            this.PipeSizeComboBox.Size = new System.Drawing.Size(125, 21);
            this.PipeSizeComboBox.TabIndex = 14;
            this.PipeSizeComboBox.Text = "Select Override Size";
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
            this.SanitaionMaxUnitLabel.Location = new System.Drawing.Point(30, 191);
            this.SanitaionMaxUnitLabel.Name = "SanitaionMaxUnitLabel";
            this.SanitaionMaxUnitLabel.Size = new System.Drawing.Size(59, 13);
            this.SanitaionMaxUnitLabel.TabIndex = 8;
            this.SanitaionMaxUnitLabel.Text = "Max Unit: ";
            // 
            // SanitationFixtureConnectionLabel
            // 
            this.SanitationFixtureConnectionLabel.AutoSize = true;
            this.SanitationFixtureConnectionLabel.Location = new System.Drawing.Point(30, 89);
            this.SanitationFixtureConnectionLabel.Name = "SanitationFixtureConnectionLabel";
            this.SanitationFixtureConnectionLabel.Size = new System.Drawing.Size(108, 13);
            this.SanitationFixtureConnectionLabel.TabIndex = 3;
            this.SanitationFixtureConnectionLabel.Text = "Fixture Connection:";
            // 
            // FixtureConnectionBox
            // 
            this.FixtureConnectionBox.Enabled = false;
            this.FixtureConnectionBox.Location = new System.Drawing.Point(159, 86);
            this.FixtureConnectionBox.Name = "FixtureConnectionBox";
            this.FixtureConnectionBox.Size = new System.Drawing.Size(100, 22);
            this.FixtureConnectionBox.TabIndex = 7;
            // 
            // SanitationOverrideBtn
            // 
            this.SanitationOverrideBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.SanitationOverrideBtn.Location = new System.Drawing.Point(178, 145);
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
            this.WaterTab.Location = new System.Drawing.Point(4, 22);
            this.WaterTab.Name = "WaterTab";
            this.WaterTab.Padding = new System.Windows.Forms.Padding(3);
            this.WaterTab.Size = new System.Drawing.Size(623, 367);
            this.WaterTab.TabIndex = 1;
            this.WaterTab.Text = "Water";
            this.WaterTab.UseVisualStyleBackColor = true;
            // 
            // GasTab
            // 
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
            // GasLengthComboBox
            // 
            this.GasLengthComboBox.FormattingEnabled = true;
            this.GasLengthComboBox.Location = new System.Drawing.Point(30, 118);
            this.GasLengthComboBox.Name = "GasLengthComboBox";
            this.GasLengthComboBox.Size = new System.Drawing.Size(200, 21);
            this.GasLengthComboBox.TabIndex = 3;
            this.GasLengthComboBox.Text = "Select Length";
            // 
            // PressureBox
            // 
            this.PressureBox.Controls.Add(this.RadioBtnPressureMed);
            this.PressureBox.Controls.Add(this.RadioBtnPressureLow);
            this.PressureBox.Location = new System.Drawing.Point(30, 36);
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
            this.RadioBtnPressureMed.TabStop = true;
            this.RadioBtnPressureMed.Text = "Med";
            this.RadioBtnPressureMed.UseVisualStyleBackColor = true;
            // 
            // RadioBtnPressureLow
            // 
            this.RadioBtnPressureLow.AutoSize = true;
            this.RadioBtnPressureLow.Location = new System.Drawing.Point(28, 22);
            this.RadioBtnPressureLow.Name = "RadioBtnPressureLow";
            this.RadioBtnPressureLow.Size = new System.Drawing.Size(46, 17);
            this.RadioBtnPressureLow.TabIndex = 0;
            this.RadioBtnPressureLow.TabStop = true;
            this.RadioBtnPressureLow.Text = "Low";
            this.RadioBtnPressureLow.UseVisualStyleBackColor = true;
            // 
            // StormDrainTab
            // 
            this.StormDrainTab.Controls.Add(this.groupBox1);
            this.StormDrainTab.Controls.Add(this.StormDrainTotalSelectedLabel);
            this.StormDrainTab.Controls.Add(this.StormDrainResetBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainSelectBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainGridView);
            this.StormDrainTab.Controls.Add(this.button1);
            this.StormDrainTab.Controls.Add(this.StormDrainOverrideBtn);
            this.StormDrainTab.Controls.Add(this.StormDrainSizeComboBox);
            this.StormDrainTab.Controls.Add(this.StormDrainPipeSizeLabel);
            this.StormDrainTab.Controls.Add(this.AreaSelectedTextBox);
            this.StormDrainTab.Controls.Add(this.SelectedAreaLabel);
            this.StormDrainTab.Location = new System.Drawing.Point(4, 22);
            this.StormDrainTab.Name = "StormDrainTab";
            this.StormDrainTab.Padding = new System.Windows.Forms.Padding(3);
            this.StormDrainTab.Size = new System.Drawing.Size(623, 367);
            this.StormDrainTab.TabIndex = 3;
            this.StormDrainTab.Text = "Storm Drain";
            this.StormDrainTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StormDrainRadioBtn3Hr);
            this.groupBox1.Controls.Add(this.StormDrainRadioBtn2Hr);
            this.groupBox1.Controls.Add(this.StormDrainRadioBtn1Hr);
            this.groupBox1.Location = new System.Drawing.Point(35, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 53);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leader Location";
            // 
            // StormDrainRadioBtn3Hr
            // 
            this.StormDrainRadioBtn3Hr.AutoSize = true;
            this.StormDrainRadioBtn3Hr.Location = new System.Drawing.Point(187, 21);
            this.StormDrainRadioBtn3Hr.Name = "StormDrainRadioBtn3Hr";
            this.StormDrainRadioBtn3Hr.Size = new System.Drawing.Size(51, 17);
            this.StormDrainRadioBtn3Hr.TabIndex = 2;
            this.StormDrainRadioBtn3Hr.TabStop = true;
            this.StormDrainRadioBtn3Hr.Text = "3\"/Hr";
            this.StormDrainRadioBtn3Hr.UseVisualStyleBackColor = true;
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
            // 
            // StormDrainTotalSelectedLabel
            // 
            this.StormDrainTotalSelectedLabel.AutoSize = true;
            this.StormDrainTotalSelectedLabel.Location = new System.Drawing.Point(308, 239);
            this.StormDrainTotalSelectedLabel.Name = "StormDrainTotalSelectedLabel";
            this.StormDrainTotalSelectedLabel.Size = new System.Drawing.Size(64, 13);
            this.StormDrainTotalSelectedLabel.TabIndex = 21;
            this.StormDrainTotalSelectedLabel.Text = "Total Area: ";
            // 
            // StormDrainResetBtn
            // 
            this.StormDrainResetBtn.Location = new System.Drawing.Point(467, 290);
            this.StormDrainResetBtn.Name = "StormDrainResetBtn";
            this.StormDrainResetBtn.Size = new System.Drawing.Size(106, 28);
            this.StormDrainResetBtn.TabIndex = 20;
            this.StormDrainResetBtn.Text = "Reset";
            this.StormDrainResetBtn.UseVisualStyleBackColor = true;
            // 
            // StormDrainSelectBtn
            // 
            this.StormDrainSelectBtn.Location = new System.Drawing.Point(306, 290);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.ForeColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(80, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 37);
            this.button1.TabIndex = 17;
            this.button1.Text = "Apply Update";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // StormDrainOverrideBtn
            // 
            this.StormDrainOverrideBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.StormDrainOverrideBtn.Location = new System.Drawing.Point(193, 179);
            this.StormDrainOverrideBtn.Name = "StormDrainOverrideBtn";
            this.StormDrainOverrideBtn.Size = new System.Drawing.Size(101, 29);
            this.StormDrainOverrideBtn.TabIndex = 7;
            this.StormDrainOverrideBtn.Text = "Override";
            this.StormDrainOverrideBtn.UseVisualStyleBackColor = true;
            // 
            // StormDrainSizeComboBox
            // 
            this.StormDrainSizeComboBox.FormattingEnabled = true;
            this.StormDrainSizeComboBox.Location = new System.Drawing.Point(35, 184);
            this.StormDrainSizeComboBox.Name = "StormDrainSizeComboBox";
            this.StormDrainSizeComboBox.Size = new System.Drawing.Size(113, 21);
            this.StormDrainSizeComboBox.TabIndex = 3;
            // 
            // StormDrainPipeSizeLabel
            // 
            this.StormDrainPipeSizeLabel.AutoSize = true;
            this.StormDrainPipeSizeLabel.Location = new System.Drawing.Point(32, 159);
            this.StormDrainPipeSizeLabel.Name = "StormDrainPipeSizeLabel";
            this.StormDrainPipeSizeLabel.Size = new System.Drawing.Size(52, 13);
            this.StormDrainPipeSizeLabel.TabIndex = 2;
            this.StormDrainPipeSizeLabel.Text = "Pipe Size";
            // 
            // AreaSelectedTextBox
            // 
            this.AreaSelectedTextBox.Location = new System.Drawing.Point(128, 120);
            this.AreaSelectedTextBox.Name = "AreaSelectedTextBox";
            this.AreaSelectedTextBox.Size = new System.Drawing.Size(128, 22);
            this.AreaSelectedTextBox.TabIndex = 1;
            // 
            // SelectedAreaLabel
            // 
            this.SelectedAreaLabel.AutoSize = true;
            this.SelectedAreaLabel.Location = new System.Drawing.Point(32, 123);
            this.SelectedAreaLabel.Name = "SelectedAreaLabel";
            this.SelectedAreaLabel.Size = new System.Drawing.Size(76, 13);
            this.SelectedAreaLabel.TabIndex = 0;
            this.SelectedAreaLabel.Text = "Area Selected";
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
            this.SanitaitonTab.ResumeLayout(false);
            this.SanitaitonTab.PerformLayout();
            this.SanitationHeadLocation.ResumeLayout(false);
            this.SanitationHeadLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanitationGridView)).EndInit();
            this.GasTab.ResumeLayout(false);
            this.PressureBox.ResumeLayout(false);
            this.PressureBox.PerformLayout();
            this.StormDrainTab.ResumeLayout(false);
            this.StormDrainTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StormDrainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PipeSumTab;
        private System.Windows.Forms.TabPage SanitaitonTab;
        private System.Windows.Forms.TabPage WaterTab;
        private System.Windows.Forms.TabPage GasTab;
        private System.Windows.Forms.TabPage StormDrainTab;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button PipeSumCloseBtn;
        private System.Windows.Forms.GroupBox PressureBox;
        private System.Windows.Forms.RadioButton RadioBtnPressureMed;
        private System.Windows.Forms.RadioButton RadioBtnPressureLow;
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
        private System.Windows.Forms.Label SelectedAreaLabel;
        private System.Windows.Forms.TextBox AreaSelectedTextBox;
        private System.Windows.Forms.Label StormDrainPipeSizeLabel;
        private System.Windows.Forms.ComboBox StormDrainSizeComboBox;
        private System.Windows.Forms.Label StormDrainTotalSelectedLabel;
        private System.Windows.Forms.Button StormDrainResetBtn;
        private System.Windows.Forms.Button StormDrainSelectBtn;
        private System.Windows.Forms.DataGridView StormDrainGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button StormDrainOverrideBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn PipeSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private GroupBox SanitationHeadLocation;
        private RadioButton RIghtArrowLocation;
        private RadioButton LeftArrowLocation;
        private GroupBox groupBox1;
        private RadioButton StormDrainRadioBtn2Hr;
        private RadioButton StormDrainRadioBtn1Hr;
        private RadioButton StormDrainRadioBtn3Hr;
    }
}