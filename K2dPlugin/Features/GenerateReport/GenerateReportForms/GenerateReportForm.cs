using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System;
using System.Linq;
using System.Windows.Forms;
using K2dPlugin.Features.GenerateReport.Handlers;
using System.Diagnostics;
using K2dPlugin.Features.GenerateReport.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using K2dPlugin.Services;
using View = Autodesk.Revit.DB.View;
using System.Windows.Controls;
using K2dPlugin.Features.PipeSum;
using System.Windows.Markup;
using Autodesk.Revit.DB.Plumbing;
using System.Xml.Linq;
using TextBox = System.Windows.Forms.TextBox;

namespace K2dPlugin.Features.GenerateReport.GenerateReportForms
{
    public partial class Test : System.Windows.Forms.Form
    {
        private readonly ExternalCommandData _commandData;
        private readonly Document _document;
        private readonly UIApplication _uiApp;
        private readonly ExternalEvent _externalEventSheet;
        private readonly ExternalEvent _externalEventTextNoteType;
        private readonly ExternalEvent _externalEventLegend;
        private readonly ExternalEvent _externalEventDeleteTextNote;
        private readonly ExternalEvent _externalCreateWaterDemandLegend;
        private readonly ExternalEvent _externalEventCreateLineLegend;
        private readonly ExternalEvent _externalEventCreateCopperType;
        private readonly ExternalEvent _externalEventCreateCpvc;
        private readonly ExternalEvent _externalEventCreatePex;
        private readonly ExternalEvent _externalEventCopperLinEvent;
        private readonly ExternalEvent _externalEventCpvcLineEvent;
        private readonly ExternalEvent _externalEventPexLineEvent;

        private readonly CreateLegendHandler _createLegendHandler = new CreateLegendHandler();
        private readonly DeleteAllTextNoteHandler _deleteAllTextNoteHandler = new DeleteAllTextNoteHandler();
        private readonly CreateWaterDemandLegendHandler _createWaterDemandLegendHandler = new CreateWaterDemandLegendHandler();
        private readonly CreateLineLegendHandler _createLineLegendHandler = new CreateLineLegendHandler();
        private readonly CreateCopperTypeHandler _createCopperTypeHandler = new CreateCopperTypeHandler();
        private readonly CreateCpvcHandler _createCpvcHandler = new CreateCpvcHandler();
        private readonly CreatePexHandler _createPexHandler = new CreatePexHandler();

        //Lines
        private readonly CreateLineCopperHandler _createLineCopper = new CreateLineCopperHandler();
        private readonly CreateLineCpvcHandler _createLineCpvc = new CreateLineCpvcHandler();
        private readonly CreateLinePexHandler _createLinePex = new CreateLinePexHandler();

        private readonly FixtureUnitGpmService _fixtureUnitGpmService = new FixtureUnitGpmService();
        private readonly WaterInputSizeLossService _waterInputSizeLossService = new WaterInputSizeLossService();
        private double _totalFixtureUnit = 0;
        private readonly WaterDemandTotalDto _waterDemandTotalDto = new WaterDemandTotalDto();
        private readonly PipeVelocityService _pipeVelocityService = new PipeVelocityService();

        private readonly WaterService _waterService = new WaterService();

        private static readonly List<string> PlumbingFixtures = new List<string>()
        {
            "BATHTUB/SHOWER",
            "SHOWER",
            "CLOTH WASHER",
            "KITCHEN SINK",
            "DISHWASHER",
            "LAVATORY",
            "W.C (GRAVITY TANK)",
            "W.C (FLUSH VALVE)",
            "LANDRY SINK",
            "BIDET",
            "URINAL",
            "SAUNA/STEAM SHOWER",
            "OTHER SINK",
            "BAR SINK",
            "REF",
            "ICE MAKER",
            "SERVICE SINK",
            "HOSE BIBB",
            "HOSE BIBB (EACH ADDITIONAL)",
        };

        private static readonly Dictionary<Tuple<double, double, double>, string> WaterDictionary =
            new Dictionary<Tuple<double, double, double>, string>()
            {
                {Tuple.Create(56.633092215, 28.117881684, 0.000000000), "OtherWaterRequiredFu" },
                {Tuple.Create(56.633092215, 25.098087543, 0.000000000), "ExistWaterRequiredFu" },

            };

        private static readonly Dictionary<Tuple<double, double, double>, string> LocationDictionary =
            new Dictionary<Tuple<double, double, double>, string>()
            {
                {Tuple.Create(14.205878046, 17.709455405, 0.000000000), "SystemType" },
                {Tuple.Create(14.205878046, 14.222991206, 0.000000000),"SystemLoss"},
                {Tuple.Create(14.205878046, 6.881313079, 0.000000000),"TotalFixtureUnit"},

                {Tuple.Create(16.318766543, -10.964445992, 0.000000000), "PressureCityHigh"},
                {Tuple.Create(39.054539070, -10.964445992, 0.000000000), "PressureCityLow"},
                {Tuple.Create(62.918348067, -10.964445992, 0.000000000), "CityElevation"},

                {Tuple.Create(16.318766543, -21.611544582, 0.000000000), "PressurePropertyHigh"},
                {Tuple.Create(39.054539070, -21.611544582, 0.000000000), "PressurePropertyLow"},
                {Tuple.Create(62.918348067, -21.611544582, 0.000000000), "PropertyElevation"},

                {Tuple.Create(19.886309440, -31.620525593, 0.000000000), "WaterMeterSize"},

                {Tuple.Create(35.886309440, -31.620525593, 0.000000000), "ConvertedFuToGpm"},
                {Tuple.Create(54.386309440, -31.620525593, 0.000000000), "WaterMeterSizeLoss"},

                {Tuple.Create(22.958130739, -40.620525593, 0.000000000), "MakeModelGpm"},
                {Tuple.Create(22.958130739, -43.620525593, 0.000000000), "MakeModel"},

                {Tuple.Create(54.386309440, -40.620525593, 0.000000000), "SubMeterFrictionLoss"},
                {Tuple.Create(54.386309440, -43.620525593, 0.000000000), "FiltrationFrictionLoss"},
                {Tuple.Create(54.386309440, -46.620525593, 0.000000000), "RequiredFixturePressure"},

                {Tuple.Create(22.958130739, -49.870525593, 0.000000000), "BuildingHeight"},
                {Tuple.Create(22.958130739, -52.787192259, 0.000000000), "MakeAndModelTmv"},

                {Tuple.Create(54.386309440, -52.870525593, 0.000000000), "PressureLossTmv"},
                {Tuple.Create(3.512201542, -67.496738569, 0.000000000), "DevelopedPipeLength"},

                {Tuple.Create(57.678858162, 10.511576975, 0.000000000),"SarDate"},
                {Tuple.Create(57.678858162, 6.881313079, 0.000000000),"Source"},
                {Tuple.Create(57.678858162, 3.023793927, 0.000000000),"ContactInfo"},
                {Tuple.Create(54.386309440, -67.748299524, 0.000000000),"ManualPsi"}

            };

