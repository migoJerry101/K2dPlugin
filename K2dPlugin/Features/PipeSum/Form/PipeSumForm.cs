using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Interface;
using K2dPlugin.Services;
using K2dPlugin.Features.PipeSum.Dto;
using K2dPlugin.Features.PipeSum.Enum;
using static System.Net.Mime.MediaTypeNames;
using Autodesk.Revit.DB.Visual;
using ComboBox = System.Windows.Forms.ComboBox;
using Control = System.Windows.Forms.Control;
using TextBox = Autodesk.Revit.UI.TextBox;
using System.Windows.Input;

namespace K2dPlugin.Features.PipeSum.Form
{
    public partial class PipeSumForm : System.Windows.Forms.Form
    {
        public Document Document;
        private UIApplication UIApp;

        private readonly SanitaryService _sanitary = new SanitaryService();
        private readonly TextNoteService _textNote = new TextNoteService();
        private readonly StormDrainService _stormDrain = new StormDrainService();
        private readonly GasService _gasService = new GasService();
        private readonly WaterService _waterService = new WaterService();

        private static List<ElementId> _elementIds = new List<ElementId>();

        private static double _pipeSizeData;
        private static string _pipeSizeDataWater;
        private static string _pipeSizeForGas;
        private static string _pipeSizeForWater;

        private static double _fixtureConnection;
        private static double _stormDrainTotalArea;
        private static double _gasTotalLength;
        private static double _waterTotal;

        private static bool _isVent;
        private static PipeSumTabType _tabType;
        private static StormDrainType _stormDrainType = StormDrainType.Area3Hr;
        private static WaterPipeMaterialType _waterPipeMaterial = WaterPipeMaterialType.COPPER;
        private static bool _isSelect = true;
        private static bool _isUpdate;
        private static bool _isMessageBoxShown = false;
        private static bool _isProgrammaticChange = false;


        private static bool _isOverride;
        private static bool _isGasLow = true;
        private static bool _isFlushTank = true;
        private static bool _isWaterCold = true;
        private static bool _hasLeader;
        private static bool _isOnRight;
        private static XYZ _location;
        private static bool _comboBoxIsSet;
        private static bool _comboBoxFlushIsSet;
        private static string selectedSanitationItem;
        private static string selectedFlushSetting;

        private static double _temporaryPipeSize = 0;
        private static string _temporaryPipeSizeWater = string.Empty;

        private static double _PsiPerFootComboBoxKey = 0;

        private static int _tempGasLength = 0;

        private static List<PipeDiameterDto> _gasPipeDtos = new List<PipeDiameterDto>();

        private static List<PipeDiameterDto> _waterPipeDtos = new List<PipeDiameterDto>();
        //set const text here next time

        public PipeSumForm(Document document, UIApplication uiApp)
        {
            InitializeComponent();
            this.UIApp = uiApp;
            this.Show();
            this.KeyPreview = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular);
            this.Padding = new Padding(5);
            this.TopMost = true;

            Document = document;
            this.UIApp = uiApp;

            if (SanitationComboBox.Items.Count == 0)
            {
                SanitationComboBox.Items.Add("Sanitary");
                SanitationComboBox.Items.Add("Sanitary Vent");
            }

            if (FlushSettingComboBox.Items.Count == 0)
            {
                FlushSettingComboBox.Items.Add("Flush Tank");
                FlushSettingComboBox.Items.Add("Flush Valve");

            }

            if (_isGasLow)
            {
                LowPressureGasRadioBtn.Checked = true;
            }
            else
            {
                RadioBtnPressureMed.Checked = true;
            }


            switch (_waterPipeMaterial)
            {
                case WaterPipeMaterialType.COPPER:
                    CopperRadioBtn.Checked = true;
                    break;
                case WaterPipeMaterialType.CPVC:
                    CpvcRadioBtn.Checked = true;
                    break;
                case WaterPipeMaterialType.PEX:
                    PexRadioBtn.Checked = true;
                    break;
                default:
                    break;
            }

            if (_isWaterCold)
            {
                ColdRadioBtn.Checked = true;
            }
            else
            {
                HotRadioBtn.Checked = true;
            }

            SanitationComboBox.SelectedItem = _comboBoxIsSet ? selectedSanitationItem : "Select Pipe System";
            FlushSettingComboBox.SelectedItem = _comboBoxFlushIsSet ? selectedFlushSetting : "Select Flush Settings";

            SanitationGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            SanitationGridView.ReadOnly = true;

            PipeSumTab.SelectedIndex = (int)_tabType;
            if (_isSelect)
            {
                GetElementId();
                FormDataPopulateSwitch();
            }
            else
            {
                var forUpdate = GetSelectedDataFromRevit(true);


                if (forUpdate.Any()) UpdateSanitaryText(forUpdate.FirstOrDefault().Id);
                FormDataPopulateSwitch();

                this.BringToFront();
            }


            if (_location != null)
            {
                this.Location = new System.Drawing.Point((int)_location.X, (int)_location.Y);
            }
        }   

