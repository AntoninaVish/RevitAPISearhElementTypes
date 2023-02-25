using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPISearhElementTypes
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //поиск типов дверей в текущем  документе
            //FamilySymbol - это тип семейства
            List<FamilySymbol> doorTypes = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Doors)
                .WhereElementIsElementType()//собираем именно по типам!!
                .Cast<FamilySymbol>() //преобразуем в FamilySymbol
                .ToList();// список

            TaskDialog.Show("Door types info", doorTypes.Count.ToString());


            return Result.Succeeded;
        }
    }
}
