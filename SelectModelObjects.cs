using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tekla.Structures.Model;

namespace ModelSelector
{

    public class SelectModelObjects
    {
        private CreateSelectionSet createSelectionSet = new CreateSelectionSet();
        string jsonPath = "../../../JsonData/Read/SelectModelObjects/guidOfObject.json";
        string jsonString = File.ReadAllText(jsonPath);
        List<string> guids = JsonConvert.DeserializeObject<List<string>>(jsonString);
        public void SelectElements(List<string> exchangeIds)
        {
            List<string> objIDs = new List<string>();
            bool IsFromRead = true;
            
            for (int readArrayIndex = 0; readArrayIndex < guids.Count; readArrayIndex++)
            {
                string guids = readArrayIndex.ToString();

            }

            if (IsFromRead)
            {
                for (int writeArrayIndex = 0; writeArrayIndex < guids.Count; writeArrayIndex++)
                {

                    string guids = writeArrayIndex.ToString();

                }
            }

            SelectAndZoomElement(guids);
        }

        private void SelectAndZoomElement(List<string> selectedObjectIds)
        {
            ArrayList objectsToSelect = new ArrayList();
            Tekla.Structures.Model.UI.ModelObjectSelector modelobjselectorobj = new Tekla.Structures.Model.UI.ModelObjectSelector();
            try
            {
                foreach (string ObjectId in selectedObjectIds)
                {
                    Tekla.Structures.Identifier identifier = createSelectionSet.ActiveModel.GetIdentifierByGUID(ObjectId);
                    ModelObject modelObject = createSelectionSet.ActiveModel.SelectModelObject(identifier);
                    objectsToSelect.Add(modelObject);
                }
            }
            catch (System.ArgumentException ex)
            { // TODO : need to handle properly
            }
            modelobjselectorobj.Select(objectsToSelect);
            Tekla.Structures.ModelInternal.Operation.dotStartAction("ZoomToSelected", "");
        }
    }
}