        public readonly Dictionary<string, WaterDemandDto> WaterDemandDictionary =
            new Dictionary<string, WaterDemandDto>()
            {
                {"BathTubShower" , new WaterDemandDto()},
                {"Shower" , new WaterDemandDto()},
                {"ClothWasher" , new WaterDemandDto()},
                {"KitchenSink" , new WaterDemandDto()},
                {"Dishwasher" , new WaterDemandDto()},
                {"Lavatory" , new WaterDemandDto()},
                {"GravityTank" , new WaterDemandDto()},
                {"FlushValve" , new WaterDemandDto()},
                {"LaundrySink" , new WaterDemandDto()},
                {"Bidet" , new WaterDemandDto()},
                {"Urinal" , new WaterDemandDto()},
                {"SaunaSteamShower" , new WaterDemandDto()},
                {"OtherSink" , new WaterDemandDto()},
                {"BarSink" , new WaterDemandDto()},
                {"Ref" , new WaterDemandDto()},
                {"IceMaker" , new WaterDemandDto()},
                {"ServiceSink" , new WaterDemandDto()},
                {"HoseBibb" , new WaterDemandDto()},
                {"HoseBibbAdd" , new WaterDemandDto()},

            };

        private static readonly List<PlumbingFixtureDto> PlumbingFixturesList = new List<PlumbingFixtureDto>()
        {
            new PlumbingFixtureDto(){Name = "BATHTUB/SHOWER", PrivateMultiplier = 4, PublicMultiplier = 4, key ="BathTubShower" },
            new PlumbingFixtureDto(){Name = "SHOWER", PrivateMultiplier = 4, PublicMultiplier = 4, key = "Shower"},
            new PlumbingFixtureDto(){Name = "CLOTH WASHER", PrivateMultiplier = 4, PublicMultiplier = 4, key = "ClothWasher"},
            new PlumbingFixtureDto(){Name = "KITCHEN SINK", PrivateMultiplier = 1.5, PublicMultiplier = 1.5, key = "KitchenSink"},
            new PlumbingFixtureDto(){Name = "DISHWASHER", PrivateMultiplier = 1.5, PublicMultiplier = 1.5, key = "Dishwasher"},
            new PlumbingFixtureDto(){Name = "LAVATORY", PrivateMultiplier = 1, PublicMultiplier = 1, key = "Lavatory"},
            new PlumbingFixtureDto(){Name = "W.C (GRAVITY TANK)", PrivateMultiplier = 2.5, PublicMultiplier = 2.5, key = "GravityTank"},
            new PlumbingFixtureDto(){Name = "W.C (FLUSH VALVE)", PrivateMultiplier = 5, PublicMultiplier = 5, key = "FlushValve"},
            new PlumbingFixtureDto(){Name = "LAUNDRY SINK", PrivateMultiplier = 1.5, PublicMultiplier = 1.5, key = "LaundrySink"},
            new PlumbingFixtureDto(){Name = "BIDET", PrivateMultiplier = 1, PublicMultiplier = 1, key = "Bidet"},
            new PlumbingFixtureDto(){Name = "URINAL", PrivateMultiplier = 3, PublicMultiplier = 4, key = "Urinal"},
            new PlumbingFixtureDto(){Name = "SAUNA/STEAM SHOWER", PrivateMultiplier = 2, PublicMultiplier = 2, key = "SaunaSteamShower"},
            new PlumbingFixtureDto(){Name = "OTHER SINK", PrivateMultiplier = 2, PublicMultiplier = 2, key = "OtherSink"},
            new PlumbingFixtureDto(){Name = "BAR SINK", PrivateMultiplier = 1.5, PublicMultiplier = 1.5, key = "BarSink"},
            new PlumbingFixtureDto(){Name = "REF", PrivateMultiplier = 0.5, PublicMultiplier = 0.5, key = "Ref"},
            new PlumbingFixtureDto(){Name = "ICE MAKER", PrivateMultiplier = 0.5, PublicMultiplier = 0.5, key = "IceMaker"},
            new PlumbingFixtureDto(){Name = "SERVICE SINK", PrivateMultiplier = 3, PublicMultiplier = 3, key = "ServiceSink"},
            new PlumbingFixtureDto(){Name = "HOSE BIBB", PrivateMultiplier = 2.5, PublicMultiplier = 2.5, key = "HoseBibb"},
            new PlumbingFixtureDto(){Name = "HOSE BIBB (EACH ADDITIONAL)", PrivateMultiplier = 1, PublicMultiplier = 1, key = "HoseBibbAdd"}
        };



