using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
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
using Control = System.Windows.Forms.Control;
using TextBox = Autodesk.Revit.UI.TextBox;

namespace K2dPlugin.Features.PipeSum.Form
{
    public partial class PipeSumForm : System.Windows.Forms.Form
    {
        public Document Document;
        private UIApplication UIApp;

        private readonly SanitaryService _sanitary = new SanitaryService();
        private readonly TextNoteService _textNote = new TextNoteService();
        private readonly StormDrainService _stormDrain = new StormDrainService();

        private static double _pipeSizeData;
        private static double _fixtureConnection;
        private static bool _isVent;
        private static PipeSumTabType _tabType;
        private static bool _isSelect = true;
        private static bool _isOveride = true;
        private static bool _hasLeader;
        private static bool _isOnRight;
        private static XYZ _location;
        private static bool _comboBoxIsSet = false;
        private static string selectedSanitationItem;
        //set const text here next time

        public PipeSumForm(Document document, UIApplication uiApp)
        {
            InitializeComponent();
            this.UIApp = uiApp;
            this.Show();
            this.KeyPreview = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular);
            this.Padding = new Padding(5);

            Document = document;
            this.UIApp = uiApp;

            if (SanitationComboBox.Items.Count == 0)
            {
                SanitationComboBox.Items.Add("Sanitary");
                SanitationComboBox.Items.Add("Sanitary Vent");
            }

            SanitationComboBox.SelectedItem = _comboBoxIsSet ? selectedSanitationItem : "Select Pipe System";

            SanitationGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            SanitationGridView.ReadOnly = true;

        }

        private void PipeSum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PipeSumForm_Load(object sender, EventArgs e)
        {
            var sizes = _sanitary.GetPipeSizes();
            var sizesWithoutFirstTwo = sizes.Skip(2).ToList();

            if (_isSelect)
            {
                if (SanitationComboBox.SelectedItem != null)
                {
                    SanitationComboBox.SelectedIndex = 0;
                }

                foreach (var size in sizesWithoutFirstTwo)
                {
                    PipeSizeComboBox.Items.Add(size);
                }

                switch (PipeSumTab.SelectedTab.TabIndex)
                {
                    case (int)PipeSumTabType.SanitaryTab:
                        PopulateSanitationFormData();
                        if (!_isOveride) AutoSetSizeSanitation();
                        _tabType = PipeSumTabType.SanitaryTab;
                        break;
                    case (int)PipeSumTabType.WaterTab:
                        _tabType = PipeSumTabType.WaterTab;
                        break;
                    case (int)PipeSumTabType.GasTab:
                        _tabType = PipeSumTabType.GasTab;
                        break;
                    case (int)PipeSumTabType.StormDrainTab:
                        _tabType = PipeSumTabType.StormDrainTab;
                        break;
                    default:
                        break;
                }
                /*PopulateSanitationFormData();
                AutoSetSizeSanitation();*/
            }
            else
            {

                var forUpdate = GetSelectedDataFromRevit();

                if (forUpdate.Any()) UpdateSanitaryText(forUpdate.FirstOrDefault().Id);

                this.BringToFront();
            }


            if (!_isOveride) AutoSetSizeSanitation();

            if (_location != null)
            {
                this.Location = new System.Drawing.Point((int)_location.X, (int)_location.Y);
            }
        }


        /*private void PipeSumForm_MouseClick(object sender, MouseEventArgs e)
        {

            var uiApp = this.UIApp.ActiveUIDocument.Application;
            var uiDoc = uiApp.ActiveUIDocument;
            var doc = uiDoc.Document;

            var loc = e.Location;

            var revitLoc = new XYZ(loc.X, loc.Y, 0.0);

            using (var transaction = new Transaction(doc, "Add Text"))
            {
                transaction.Start();

                var textNoteType = new FilteredElementCollector(doc)
                    .OfClass(typeof(TextNoteType))
                    .Cast<TextNoteType>()
                    .FirstOrDefault();

                var fixtureString = "\"(" + _fixtureConnection + ")";
                var text = _pipeSizeData + fixtureString;
                var textNote = TextNote.Create(doc, doc.ActiveView.Id, revitLoc, text, textNoteType.Id);

                textNote.AddLeader(TextNoteLeaderTypes.TNLT_STRAIGHT_L);
                textNote.LeaderLeftAttachment = LeaderAtachement.TopLine;
                var leader = textNote.GetLeaders().FirstOrDefault();

                doc.Regenerate();

                transaction.Commit();
            }
        }*/

