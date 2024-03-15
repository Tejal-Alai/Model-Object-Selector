using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;

namespace ModelSelector
{
    public partial class ModelSelectorForm : PluginFormBase
    {
        public static Tekla.Structures.Model.Model ActiveModel;
        public static string selectedCreateExcahngeByOption;
        private CreateSelectionSet createSelectionSet = new CreateSelectionSet();
        public ModelSelectorForm()
        {
            InitializeComponent();
        }

        //Remember to assign these events to the buttons.

        private void ModelSelectorForm_Load(object sender, EventArgs e)
        {

        }

        private void selectModelObjects_Click(object sender, EventArgs e)
        {
            List<ModelObject> modelObject = new List<ModelObject>();
            List<ModelObject> primitiveList = new List<ModelObject>();
            createSelectionSet.GetSelectedObjectAsync(selectedCreateExcahngeByOption, ActiveModel, out primitiveList);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        internal void createSelectionSet_Click(object sender, EventArgs e)
        {
            List<ModelObject> modelObject = new List<ModelObject>();
            List<ModelObject> primitiveList = new List<ModelObject>();
            List<ModelObject> listOfSelectedObjects=createSelectionSet.GetSelectedObjectAsync(selectedCreateExcahngeByOption, ActiveModel, out primitiveList);
            foreach (var selectedObject in listOfSelectedObjects)
            {
                string objectguid = new Model().GetGUIDByIdentifier(selectedObject.Identifier);
                string filepath = "../../../JsonData/Read/SelectModelObjects/guidOfObject.json";
                string jsonString = JsonConvert.SerializeObject(objectguid, Formatting.Indented);
                File.WriteAllText(filepath, jsonString);
            }
           
        }
    }
}
