using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace ModelSelector
{
   internal class CreateSelectionSet
    {
        public Tekla.Structures.Model.Model ActiveModel;
        internal HashSet<string> UnsupportedItems = new HashSet<string>();
        public static List<string> guidsList = new List<string>();
        
        internal void CheckUnsupportedItemsAndLog(ModelObject modelObject, ref int unsupportedItemsCount)
        {
            if (!(modelObject is ControlPoint || modelObject is HierarchicDefinition || modelObject is HierarchicObject || modelObject is GridPlane || modelObject is Grid || modelObject is LoadGroup))
            {
                unsupportedItemsCount++;
               Console.WriteLine("Unsupported Items");
                UnsupportedItems.Add(modelObject.GetType().Name);
            }
        }

        public List<ModelObject> GetSelectedObjectAsync(string selectedCreateExcahngeByOption, Model model, out List<ModelObject> primitiveList)
        {
            int UnsupportedItemsCount = 0;
            List<ModelObject> SelectedObject = new List<ModelObject>();
            primitiveList = new List<ModelObject>();

            ModelObjectEnumerator modelObject = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();

            foreach (ModelObject obj in modelObject)
            {
                if (obj is ControlLine || obj is ControlPoint || obj is ControlPolycurve || obj is ControlCircle || obj is ControlArc || obj is ControlPlane)
                {
                    primitiveList.Add(obj);
                }
                else
                {

                    if (obj is Assembly)
                    {
                        Assembly assembly = obj as Assembly;
                        ArrayList arrayList = assembly.GetSecondaries();
                        if (arrayList.Count == 0)
                        {
                            Part MainObject = assembly.GetMainPart() as Part;

                            if (MainObject != null)
                            {
                                if (MainObject.GetReinforcements().GetSize() == 0)
                                {
                                    guidsList.Add(MainObject.Identifier.GUID.ToString());
                                    SelectedObject.Add(MainObject);
                                }
                            }
                        }
                        else
                        {
                            if (assembly != null)
                            {
                                SelectedObject.Add(assembly);
                                guidsList.Add(assembly.Identifier.GUID.ToString());
                            }
                        }
                    }
                    else if (obj is Part)
                    {
                        if ((obj as Part).GetReinforcements().GetSize() == 0)
                        {
                            SelectedObject.Add(obj);
                            guidsList.Add(obj.Identifier.GUID.ToString());
                        }
                    }
                    else
                    {
                        CheckUnsupportedItemsAndLog(obj, ref UnsupportedItemsCount);
                    }
                }
            }
            if (UnsupportedItemsCount > 0)
            {
                Console.WriteLine("unsupported items");
            }


            return SelectedObject;
        }

    }
    
}
