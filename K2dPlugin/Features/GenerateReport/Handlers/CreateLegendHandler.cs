using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Features.GenerateReport.Dto;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateLegendHandler : IExternalEventHandler
    {
        public GenerateReportFormDto Dto { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;

            using (Transaction tx = new Transaction(doc))
            {
                try
                {
                    tx.Start("Create Legend");

                    List<View> legendViews = new List<View>();

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                    foreach (Element e in views)
                    {
                        View view = e as View;

                        if (view != null && view.ViewType == ViewType.Legend && view.Name == "Water Calculation")
                        {
                            legendViews.Add(view);
                        }
                    }

                    var legend = legendViews.SingleOrDefault();

                    if (legend != null)
                    {

                        var headerText = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "headerText");

                        var normalText = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "normalText");

                        var normalTextUnderline = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "normalTextUnderline");


                        AddTextNote(doc, legend, headerText, new XYZ(12.193501564, 25.690167850, 0.000000000), "WATER CALCULATION");

                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, 17.709455405, 0.000000000), "TYPE OF SYSTEM:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(14.205878046, 17.709455405, 0.000000000), Dto.SystemType);//VAL System Type

                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, 14.222991206, 0.000000000), "PIPE LOSS ARE BASED ON:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(14.205878046, 14.222991206, 0.000000000), Dto.SystemLoss);//VAL System Loss


                        AddTextNote(doc, legend, normalText, new XYZ(48.137457639, 10.511576975, 0.000000000), "SAR DATE:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(57.678858162, 10.511576975, 0.000000000), Dto.SarDate);//VAL SAR DATE:

                        AddTextNote(doc, legend, normalText, new XYZ(48.137457639, 6.881313079, 0.000000000), "SOURCE:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(57.678858162, 6.881313079, 0.000000000), Dto.Source);//VAL SAR DATE:

                        AddTextNote(doc, legend, normalText, new XYZ(43.398674922, 3.023793927, 0.000000000), "CONTACT INFO:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(57.678858162, 3.023793927, 0.000000000), Dto.ContactInfo);//VAL SAR DATE:


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, 6.881313079, 0.000000000), "MAXIMUM C.W. DEMAND:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(14.205878046, 6.881313079, 0.000000000), $"{Dto.TotalFixtureUnit}");//VAL total fixture unit
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(19.948925244, 6.881313079, 0.000000000), "FU");//VAL total fixture unit

                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(28.596126989, 6.881313079, 0.000000000), $"{Dto.ConvertedFuToGpm} GPM");//VAL for calculated from FU
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(33.096126989, 6.881313079, 0.000000000), "GPM");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, 3.023793927, 0.000000000), "MAXIMUM H.W. DEMAND:");

                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(14.205878046, 3.023793927, 0.000000000), " - ");//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(19.948925244, 3.023793927, 0.000000000), "FU");

                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(28.596126989, 3.023793927, 0.000000000), " - ");//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(33.096126989, 3.023793927, 0.000000000), "GPM");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -6.989386786, 0.000000000), "AVAILABLE PRESSURE (CITY STREET MAIN):");

                        AddTextNote(doc, legend, normalText, new XYZ(8.476741173, -10.964445992, 0.000000000), "HIGH:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(16.318766543, -10.964445992, 0.000000000), $"{ConvertToTwoDecimal(Dto.PressureCityHigh)}");//VAL Pressure City High
                        AddTextNote(doc, legend, normalText, new XYZ(20.588189043, -10.964445992, 0.000000000), "PSI");



                        AddTextNote(doc, legend, normalText, new XYZ(30.715594834, -10.964445992, 0.000000000), "LOW:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(39.054539070, -10.964445992, 0.000000000), $"{ConvertToTwoDecimal(Dto.PressureCityLow)}");//VAL Pressure City Low
                        AddTextNote(doc, legend, normalText, new XYZ(42.588189043, -10.964445992, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -15.736767808, 0.000000000), "AVAILABLE PRESSURE AT THE PROPERTY(WATER METER LOCATION):");

                        AddTextNote(doc, legend, normalText, new XYZ(8.476741173, -21.611544582, 0.000000000), "HIGH:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(16.318766543, -21.611544582, 0.000000000), $"{ConvertToTwoDecimal(Dto.PressurePropertyHigh)}");//VAL property High
                        AddTextNote(doc, legend, normalText, new XYZ(20.588189043, -21.611544582, 0.000000000), "PSI");

                        AddTextNote(doc, legend, normalText, new XYZ(30.715594834, -21.611544582, 0.000000000), "LOW:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(39.054539070, -21.611544582, 0.000000000), $"{ConvertToTwoDecimal(Dto.PressurePropertyLow)}");//VAL property Low
                        AddTextNote(doc, legend, normalText, new XYZ(42.588189043, -21.611544582, 0.000000000), "PSI");

                        AddTextNote(doc, legend, normalText, new XYZ(51.741947335, -10.964445992, 0.000000000), "ELEVATION:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(62.918348067, -10.964445992, 0.000000000), $"{Dto.CityElevation} FT");//VAL--

                        AddTextNote(doc, legend, normalText, new XYZ(51.741947335, -21.611544582, 0.000000000), "ELEVATION:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(62.918348067, -21.611544582, 0.000000000), $"{Dto.PropertyElevation} FT");//VAL--

                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -25.559147614, 0.000000000), "NOT ALL LOSSES SHOWN IN P.S.I.");

                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -31.620525593, 0.000000000), "LOSS THROUGH WATER METER:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(19.886309440, -31.620525593, 0.000000000), $"{Dto.WaterMeterSize}\"");//VAL--
                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -31.620525593, 0.000000000), "SIZE @");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(35.886309440, -31.620525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.ConvertedFuToGpm)}");//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(41.052976107, -31.620525593, 0.000000000), "GPM");//VAL

                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -31.620525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.WaterMeterSizeLoss)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -31.696499613, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(13.930293052, -34.696499613, 0.000000000), "AVAILABLE PRESSURE:");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(33.611284552, -34.696499613, 0.000000000), $"{ConvertToTwoDecimal(Dto.PressurePropertyLow)}");//VAl
                        AddTextNote(doc, legend, normalText, new XYZ(37.364001798, -34.696499613, 0.000000000), "-");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(39.639026686, -34.696499613, 0.000000000), $"{ConvertToTwoDecimal(Dto.WaterMeterSizeLoss)}");//VAL

                        var availablePressure = Dto.PressurePropertyLow - Dto.WaterMeterSizeLoss;
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -34.696499613, 0.000000000), $"{ConvertToTwoDecimal(availablePressure)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -34.544551573, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -25.559147614, 0.000000000), "NOT ALL LOSSES SHOWN IN P.S.I.");

                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -40.620525593, 0.000000000), "LOSS THRU SUBMETER");

                        var makeModelGpm = Dto.MakeModelGpm == "" ? "N/A" : Dto.MakeModelGpm;
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(22.958130739, -40.620525593, 0.000000000), makeModelGpm);//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -40.620525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.SubMeterFrictionLoss)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -40.544551573, 0.000000000), "PSI");

                        var makeModel = Dto.MakeModel ?? "N/A";
                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -43.620525593, 0.000000000), "LOSS THRU WATER FILTRATION SYSTEM");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(22.958130739, -43.620525593, 0.000000000), $"{makeModel}");//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -43.620525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.FiltrationFrictionLoss)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -43.620525593, 0.000000000), "PSI");
                            

                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -46.620525593, 0.000000000), "PRESSURE REQUIRED @ FIXTURE");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -46.620525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.RequiredFixturePressure)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -46.544551573, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -49.870525593, 0.000000000), "STATIC LOSS: ");
                        AddTextNote(doc, legend, normalText, new XYZ(-1.255470748, -49.870525593, 0.000000000), "BUILDING HEIGHT");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(22.958130739, -49.870525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.BuildingHeight)}");//VAl
                        AddTextNote(doc, legend, normalText, new XYZ(27.045825443, -49.870525593, 0.000000000), "FT. X");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(32.782875014, -49.870525593, 0.000000000), "0.434");//VAL


                        var convertedValue = Dto.BuildingHeight * 0.43;
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -49.870525593, 0.000000000), $"{ConvertToTwoDecimal(convertedValue)}");//VAL4
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -52.711218239, 0.000000000), "PSI");

                        var makeModelTmv = string.IsNullOrWhiteSpace(Dto.MakeAndModelTmv) ? "N/A" : Dto.MakeAndModelTmv;
                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -52.787192259, 0.000000000), "LOSS THRU THERMOSTATIC MIXING VALVE");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(22.958130739, -52.787192259, 0.000000000), $"{makeModelTmv}");//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -52.870525593, 0.000000000), $"{ConvertToTwoDecimal(Dto.PressureLossTmv)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -49.794551573, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalText, new XYZ(6.252850269, -55.918898675, 0.000000000), "TOTAL LOSSES");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(22.958130739, -55.870525593, 0.000000000),
                            $"{ConvertToTwoDecimal(Dto.SubMeterFrictionLoss)} + {ConvertToTwoDecimal(Dto.FiltrationFrictionLoss)} + {ConvertToTwoDecimal(Dto.RequiredFixturePressure)} + {ConvertToTwoDecimal(convertedValue)} + {ConvertToTwoDecimal(Dto.PressureLossTmv)}");//VAL

                        var totalLoss = Dto.SubMeterFrictionLoss + Dto.FiltrationFrictionLoss +
                                        Dto.RequiredFixturePressure + convertedValue + Dto.PressureLossTmv;


                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -55.918898675, 0.000000000), $"{ConvertToTwoDecimal(totalLoss)}");//VAL
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(59.412881421, -55.870525593, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -59.062284516, 0.000000000), "AVAILABLE PRESSURE FOR FRICTION LOSS = ");


                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(23.784484473, -59.318483599, 0.000000000), $"{ConvertToTwoDecimal(availablePressure)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(28.535437997, -58.982748578, 0.000000000), "-");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(31.942562082, -59.318483599, 0.000000000), $"{ConvertToTwoDecimal(totalLoss)}");//VAL


                        var availablePressureForFrictionLoss = availablePressure - totalLoss;
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -59.318483599, 0.000000000), $"{ConvertToTwoDecimal(availablePressureForFrictionLoss)}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(59.412881421, -59.318483599, 0.000000000), "PSI");


                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(-14.644433468, -64.598984763, 0.000000000), $"{ConvertToTwoDecimal(availablePressureForFrictionLoss)}");
                        AddTextNote(doc, legend, normalText, new XYZ(-8.187161031, -64.598984763, 0.000000000), $"X 100");


                        var divisor = Dto.DevelopedPipeLength * 1.25;
                        var convertedAvailablePressureForFrictionLoss =
                            availablePressureForFrictionLoss / divisor;


                        AddTextNote(doc, legend, normalText, new XYZ(31.942562082, -64.598984763, 0.000000000), "PSI / 100 FT.");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(54.386309440, -64.598984763, 0.000000000), $"{Math.Round(convertedAvailablePressureForFrictionLoss * 100, 1)}");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -67.496738569, 0.000000000), "TOTAL LENGTH OF RUN");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(3.512201542, -67.496738569, 0.000000000), $"{Dto.DevelopedPipeLength}");
                        AddTextNote(doc, legend, normalText, new XYZ(8.404530675, -67.591642954, 0.000000000), "FT.");


                        AddTextNote(doc, legend, normalText, new XYZ(-15.755470748, -70.496738569, 0.000000000), "FEET X 1.25 =");
                        AddTextNote(doc, legend, normalTextUnderline, new XYZ(3.512201542, -70.496738569, 0.000000000), $"{Math.Round(divisor)}");
                        AddTextNote(doc, legend, normalText, new XYZ(8.404530675, -70.473556700, 0.000000000), "TDL");

                        AddTextNote(doc, legend, normalText, new XYZ(31.942562082, -70.473556700, 0.000000000), "(LOCATE ON PIPE SIZING CHART)");

                        



                        AddTextNote(doc, legend, normalText, new XYZ(48.971721542, -67.748299524, 0.000000000), "SAY");
                        AddTextNote(doc, legend, normalText, new XYZ(54.386309440, -67.748299524, 0.000000000), $"{Dto.ManualPsi}");

                    }


                    tx.Commit();

                    TaskDialog.Show("Legend Created", "Legend view created successfully.");
                }
                catch (Exception ex)
                {
                    if (tx.HasStarted())
                    {
                        tx.RollBack();
                    }
                    TaskDialog.Show("Error", ex.Message);
                }
            }
        }

        public string GetName()
        {
            return "CreateLegendHandler";
        }

        private void AddTextNote(Document doc, View legend, TextNoteType textNoteType, XYZ position, string text, string name = "")
        {
            TextNote textNote = TextNote.Create(doc, legend.Id, position, text, textNoteType.Id);
        }

        private double ConvertToTwoDecimal(double val) => Math.Round(val, 2);
    }
}
