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
        private int paramForce;
        // 0 = If compatible with the shader used (todo), ALWAYS use this parameter.
        // 1 = Only overwrite existing parameters- do not write to file if the parameter isn't there.
        // 2 - Do not overwrite, only use where the parameter is not present.
        private int randomizerChance; // Chance of being applied to the material (determined at runtime)
        private float randomizerOffset; // Offset of value in randomization
        private List<string[]> proxyParameterArray = new List<string[]>();
        private List<string> shaderFilterArray = new List<string>();
        private int shaderFilterMode;
        public string ParamName { get => paramName; set => paramName = value; }
        public string Parameter { get => parameter; set => parameter = value; }
        public string ParamType { get => paramType; set => paramType = value; }
        public string ParamValue { get => paramValue; set => paramValue = value; }
        public int ParamForce { get => paramForce; set => paramForce = value; }
        public int RandomizerChance { get => randomizerChance; set => randomizerChance = value; }
        public float RandomizerOffset { get => randomizerOffset; set => randomizerOffset = value; }
        public List<string[]> ProxyParameterArray { get => proxyParameterArray; set => proxyParameterArray = value; }
        public List<string> ShaderFilterArray { get => shaderFilterArray; set => shaderFilterArray = value; }
        public int ShaderFilterMode { get => shaderFilterMode; set => shaderFilterMode = value; }

        public MaterialParameter(string name,
                                 string parameter,
                                 string type,
                                 string value,
                                 int force = 0,
                                 int chance = 100,
                                 float offset = 0.0f,
                                 List<string[]> proxyParameters = null,
                                 List<string> shaderFilters = null,
                                 int filterMode = 0)
        {
            paramName = name;
            this.parameter = parameter;
            paramType = type;
            paramValue = value;
            paramForce = force;
            randomizerChance = chance;
            randomizerOffset = offset;
            if (proxyParameters == null)
            {
                proxyParameterArray = new List<string[]>
                {
                    new string[2]
                };
            }
            else
            {
                proxyParameterArray = proxyParameters;
            }

            if (shaderFilters == null)
            {
                shaderFilterArray = new List<string>();
            }
            else
            {
                shaderFilterArray = shaderFilters;
            }
            shaderFilterMode = filterMode;
        }
    }
}
