using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateCpvcHandler : IExternalEventHandler
    {
        public List<int> FlushTank { get; set; }
        public List<int> FlushValve { get; set; }
        public List<string> Velocity { get; set; }

        public List<int> MaxGpm { get; set; }
        public double PsiPerFt { get; set; }

        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;

            using (Transaction tx = new Transaction(doc))
            {
                try
                {
                    tx.Start("Create Legend CPVC");

                    List<View> legendViews = new List<View>();

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                    foreach (Element e in views)
                    {
                        View view = e as View;

                        if (view != null && view.ViewType == ViewType.Legend && view.Name == "Cpvc")
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


                        var cpvcText = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "Schedule Default Table");



                        AddTextNote(doc, legend, headerText, new XYZ(26.337117890, 8.553430805, 0.000000000), "CPVC PIPE SIZING TABLE");
                        AddTextNote(doc, legend, cpvcText, new XYZ(13.350218069, 1.886764138, 0.000000000), $"CPVC PLASTIC PIPE SDR11 FOR 2-INCH AND SMALLER PIPE SIZES CHARLOTTE PIPE FLOW \r\nGUARD GOLD  {PsiPerFt}  PSI PER 100 FT., 8 FPS MAX. VELOCITY (LARR 5697)");
                        AddTextNote(doc, legend, cpvcText, new XYZ(14.035674320, -37.113235862, 0.000000000), $"CPVC SCH.80 PLASTIC PIPE FOR 2-1/2-INCH PIPE AND LARGER PIPE SIZES IPEX USA LLC \r\n{PsiPerFt} PSI PER 100 FT., 8 FPS MAX. VELOCITY (LARR 5717)");

                        AddTextNote(doc, legend, normalText, new XYZ(2.479188167, -5.605490576, 0.000000000), "PIPE SIZE");
                        AddTextNote(doc, legend, normalText, new XYZ(11.880926730, -5.605490576, 0.000000000), "1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(18.630926730, -5.605490576, 0.000000000), "3/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(26.171836796, -5.605490576, 0.000000000), "1\"");
                        AddTextNote(doc, legend, normalText, new XYZ(32.211752111, -5.605490576, 0.000000000), "1 1/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(39.295085444, -5.605490576, 0.000000000), "1 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(47.234162521, -5.605490576, 0.000000000), "2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(54.650829188, -5.772157243, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.650829188, -5.772157243, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.650829188, -5.772157243, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.900829188, -5.772157243, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.400829188, -5.772157243, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(11.880926730, -11.105490576, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(18.547593396, -11.105490576, 0.000000000), "0.75");
                        AddTextNote(doc, legend, normalText, new XYZ(26.464260063, -11.105490576, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(32.630926730, -11.105490576, 0.000000000), "1.25");
                        AddTextNote(doc, legend, normalText, new XYZ(39.964260063, -11.105490576, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(47.297593396, -11.105490576, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.900829188, -11.105490576, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(61.400829188, -11.105490576, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(68.400829188, -11.105490576, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(75.900829188, -11.105490576, 0.000000000), "6");
                        AddTextNote(doc, legend, normalText, new XYZ(82.400829188, -11.105490576, 0.000000000), "8");

                        AddTextNote(doc, legend, normalText, new XYZ(4.028963405, -16.105490576, 0.000000000), "GPM");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -20.022157243, 0.000000000), "FT");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -22.374255092, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -25.022157243, 0.000000000), "FV");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -27.374255092, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.445630072, -31.207588425, 0.000000000), "VEL");


                        //GPM COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -16.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.547593396, -16.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.464260063, -16.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.214260063, -16.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.464260063, -16.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(47.130926730, -16.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(53.309952427, -16.338613117, 0.000000000), "   -");
                        AddTextNote(doc, legend, normalText, new XYZ(60.309952427, -16.338613117, 0.000000000), "   -");
                        AddTextNote(doc, legend, normalText, new XYZ(67.309952427, -16.338613117, 0.000000000), "   -");
                        AddTextNote(doc, legend, normalText, new XYZ(74.559952427, -16.338613117, 0.000000000), "   -");
                        AddTextNote(doc, legend, normalText, new XYZ(81.476619093, -16.338613117, 0.000000000), "   -");


                        //FT FU COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -21.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.547593396, -21.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.167440696, -21.091752796, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.214260063, -21.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.464260063, -21.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(47.234162521, -21.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.650829188, -21.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.650829188, -21.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.650829188, -21.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.900829188, -21.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.400829188, -21.105490576, 0.000000000), "-");


                        //Fv Fu COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -26.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.547593396, -26.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.547593396, -26.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.464260063, -26.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.714260063, -26.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.964260063, -26.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.650829188, -26.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.650829188, -26.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.650829188, -26.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.900829188, -26.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.400829188, -26.105490576, 0.000000000), "-");

                        //VEL COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -31.105490576, 0.000000000), $"{Velocity[index: 0]}");
                        AddTextNote(doc, legend, normalText, new XYZ(18.599223418, -31.207588425, 0.000000000), $"{Velocity[index: 1]}");
                        AddTextNote(doc, legend, normalText, new XYZ(25.663119081, -31.207588425, 0.000000000), $"{Velocity[index: 2]}");
                        AddTextNote(doc, legend, normalText, new XYZ(32.663119081, -31.207588425, 0.000000000), $"{Velocity[index: 3]}");
                        AddTextNote(doc, legend, normalText, new XYZ(39.528522505, -31.207588425, 0.000000000), $"{Velocity[index: 4]}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.746452414, -31.207588425, 0.000000000), $"{Velocity[index: 5]}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.650829188, -31.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.650829188, -31.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.650829188, -31.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.900829188, -31.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.400829188, -31.207588425, 0.000000000), "-");


                        //HOT
                        AddTextNote(doc, legend, normalText, new XYZ(2.479188167, -44.605490576, 0.000000000), "PIPE SIZE");
                        AddTextNote(doc, legend, normalText, new XYZ(12.630926730, -44.605490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(19.639026484, -44.605490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(26.797593396, -44.605490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(33.880926730, -44.605490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(40.880926730, -44.605490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(47.714260063, -44.605490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(53.425967747, -44.605490576, 0.000000000), "2 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(61.092634413, -44.605490576, 0.000000000), "3\"");
                        AddTextNote(doc, legend, normalText, new XYZ(68.092634413, -44.605490576, 0.000000000), "4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(75.342634413, -44.605490576, 0.000000000), "6\"");
                        AddTextNote(doc, legend, normalText, new XYZ(82.092634413, -44.605490576, 0.000000000), "8\"");

                        AddTextNote(doc, legend, normalText, new XYZ(11.880926730, -50.105490576, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(18.547593396, -50.105490576, 0.000000000), "0.75");
                        AddTextNote(doc, legend, normalText, new XYZ(26.464260063, -50.105490576, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(32.630926730, -50.105490576, 0.000000000), "1.25");
                        AddTextNote(doc, legend, normalText, new XYZ(39.964260063, -50.105490576, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(47.297593396, -50.105490576, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.900829188, -50.105490576, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(61.400829188, -50.105490576, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(68.400829188, -50.105490576, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(75.900829188, -50.105490576, 0.000000000), "6");
                        AddTextNote(doc, legend, normalText, new XYZ(82.400829188, -50.105490576, 0.000000000), "8");


                        AddTextNote(doc, legend, normalText, new XYZ(4.028963405, -55.105490576, 0.000000000), "GPM");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -59.022157243, 0.000000000), "FT");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -61.374255092, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -64.022157243, 0.000000000), "FV");
                        AddTextNote(doc, legend, normalText, new XYZ(4.778963405, -66.374255092, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.445630072, -70.207588425, 0.000000000), "VEL");



                        //GPM HOT
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -55.338613117, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(19.639026484, -55.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(26.639026484, -55.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(33.639026484, -55.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(40.639026484, -55.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(47.639026484, -55.338613117, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(54.214260063, -55.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.949253284, -55.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.782586617, -55.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.925967747, -55.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(81.925967747, -55.338613117, 0.000000000), $"{ConvertNumberToString(MaxGpm[10])}");


                        //FT FU HOT
                        //(40.880926730, -65.105490576, 0.000000000)
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -60.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(19.639026484, -59.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(26.639026484, -59.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(33.639026484, -59.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(40.639026484, -59.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(47.639026484, -60.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(53.630926730, -60.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 6])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.900829188, -60.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.196037105, -60.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.529370439, -60.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(81.529370439, -60.105490576, 0.000000000), $"{ConvertNumberToString(FlushTank[index: 10])}");

                        ////FV FU HOT
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -65.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(19.639026484, -64.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(26.639026484, -64.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(33.639026484, -64.872368036, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(40.469193036, -54.857924931, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(47.639026484, -65.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(40.880926730, -65.105490576, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(53.900829188, -65.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 7])}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.949253284, -65.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 8])}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.196037105, -65.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 9])}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.196037105, -65.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 10])}");
                        AddTextNote(doc, legend, normalText, new XYZ(81.196037105, -65.105490576, 0.000000000), $"{ConvertNumberToString(FlushValve[index: 11])}");

                        ////VEL HOT
                        AddTextNote(doc, legend, normalText, new XYZ(12.389026484, -70.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(19.639026484, -70.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(26.639026484, -70.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(33.639026484, -70.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(40.639026484, -70.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(47.639026484, -70.207588425, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(53.464260063, -70.207588425, 0.000000000), $"{Velocity[index: 6]}");
                        AddTextNote(doc, legend, normalText, new XYZ(60.425967747, -70.207588425, 0.000000000), $"{Velocity[index: 7]}");
                        AddTextNote(doc, legend, normalText, new XYZ(67.630926730, -70.105490576, 0.000000000), $"{Velocity[index: 8]}");
                        AddTextNote(doc, legend, normalText, new XYZ(74.925967747, -70.105490576, 0.000000000), $"{Velocity[index: 9]}");
                        AddTextNote(doc, legend, normalText, new XYZ(81.529370439, -70.105490576, 0.000000000), $"{Velocity[index: 10]}");



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
            return "CreateCpvcHandler";
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
