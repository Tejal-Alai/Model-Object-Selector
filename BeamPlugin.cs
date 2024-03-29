﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Plugins;

namespace ModelSelector
{
    /// <summary>
    /// This is the same example found in the Open API Reference PluginBase section, 
    /// but implemented using Windows Forms. The plugin asks the user to pick two points.
    /// The plug-in then calculates new insertion points using a double parameter from the 
    /// dialog and creates a beam.
    /// </summary>
    [Plugin("ModelSelector")] // Mandatory field which defines that the class is a plug-in-and stores the name of the plug-in to the system.
    [PluginUserInterface("ModelSelector.ModelSelectorForm")] // Mandatory field which defines the user interface the plug-in uses. A windows form class of a .inp file.
    public class ModelSelector : PluginBase
    {
        private Object sender = new Object();
        private EventArgs e = new EventArgs();
        private StructuresData Data { get; set; }

        private double _lengthFactor;
        private string _profile;

        public BeamBuilder BeamBuilder = new BeamBuilder();
        public InputService InputService = new InputService();
        public PointBuilder PointBuilder = new PointBuilder();
        public ModelSelectorForm modelSelectorForm = new ModelSelectorForm();

        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public ModelSelector(StructuresData data)
        {
            //MessageBox.Show("MainPlugin Constructor");
            //MessageBox.Show(JsonConvert.SerializeObject(data));
            //modelSelectorForm.Show();
            //modelSelectorForm.createSelectionSet_Click(sender,e);
            Data = data;
        }
        
        //Defines the inputs to be passed to the plug-in.
        public override List<InputDefinition> DefineInput()
        {
            return InputService.GetInputDefinitions();
        }


        // Gets the values from the dialog and sets the default values if needed
        private void GetValuesFromDialog()
        {
            _lengthFactor = Data.LengthFactor;
            _profile = Data.Profile;

            if (IsDefaultValue(_lengthFactor))
            {
                _lengthFactor = 2.0;
            }
            if (IsDefaultValue(_profile))
            {
                _profile = "HEA300";
            }
            //modelSelectorForm.createSelectionSet_Click(sender, e);
        }

        //Main method of the plug-in.
        public override bool Run(List<InputDefinition> inputs)
        {
            try
            {
                if (inputs == null || inputs.Count < 2) return false;

                GetValuesFromDialog();

                var points = PointBuilder.GetPoints(inputs, _lengthFactor);

                if (points == null || points.Count < 2) return false;

                BeamBuilder.CreateBeam(points[0], points[1], _profile, "PAINT", "MyBeam01");
                //modelSelectorForm.createSelectionSet_Click(sender, e);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return true;
        }
    }
}
