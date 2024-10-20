namespace K2dPlugin.Features.GenerateReport.GenerateReportForms
{
    partial class Test
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
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.CreateTextNoteType = new System.Windows.Forms.Button();
            this.DataGridComponentCount = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivateQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivateFixtureUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicFixtureUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemTypeCombo = new System.Windows.Forms.ComboBox();
            this.SystemTypeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SystemLossCombo = new System.Windows.Forms.ComboBox();
            this.PressurreCityStreetMain = new System.Windows.Forms.Label();
            this.CityHigh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CityLow = new System.Windows.Forms.TextBox();
            this.PressureProperty = new System.Windows.Forms.Label();
            this.PropertyLow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PropertyHigh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CityElevation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PropertyElevation = new System.Windows.Forms.TextBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SizeOfWaterMeter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MakeModeText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.MakeModelTmvText = new System.Windows.Forms.Label();
            this.FrictionLossSubMeter = new System.Windows.Forms.TextBox();
            this.FrictionLossFiltration = new System.Windows.Forms.TextBox();
            this.RequiredPressureFixture = new System.Windows.Forms.TextBox();
            this.PressureLossTmv = new System.Windows.Forms.TextBox();
            this.BuildingHeight = new System.Windows.Forms.TextBox();
            this.MakeMode = new System.Windows.Forms.TextBox();
            this.MakeModelGpm = new System.Windows.Forms.TextBox();
            this.MakeModelTmv = new System.Windows.Forms.TextBox();
            this.DevelopPipeLength = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TotalFixtureUnit = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ConvertedFuToGpm = new System.Windows.Forms.TextBox();
            this.OtherWaterReqGpm = new System.Windows.Forms.TextBox();
            this.OtherWaterReq = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ExustWaterReqGpm = new System.Windows.Forms.TextBox();
            this.ExustWaterReq = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ContactInfo = new System.Windows.Forms.TextBox();
            this.ContactInfoLabel = new System.Windows.Forms.Label();
            this.Source = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.SarDate = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Psi100FtCacl = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.Psi100Ft = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.UpdateSystemLossBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridComponentCount)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(598, 839);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(154, 46);
            this.GenerateBtn.TabIndex = 0;
            this.GenerateBtn.Text = "Create Note Type";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // CreateTextNoteType
            // 
            this.CreateTextNoteType.Location = new System.Drawing.Point(56, 839);
            this.CreateTextNoteType.Name = "CreateTextNoteType";
            this.CreateTextNoteType.Size = new System.Drawing.Size(154, 46);
            this.CreateTextNoteType.TabIndex = 1;
            this.CreateTextNoteType.Text = "Generate Legend";
            this.CreateTextNoteType.UseVisualStyleBackColor = true;
            this.CreateTextNoteType.Click += new System.EventHandler(this.CreateTextNoteType_Click);
            // 
            // DataGridComponentCount
            // 
            this.DataGridComponentCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridComponentCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.TotalCount,
            this.PrivateQuantity,
            this.PublicQuantity,
            this.PrivateFixtureUnit,
            this.PublicFixtureUnit,
            this.TotalFU});
            this.DataGridComponentCount.Location = new System.Drawing.Point(28, 341);
            this.DataGridComponentCount.Name = "DataGridComponentCount";
            this.DataGridComponentCount.Size = new System.Drawing.Size(767, 357);
            this.DataGridComponentCount.TabIndex = 2;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Name.DataPropertyName = "Name";
            this.Name.Frozen = true;
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 150;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 150;
            // 
            // TotalCount
            // 
            this.TotalCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TotalCount.DataPropertyName = "TotalCount";
            this.TotalCount.Frozen = true;
            this.TotalCount.HeaderText = "Total Count";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.ReadOnly = true;
            this.TotalCount.Width = 80;
            // 
            // PrivateQuantity
            // 
            this.PrivateQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PrivateQuantity.DataPropertyName = "PrivateQuantity";
            this.PrivateQuantity.Frozen = true;
            this.PrivateQuantity.HeaderText = "Private Quantity";
            this.PrivateQuantity.Name = "PrivateQuantity";
            this.PrivateQuantity.Width = 98;
            // 
            // PublicQuantity
            // 
            this.PublicQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PublicQuantity.DataPropertyName = "PublicQuantity";
            this.PublicQuantity.Frozen = true;
            this.PublicQuantity.HeaderText = "Public Quantity";
            this.PublicQuantity.Name = "PublicQuantity";
            this.PublicQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PublicQuantity.Width = 95;
            // 
            // PrivateFixtureUnit
            // 
            this.PrivateFixtureUnit.DataPropertyName = "PrivateFixtureUnit";
            this.PrivateFixtureUnit.Frozen = true;
            this.PrivateFixtureUnit.HeaderText = "Private Fixture Unit";
            this.PrivateFixtureUnit.Name = "PrivateFixtureUnit";
            this.PrivateFixtureUnit.ReadOnly = true;
            // 
            // PublicFixtureUnit
            // 
            this.PublicFixtureUnit.DataPropertyName = "PublicFixtureUnit";
            this.PublicFixtureUnit.Frozen = true;
            this.PublicFixtureUnit.HeaderText = "Public Fixture Unit";
            this.PublicFixtureUnit.Name = "PublicFixtureUnit";
            // 
            // TotalFU
            // 
            this.TotalFU.DataPropertyName = "TotalFU";
            this.TotalFU.Frozen = true;
            this.TotalFU.HeaderText = "Total (FU)";
            this.TotalFU.Name = "TotalFU";
            this.TotalFU.ReadOnly = true;
            // 
            // SystemTypeCombo
            // 
            this.SystemTypeCombo.FormattingEnabled = true;
            this.SystemTypeCombo.Location = new System.Drawing.Point(123, 50);
            this.SystemTypeCombo.Name = "SystemTypeCombo";
            this.SystemTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.SystemTypeCombo.TabIndex = 3;
            this.SystemTypeCombo.SelectedIndexChanged += new System.EventHandler(this.SystemTypeCombo_SelectedIndexChanged);
            // 
            // SystemTypeLabel
            // 
            this.SystemTypeLabel.AutoSize = true;
            this.SystemTypeLabel.Location = new System.Drawing.Point(25, 53);
            this.SystemTypeLabel.Name = "SystemTypeLabel";
            this.SystemTypeLabel.Size = new System.Drawing.Size(71, 13);
            this.SystemTypeLabel.TabIndex = 4;
            this.SystemTypeLabel.Text = "System Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "System Loss:";
            // 
            // SystemLossCombo
            // 
            this.SystemLossCombo.FormattingEnabled = true;
            this.SystemLossCombo.Location = new System.Drawing.Point(123, 94);
            this.SystemLossCombo.Name = "SystemLossCombo";
            this.SystemLossCombo.Size = new System.Drawing.Size(121, 21);
            this.SystemLossCombo.TabIndex = 5;
            // 
            // PressurreCityStreetMain
            // 
            this.PressurreCityStreetMain.AutoSize = true;
            this.PressurreCityStreetMain.Location = new System.Drawing.Point(263, 27);
            this.PressurreCityStreetMain.Name = "PressurreCityStreetMain";
            this.PressurreCityStreetMain.Size = new System.Drawing.Size(148, 13);
            this.PressurreCityStreetMain.TabIndex = 7;
            this.PressurreCityStreetMain.Text = "Pressure(PSI) City Street Main";
            // 
            // CityHigh
            // 
            this.CityHigh.Location = new System.Drawing.Point(340, 47);
            this.CityHigh.Name = "CityHigh";
            this.CityHigh.Size = new System.Drawing.Size(71, 20);
            this.CityHigh.TabIndex = 8;
            this.CityHigh.TextChanged += new System.EventHandler(this.CityHigh_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "High :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Low :";
            // 
            // CityLow
            // 
            this.CityLow.Location = new System.Drawing.Point(340, 90);
            this.CityLow.Name = "CityLow";
            this.CityLow.Size = new System.Drawing.Size(71, 20);
            this.CityLow.TabIndex = 11;
            this.CityLow.TextChanged += new System.EventHandler(this.CityLow_TextChanged);
            // 
            // PressureProperty
            // 
            this.PressureProperty.AutoSize = true;
            this.PressureProperty.Location = new System.Drawing.Point(459, 27);
            this.PressureProperty.Name = "PressureProperty";
            this.PressureProperty.Size = new System.Drawing.Size(113, 13);
            this.PressureProperty.TabIndex = 12;
            this.PressureProperty.Text = "Pressure(PSI) Property";
            // 
            // PropertyLow
            // 
            this.PropertyLow.Enabled = false;
            this.PropertyLow.Location = new System.Drawing.Point(523, 90);
            this.PropertyLow.Name = "PropertyLow";
            this.PropertyLow.Size = new System.Drawing.Size(73, 20);
            this.PropertyLow.TabIndex = 16;
            this.PropertyLow.TextChanged += new System.EventHandler(this.PropertyLow_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Low :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "High :";
            // 
            // PropertyHigh
            // 
            this.PropertyHigh.Enabled = false;
            this.PropertyHigh.Location = new System.Drawing.Point(523, 51);
            this.PropertyHigh.Name = "PropertyHigh";
            this.PropertyHigh.Size = new System.Drawing.Size(73, 20);
            this.PropertyHigh.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Elevation :";
            // 
            // CityElevation
            // 
            this.CityElevation.Location = new System.Drawing.Point(340, 128);
            this.CityElevation.Name = "CityElevation";
            this.CityElevation.Size = new System.Drawing.Size(71, 20);
            this.CityElevation.TabIndex = 18;
            this.CityElevation.TextChanged += new System.EventHandler(this.CityElevation_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Elevation :";
            // 
            // PropertyElevation
            // 
            this.PropertyElevation.Location = new System.Drawing.Point(522, 128);
            this.PropertyElevation.Name = "PropertyElevation";
            this.PropertyElevation.Size = new System.Drawing.Size(74, 20);
            this.PropertyElevation.TabIndex = 20;
            this.PropertyElevation.TextChanged += new System.EventHandler(this.PropertyElevation_TextChanged);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(312, 839);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(154, 46);
            this.UpdateBtn.TabIndex = 21;
            this.UpdateBtn.Text = "Update Legend";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Size of water meter :";
            // 
            // SizeOfWaterMeter
            // 
            this.SizeOfWaterMeter.FormattingEnabled = true;
            this.SizeOfWaterMeter.Location = new System.Drawing.Point(153, 172);
            this.SizeOfWaterMeter.Name = "SizeOfWaterMeter";
            this.SizeOfWaterMeter.Size = new System.Drawing.Size(91, 21);
            this.SizeOfWaterMeter.TabIndex = 23;
            this.SizeOfWaterMeter.SelectedIndexChanged += new System.EventHandler(this.SizeOfWaterMeter_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Friction loss of sub-meter:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Frictin loss of Filtration:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Pressure loss through TMV:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(290, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Building Height:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(290, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Required pressure at Fixture:";
            // 
            // MakeModeText
            // 
            this.MakeModeText.AutoSize = true;
            this.MakeModeText.Location = new System.Drawing.Point(575, 255);
            this.MakeModeText.Name = "MakeModeText";
            this.MakeModeText.Size = new System.Drawing.Size(71, 13);
            this.MakeModeText.TabIndex = 38;
            this.MakeModeText.Text = "Make/Model:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(575, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Make/Model and GPM:";
            // 
            // MakeModelTmvText
            // 
            this.MakeModelTmvText.AutoSize = true;
            this.MakeModelTmvText.Location = new System.Drawing.Point(575, 175);
            this.MakeModelTmvText.Name = "MakeModelTmvText";
            this.MakeModelTmvText.Size = new System.Drawing.Size(127, 13);
            this.MakeModelTmvText.TabIndex = 34;
            this.MakeModelTmvText.Text = "Make and model of TMV:";
            // 
            // FrictionLossSubMeter
            // 
            this.FrictionLossSubMeter.Location = new System.Drawing.Point(153, 216);
            this.FrictionLossSubMeter.Name = "FrictionLossSubMeter";
            this.FrictionLossSubMeter.Size = new System.Drawing.Size(91, 20);
            this.FrictionLossSubMeter.TabIndex = 40;
            this.FrictionLossSubMeter.TextChanged += new System.EventHandler(this.FrictionLossSubMeter_TextChanged);
            // 
            // FrictionLossFiltration
            // 
            this.FrictionLossFiltration.Location = new System.Drawing.Point(153, 252);
            this.FrictionLossFiltration.Name = "FrictionLossFiltration";
            this.FrictionLossFiltration.Size = new System.Drawing.Size(91, 20);
            this.FrictionLossFiltration.TabIndex = 41;
            this.FrictionLossFiltration.TextChanged += new System.EventHandler(this.FrictionLossFiltration_TextChanged);
            // 
            // RequiredPressureFixture
            // 
            this.RequiredPressureFixture.Location = new System.Drawing.Point(436, 172);
            this.RequiredPressureFixture.Name = "RequiredPressureFixture";
            this.RequiredPressureFixture.Size = new System.Drawing.Size(91, 20);
            this.RequiredPressureFixture.TabIndex = 42;
            this.RequiredPressureFixture.TextChanged += new System.EventHandler(this.RequiredPressureFixture_TextChanged);
            // 
            // PressureLossTmv
            // 
            this.PressureLossTmv.Location = new System.Drawing.Point(436, 249);
            this.PressureLossTmv.Name = "PressureLossTmv";
            this.PressureLossTmv.Size = new System.Drawing.Size(91, 20);
            this.PressureLossTmv.TabIndex = 44;
            this.PressureLossTmv.TextChanged += new System.EventHandler(this.PressureLossTmv_TextChanged);
            // 
            // BuildingHeight
            // 
            this.BuildingHeight.Location = new System.Drawing.Point(436, 213);
            this.BuildingHeight.Name = "BuildingHeight";
            this.BuildingHeight.Size = new System.Drawing.Size(91, 20);
            this.BuildingHeight.TabIndex = 43;
            this.BuildingHeight.TextChanged += new System.EventHandler(this.BuildingHeight_TextChanged);
            // 
            // MakeMode
            // 
            this.MakeMode.Location = new System.Drawing.Point(720, 249);
            this.MakeMode.Name = "MakeMode";
            this.MakeMode.Size = new System.Drawing.Size(91, 20);
            this.MakeMode.TabIndex = 47;
            // 
            // MakeModelGpm
            // 
            this.MakeModelGpm.Location = new System.Drawing.Point(720, 213);
            this.MakeModelGpm.Name = "MakeModelGpm";
            this.MakeModelGpm.Size = new System.Drawing.Size(91, 20);
            this.MakeModelGpm.TabIndex = 46;
            // 
            // MakeModelTmv
            // 
            this.MakeModelTmv.Location = new System.Drawing.Point(720, 172);
            this.MakeModelTmv.Name = "MakeModelTmv";
            this.MakeModelTmv.Size = new System.Drawing.Size(91, 20);
            this.MakeModelTmv.TabIndex = 45;
            // 
            // DevelopPipeLength
            // 
            this.DevelopPipeLength.Location = new System.Drawing.Point(153, 293);
            this.DevelopPipeLength.Name = "DevelopPipeLength";
            this.DevelopPipeLength.Size = new System.Drawing.Size(91, 20);
            this.DevelopPipeLength.TabIndex = 49;
            this.DevelopPipeLength.TextChanged += new System.EventHandler(this.DevelopPipeLength_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 296);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "Developed Pipe Length:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(484, 726);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Fixture Unit Total";
            // 
            // TotalFixtureUnit
            // 
            this.TotalFixtureUnit.Enabled = false;
            this.TotalFixtureUnit.Location = new System.Drawing.Point(587, 723);
            this.TotalFixtureUnit.Name = "TotalFixtureUnit";
            this.TotalFixtureUnit.Size = new System.Drawing.Size(73, 20);
            this.TotalFixtureUnit.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(679, 726);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "GPM";
            // 
            // ConvertedFuToGpm
            // 
            this.ConvertedFuToGpm.Enabled = false;
            this.ConvertedFuToGpm.Location = new System.Drawing.Point(738, 723);
            this.ConvertedFuToGpm.Name = "ConvertedFuToGpm";
            this.ConvertedFuToGpm.Size = new System.Drawing.Size(73, 20);
            this.ConvertedFuToGpm.TabIndex = 53;
            // 
            // OtherWaterReqGpm
            // 
            this.OtherWaterReqGpm.Enabled = false;
            this.OtherWaterReqGpm.Location = new System.Drawing.Point(738, 761);
            this.OtherWaterReqGpm.Name = "OtherWaterReqGpm";
            this.OtherWaterReqGpm.Size = new System.Drawing.Size(73, 20);
            this.OtherWaterReqGpm.TabIndex = 57;
            // 
            // OtherWaterReq
            // 
            this.OtherWaterReq.Location = new System.Drawing.Point(587, 761);
            this.OtherWaterReq.Name = "OtherWaterReq";
            this.OtherWaterReq.Size = new System.Drawing.Size(73, 20);
            this.OtherWaterReq.TabIndex = 55;
            this.OtherWaterReq.TextChanged += new System.EventHandler(this.OtherWaterReq_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(459, 764);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(111, 13);
            this.label19.TabIndex = 54;
            this.label19.Text = "Other Water Required";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(679, 764);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 58;
            this.label18.Text = "GPM";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(679, 800);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 62;
            this.label20.Text = "GPM";
            // 
            // ExustWaterReqGpm
            // 
            this.ExustWaterReqGpm.Enabled = false;
            this.ExustWaterReqGpm.Location = new System.Drawing.Point(738, 797);
            this.ExustWaterReqGpm.Name = "ExustWaterReqGpm";
            this.ExustWaterReqGpm.Size = new System.Drawing.Size(73, 20);
            this.ExustWaterReqGpm.TabIndex = 61;
            // 
            // ExustWaterReq
            // 
            this.ExustWaterReq.Location = new System.Drawing.Point(587, 797);
            this.ExustWaterReq.Name = "ExustWaterReq";
            this.ExustWaterReq.Size = new System.Drawing.Size(73, 20);
            this.ExustWaterReq.TabIndex = 60;
            this.ExustWaterReq.TextChanged += new System.EventHandler(this.ExustWaterReq_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(460, 800);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 13);
            this.label21.TabIndex = 59;
            this.label21.Text = "Exist. Water Required";
            // 
            // ContactInfo
            // 
            this.ContactInfo.Location = new System.Drawing.Point(737, 128);
            this.ContactInfo.Name = "ContactInfo";
            this.ContactInfo.Size = new System.Drawing.Size(74, 20);
            this.ContactInfo.TabIndex = 68;
            // 
            // ContactInfoLabel
            // 
            this.ContactInfoLabel.AutoSize = true;
            this.ContactInfoLabel.Location = new System.Drawing.Point(656, 130);
            this.ContactInfoLabel.Name = "ContactInfoLabel";
            this.ContactInfoLabel.Size = new System.Drawing.Size(68, 13);
            this.ContactInfoLabel.TabIndex = 67;
            this.ContactInfoLabel.Text = "Contact Info:";
            // 
            // Source
            // 
            this.Source.Location = new System.Drawing.Point(738, 90);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(73, 20);
            this.Source.TabIndex = 66;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(656, 92);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 13);
            this.label23.TabIndex = 65;
            this.label23.Text = "Source:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(656, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 13);
            this.label24.TabIndex = 64;
            this.label24.Text = "Sar Date:";
            // 
            // SarDate
            // 
            this.SarDate.Location = new System.Drawing.Point(738, 51);
            this.SarDate.Name = "SarDate";
            this.SarDate.Size = new System.Drawing.Size(73, 20);
            this.SarDate.TabIndex = 63;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(21, 726);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 13);
            this.label22.TabIndex = 70;
            this.label22.Text = "PSI/100FT";
            // 
            // Psi100FtCacl
            // 
            this.Psi100FtCacl.Enabled = false;
            this.Psi100FtCacl.Location = new System.Drawing.Point(130, 723);
            this.Psi100FtCacl.Name = "Psi100FtCacl";
            this.Psi100FtCacl.Size = new System.Drawing.Size(85, 20);
            this.Psi100FtCacl.TabIndex = 69;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(21, 764);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(103, 13);
            this.label25.TabIndex = 72;
            this.label25.Text = "PSI/100FT Override";
            // 
            // Psi100Ft
            // 
            this.Psi100Ft.Location = new System.Drawing.Point(130, 761);
            this.Psi100Ft.Name = "Psi100Ft";
            this.Psi100Ft.Size = new System.Drawing.Size(85, 20);
            this.Psi100Ft.TabIndex = 71;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 726);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 46);
            this.button1.TabIndex = 73;
            this.button1.Text = "Generate System Loss Form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateSystemLossBtn
            // 
            this.UpdateSystemLossBtn.Location = new System.Drawing.Point(339, 726);
            this.UpdateSystemLossBtn.Name = "UpdateSystemLossBtn";
            this.UpdateSystemLossBtn.Size = new System.Drawing.Size(105, 46);
            this.UpdateSystemLossBtn.TabIndex = 74;
            this.UpdateSystemLossBtn.Text = "Update System Loss Form";
            this.UpdateSystemLossBtn.UseVisualStyleBackColor = true;
            this.UpdateSystemLossBtn.Click += new System.EventHandler(this.UpdateSystemLossBtn_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(852, 897);
            this.Controls.Add(this.UpdateSystemLossBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.Psi100Ft);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.Psi100FtCacl);
            this.Controls.Add(this.ContactInfo);
            this.Controls.Add(this.ContactInfoLabel);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.SarDate);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ExustWaterReqGpm);
            this.Controls.Add(this.ExustWaterReq);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.OtherWaterReqGpm);
            this.Controls.Add(this.OtherWaterReq);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ConvertedFuToGpm);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TotalFixtureUnit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DevelopPipeLength);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.MakeMode);
            this.Controls.Add(this.MakeModelGpm);
            this.Controls.Add(this.MakeModelTmv);
            this.Controls.Add(this.PressureLossTmv);
            this.Controls.Add(this.BuildingHeight);
            this.Controls.Add(this.RequiredPressureFixture);
            this.Controls.Add(this.FrictionLossFiltration);
            this.Controls.Add(this.FrictionLossSubMeter);
            this.Controls.Add(this.MakeModeText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.MakeModelTmvText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SizeOfWaterMeter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.PropertyElevation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CityElevation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PropertyLow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PropertyHigh);
            this.Controls.Add(this.PressureProperty);
            this.Controls.Add(this.CityLow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CityHigh);
            this.Controls.Add(this.PressurreCityStreetMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SystemLossCombo);
            this.Controls.Add(this.SystemTypeLabel);
            this.Controls.Add(this.SystemTypeCombo);
            this.Controls.Add(this.DataGridComponentCount);
            this.Controls.Add(this.CreateTextNoteType);
            this.Controls.Add(this.GenerateBtn);
            this.Text = "Generate Report";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridComponentCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Button CreateTextNoteType;
        private System.Windows.Forms.DataGridView DataGridComponentCount;
        private System.Windows.Forms.ComboBox SystemTypeCombo;
        private System.Windows.Forms.Label SystemTypeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SystemLossCombo;
        private System.Windows.Forms.Label PressurreCityStreetMain;
        private System.Windows.Forms.TextBox CityHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CityLow;
        private System.Windows.Forms.Label PressureProperty;
        private System.Windows.Forms.TextBox PropertyLow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PropertyHigh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CityElevation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PropertyElevation;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox SizeOfWaterMeter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label MakeModeText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label MakeModelTmvText;
        private System.Windows.Forms.TextBox FrictionLossSubMeter;
        private System.Windows.Forms.TextBox FrictionLossFiltration;
        private System.Windows.Forms.TextBox RequiredPressureFixture;
        private System.Windows.Forms.TextBox PressureLossTmv;
        private System.Windows.Forms.TextBox BuildingHeight;
        private System.Windows.Forms.TextBox MakeMode;
        private System.Windows.Forms.TextBox MakeModelGpm;
        private System.Windows.Forms.TextBox MakeModelTmv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateFixtureUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicFixtureUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFU;
        private System.Windows.Forms.TextBox DevelopPipeLength;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TotalFixtureUnit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ConvertedFuToGpm;
        private System.Windows.Forms.TextBox OtherWaterReqGpm;
        private System.Windows.Forms.TextBox OtherWaterReq;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox ExustWaterReqGpm;
        private System.Windows.Forms.TextBox ExustWaterReq;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox ContactInfo;
        private System.Windows.Forms.Label ContactInfoLabel;
        private System.Windows.Forms.TextBox Source;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox SarDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox Psi100FtCacl;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox Psi100Ft;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button UpdateSystemLossBtn;
    }
}