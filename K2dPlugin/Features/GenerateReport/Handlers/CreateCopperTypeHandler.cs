using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateCopperTypeHandler : IExternalEventHandler
    {
        public List<int> FlashTankCold { get; set; }
        public List<int> FlashValveCold { get; set; }
        public List<int> FlashTankHot { get; set; }
        public List<string> VelocityHot { get; set; }
        public List<string> VelocityCold { get; set; }
        public List<int> MaxGpmCold { get; set; }
        public List<int> MaxGpmHot { get; set; }


        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;

            using (Transaction tx = new Transaction(doc))
            {
                try
                {
                    tx.Start("Create Legend Copper Type");

                    List<View> legendViews = new List<View>();

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                    foreach (Element e in views)
                    {
                        View view = e as View;

                        if (view != null && view.ViewType == ViewType.Legend && view.Name == "Copper Type")
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


                        AddTextNote(doc, legend, headerText, new XYZ(18.342050863, 8.534118991, 0.000000000), "COPPER \"TYPE L\" PIPE SIZING TABLE");
                        AddTextNote(doc, legend, headerText, new XYZ(8.758717529, 2.367452324, 0.000000000), "COLD WATER SIZING TABLE @ 8 FPS MAX VELOCITY");
                        AddTextNote(doc, legend, headerText, new XYZ(8.758717529, -36.752572135, 0.000000000), "HOT WATER SIZING TABLE @ 8 FPS MAX VELOCITY");

                        AddTextNote(doc, legend, normalText, new XYZ(2.484121140, -5.624802390, 0.000000000), "PIPE SIZE");
                        AddTextNote(doc, legend, normalText, new XYZ(11.885859702, -5.624802390, 0.000000000), "1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(18.635859702, -5.624802390, 0.000000000), "3/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(26.176769768, -5.624802390, 0.000000000), "1\"");
                        AddTextNote(doc, legend, normalText, new XYZ(32.216685084, -5.624802390, 0.000000000), "1 1/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(39.300018417, -5.624802390, 0.000000000), "1 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(47.239095494, -5.624802390, 0.000000000), "2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(53.430900719, -5.624802390, 0.000000000), "2 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(61.097567386, -5.624802390, 0.000000000), "3\"");
                        AddTextNote(doc, legend, normalText, new XYZ(68.097567386, -5.624802390, 0.000000000), "4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(75.347567386, -5.624802390, 0.000000000), "6\"");
                        AddTextNote(doc, legend, normalText, new XYZ(82.097567386, -5.624802390, 0.000000000), "8\"");

                        AddTextNote(doc, legend, normalText, new XYZ(11.885859702, -11.124802390, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(18.552526369, -11.124802390, 0.000000000), "0.75");
                        AddTextNote(doc, legend, normalText, new XYZ(26.469193036, -11.124802390, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(32.635859702, -11.124802390, 0.000000000), "1.25");
                        AddTextNote(doc, legend, normalText, new XYZ(39.969193036, -11.124802390, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(47.302526369, -11.124802390, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.905762160, -11.124802390, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(61.405762160, -11.124802390, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(68.405762160, -11.124802390, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(75.905762160, -11.124802390, 0.000000000), "6");
                        AddTextNote(doc, legend, normalText, new XYZ(82.405762160, -11.124802390, 0.000000000), "8");

                        AddTextNote(doc, legend, normalText, new XYZ(4.033896378, -16.124802390, 0.000000000), "GPM");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -20.041469057, 0.000000000), "FT");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -22.393566906, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -25.041469057, 0.000000000), "FV");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -27.393566906, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.450563044, -31.226900239, 0.000000000), "VEL");


                        //GPM COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.552526369, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.469193036, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.219193036, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.469193036, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(47.135859702, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.219193036, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.954186256, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.787519590, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.564885399, -16.357924931, 0.000000000), $"{ConvertNumberToString(MaxGpmCold[9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(81.481552066, -16.357924931, 0.000000000), "-");



                        //FT FU COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.552526369, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.172373669, -21.111064610, 0.000000000), $"{ConvertNumberToString(FlashTankCold[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.219193036, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.469193036, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.802526369, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(53.635859702, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.905762160, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.200970078, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.231552066, -21.124802390, 0.000000000), $"{ConvertNumberToString(FlashTankCold[9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(82.347567386, -21.124802390, 0.000000000), $"-");

                        //FT FV COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.552526369, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.552526369, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.469193036, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.626990437, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.969193036, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(53.905762160, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.954186256, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.200970078, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(75.097567386, -26.124802390, 0.000000000), $"{ConvertNumberToString(FlashValveCold[9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(82.264234053, -26.124802390, 0.000000000), "-");

                        //VEL COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -31.124802390, 0.000000000), $"-");
                        AddTextNote(doc, legend, normalText, new XYZ(18.604156390, -31.226900239, 0.000000000), $"{VelocityCold[1]}");
                        AddTextNote(doc, legend, normalText, new XYZ(25.668052053, -31.226900239, 0.000000000), $"{VelocityCold[2]}");
                        AddTextNote(doc, legend, normalText, new XYZ(32.668052053, -31.226900239, 0.000000000), $"{VelocityCold[3]}");
                        AddTextNote(doc, legend, normalText, new XYZ(39.533455478, -31.226900239, 0.000000000), $"{VelocityCold[4]}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.751385387, -31.226900239, 0.000000000), $"{VelocityCold[5]}");
                        AddTextNote(doc, legend, normalText, new XYZ(53.469193036, -31.226900239, 0.000000000), $"{VelocityCold[6]}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.430900719, -31.226900239, 0.000000000), $"{VelocityCold[7]}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.635859702, -31.124802390, 0.000000000), $"{VelocityCold[8]}");
                        AddTextNote(doc, legend, normalText, new XYZ(75.097567386, -31.124802390, 0.000000000), $"{VelocityCold[9]}");
                        AddTextNote(doc, legend, normalText, new XYZ(82.264234053, -31.124802390, 0.000000000), "-");




















                        //HOT
                        AddTextNote(doc, legend, normalText, new XYZ(2.484121140, -44.124802390, 0.000000000), "PIPE SIZE");
                        AddTextNote(doc, legend, normalText, new XYZ(11.885859702, -44.124802390, 0.000000000), "1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(18.635859702, -44.124802390, 0.000000000), "3/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(26.176769768, -44.124802390, 0.000000000), "1\"");
                        AddTextNote(doc, legend, normalText, new XYZ(32.216685084, -44.124802390, 0.000000000), "1 1/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(39.300018417, -44.124802390, 0.000000000), "1 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(47.239095494, -44.124802390, 0.000000000), "2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(53.430900719, -44.124802390, 0.000000000), "2 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(61.097567386, -44.124802390, 0.000000000), "3\"");
                        AddTextNote(doc, legend, normalText, new XYZ(68.097567386, -44.124802390, 0.000000000), "4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(75.347567386, -44.124802390, 0.000000000), "6\"");
                        AddTextNote(doc, legend, normalText, new XYZ(82.097567386, -44.124802390, 0.000000000), "8\"");

                        AddTextNote(doc, legend, normalText, new XYZ(11.885859702, -49.624802390, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(18.552526369, -49.624802390, 0.000000000), "0.75");
                        AddTextNote(doc, legend, normalText, new XYZ(26.469193036, -49.624802390, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(32.635859702, -49.624802390, 0.000000000), "1.25");
                        AddTextNote(doc, legend, normalText, new XYZ(39.969193036, -49.624802390, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(47.302526369, -49.624802390, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.905762160, -49.624802390, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(61.405762160, -49.624802390, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(68.405762160, -49.624802390, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(75.905762160, -49.624802390, 0.000000000), "6");
                        AddTextNote(doc, legend, normalText, new XYZ(82.405762160, -49.624802390, 0.000000000), "8");


                        AddTextNote(doc, legend, normalText, new XYZ(4.033896378, -54.624802390, 0.000000000), "GPM");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -58.541469057, 0.000000000), "FT");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -60.893566906, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -63.541469057, 0.000000000), "FV");
                        AddTextNote(doc, legend, normalText, new XYZ(4.783896378, -65.893566906, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.450563044, -69.726900239, 0.000000000), "VEL");



                        //GPM HOT
                            AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.552526369, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.469193036, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.219193036, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.469193036, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(47.135859702, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.219193036, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.954186256, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.787519590, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.564885399, -54.857924931, 0.000000000), $"{ConvertNumberToString(MaxGpmHot[9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(81.481552066, -54.857924931, 0.000000000), "-");


                        //FT FU HOT
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.552526369, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.172373669, -59.611064610, 0.000000000), $"{ConvertNumberToString(FlashTankHot[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.219193036, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.469193036, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.802526369, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(53.635859702, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.905762160, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.200970078, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(75.264234053, -59.624802390, 0.000000000), $"{ConvertNumberToString(FlashTankHot[9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(82.347567386, -59.624802390, 0.000000000), "-");

                        ////FT FV HOT
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -64.624802390, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(20.176769768, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(26.469193036, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(33.969193036, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(40.847567386, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(47.847567386, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(54.847567386, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(60.534303411, -64.624802390, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(67.677861932, -64.864202944, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.097567386, -64.624802390, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.264234053, -64.624802390, 0.000000000), "-");

                        ////VEL HOT
                        AddTextNote(doc, legend, normalText, new XYZ(12.393959457, -69.624802390, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(18.604156390, -69.726900239, 0.000000000), $"{VelocityHot[1]}");
                        AddTextNote(doc, legend, normalText, new XYZ(25.668052053, -69.726900239, 0.000000000), $"{VelocityHot[2]}");
                        AddTextNote(doc, legend, normalText, new XYZ(32.668052053, -69.726900239, 0.000000000), $"{VelocityHot[3]}");
                        AddTextNote(doc, legend, normalText, new XYZ(39.533455478, -69.726900239, 0.000000000), $"{VelocityHot[4]}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.751385387, -69.726900239, 0.000000000), $"{VelocityHot[5]}");
                        AddTextNote(doc, legend, normalText, new XYZ(53.469193036, -69.726900239, 0.000000000), $"{VelocityHot[6]}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.430900719, -69.726900239, 0.000000000), $"{VelocityHot[7]}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.635859702, -69.624802390, 0.000000000), $"{VelocityHot[8]}");
                        AddTextNote(doc, legend, normalText, new XYZ(75.097567386, -69.624802390, 0.000000000), $"{VelocityHot[9]}");
                        AddTextNote(doc, legend, normalText, new XYZ(82.264234053, -69.624802390, 0.000000000), "-");



                        tx.Commit();
                    }
                }
                catch (Exception e)
                {
                    if (tx.HasStarted())
                    {
                        tx.RollBack();
                    }
                    TaskDialog.Show("Error", e.Message);
                }
            }
        }

        public string GetName()
        {
            return "CreateCopperTypeHandler";
        }

        private void AddTextNote(Document doc, View legend, TextNoteType textNoteType, XYZ position, string text, string name = "")
        {
            TextNote textNote = TextNote.Create(doc, legend.Id, position, text, textNoteType.Id);
        }

        private double ConvertToTwoDecimal(double val) => Math.Round(val, 2);

        public string ConvertNumberToString(double number)
        {
            return number != 0 ? number.ToString() : "-";
        }
    }
}
