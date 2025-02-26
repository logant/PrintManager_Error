# Revit 2025 Export Error
This is intended to showcase recent errors with the PrintManager object while Exporting for Revit 2025 while it works in Revit 2024 and during the Printing events for both versions.

## Notes
Main Branch is built for Revit 2024 and .net Framework 4.8. revit2025 branch is built for Revit 2025 and .net 8

This project contains a single IExternalApplication for Revit that adds hooks to the DocumentPrinting and FileExporting events during the OnStartup method. The DocumentPrintingEventArgs has a property to get the views being printed, but the FileExportingEventArgs does not. To circumvent that missing function, for versions of Revit through Revit 2024 I was able to use the PrintManager object to get the views being printed. For Revit 2025 whenever I access the PrintManager from the FileExporting event it throws an error.

## Testing on Revit 2024
- Build on the main branch for Revit 2024.
- Compile and load the plugin into Revit 2024.
- You can simply start a new file using the "Imperial Multi-Discipline"  template.
- Print using the "All Sheets" view set.
  - A TaskDialog will appear telling you how many sheets are being printed. This uses the event args .GetViewElementIds() method.
  - A second TaskDialog will appear telling you how many sheets are being printed. This uses the doc.PrintManager.ViewSheetSetting.CurrentViewSheetSet.Views property.
- Export to PDF using the "All Sheets" view set.
  - A TaskDialog will appear telling you how many views/sheets are being exported. This uses the doc.PrintManager.ViewSheetSetting.CurrentViewSheetSet.Views property.

## Testing on Revit 2025
- Build on the 'revit2025' branch for Revit 2025.
- Compile and load the plugin into Revit 2025.
- You can simply start a new file using the "Imperial Multi-Discipline"  template.
- Print using the "All Sheets" view set.
  - A TaskDialog will appear telling you how many sheets are being printed. This uses the event args .GetViewElementIds() method.
  - A second TaskDialog will appear telling you how many sheets are being printed. This uses the doc.PrintManager.ViewSheetSetting.CurrentViewSheetSet.Views property.
- Export to PDF using the "All Sheets" view set.
  - An erorr will be thrown due to the PrintManager being null.
 