        private void PipeSum_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanitaryReset();
            StormDrainRest();
            GasResetAction();
            WaterReset();
            FormDataPopulateSwitch();
        }

        public void FormDataPopulateSwitch()
        {
            StormDrainSizeComboBox.Items.Clear();
            PipeSizeComboBox.Items.Clear();


            switch (PipeSumTab.SelectedTab.TabIndex)
            {
                case (int)PipeSumTabType.SanitaryTab:
                    PopulateSanitationFormData();
                    SanitationPipeSizeComboBoxSetItems();

                    if (!_isOverride && SanitationGridView.Rows.Count > 0) AutoSetSizeSanitation();
                    _tabType = PipeSumTabType.SanitaryTab;
                    break;
                case (int)PipeSumTabType.WaterTab:
                    PopulateWaterFormData();
                    SetWaterPipePressure();

                    if (!_isOverride && WaterDataGrid.Rows.Count > 0) AutoSetSizeWater();
                    _tabType = PipeSumTabType.WaterTab;
                    break;
                case (int)PipeSumTabType.GasTab:
                    PopulateGasFormData();

                    if (GasLengthComboBox.Items.Count == 0)
                    {
                        SetGasLengthComboBoxItems();
                        GasLengthComboBox.SelectedIndex = _tempGasLength;
                    }

                    if(!_isOverride && GasDataGrid.Rows.Count > 0) AutoSetSizeGas();
                    _tabType = PipeSumTabType.GasTab;
                    break;
                case (int)PipeSumTabType.StormDrainTab:
                    SetRadioBtnForStormDrainType();
                    PopulateStormDrainFormData();
                    StormDrainPipeSizeComboBoxSetItems();

                    if (!_isOverride && StormDrainGridView.Rows.Count > 0) AutoSetSizeStormDrain();
                    //SanitaryReset();
                    _tabType = PipeSumTabType.StormDrainTab;
                    break;
                default:
                    break;
            }
        }


        private void SetGasLengthComboBoxItems()
        {
            GasLengthComboBox.Items.Clear();
            var lengths = _isGasLow ? _gasService.GetGasLowLengthKeys() : _gasService.GetGasMedLengthKeys() ;

            foreach (var x in lengths)
            {
                GasLengthComboBox.Items.Add(x);
            }
        }

        private void SanitationPipeSizeComboBoxSetItems()
        {
            var sizes = _sanitary.GetPipeSizes();
            var sizesWithoutFirstTwo = sizes.Skip(2).ToList();

            foreach (var size in sizesWithoutFirstTwo)
            {
                PipeSizeComboBox.Items.Add(size);
            }
        }

        private void StormDrainPipeSizeComboBoxSetItems()
        {
            var sizes = _stormDrain.GetPipeSizes().Where(x => x > 0);

            foreach (var size in sizes)
            {
                StormDrainSizeComboBox.Items.Add(size);
            }
        }

        private void SetRadioBtnForStormDrainType()
        {
            switch (_stormDrainType)
            {
                case StormDrainType.Area1Hr:
                    StormDrainRadioBtn1Hr.Checked = true;
                    break;
                case StormDrainType.Area2Hr:
                    StormDrainRadioBtn2Hr.Checked = true;
                    break;
                case StormDrainType.Area3Hr:
                    StormDrainRadioBtn3Hr.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void PipeSumForm_Load(object sender, EventArgs e)
        {


        }

        private void SanitationSelectTxtBtn_Click(object sender, EventArgs e)
        {
            _isSelect = true;
            _isUpdate = false;

            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (_isSelect)
        //    {
        //        if (keyData != Keys.Space) return false;

        //        //AutoSetSizeSanitation();
        //        this.Show();
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void PopulateSanitationFormData() 
        {
            SanitationGridView.Rows.Clear();
            const string totalString = @"Total Selected: ";
            SanitationTotalSelectedLabel.Text = totalString;
            var selectedPipes =  GetSelectedDataFromRevit(false);

            foreach (var pipe in selectedPipes)
            {
                SanitationGridView.Rows.Add(pipe.Id, pipe.Count, pipe.PipeSize + '"', pipe.Unit);
            }

            var total = selectedPipes.Sum(x => x.Unit);
            FixtureConnectionBox.Text = total.ToString();
            _fixtureConnection = total;
            SanitationTotalSelectedLabel.Text += total.ToString();
        }

        private void PopulateWaterFormData()
        {
            WaterDataGrid.Rows.Clear();
            const string totalString = @"Total Selected: ";
            WaterTotalSelectedLabel.Text = totalString;
            var selectedPipes = GetSelectedDataFromRevit(false);

            foreach (var pipe in selectedPipes)
            {
                WaterDataGrid.Rows.Add(pipe.Id, pipe.Count, pipe.PipeSize + '"', pipe.Unit);
            }

            var total = selectedPipes.Sum(x => x.Unit);
            _waterTotal = total;
            WaterTotalSelectedLabel.Text += _waterTotal.ToString();
        }

        private void PopulateStormDrainFormData()
        {
            StormDrainGridView.Rows.Clear();
            const string totalString = @"Total Selected: ";
            StormDrainTotalSelectedLabel.Text = totalString;
            var selectedPipes = GetSelectedDataFromRevit(false);

            foreach (var pipe in selectedPipes)
            {
                StormDrainGridView.Rows.Add(pipe.Id, pipe.Count, pipe.PipeSize + '"', pipe.Unit);
            }

            var total = selectedPipes.Sum(x => x.Unit);//this is area for stormDrain
            _stormDrainTotalArea = total;
            StormDrainTotalSelectedLabel.Text += total.ToString();
        }
        private void PopulateGasFormData()
        {
            GasDataGrid.Rows.Clear();
            const string totalString = @"Total Selected: ";
            GasTotalLengthLabel.Text = totalString;
            var selectedPipes = GetSelectedDataFromRevit(false);

            foreach (var pipe in selectedPipes)
            {
                GasDataGrid.Rows.Add(pipe.Id, pipe.Count, pipe.PipeSize + '"', pipe.Unit);
            }

            var total = selectedPipes.Sum(x => x.Unit);//this is area for stormDrain
            _gasTotalLength = total;
            GasTotalLengthLabel.Text += total.ToString();
        }

        private void GetElementId()
        {
            var doc = this.UIApp.ActiveUIDocument.Document;
            var data = this.UIApp.ActiveUIDocument.Selection.GetElementIds();

            foreach (var id in data)
            {
                var contains = _elementIds.Contains(id);
                if (doc.GetElement(id) is TextNote && _isSelect && !contains && !_isUpdate) _elementIds.Add(id);
            }
        }

        private IEnumerable<Pipe> GetSelectedDataFromRevit(bool isUpDate)
        {
            var doc = this.UIApp.ActiveUIDocument.Document;
            var pipeList = new List<Pipe>();
            var count = 1;
            var data = (isUpDate & !_isSelect) ? this.UIApp.ActiveUIDocument.Selection.GetElementIds() : _elementIds;

            //create a Pipe from the selected element
            foreach (var elementId in data)
            {

                if (!(doc.GetElement(elementId) is TextNote element)) continue;

                var text = element.Text;
                var splitText = text.Split('"');
                var pipe = new Pipe();

                if (splitText.Length > 1)
                {
                    var valPostReplace = splitText[1]
                        .Replace("(", "")
                        .Replace(")", "");

                    if (double.TryParse(valPostReplace, out var unit)) pipe.Unit = unit;
                }

                pipe.Count = count;
                pipe.PipeSize = splitText[0];
                pipe.Id = element.Id.IntegerValue.ToString();
                pipeList.Add(pipe);
                count++;
            }

            return pipeList;
        }

        private void SanitaryResetTxtBtn_Click(object sender, EventArgs e)
        {
            SanitaryReset();
        }

        private void SanitaryReset()
        {
            _elementIds = new List<ElementId>();
            _isSelect = true;
            _isUpdate = false;
            _hasLeader = false;
            _isOverride = false;
            _pipeSizeData = 0;
            _temporaryPipeSize = 0;
            PipeSizeComboBox.Visible = false;

            SanitationTotalSelectedLabel.Text = @"Total Selected: ";
            SanitationGridView.Rows.Clear();
            SanitaionMaxUnitLabel.Text = @"Max Unit: ";
            PipeSizeLabel.Text = @"PipeSize: ";
            PipeSizeComboBox.SelectedItem = "Select Override Size";
            SanitationComboBox.SelectedValue = "Select Pipe System";
        }

        private void SanitationOverrideBtn_Click(object sender, EventArgs e)
        {
            if (PipeSizeComboBox.Visible)
            {
                PipeSizeLabel.Text = @"PipeSize: ";
                _pipeSizeData = _temporaryPipeSize;
                PipeSizeLabel.Text += _pipeSizeData.ToString();
                _isOverride = !_isOverride;
            }

            PipeSizeComboBox.Visible = !PipeSizeComboBox.Visible;
        }

        private void StormDrainOverrideBtn_Click(object sender, EventArgs e)
        {
            if (StormDrainSizeComboBox.Visible)
            {
                _pipeSizeData = _temporaryPipeSize;
                StormDrainPipeSizeLabel.Text = $"PipeSize: {_pipeSizeData}";
                _isOverride = !_isOverride;
            }

            StormDrainSizeComboBox.Visible = !StormDrainSizeComboBox.Visible;
        }

        private void AutoSetSizeStormDrain()
        {
            var dtos = _stormDrain.GetListOfPipeDto().ToArray();
            var count = dtos.Count();
            var DiameterDtos = new List<PipeDiameterDto>();

            switch (_stormDrainType)
            {
                case StormDrainType.Area1Hr:
                    for (var i = 0; i < count - 1; i++)
                    {
                        var dto = new PipeDiameterDto()
                        {
                            Diameter = dtos[i + 1].Diameter,
                            Max = dtos[i + 1].Area1Hr,
                            Min = dtos[i].Area1Hr
                        };

                        DiameterDtos.Add(dto);
                    }
                    break;
                case StormDrainType.Area2Hr:
                    for (var i = 0; i < count - 1; i++)
                    {
                        var dto = new PipeDiameterDto()
                        {
                            Diameter = dtos[i + 1].Diameter,
                            Max = dtos[i + 1].Area2Hr,
                            Min = dtos[i].Area2Hr
                        };

                        DiameterDtos.Add(dto);
                    }
                    break;
                case StormDrainType.Area3Hr:
                    for (var i = 0; i < count - 1; i++)
                    {
                        var dto = new PipeDiameterDto()
                        {
                            Diameter = dtos[i + 1].Diameter,
                            Max = dtos[i + 1].Area3Hr,
                            Min = dtos[i].Area3Hr
                        };

                        DiameterDtos.Add(dto);
                    }
                    break;
                default:
                    break;

            }

            foreach (var diaDto in DiameterDtos)
            {
                if (_stormDrainTotalArea > diaDto.Min && _stormDrainTotalArea <= diaDto.Max)
                {
                    _pipeSizeData = diaDto.Diameter;
                    StormDrainPipeSizeLabel.Text = @"PipeSize: ";
                    StormDrainMaxLabel.Text = @"Max Unit: ";
                    StormDrainMaxLabel.Text += diaDto.Max.ToString();
                    StormDrainPipeSizeLabel.Text += _pipeSizeData.ToString();
                }
            }
        }

        private void AutoSetSizeSanitation()
        {
            var dtos = _sanitary.GetListOfPipeDto().ToArray();
            var count = dtos.Count();
            var DiameterDtos = new List<PipeDiameterDto>();

            if (!_isVent)
            {
                for (var i = 0; i < count - 1; i++)
                {
                    var dto = new PipeDiameterDto()
                    {
                        Diameter = dtos[i + 1].Diameter,
                        Max = dtos[i + 1].WasteFixture,
                        Min = dtos[i].WasteFixture
                    };

                    DiameterDtos.Add(dto);
                }
            }
            else
            {
                for (var i = 0; i < count - 1; i++)
                {
                    var dto = new PipeDiameterDto()
                    {
                        Diameter = dtos[i + 1].Diameter,
                        Max = dtos[i + 1].Vent,
                        Min = dtos[i].Vent
                    };

                    DiameterDtos.Add(dto);
                }
            }


            foreach (var diaDto in DiameterDtos)
            {
                if (_fixtureConnection > diaDto.Min && _fixtureConnection <= diaDto.Max)
                {
                    _pipeSizeData = diaDto.Diameter;
                    PipeSizeLabel.Text = @"PipeSize: ";
                    SanitaionMaxUnitLabel.Text = @"Max Unit: ";
                    SanitaionMaxUnitLabel.Text += diaDto.Max.ToString();
                    PipeSizeLabel.Text += _pipeSizeData.ToString();
                }
            }
        }

        private void AutoSetSizeGas()
        {
            int trueIndex = -1;
            GasPipeSizelabel.Text = @"PipeSize: ";
            _pipeSizeForGas = string.Empty;


            for (int i = 0; i < _gasPipeDtos.Count; i++)
            {
                var diaDto = _gasPipeDtos[i];
                GasMaxLabel.Text = "Max Unit: ";
                if (_gasTotalLength > diaDto.Min && _gasTotalLength <= diaDto.Max)
                {
                    trueIndex = i + 1;

                    GasMaxLabel.Text += diaDto.Max;
                    break; 
                }
            }

            if (trueIndex > -1)
            {
                var radius = _isGasLow ? _gasService.DiameterLowList() : _gasService.DiameterMedList();

                var diameter = radius[trueIndex];
                _pipeSizeForGas = diameter;
                GasPipeSizelabel.Text += _pipeSizeForGas;
            }

            if(trueIndex < 0 && _pipeSizeForGas.Length == 0 && GasDataGrid.Rows.Count > 0 && GasLengthComboBox.Text != null && !_isMessageBoxShown)
            {
                MessageBox.Show("Out of Range, Set New Length", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isMessageBoxShown = true;
            }
        }

        private void PipeSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PipeSizeComboBox.SelectedItem != null)
            {
                _temporaryPipeSize = (double)PipeSizeComboBox.SelectedItem;
                var dtos = _sanitary.GetListOfPipeDto().ToArray();
                var pipe = dtos.Where(x => x.Diameter == _temporaryPipeSize).First();
                SanitaionMaxUnitLabel.Text = @"Max Unit: ";
                var maxValue = _isVent ? pipe.Vent : pipe.WasteFixture;
                SanitaionMaxUnitLabel.Text += maxValue.ToString();
                SanitationOverrideBtn.Enabled = maxValue > _fixtureConnection;
            }
        }

        private void UpdateSanitaryText(string id)
        {
            var uiApp = this.UIApp.ActiveUIDocument.Application;
            var uiDoc = uiApp.ActiveUIDocument;
            var doc = uiDoc.Document;

            try
            {
                using (var transaction = new Transaction(doc, "Sanitation Update"))
                {
                    var selectedElementIds = uiDoc.Selection.GetElementIds();
                    transaction.Start();

                    // Create a list to store the detail curves
                    var detailCurves = new List<Element>();

                    var id1 = new ElementId(

                        BuiltInParameter.ALL_MODEL_FAMILY_NAME);

                    var provider = new ParameterValueProvider(id1);
                    var evaluator = new FilterStringEquals();
                    var rule = new FilterStringRule(provider, evaluator, "Arrowhead", false);
                    var filter = new ElementParameterFilter(rule);
                    var collector = new FilteredElementCollector(doc)
                        .OfClass(typeof(ElementType))
                        .WherePasses(filter).Where(x => x.Id.ToString() == "243");

                    var text = string.Empty;
                    var pipeSize = string.Empty;

                    switch (_tabType)
                    {
                        case PipeSumTabType.SanitaryTab:
                            text = _fixtureConnection.ToString();
                            pipeSize = _pipeSizeData.ToString();
                            break;
                        case PipeSumTabType.GasTab:
                            text = _gasTotalLength.ToString();
                            pipeSize = _pipeSizeForGas;
                            break;
                        case PipeSumTabType.StormDrainTab:
                            text = _stormDrainTotalArea.ToString();
                            pipeSize = _pipeSizeData.ToString();
                            break;
                        case PipeSumTabType.WaterTab:
                            text = _waterTotal.ToString();
                            pipeSize = _pipeSizeDataWater.ToString();
                            break;
                        default:
                            break;
                    }

                    if (_elementIds.Count == 0) return;

                    foreach (var elementId in selectedElementIds)
                    {

                        var element = doc.GetElement(elementId) as TextNote;
                        var test = element.Id.ToString();

                        if (id != test) continue;

                        var fixtureString = "(" + text + ")";
                        var newText = pipeSize + fixtureString;
                        element.Text = newText.Replace("(", "\"(");

                        var location = _isOnRight
                            ? TextNoteLeaderTypes.TNLT_STRAIGHT_R
                            : TextNoteLeaderTypes.TNLT_STRAIGHT_L;


                        if (element.LeaderCount == 0 && _hasLeader)
                        {
                            element.AddLeader(location);
                        }
                    }

                    doc.Regenerate();
                    transaction.Commit();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            _isSelect = false;
            _isUpdate = true;
            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        private void SanitationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SanitationComboBox.SelectedItem != null)
            {
                _comboBoxIsSet = true;
                _isVent = SanitationComboBox.SelectedItem.ToString() == "Sanitary Vent";
                selectedSanitationItem = _isVent ? "Sanitary Vent" : "Sanitary";
            }

            AutoSetSizeSanitation();
        }

        private void PipeSumCloseBtn_Click(object sender, EventArgs e)
        {
            _location = null;
            SanitaryReset();
            StormDrainRest();
            GasResetAction();
            WaterReset();
            _elementIds = new List<ElementId>();
            this.Dispose();
        }

        //private void LeftArrowLocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    _isOnRight = false;
        //    _hasLeader = LeftArrowLocation.Checked || RIghtArrowLocation.Checked;
        //}

        //private void RIghtArrowLocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    _isOnRight = true;
        //    _hasLeader = LeftArrowLocation.Checked || RIghtArrowLocation.Checked;
        //}

        private void StormDrainSelectBtn_Click(object sender, EventArgs e)
        {
            _isSelect = true;
            _isUpdate = false;

            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        private void GasSelectBtn_Click(object sender, EventArgs e)
        {   
            _isSelect = true;
            _isUpdate = false;

            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        private void SetStormDrainMaxUnit()
        {
            var dtos = _sanitary.GetListOfPipeDto().ToArray();
            var pipe = dtos.Where(x => x.Diameter == _pipeSizeData).First();
            SanitaionMaxUnitLabel.Text = @"Max Unit: ";
            SanitaionMaxUnitLabel.Text += _isVent ? pipe.Vent.ToString() : pipe.WasteFixture.ToString();
        }

        private void StormDrainRadioBtn1Hr_CheckedChanged(object sender, EventArgs e)
        {
            _stormDrainType = StormDrainType.Area1Hr;
            if (!_isOverride && StormDrainGridView.Rows.Count > 0)
            {
                AutoSetSizeStormDrain();
            }
            else
            {
                SetStormDrainMaxUnit();
            }
        }

        private void StormDrainRadioBtn2Hr_CheckedChanged(object sender, EventArgs e)
        {
            _stormDrainType = StormDrainType.Area2Hr;
            if (!_isOverride && StormDrainGridView.Rows.Count > 0)
            {
                AutoSetSizeStormDrain();
            }
            else
            {
                SetStormDrainMaxUnit();
            }
        }

        private void StormDrainRadioBtn3Hr_CheckedChanged(object sender, EventArgs e)
        {
            _stormDrainType = StormDrainType.Area3Hr;
            if (!_isOverride && StormDrainGridView.Rows.Count > 0) AutoSetSizeStormDrain();

            SetStormDrainMaxLabel();
        }

        private void SetStormDrainMaxLabel()
        {
            var dtos = _stormDrain.GetListOfPipeDto().ToArray();
            var pipe = dtos.Where(x => x.Diameter == _pipeSizeData).First();
            var text = string.Empty;
            switch (_stormDrainType)
            {
                case StormDrainType.Area1Hr:
                    text = pipe.Area1Hr.ToString();
                    break;
                case StormDrainType.Area2Hr:
                    text = pipe.Area2Hr.ToString();
                    break;
                case StormDrainType.Area3Hr:
                    text = pipe.Area3Hr.ToString();
                    break;
                default:
                    break;

            }

            StormDrainMaxLabel.Text = $"Max Unit: {text}";

        }

        private void StormDrainSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StormDrainSizeComboBox.SelectedItem != null)
            {
                _temporaryPipeSize = (double)StormDrainSizeComboBox.SelectedItem;
                var dtos = _stormDrain.GetListOfPipeDto().ToArray();
                var pipe = dtos.Where(x => x.Diameter == _temporaryPipeSize).First();
                StormDrainMaxLabel.Text = @"Max Unit: ";
                var text = 0.0;

                switch (_stormDrainType)
                {
                    case StormDrainType.Area1Hr:
                        text = pipe.Area1Hr;
                        break;
                    case StormDrainType.Area2Hr:
                        text = pipe.Area2Hr;
                        break;
                    case StormDrainType.Area3Hr:
                         text = pipe.Area3Hr;
                        break;
                    default:
                        break;

                }

                StormDrainMaxLabel.Text += text.ToString();

                StormDrainOverrideBtn.Enabled = text > _stormDrainTotalArea;
            }
        }

        private void ApplyClick()
        {
            _isSelect = false;
            _isUpdate = true;
            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        private void StormDrainApplyBtn_Click(object sender, EventArgs e)
        {
            ApplyClick();
        }

        //private void LeftLeaderRadioBtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    _isOnRight = false;
        //    _hasLeader = LeftLeaderRadioBtn.Checked || RightLeaderRadioBtn.Checked;
        //}

        //private void RightLeaderRadioBtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    _isOnRight = true;
        //    _hasLeader = LeftLeaderRadioBtn.Checked || RightLeaderRadioBtn.Checked;
        //}

        private void StormDrainResetBtn_Click(object sender, EventArgs e)
        {
            StormDrainRest();
        }

        private void GasReset_Click(object sender, EventArgs e)
        {
            GasResetAction();
        }

        private void GasResetAction()
        {
            _elementIds = new List<ElementId>();
            _isSelect = true;
            _hasLeader = false;
            _isOverride = false;
            _pipeSizeData = 0;
            _temporaryPipeSize = 0;
            _tempGasLength = 0;
            _isGasLow = true;

            GasTotalLengthLabel.Text = @"Total Length: ";
            GasDataGrid.Rows.Clear();
            GasPipeSizelabel.Text = @"PipeSize: ";
        }

        private void StormDrainRest()
        {
            _elementIds = new List<ElementId>();
            _isSelect = true;
            _hasLeader = false;
            _isOverride = false;
            _pipeSizeData = 0;
            _temporaryPipeSize = 0;
            StormDrainSizeComboBox.Visible = false;

            StormDrainTotalSelectedLabel.Text = @"Total Selected: ";
            StormDrainGridView.Rows.Clear();
            StormDrainMaxLabel.Text = @"Max Unit: ";
            StormDrainPipeSizeLabel.Text = @"PipeSize: ";
            PipeSizeComboBox.SelectedItem = "Select Override Size";
            //LeftLeaderRadioBtn.Checked = false;
            //RightLeaderRadioBtn.Checked = false;
        }

        private void LowPressureGasRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _isGasLow = true;
            _isMessageBoxShown = false;
            ComputeGasPipeSize();
            /*if (GasDataGrid.Rows.Count > 0) AutoSetSizeGas();*/
        }

        private void RadioBtnPressureMed_CheckedChanged(object sender, EventArgs e)
        {
            _isGasLow = false;
            _isMessageBoxShown = false;
            ComputeGasPipeSize();
            /*if (GasDataGrid.Rows.Count > 0) AutoSetSizeGas();*/
        }

        private void ComputeGasPipeSize()
        {
            _gasPipeDtos = new List<PipeDiameterDto>();

            if (GasLengthComboBox.SelectedItem != null)
            {
                var key = (int)GasLengthComboBox.SelectedItem;
                _tempGasLength = GasLengthComboBox.SelectedIndex;

                var list = _isGasLow
                    ? _gasService.GetListOfLowLengthByKey(key)
                    : _gasService.GetListOfMedLengthByKey(key);

                for (var i = 0; i < list.Count - 1; i++)
                {
                    var dto = new PipeDiameterDto()
                    {
                        Max = list[i + 1],
                        Min = list[i]
                    };

                    _gasPipeDtos.Add(dto);
                }

                AutoSetSizeGas();
            }
        }

        private void GasLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isMessageBoxShown = false;
            ComputeGasPipeSize();
        }

        private void GasApplyBtn_Click(object sender, EventArgs e)
        {
            ApplyClick();
        }

        //private void GasLeftLeaderLocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    _isOnRight = false;
        //    _hasLeader = GasRightLeaderLocation.Checked || GasLeftLeaderLocation.Checked;
        //}

        //private void GasRightLeaderLocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    _isOnRight = true;
        //    _hasLeader = GasRightLeaderLocation.Checked || GasLeftLeaderLocation.Checked;
        //}

        private void WaterSelectBtn_Click(object sender, EventArgs e)
        {
            _isSelect = true;
            _isUpdate = false;

            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        private void FlushSettingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlushSettingComboBox.SelectedItem != null)
            {
                _comboBoxFlushIsSet = true;
                _isFlushTank = FlushSettingComboBox.SelectedItem.ToString() == "Flush Tank";
                selectedFlushSetting = _isFlushTank ? "Flush Tank" : "Flush Valve";
            }

            _isMessageBoxShown = false;
            SetWaterPipePressure();
        }

        private void SetWaterPipePressure()
        {
            PsiPerFootComboBox.Items.Clear();

            switch (_waterPipeMaterial)
            {
                case WaterPipeMaterialType.COPPER:
                    var copperData = new List<double>();
                    WaterSystemGroupBox.Enabled = true;

                    if (_isFlushTank)
                    {
                        copperData = _isWaterCold
                            ? _waterService.CopperFlushTankColdKeys()
                            : _waterService.CopperFlushTankHotKeys();
                    }
                    else
                    {
                        copperData = _waterService.CopperFlushValveColdKeys();
                    }


                    foreach (var key in copperData)
                    {
                        PsiPerFootComboBox.Items.Add(key);
                    }

                    break;
                case WaterPipeMaterialType.CPVC:
                    WaterSystemGroupBox.Enabled = false;
                    var dataCpvc = _isFlushTank 
                        ? _waterService.CpvcFlushTankKeys()
                        : _waterService.CpvcFlushValveKeys();

                    foreach (var key in dataCpvc)
                    {
                        PsiPerFootComboBox.Items.Add(key);
                    }


                    break;
                case WaterPipeMaterialType.PEX:
                    WaterSystemGroupBox.Enabled = false;
                    var dataPex = _isFlushTank
                        ? _waterService.PexFlushTankKeys()
                        : _waterService.PexFlushValveKeys();

                    foreach (var key in dataPex)
                    {
                        PsiPerFootComboBox.Items.Add(key);
                    }

                    break;
                default:
                    break;

            }

            if (PsiPerFootComboBox.Items.Count != 0 && PsiPerFootComboBox.SelectedItem == null)
            {
                _isProgrammaticChange = true;
                PsiPerFootComboBox.SelectedItem = _PsiPerFootComboBoxKey;

                _isProgrammaticChange = false;
            }
        }

        private void CopperRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (CopperRadioBtn.Checked)
            {
                _isMessageBoxShown = false;
                _waterPipeMaterial = WaterPipeMaterialType.COPPER;
                _isOverride = false;
                SetWaterPipePressure();
            }
        }

        private void CpvcRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (CpvcRadioBtn.Checked)
            {
                _isMessageBoxShown = false;
                _waterPipeMaterial = WaterPipeMaterialType.CPVC;
                _isOverride = false;
                SetWaterPipePressure();
            }
        }

        private void PexRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (PexRadioBtn.Checked)
            {
                _isMessageBoxShown = false;
                _waterPipeMaterial = WaterPipeMaterialType.PEX;
                _isOverride = false;
                SetWaterPipePressure();
            }
        }

        private void ColdRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ColdRadioBtn.Checked)_isWaterCold = true;
            _isMessageBoxShown = false;

            SetWaterPipePressure();
        }

        private void HotRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (HotRadioBtn.Checked)_isWaterCold = false;
            _isMessageBoxShown = false;

            SetWaterPipePressure();
        }

        private void PsiPerFootComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _waterPipeDtos = new List<PipeDiameterDto>();

            if(!_isProgrammaticChange) _isMessageBoxShown = false;

            PsiPerFootLabel.Text = "PSI/Foot: ";

            if (PsiPerFootComboBox.SelectedItem != null)
            {
                var key = (double)PsiPerFootComboBox.SelectedItem;

                _PsiPerFootComboBoxKey = key;
                PsiPerFootLabel.Text += key.ToString();
                var dtoSource = new List<int>();

                switch (_waterPipeMaterial)
                {
                    case WaterPipeMaterialType.COPPER:
                        if (_isFlushTank)
                        {
                            dtoSource = _isWaterCold
                                ? _waterService.GetListOfCopperFlushTankColdByKey(key)
                                : _waterService.GetListOfCopperFlushTankHotByKey(key);
                        }
                        else
                        {
                            dtoSource = _waterService.GetListOfCopperFlushValveColdByKey(key);
                        }

                        break;
                    case WaterPipeMaterialType.CPVC:
                        dtoSource = _isFlushTank
                            ? _waterService.GetListOfCpvcFlushTankByKey(key)
                            : _waterService.GetListOfCpvcFlushValveByKey(key);

                        break;
                    case WaterPipeMaterialType.PEX:
                        dtoSource = _isFlushTank
                            ? _waterService.GetListPexFlushTankByKey(key)
                            : _waterService.GetListPexFlushValveByKey(key);
                        break;
                    default:
                        break;
                }

                for (var i = 0; i < dtoSource.Count - 1; i++)
                {
                    var dto = new PipeDiameterDto()
                    {
                        Max = dtoSource[i + 1],
                        Min = dtoSource[i]
                    };

                    _waterPipeDtos.Add(dto);
                }
            }


            if (!_isOverride && WaterDataGrid.Rows.Count > 0 && !_isMessageBoxShown) AutoSetSizeWater();
        }

        private void AutoSetSizeWater()
        {
            int trueIndex = -1;
            WaterPipeSizeLabel.Text = @"Pipe Size: ";
            _pipeSizeForWater = string.Empty;


            for (int i = 0; i < _waterPipeDtos.Count; i++)
            {
                var diaDto = _waterPipeDtos[i];
;

                if (_waterTotal > diaDto.Min && _waterTotal <= diaDto.Max)
                {
                    WaterMaxUnit.Text = "Max Unit: ";
                    WaterMaxUnit.Text += diaDto.Max;

                    switch (_waterPipeMaterial)
                    {
                        case WaterPipeMaterialType.COPPER:
                            trueIndex = i+1;

                            break;
                        case WaterPipeMaterialType.CPVC:
                            trueIndex = i+1;

                            break;
                        case WaterPipeMaterialType.PEX:
                            trueIndex = i + 1;
                            break;
                        default:
                            trueIndex = i + 1;
                            break;
                    }

                    //trueIndex = i + 1;


                    //if (trueIndex > _waterPipeDtos.Count-1)
                    //{
                    //    trueIndex = trueIndex - 1;
                    //}

                    break;
                }
            }

            WaterPipeSizeComboBox.Items.Clear();

            if (trueIndex > -1 & !_isOverride)
            {
                var diameters = new List<string>();
                switch (_waterPipeMaterial)
                {
                    case WaterPipeMaterialType.COPPER:
                        diameters = _isFlushTank
                                ? _waterService.DiameterCopperFlushTank()
                                : _waterService.DiameterCopperFlushValve();

                        break;
                    case WaterPipeMaterialType.CPVC:
                        diameters = _isFlushTank
                            ? _waterService.DiameterCpvcFlushTank()
                            : _waterService.DiameterCpvcFlushValve();

                        break;
                    case WaterPipeMaterialType.PEX:
                        diameters = _isFlushTank
                            ? _waterService.DiameterPexFlushTank()
                            : _waterService.DiameterPexFlushValve();
                        break;
                    default:
                        break;  
                }


                foreach (var dia in diameters.Distinct())
                {
                    WaterPipeSizeComboBox.Items.Add(dia);
                }

                var diameter = diameters[trueIndex];
                _pipeSizeDataWater = diameter;
                WaterPipeSizeLabel.Text += _pipeSizeDataWater;
            }

            if (trueIndex < 0 && WaterDataGrid.Rows.Count > 0)
            {
                var lastMaxPsiPerLength = new List<int>();
                switch (_waterPipeMaterial)
                {
                    case WaterPipeMaterialType.COPPER:
                        if (_isFlushTank)
                        {
                            lastMaxPsiPerLength = _isWaterCold
                                ? _waterService.GetListOfCopperFlushTankColdByKey(12.8)
                                : _waterService.GetListOfCopperFlushTankHotByKey(25);
                        }
                        else
                        {
                            lastMaxPsiPerLength = _waterService.GetListOfCopperFlushValveColdByKey(25);
                        }

                        break;
                    case WaterPipeMaterialType.CPVC:
                        lastMaxPsiPerLength = _isFlushTank
                            ? _waterService.GetListOfCpvcFlushTankByKey(13.7)
                            : _waterService.GetListOfCpvcFlushValveByKey(13.7);

                        break;
                    case WaterPipeMaterialType.PEX:
                        lastMaxPsiPerLength = _isFlushTank
                            ? _waterService.GetListPexFlushTankByKey(15)
                            : _waterService.GetListPexFlushValveByKey(15.0);
                        break;
                    default:
                        break;
                }


                if (_waterTotal > lastMaxPsiPerLength.LastOrDefault() && !_isMessageBoxShown)
                {
                    WaterMaxUnit.Text = "Max Unit: ";
                    WaterMaxUnit.Text += lastMaxPsiPerLength.LastOrDefault();
                    _isMessageBoxShown = true;

                    MessageBox.Show("change pipe material, Total Selected out of Range", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                if(trueIndex < 0 && !_isMessageBoxShown)
                {
                    if (_waterPipeDtos.Count > 0)
                    {
                        var max = _waterPipeDtos.LastOrDefault().Max;
                        WaterMaxUnit.Text = "Max Unit: ";
                        WaterMaxUnit.Text += max.ToString();
                    }


                    MessageBox.Show("Total Selected Out of Range, Plese Select Higher Psi/Foot", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _isMessageBoxShown = true;
                }


            }
        }

        private void WaterOverrideBtn_Click(object sender, EventArgs e)
        {
            if ( WaterDataGrid.Rows.Count == 0)
            {
                MessageBox.Show("No Text selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (WaterPipeSizeComboBox.Visible)
            {
                WaterPipeSizeLabel.Text = @"Pipe Size: ";
                _pipeSizeDataWater = _temporaryPipeSizeWater;

                if (_pipeSizeDataWater != string.Empty)
                {
                    WaterPipeSizeLabel.Text += _pipeSizeDataWater.ToString();
                }

                _isOverride = !_isOverride;
            }

            WaterPipeSizeComboBox.Visible = !WaterPipeSizeComboBox.Visible;
        }

        private void WaterPipeSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WaterPipeSizeComboBox.SelectedItem != null)
            {
                _temporaryPipeSizeWater = WaterPipeSizeComboBox.SelectedItem.ToString();
            }
        }

        private void WaterApplyBtn_Click(object sender, EventArgs e)
        {
            _isSelect = false;
            _isUpdate = true;
            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        private void WaterReset()
        {
            WaterDataGrid.Rows.Clear();
            _elementIds = new List<ElementId>();
            _isSelect = true;
            _hasLeader = false;
            _isOverride = false;
            _pipeSizeDataWater = string.Empty;
            _temporaryPipeSizeWater = string.Empty;
            _isWaterCold = true;
            const string totalString = @"Total Selected: ";
            WaterMaxUnit.Text = "Max Unit: ";
            WaterTotalSelectedLabel.Text = totalString;
            WaterPipeSizeComboBox.Items.Clear();
            WaterPipeSizeComboBox.Visible = false;
            _waterTotal = 0;
            _isMessageBoxShown = false;
            _isProgrammaticChange = false;

            PsiPerFootLabel.Text = "PSI/Foot: ";
            WaterPipeSizeLabel.Text = "Pipe Size: ";
        }

        private void WaterRestBtn_Click(object sender, EventArgs e)
        {
            WaterReset();
        }
    }
}