        public Test(ExternalCommandData commandData, Document document, UIApplication uiApp)
        {
            InitializeComponent();
            _commandData = commandData;
            _document = document;
            _uiApp = uiApp;

            PopulateDataGrid();


            var typeOfSystem = new List<string>()
            {
                "Flush Tank",
                "Flush Valve"
            };

            var systemLoss = new List<string>()
            {
                "Copper Type L",
                "Copper Type K",
                "Copper Type M",
                "CPVC",
                "PEX"
            };

            var diameters = _waterInputSizeLossService.GetDiameters();

            foreach (var dia in diameters)
            {
                this.SizeOfWaterMeter.Items.Add($"{dia}\"");
            }

            foreach (string system in typeOfSystem)
            {
                SystemTypeCombo.Items.Add(system);
            }

            foreach (var loss in systemLoss)
            {
                SystemLossCombo.Items.Add(loss);
            }



            var noteTypeList = new List<TextNoteDto>()
            {
                new TextNoteDto() { Name = "headerText", Size = 0.3 }
            };

            var createSheetHandler = new CreateSheetHandler(document);


            _externalEventSheet = ExternalEvent.Create(createSheetHandler);
            _externalEventLegend = ExternalEvent.Create(_createLegendHandler);
            _externalEventDeleteTextNote = ExternalEvent.Create(_deleteAllTextNoteHandler);
            _externalCreateWaterDemandLegend = ExternalEvent.Create(_createWaterDemandLegendHandler);
            _externalEventCreateLineLegend = ExternalEvent.Create(_createLineLegendHandler);
            _externalEventCreateCopperType = ExternalEvent.Create(_createCopperTypeHandler);
            _externalEventCreateCpvc = ExternalEvent.Create(_createCpvcHandler);
            _externalEventCreatePex = ExternalEvent.Create(_createPexHandler);

            //lines
            _externalEventCopperLinEvent = ExternalEvent.Create(_createLineCopper);
            _externalEventCpvcLineEvent = ExternalEvent.Create(_createLineCpvc);
            _externalEventPexLineEvent = ExternalEvent.Create(_createLinePex);

            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element,false);
                PopulateWaterDemandUpdate();
        }

