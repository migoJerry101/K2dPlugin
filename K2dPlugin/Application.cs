﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

using K2dPlugin.Features.PipeSum;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Events;


namespace K2dPlugin
{
    [Transaction(TransactionMode.Manual)]
    //[Regeneration(RegenerationOption.Manual)]
    public class Application : IExternalApplication
    {

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var panel = RibbonPanel(application);
            var assemblyPath = Assembly.GetExecutingAssembly().Location;

            if (panel.AddItem(new PushButtonData("Pipe Sum", "Pipe Sum", assemblyPath, typeof(PipeSumCommand).ToString()))
                is PushButton button)
            {
                button.ToolTip = "Pipe Sum";

                var uri = new Uri(Path.Combine(Path.GetDirectoryName(assemblyPath), "Resources", "pipe.ico"));
                var bitmap = new BitmapImage(uri);

                button.LargeImage = bitmap;
            }

            return Result.Succeeded;
        }

        public RibbonPanel RibbonPanel(UIControlledApplication application)
        {
            const string tabName = "K2d";
            const string panelName = "K2d Plugin";

            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            try
            {
                application.CreateRibbonPanel(tabName, panelName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            var ribbonPanel = application
                .GetRibbonPanels(tabName)
                .FirstOrDefault(x => x.Name == panelName);

            return ribbonPanel;
        }
    }
}
