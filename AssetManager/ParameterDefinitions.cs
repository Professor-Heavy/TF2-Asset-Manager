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
        private string parameter; // Parameter
        private string paramType; // Parameter's data type
        private dynamic paramValue; // Parameter's value
        private int paramForce;
        private List<string[]> proxyParameterArray = new List<string[]>();
        private List<string> shaderFilterArray = new List<string>();
        private List<string> randomChoiceArray = new List<string>();
        private int shaderFilterMode;
        public string ParamName { get; set; }
        public string Parameter { get; set; }
        public string ParamType { get; set; }
        public dynamic ParamValue { get; set; }
        public int ParamForce { get; set; }
        public int RandomizerChance { get; set; }
        public float RandomizerOffset { get; set; }
        public List<string[]> ProxyParameterArray { get; set; }
        public List<string> ShaderFilterArray { get; set; }
        public int ShaderFilterMode { get; set; }
        public List<string> RandomChoiceArray { get; set; }

        public MaterialParameter(string name,
                                 string parameter,
                                 string type,
                                 dynamic value,
                                 int force = 0,
                                 int chance = 100,
                                 float offset = 0.0f,
                                 List<string> shaderFilters = null,
                                 int filterMode = 0)
        {
            ParamName = name;
            Parameter = parameter;
            ParamType = type;
            ParamValue = value;
            ParamForce = force;
            RandomizerChance = chance;
            RandomizerOffset = offset;
            if (shaderFilters == null)
            {
                ShaderFilterArray = new List<string>();
            }
            else
            {
                ShaderFilterArray = shaderFilters;
            }
            shaderFilterMode = filterMode;
        }
    }

    public class MaterialParameterType
    {
        public string parameterName;
        public string parameterInternalName;
        public Type parameterType;
        public bool isParameterArray;
        public string[] parameterKeys;
        public MaterialParameterType(string parameterName,
                                     string parameterInternalName,
                                     Type parameterType,
                                     bool isParameterArray,
                                     string[] parameterKeys)
        {

        }
    }
}
