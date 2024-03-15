using Tekla.Structures.Plugins;

namespace ModelSelector
{
    public class StructuresData
    {
        [StructuresField("LengthFactor")]
        public double LengthFactor;

        [StructuresField("Profile")]
        public string Profile;
    }
}