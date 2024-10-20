using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class TextNotePropertyHandler : IExternalEventHandler
    {
        public Document Document { get; set; }
        public void Execute(UIApplication app)
        {
            try
            {
                using (Transaction trans = new Transaction(Document, "Add Parameter TextNote"))
                {
                    trans.Start();

                    // Get the shared parameter file
                    var sharedParamFile = app.Application.OpenSharedParameterFile();

                    DefinitionGroup group = sharedParamFile.Groups.get_Item("TextNoteParameters")
                                            ?? sharedParamFile.Groups.Create("TextNoteParameters");

                    // Find or create the shared parameter definition
                    Definition sharedParamDef = group.Definitions.get_Item("UniqueTextNoteParameter")
                                                ?? group.Definitions.Create(new ExternalDefinitionCreationOptions("UniqueTextNoteParameter", ParameterType.Text));

                    // Get the TextNote category
                    Category textNoteCategory = Document.Settings.Categories.get_Item(BuiltInCategory.OST_TextNotes);
                    CategorySet categories = app.Application.Create.NewCategorySet();
                    categories.Insert(textNoteCategory);

                    // Bind the parameter to the TextNote category as an instance parameter
                    InstanceBinding binding = app.Application.Create.NewInstanceBinding(categories);
                    BindingMap bindingMap = Document.ParameterBindings;
                    bindingMap.Insert(sharedParamDef, binding, BuiltInParameterGroup.PG_TEXT);

                    // Get all TextNote elements in the document
                    FilteredElementCollector collector = new FilteredElementCollector(Document)
                        .OfClass(typeof(TextNote));

                    foreach (Element textNote in collector)
                    {
                        Parameter param = textNote.get_Parameter(sharedParamDef);

                        if (param != null && !param.IsReadOnly)
                        {
                            param.Set(string.Empty);
                        }
                    }

                    trans.Commit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public string GetName()
        {
            return "TextNotePropertyHandler";
        }
    }
}