        private void SanitationSelectTxtBtn_Click(object sender, EventArgs e)
        {
            if(!_isSelect) _isSelect = !_isSelect;

            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }

        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_isSelect)
            {
                if (keyData != Keys.Enter) return false;

                PopulateFormData();
                AutoSetSizeSanitation();
                this.Show();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }*/

        private void PopulateSanitationFormData()
        {
            SanitationGridView.Rows.Clear();
            const string totalString = @"Total Selected: ";
            SanitationTotalSelectedLabel.Text = totalString;
            var selectedPipes = GetSelectedDataFromRevit();

            foreach (var pipe in selectedPipes)
            {
                SanitationGridView.Rows.Add(pipe.Id, pipe.Count, pipe.PipeSize + '"', pipe.Unit);
            }

            var total = selectedPipes.Sum(x => x.Unit);
            FixtureConnectionBox.Text = total.ToString();
            _fixtureConnection = total;
            SanitationTotalSelectedLabel.Text += total.ToString();
        }

        private IEnumerable<Pipe> GetSelectedDataFromRevit()
        {
            var doc = this.UIApp.ActiveUIDocument.Document;
            var pipeList = new List<Pipe>();
            var count = 1;
            //create a Pipe from the selected element
            foreach (var elementId in this.UIApp.ActiveUIDocument.Selection.GetElementIds())
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
            _isSelect = true;
            SanitationTotalSelectedLabel.Text = @"Total Selected: ";
            SanitationGridView.Rows.Clear();
            SanitaionMaxUnitLabel.Text = @"Max Unit: ";
            PipeSizeLabel.Text = @"PipeSize: ";
            PipeSizeComboBox.SelectedItem = "Select Override Size";
            SanitationComboBox.SelectedItem = "Select Pipe System";
            LeftArrowLocation.Checked = false;
            RIghtArrowLocation.Checked = false;
        }

        private void SanitationOverrideBtn_Click(object sender, EventArgs e)
        {
            PipeSizeLabel.Text = @"PipeSize: ";
            PipeSizeLabel.Text += _pipeSizeData.ToString();
            _isOveride = true;

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
                if (_fixtureConnection > diaDto.Min && _fixtureConnection < diaDto.Max)
                {
                    _pipeSizeData = diaDto.Diameter;
                    PipeSizeLabel.Text = @"PipeSize: ";
                    SanitaionMaxUnitLabel.Text = @"Max Unit: ";
                    SanitaionMaxUnitLabel.Text += diaDto.Max.ToString();
                    PipeSizeLabel.Text += _pipeSizeData.ToString();
                }
            }
        }

        private void PipeSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PipeSizeComboBox.SelectedItem != null)
            {
                _pipeSizeData = (double)PipeSizeComboBox.SelectedItem;
                var dtos = _sanitary.GetListOfPipeDto().ToArray();
                var pipe = dtos.Where(x => x.Diameter == _pipeSizeData).First();
                SanitaionMaxUnitLabel.Text = @"Max Unit: ";
                SanitaionMaxUnitLabel.Text += _isVent ? pipe.Vent.ToString() : pipe.WasteFixture.ToString();

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


                    foreach (var elementId in selectedElementIds)
                    {
                        var element = doc.GetElement(elementId) as TextNote;
                        var test = element.Id.ToString();

                        if (id != test) continue;

                        var fixtureString = "(" + _fixtureConnection + ")";
                        var newText = _pipeSizeData + fixtureString;
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
            _isSelect = !_isSelect;
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
            this.Dispose();
        }

        private void LeftArrowLocation_CheckedChanged(object sender, EventArgs e)
        {
            _isOnRight = false;
            _hasLeader = LeftArrowLocation.Checked || RIghtArrowLocation.Checked;
        }

        private void RIghtArrowLocation_CheckedChanged(object sender, EventArgs e)
        {
            _isOnRight = true;
            _hasLeader = LeftArrowLocation.Checked || RIghtArrowLocation.Checked;
        }

        private void StormDrainSelectBtn_Click(object sender, EventArgs e)
        {
            var shit = _stormDrain.GetListOfPipeDto();
            _isSelect = true;
            this.Hide();
            var location = this.Location;
            _location = new XYZ(location.X, location.Y, 0);
        }
    }
}
