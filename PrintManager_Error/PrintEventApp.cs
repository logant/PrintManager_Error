using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;

namespace PrintManager_Error
{
    public class PrintEventApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            application.ControlledApplication.DocumentPrinting -= OnPrinting;
            application.ControlledApplication.FileExporting -= OnExporting;

            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.ControlledApplication.DocumentPrinting += OnPrinting;
            application.ControlledApplication.FileExporting += OnExporting;

            return Result.Succeeded;
        }

        public void OnPrinting(object sender, DocumentPrintingEventArgs e)
        {
            List<ElementId> views = e.GetViewElementIds().ToList();
            TaskDialog.Show("Printing", $"Printing {views.Count} Views based on e.GetViewElementIds()");

            PrintManager printManager = e.Document.PrintManager;
            ViewSet vs = printManager.ViewSheetSetting.CurrentViewSheetSet.Views;
            TaskDialog.Show("Printing", $"Printing {vs.Size} Views based on printManager.ViewSheetSetting.CurrentViewSheetSet.Views");
        }

        public void OnExporting(object sender, FileExportingEventArgs e)
        {
            PrintManager printManager = e.Document.PrintManager;
            ViewSet vs = printManager.ViewSheetSetting.CurrentViewSheetSet.Views;
            TaskDialog.Show("Printing", $"Printing {vs.Size} Views based on printManager.ViewSheetSetting.CurrentViewSheetSet.Views");
        }
    }
}