        private Element GetLegendView(string viewName)
        {
            try
            {
                var waterCalculationLegend = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document)
                    .OfClass(typeof(View)).ToElements();

                foreach (Element element in waterCalculationLegend)
                {
                    if (element.Name == viewName)
                    {
                        return element;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

        private void PopulateWaterDemandUpdate()
        {
            var element = GetLegendView("Water Demand");
            var updateDto = new WaterDemandTotalDto();

            var textNotes = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, element.Id)
                .OfClass(typeof(TextNote))
                .Cast<TextNote>()
                .ToList();

            foreach (var textNote in textNotes)
            {
                var textCoordinate = textNote.Coord;
                var coordinateTuple = Tuple.Create(textCoordinate.X, textCoordinate.Y, textCoordinate.Z);
                var isAValueText = WaterDictionary.TryGetValue(coordinateTuple, out string propName);


                if (isAValueText)
                {
                    // Use reflection to set the property dynamically
                    var propertyInfo = typeof(WaterDemandTotalDto).GetProperty(propName);



                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        bool conversionSuccess = false;

                        if (propertyInfo.PropertyType == typeof(double))
                        {
                            string filteredText;


                            filteredText = textNote.Text.Replace("\"", "").Replace("\r", "");
                            conversionSuccess = double.TryParse(filteredText, out double doubleValue);

                            propertyInfo.SetValue(updateDto, doubleValue);
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            var cleanText = textNote.Text.Replace("\r", "");

                            propertyInfo.SetValue(updateDto, cleanText);
                            conversionSuccess = true;
                        }
                    }
                }
            }

            this.OtherWaterReq.Text = updateDto.OtherWaterRequiredFu.ToString();
            this.ExustWaterReq.Text = updateDto.ExistWaterRequiredFu.ToString();
        }


        private void PopulateFormForUpdateDto(Element element, bool isUpdate)
        {
            try
            {
                var updateDto = new GenerateReportFormDto();

                var textNotes = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, element.Id)
                    .OfClass(typeof(TextNote))
                    .Cast<TextNote>()
                    .ToList();

                foreach (var textNote in textNotes)
                {
                    var textCoord = textNote.Coord;


                    var coordTuple = Tuple.Create(textCoord.X, textCoord.Y, textCoord.Z);

                    var isAValueText = LocationDictionary.TryGetValue(coordTuple, out string propName);

                    if (isAValueText)
                    {
                        // Use reflection to set the property dynamically
                        var propertyInfo = typeof(GenerateReportFormDto).GetProperty(propName);

                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            bool conversionSuccess = false;

                            if (propertyInfo.PropertyType == typeof(double))
                            {
                                string filteredText;


                                filteredText = textNote.Text.Replace("\"", "").Replace("\r", "");
                                conversionSuccess = double.TryParse(filteredText, out double doubleValue);

                                propertyInfo.SetValue(updateDto, doubleValue);
                            }
                            else if (propertyInfo.PropertyType == typeof(string))
                            {
                                var cleanText = textNote.Text.Replace("\r", "");

                                propertyInfo.SetValue(updateDto, cleanText);
                                conversionSuccess = true;
                            }
                        }
                    }
                }

                if (!isUpdate)
                {
                    SizeOfWaterMeter.Text = updateDto.WaterMeterSize != null
                        ? $"{updateDto.WaterMeterSize}\""
                        : string.Empty;
                    PropertyLow.Text = updateDto.PressurePropertyLow != null
                        ? updateDto.PressurePropertyLow.ToString()
                        : string.Empty;
                    BuildingHeight.Text = updateDto.BuildingHeight != null
                        ? updateDto.BuildingHeight.ToString()
                        : string.Empty;
                    FrictionLossSubMeter.Text = updateDto.SubMeterFrictionLoss != null
                        ? updateDto.SubMeterFrictionLoss.ToString()
                        : string.Empty;
                    FrictionLossFiltration.Text = updateDto.FiltrationFrictionLoss != null
                        ? updateDto.FiltrationFrictionLoss.ToString()
                        : string.Empty;
                    RequiredPressureFixture.Text = updateDto.RequiredFixturePressure != null
                        ? updateDto.RequiredFixturePressure.ToString()
                        : string.Empty;
                    PressureLossTmv.Text = updateDto.PressureLossTmv != null
                        ? updateDto.PressureLossTmv.ToString()
                        : string.Empty;
                    DevelopPipeLength.Text = updateDto.DevelopedPipeLength != null
                        ? updateDto.DevelopedPipeLength.ToString()
                        : string.Empty;

                    CityLow.Text = updateDto.PressurePropertyLow != null
                        ? updateDto.PressureCityLow.ToString()
                        : string.Empty; 
                    SystemTypeCombo.Text = updateDto.SystemType;
                    SystemLossCombo.Text = updateDto.SystemLoss;
                    CityHigh.Text = updateDto.PressureCityHigh != null
                        ? updateDto.PressureCityHigh.ToString()
                        : string.Empty;

                    CityElevation.Text = updateDto.CityElevation != null
                        ? updateDto.CityElevation.ToString() : string.Empty;
                    PropertyHigh.Text = updateDto.PressurePropertyHigh != null
                        ? updateDto.PressurePropertyHigh.ToString()
                        : string.Empty;

                    PropertyElevation.Text = updateDto.PropertyElevation != null
                        ? updateDto.PropertyElevation.ToString() : string.Empty;

                    Psi100Ft.Text = updateDto.ManualPsi.ToString();

                    SarDate.Text = updateDto.SarDate;
                    Source.Text = updateDto.Source;
                    ContactInfo.Text = updateDto.ContactInfo;

                    MakeModelTmv.Text = updateDto.MakeAndModelTmv;
                    MakeModelGpm.Text = updateDto.MakeModelGpm;
                    MakeMode.Text = updateDto.MakeModel;
                }



                var size = SizeOfWaterMeter.Text != ""
                    ? Convert.ToDouble(SizeOfWaterMeter.Text.Replace("\"", "")) : 0;

                var waterInputLoss =  size != 0 ? _waterInputSizeLossService.GetLossByDiameter(Convert.ToDouble(size)) : 0;
                var propLow = this.PropertyLow.Text != "" ? Convert.ToDouble(this.PropertyLow.Text) : 0;

                var convertedValue = BuildingHeight.Text != "" ? Convert.ToDouble(this.BuildingHeight.Text) * 0.43 : 0;
                var availablePressure = propLow - waterInputLoss;
                var test1 = FrictionLossSubMeter.Text != "" ? Convert.ToDouble(this.FrictionLossSubMeter.Text) : 0;
                var test2 = FrictionLossFiltration.Text != "" ? Convert.ToDouble(this.FrictionLossFiltration.Text) : 0;
                var test3 = RequiredPressureFixture.Text != ""
                    ? Convert.ToDouble(this.RequiredPressureFixture.Text)
                    : 0;
                var test4 = PressureLossTmv.Text != "" ? Convert.ToDouble(this.PressureLossTmv.Text) : 0;

                var totalLoss =
                    test1
                    + test2
                    + test3
                    + convertedValue
                    + test4;


                var divisor = DevelopPipeLength.Text != "" ? Convert.ToDouble(this.DevelopPipeLength.Text) * 1.25 :0;
                var convertedAvailablePressureForFrictionLoss =
                    (availablePressure - totalLoss) / divisor;

                var test = Math.Round(convertedAvailablePressureForFrictionLoss * 100, 1);

                this.Psi100FtCacl.Text = test.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void PopulateDataGrid()
        {
            try
            {
                _totalFixtureUnit = 0;
                var components =
                    new FilteredElementCollector(_uiApp.ActiveUIDocument.Document)
                        .OfCategory(BuiltInCategory.OST_PlumbingFixtures)
                        .WhereElementIsNotElementType()
                        .ToElements()
                        .GroupBy(x =>
                        {
                            var paramName = "Unknown";
                            var isPrivateValue = false;
                            var plumbingFixtureName = GetFamilyPropertyValue("Plumbing Fixture", x);


                            foreach (Parameter param in x.Parameters)
                            {
                                if (param.Definition.ParameterGroup != BuiltInParameterGroup.PG_IDENTITY_DATA) continue;

                                var privateParamName = param.Definition.Name;

                                if (privateParamName == "Is Private")
                                {
                                    isPrivateValue = param.AsValueString() == "Yes";
                                }
                            }

                            return (PlumbingFixture: plumbingFixtureName, IsPrivate: isPrivateValue);
                        });

                var dictionary = new Dictionary<(string, bool), int>();

                foreach (var group in components)
                {
                    var plumbingFixtureName = group.Key.PlumbingFixture;
                    var isPrivateValue = group.Key.IsPrivate;
                    var groupCount = group.Count();

                    dictionary.Add((plumbingFixtureName, isPrivateValue), groupCount);
                }


                foreach (var fixture in PlumbingFixturesList)
                {
                    var isFixture = WaterDemandDictionary.TryGetValue(fixture.key, out var dto);

                    var hasFalseValue = dictionary.TryGetValue((fixture.Name, false), out int falseValue);
                    var hasTrueValue = dictionary.TryGetValue((fixture.Name, true), out int trueValue);

                    var productIsPrivate = trueValue * fixture.PrivateMultiplier;
                    var productNotIsPrivate = falseValue * fixture.PublicMultiplier;
                    var totalQuantity = falseValue + trueValue;
                    var totalFu = productIsPrivate + productNotIsPrivate;
                    _totalFixtureUnit += totalFu;

                    if (isFixture && (productIsPrivate > 0 || productNotIsPrivate > 0))
                    {
                        WaterDemandDictionary[fixture.key] = new WaterDemandDto()
                        {
                            Total = totalFu,
                            Private = trueValue,
                            Public = falseValue
                        };
                    }

                    DataGridComponentCount.Rows.Add(fixture.Name, totalQuantity, fixture.PrivateMultiplier, fixture.PublicMultiplier, trueValue, falseValue, totalFu);
                }
                _waterDemandTotalDto.FixtureUnitTotal = _totalFixtureUnit;
                this.TotalFixtureUnit.Text = _totalFixtureUnit.ToString();

                var convertedFuToGpm = ConvertFuToGpm(_totalFixtureUnit);
                this.ConvertedFuToGpm.Text = convertedFuToGpm.ToString();
                _waterDemandTotalDto.FixtureUnitTotalGpm = convertedFuToGpm;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SystemTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var convertedFuToGpm = ConvertFuToGpm(_totalFixtureUnit);
                this.ConvertedFuToGpm.Text = convertedFuToGpm.ToString();
                _waterDemandTotalDto.FixtureUnitTotalGpm = convertedFuToGpm;

                var otherWaterRq = this.OtherWaterReq.Text != "" ? Convert.ToDouble(this.OtherWaterReq.Text) : 0;
                var otherWaterReqConvertedFuToGpm = ConvertFuToGpm(otherWaterRq);
                this.OtherWaterReq.Text = otherWaterReqConvertedFuToGpm.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private string GetFamilyPropertyValue(string propertyName, Element element)
        {
            try
            {
                var familySymbol = _document.GetElement(element.GetTypeId()) as FamilySymbol;

                if (familySymbol == null) return null;

                foreach (Parameter param in familySymbol.Parameters)
                {
                    if (param.Definition.ParameterGroup != BuiltInParameterGroup.PG_IDENTITY_DATA) continue;

                    if (PlumbingFixtures.Contains(param.Definition.Name) & param.AsValueString() == "Yes")
                    {
                        return param.Definition.Name;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return "Unknown";
        }

        private void GenerateBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                _externalEventSheet.Raise();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ChangePropertyPressure()
        {
            //try
            //{
            //    var cityHigh = this.CityHigh.Text != "" ? Convert.ToDouble(this.CityHigh.Text) : 0;
            //    var cityLow = this.CityLow.Text != "" ? Convert.ToDouble(this.CityLow.Text) : 0;
            //    var cityElevation = this.CityElevation.Text != "" ? Convert.ToDouble(this.CityElevation.Text) : 0;
            //    var propElevation = this.PropertyElevation.Text != "" ? Convert.ToDouble(this.PropertyElevation.Text) : 0;

            //    //Computation For property Pressure

            //    var propHigh = (cityElevation != 0 || propElevation != 0)
            //        ? cityHigh - (propElevation - cityElevation) * (0.434)
            //        : cityHigh;

            //    var propLow = (cityElevation != 0 || propElevation != 0)
            //        ? cityLow - (propElevation - cityElevation) * (0.434)
            //        : cityLow;

            //    this.PropertyHigh.Text = propHigh.ToString();
            //    this.PropertyLow.Text = propLow.ToString();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            try
            {
                // Parse cityHigh
                double cityHigh = 0;
                if (!string.IsNullOrWhiteSpace(this.CityHigh.Text))
                {
                    double.TryParse(this.CityHigh.Text, out cityHigh);
                }

                // Parse cityLow
                double cityLow = 0;
                if (!string.IsNullOrWhiteSpace(this.CityLow.Text))
                {
                    double.TryParse(this.CityLow.Text, out cityLow);
                }

                // Parse cityElevation
                double cityElevation = 0;
                if (!string.IsNullOrWhiteSpace(this.CityElevation.Text))
                {
                    double.TryParse(this.CityElevation.Text, out cityElevation);
                }

                // Parse propertyElevation
                double propElevation = 0;
                if (!string.IsNullOrWhiteSpace(this.PropertyElevation.Text))
                {
                    double.TryParse(this.PropertyElevation.Text, out propElevation);
                }

                // Computation for property pressure
                var propHigh = (cityElevation != 0 || propElevation != 0)
                    ? cityHigh - (propElevation - cityElevation) * 0.434
                    : cityHigh;

                var propLow = (cityElevation != 0 || propElevation != 0)
                    ? cityLow - (propElevation - cityElevation) * 0.434
                    : cityLow;

                this.PropertyHigh.Text = propHigh.ToString();
                this.PropertyLow.Text = propLow.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        private void CreateLegend()
        {
            try
            {
                var size = this.SizeOfWaterMeter.Text != "" 
                    ? Convert.ToDouble(this.SizeOfWaterMeter.Text.Replace("\"", "")) : 0;
                var waterInputLoss = _waterInputSizeLossService.GetLossByDiameter(Convert.ToDouble(size));
                var cityHigh = this.CityHigh.Text != "" ? Convert.ToDouble(this.CityHigh.Text) : 0;
                var cityLow = this.CityLow.Text != "" ? Convert.ToDouble(this.CityLow.Text) : 0;
                var propHigh = this.CityLow.Text != "" ? Convert.ToDouble(this.PropertyHigh.Text) : 0;
                var propLow = this.CityLow.Text != "" ? Convert.ToDouble(this.PropertyLow.Text) : 0;
                var convertedFuToGpm = this.ConvertedFuToGpm.Text != "" ? Convert.ToDouble(this.ConvertedFuToGpm.Text) : 0;


                double cityElevation = 0;
                double propElevation = 0;

                // Try parsing the text from the TextBox
                double.TryParse(this.CityElevation.Text, out cityElevation);
                double.TryParse(this.PropertyElevation.Text, out propElevation);

                _waterDemandTotalDto.OtherWaterRequiredFu =
                    this.OtherWaterReq.Text != null ? Convert.ToDouble(this.OtherWaterReq.Text) : 0;
                

                var dto = new GenerateReportFormDto()
                {
                    SystemType = SystemTypeCombo.Text,
                    SystemLoss = SystemLossCombo.Text,
                    PressureCityHigh = cityHigh,
                    PressureCityLow = cityLow,
                    CityElevation = cityElevation,
                    PropertyElevation = propElevation,
                    PressurePropertyHigh = propHigh,
                    PressurePropertyLow = propLow,
                    BuildingHeight = Convert.ToDouble(this.BuildingHeight.Text),
                    MakeAndModelTmv = MakeModelTmv.Text,
                    MakeModel = MakeMode.Text,
                    MakeModelGpm = MakeModelGpm.Text,
                    PressureLossTmv = Convert.ToDouble(this.PressureLossTmv.Text),
                    WaterMeterSize = size,
                    WaterMeterSizeLoss = waterInputLoss,
                    TotalFixtureUnit = _totalFixtureUnit,
                    ConvertedFuToGpm = convertedFuToGpm,
                    RequiredFixturePressure = Convert.ToDouble(this.RequiredPressureFixture.Text),
                    FiltrationFrictionLoss = Convert.ToDouble(this.FrictionLossFiltration.Text),
                    SubMeterFrictionLoss = Convert.ToDouble(this.FrictionLossSubMeter.Text),
                    DevelopedPipeLength = Convert.ToDouble(this.DevelopPipeLength.Text),
                    SarDate = SarDate.Text,
                    Source = Source.Text,
                    ContactInfo = ContactInfo.Text,
                    ManualPsi = Convert.ToDouble(this.Psi100Ft.Text),
                };


                _createLegendHandler.Dto = dto;
                _createWaterDemandLegendHandler.WaterDemandDictionary = WaterDemandDictionary;
                _createWaterDemandLegendHandler.WaterDemandTotalDto = _waterDemandTotalDto;

                _externalCreateWaterDemandLegend.Raise();
                _externalEventLegend.Raise();
                _externalEventCreateLineLegend.Raise();

                var convertedValue = BuildingHeight.Text != "" ? Convert.ToDouble(this.BuildingHeight.Text) * 0.43 : 0;
                var availablePressure = propLow - waterInputLoss;
                var test1 = FrictionLossSubMeter.Text != "" ? Convert.ToDouble(this.FrictionLossSubMeter.Text) : 0;
                var test2 = FrictionLossFiltration.Text != "" ? Convert.ToDouble(this.FrictionLossFiltration.Text) : 0;
                var test3 = RequiredPressureFixture.Text != ""
                    ? Convert.ToDouble(this.RequiredPressureFixture.Text)
                    : 0;
                var test4 = PressureLossTmv.Text != "" ? Convert.ToDouble(this.PressureLossTmv.Text) : 0;

                var totalLoss =
                    test1
                    + test2
                    + test3
                    + convertedValue
                    + test4;


                var divisor = DevelopPipeLength.Text != "" ? Convert.ToDouble(this.DevelopPipeLength.Text) * 1.25 : 0;
                var convertedAvailablePressureForFrictionLoss =
                    (availablePressure - totalLoss) / divisor;

                var test = Math.Round(convertedAvailablePressureForFrictionLoss * 100, 1);

                this.Psi100FtCacl.Text = test.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CreateTextNoteType_Click(object sender, EventArgs e)
        {
            CreateLegend();
        }

        private void GetValueFromExistingLegend(ViewSheet sheet)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void UpdateLegend(ViewSheet sheet)
        {
            MessageBox.Show("Update Legend");
        }

        private void CityHigh_TextChanged(object sender, EventArgs e)
        {
            ChangePropertyPressure();
        }

        private void CityLow_TextChanged(object sender, EventArgs e)
        {
            ChangePropertyPressure();

            //var element = GetLegendView("water Calculation");

            //if (element != null) PopulateFormForUpdateDto(element, true);
            //PopulateWaterDemandUpdate();
        }

        private void CityElevation_TextChanged(object sender, EventArgs e)
        {
            ChangePropertyPressure();
        }

        private void PropertyElevation_TextChanged(object sender, EventArgs e)
        {
            ChangePropertyPressure();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var element = GetLegendView("Water Calculation");
                var elementWaterDemand = GetLegendView("Water Demand");

                if (element == null) return;

                var textNotes = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, element.Id)
                    .OfClass(typeof(TextNote)).ToList();

                var textNotesDemand = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, elementWaterDemand.Id)
                    .OfClass(typeof(TextNote)).ToList();

                textNotes.AddRange(textNotesDemand);

                //create external function to delete text using id
                _deleteAllTextNoteHandler.Elements = textNotes;
                _externalEventDeleteTextNote.Raise();
                _externalCreateWaterDemandLegend.Raise();

                CreateLegend();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void OtherWaterReq_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var otherWaterRq = this.OtherWaterReq.Text != "" ? Convert.ToDouble(this.OtherWaterReq.Text) : 0;
                var otherWaterReqConvertedFuToGpm = ConvertFuToGpm(otherWaterRq);
                this.OtherWaterReqGpm.Text = otherWaterReqConvertedFuToGpm.ToString();

                _waterDemandTotalDto.OtherWaterRequiredFu = otherWaterRq;
                _waterDemandTotalDto.OtherWaterRequiredGpm = otherWaterReqConvertedFuToGpm;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show($"Error: {exception.Message}");
            }
        }

        private void ExustWaterReq_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var exustWaterRq = this.ExustWaterReq.Text != "" ? Convert.ToDouble(this.ExustWaterReq.Text) : 0;
                var exustWaterRqGpm = ConvertFuToGpm(exustWaterRq);
                this.ExustWaterReqGpm.Text = exustWaterRqGpm.ToString();

                _waterDemandTotalDto.ExistWaterRequiredGpm = exustWaterRqGpm;
                _waterDemandTotalDto.ExistWaterRequiredFu = exustWaterRq;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show($"Error: {exception.Message}");
            }
        }

        private void SizeOfWaterMeter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        private void FrictionLossSubMeter_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            // Check if the entered text contains non-numeric characters
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, @"^\d*$"))
            {
                // If it contains non-numeric characters, remove them
                textBox.Text = System.Text.RegularExpressions.Regex.Replace(textBox.Text, @"\D", "");
                // Optionally, move the caret to the end after changing the text
                textBox.SelectionStart = textBox.Text.Length;
            }

            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        private void PropertyLow_TextChanged(object sender, EventArgs e)
        {
            PopulateWaterDemandUpdate();
            //var element = GetLegendView("water Calculation");

            //if (element != null) PopulateFormForUpdateDto(element, true);

        }

        private void BuildingHeight_TextChanged(object sender, EventArgs e)
        {
            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        private void FrictionLossFiltration_TextChanged(object sender, EventArgs e)
        {
            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        private void RequiredPressureFixture_TextChanged(object sender, EventArgs e)
        {
            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        private void PressureLossTmv_TextChanged(object sender, EventArgs e)
        {
            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        private void DevelopPipeLength_TextChanged(object sender, EventArgs e)
        {
            var element = GetLegendView("Water Calculation");

            if (element != null) PopulateFormForUpdateDto(element, true);
            PopulateWaterDemandUpdate();
        }

        public List<int> GetClosestValue(List<double> data, double psiFtConverted)
        {
            var res = new List<int>();
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (psiFtConverted > data[i])
                {
                    double closeValue = data[i];
                    res = _waterService.GetListOfCopperFlushTankColdByKey(closeValue);
                    break;
                }
            }

            return res;
        }

        public void CallExternalEventCreateCopperType(string psiFt)
        {
            var psiFtConverted = Math.Round(Convert.ToDouble(psiFt), 2);

            var copperFlushTankCold = _waterService.GetListOfCopperFlushTankColdByKey(psiFtConverted);


            if (copperFlushTankCold == null)
            {
                var data = _waterService.CopperFlushTankColdKeys()
                    .OrderByDescending(x => x).ToList();

                copperFlushTankCold = GetClosestValue(data, psiFtConverted);
            }

            var copperFlushTankHot = _waterService.GetListOfCopperFlushTankHotByKey(psiFtConverted);

            if (copperFlushTankHot == null)
            {
                var data = _waterService.CopperFlushTankHotKeys();

                copperFlushTankCold = GetClosestValue(data, psiFtConverted);
            }

            var copperFlashValveCold =
                _waterService.GetListOfCopperFlushValveColdByKey(psiFtConverted);

            if (copperFlashValveCold == null)
            {
                var data = _waterService.CopperFlushValveColdKeys();

                copperFlashValveCold = GetClosestValue(data, psiFtConverted);
            }

            _createCopperTypeHandler.FlashTankCold = copperFlushTankCold;
            _createCopperTypeHandler.FlashValveCold = copperFlashValveCold;
            _createCopperTypeHandler.FlashTankHot = copperFlushTankHot;
            var gpmDataCold = GetGpmMaxValues(copperFlushTankCold, copperFlashValveCold);

            var velocityCold = new List<string>();
            var velocityHot = new List<string>();

            var pipes = _pipeVelocityService.PipeDiameter;

            for (int i = 0; i < pipes.Count; i++)
            {
                var dia = pipes[i]; 
                var data = CalculateWaterVelocity(gpmDataCold[i], dia);


                velocityCold.Add(data);
            }

            var holderList = new List<int>()
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            var gpmDataHot = GetGpmMaxValues(copperFlushTankHot, holderList);

            for (int i = 0; i < pipes.Count; i++)
            {
                var dia = pipes[i];
                var data = CalculateWaterVelocity(gpmDataHot[i], dia);


                velocityHot.Add(data);
            }

            _createCopperTypeHandler.MaxGpmCold = gpmDataCold;
            _createCopperTypeHandler.VelocityCold = velocityCold;
            _createCopperTypeHandler.VelocityHot = velocityHot;
            _createCopperTypeHandler.MaxGpmHot = gpmDataHot;


            _externalEventCreateCopperType.Raise();
            _externalEventCopperLinEvent.Raise();
        }


        public void CallExternalEventCpvc(string psiFt)
        {
            try
            {
                var psiFtConverted = Math.Round(Convert.ToDouble(psiFt), 2);

                var cpvcFlushTank = _waterService.GetListOfCpvcFlushTankByKey(psiFtConverted);

                if (cpvcFlushTank == null)
                {
                    var data = _waterService.CpvcFlushTankKeys()
                        .OrderByDescending(x => x).ToList();

                    cpvcFlushTank = GetClosestValue(data, psiFtConverted);
                }

                var cpvcFlushValve = _waterService.GetListOfCpvcFlushValveByKey(psiFtConverted);

                if (cpvcFlushValve == null)
                {
                    var data = _waterService.CpvcFlushValveKeys()
                        .OrderByDescending(x => x).ToList();

                    cpvcFlushValve = GetClosestValue(data, psiFtConverted);
                }

                var gpmData = GetGpmMaxValues(cpvcFlushValve, cpvcFlushTank);
                var pipes = _pipeVelocityService.PipeDiameterCpvc;

                var velocity = new List<string>();

                for (int i = 0; i < pipes.Count; i++)
                {
                    var dia = pipes[i];
                    var data = CalculateWaterVelocity(gpmData[i], dia);

                    velocity.Add(data);
                }


                _createCpvcHandler.FlushValve = cpvcFlushValve;
                _createCpvcHandler.FlushTank = cpvcFlushTank;
                _createCpvcHandler.MaxGpm = gpmData;
                _createCpvcHandler.Velocity = velocity;
                _createCpvcHandler.PsiPerFt = psiFtConverted;

                _externalEventCreateCpvc.Raise();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
 
        }

        private void CallExternalEventPex(string psiFt)
        {
            var psiFtConverted = Math.Round(Convert.ToDouble(psiFt), 2);

            var pexFlushTank = _waterService.GetListPexFlushTankByKey(psiFtConverted);


            if (pexFlushTank == null)
            {
                var data = _waterService.PexFlushTankKeys()
                    .OrderByDescending(x => x).ToList();

                pexFlushTank = GetClosestValue(data, psiFtConverted);
            }


            var pexFlushTValve = _waterService.GetListPexFlushValveByKey(psiFtConverted);

            if (pexFlushTValve == null)
            {
                var data = _waterService.PexFlushValveKeys()
                    .OrderByDescending(x => x).ToList();

                pexFlushTValve = GetClosestValue(data, psiFtConverted);
            }

            var gpmData = GetGpmMaxValues(pexFlushTValve, pexFlushTank);
            var pipes = _pipeVelocityService.PipeDiameterCpvc;

            var velocity = new List<string>();


            for (int i = 0; i < gpmData.Count; i++)
            {
                var dia = pipes[i];
                var data = CalculateWaterVelocity(gpmData[i], dia);

                velocity.Add(data);
            }

            _createPexHandler.Velocity = velocity;
            _createPexHandler.MaxGpm = gpmData;
            _createPexHandler.FlushTank = pexFlushTank;
            _createPexHandler.FlushValve = pexFlushTValve;
            _createPexHandler.PsiPerFt = psiFtConverted;


            _externalEventCreatePex.Raise();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var psiFt = this.Psi100Ft.Text ?? this.Psi100FtCacl.Text;


                switch (this.SystemLossCombo.Text)
                {
                    case "CPVC":
                        CallExternalEventCpvc(psiFt);
                        break;
                    case "PEX":
                        CallExternalEventPex(psiFt);
                        break;
                    default:
                        CallExternalEventCreateCopperType(psiFt);
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show($"Error: {exception.Message}");
            }

        }

        private int ConvertFuToGpm(double fixtureValue)
        {
            try
            {
                var systemType = this.SystemTypeCombo.Text;
                var dtos = systemType == "Flush Tank"
                    ? _fixtureUnitGpmService.GetListConversionDtoFlashTank()
                    : _fixtureUnitGpmService.GetListConversionDtoFlashValve();

                var index = 0;

                foreach (var fUDto in dtos)
                {
                    index++;

                    if (fixtureValue > fUDto.Min && fixtureValue <= fUDto.Max)
                    {
                        var gpm = dtos.ToArray()[index].Gpm;

                        return gpm;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 0;
        }

        public List<int> GetGpmMaxValues(List<int> list1, List<int> list2)
        {
            int length = 0;
            switch (this.SystemLossCombo.Text)
            {
                case "CPVC":
                    length = Math.Min(list1.Count, list2.Count);
                    break;
                case "PEX":
                    length = Math.Min(list1.Count, list2.Count);
                    break;
                default:
                    length = Math.Max(list1.Count, list2.Count);
                    break;
            }

            List<int> maxValues = new List<int>();

            // Compare each value at the same index and add the max value to the result list
            for (int i = 0; i < length; i++)
            {
                maxValues.Add(Math.Max(list1[i], list2[i]));
            }

            var GpmList = maxValues.Select(x => ConvertFuToGpm(x));

            return GpmList.ToList();
        }

        public string CalculateWaterVelocity(double flowRate, double nominalSize)
        {
            try
            {
                CopperPipeSize pipe = null;

                switch (this.SystemLossCombo.Text)
                {
                    case "CPVC":
                        pipe = _pipeVelocityService.PipeSizesCpvc.SingleOrDefault(x => x.Nominal == nominalSize);
                        break;
                    case "PEX":
                        pipe = _pipeVelocityService.PipeSizesCpvc.SingleOrDefault(x => x.Nominal == nominalSize);
                        break;
                    default:
                        pipe = _pipeVelocityService.PipeSizes.SingleOrDefault(x => x.Nominal == nominalSize);
                        break;
                }


                double numerator = 4 * 144 * flowRate;
                double denominator = 60 * 7.481 * 3.1416 * Math.Pow(pipe.InnerDiameter, 2);

                // Calculate the water velocity
                double velocity = numerator / denominator;

                return velocity.ToString("F2");
            }
            catch (Exception)
            {
                return "-"; 
            }
        }

        private void UpdateSystemLossBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var psiFt = this.Psi100Ft.Text ?? this.Psi100FtCacl.Text;

                switch (this.SystemLossCombo.Text)
                {
                    case "CPVC":
                        var elementCpvc = GetLegendViewByName("Cpvc");
                        if (elementCpvc == null) return;
                        var viewCpvc = elementCpvc as View;
                        var collectorCpvc = new FilteredElementCollector(_document, viewCpvc.Id)
                            .OfClass(typeof(CurveElement)) // For all line types, or ModelCurve for model lines
                            .OfCategory(BuiltInCategory.OST_Lines).ToList();

                        var textNotesCpvc = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, elementCpvc.Id)
                            .OfClass(typeof(TextNote)).ToList();

                        collectorCpvc.AddRange(textNotesCpvc);

                        _deleteAllTextNoteHandler.Elements = collectorCpvc;
                        _externalEventDeleteTextNote.Raise();
                        CallExternalEventCpvc(psiFt);
                        _externalEventCpvcLineEvent.Raise();
                        break;
                    case "PEX":
                        var elementPex = GetLegendViewByName("Pex");
                        if (elementPex == null) return;
                        var viewPex = elementPex as View;
                        var collectorPex = new FilteredElementCollector(_document, viewPex.Id)
                            .OfClass(typeof(CurveElement)) // For all line types, or ModelCurve for model lines
                            .OfCategory(BuiltInCategory.OST_Lines).ToList();

                        var textNotesPex = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, elementPex.Id)
                            .OfClass(typeof(TextNote)).ToList();

                        collectorPex.AddRange(textNotesPex);

                        _deleteAllTextNoteHandler.Elements = collectorPex;
                        _externalEventDeleteTextNote.Raise();
                        CallExternalEventPex(psiFt);
                        _externalEventPexLineEvent.Raise();
                        break;
                    default:
                        var elementCopper = GetLegendViewByName("Copper Type");
                        if (elementCopper == null) return;
                        var viewCopper = elementCopper as View;
                        var collectorCopper = new FilteredElementCollector(_document, viewCopper.Id)
                            .OfClass(typeof(CurveElement)) // For all line types, or ModelCurve for model lines
                            .OfCategory(BuiltInCategory.OST_Lines).ToList();

                        var textNotesCopper = new FilteredElementCollector(_uiApp.ActiveUIDocument.Document, viewCopper.Id)
                            .OfClass(typeof(TextNote)).ToList();

                        collectorCopper.AddRange(textNotesCopper);

                        _deleteAllTextNoteHandler.Elements = collectorCopper;
                        _externalEventDeleteTextNote.Raise();
                        CallExternalEventCreateCopperType(psiFt);
                        _externalEventCopperLinEvent.Raise();
                        break;
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private Element GetLegendViewByName(string name)
        {
            try
            {
                FilteredElementCollector collector = new FilteredElementCollector(_document);
                ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                foreach (Element e in views)
                {
                    View view = e as View;

                    if (view != null && view.ViewType == ViewType.Legend && view.Name == name)
                    {
                        return e;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
 
        }
    }
}
