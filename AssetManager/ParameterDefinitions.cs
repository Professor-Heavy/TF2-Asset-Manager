using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AssetManager
{
    public class MaterialParameter
    {
        private string paramName; // Parameter's name
        private string parameter; // Parameter
        private string paramType; // Parameter's data type
        private string paramValue; // Parameter's value
        private int randomizerChance; // Chance of being applied to the material (determined at runtime)
        private float randomizerOffset; // Offset of value in randomization
        private string paramForce;
        // 0 = Only overwrite existing parameters- do not write to file if the parameter isn't there.
        // 1 = If compatible with the shader used, ALWAYS use this parameter.
        public string ParamName { get => paramName; set => paramName = value; }
        public string Parameter { get => parameter; set => parameter = value; }
        public string ParamType { get => paramType; set => paramType = value; }
        public string ParamValue { get => paramValue; set => paramValue = value; }
        public int RandomizerChance { get => randomizerChance; set => randomizerChance = value; }
        public float RandomizerOffset { get => randomizerOffset; set => randomizerOffset = value; }
        public MaterialParameter(string name, string parameter, string type, string value, int chance = 100, float offset = 0.0f)
        {
            paramName = name;
            this.parameter = parameter;
            paramType = type;
            paramValue = value;
            randomizerChance = chance;
            randomizerOffset = offset;
        }
    }
}
