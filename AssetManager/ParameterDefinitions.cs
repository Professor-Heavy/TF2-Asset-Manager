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
        private MaterialParameterType paramType; // Parameter's data type
        private dynamic paramValue; // Parameter's value
        private int paramForce;
        private List<string[]> proxyParameterArray = new List<string[]>();
        private List<string> shaderFilterArray = new List<string>();
        private List<string> randomChoiceArray = new List<string>();
        private int shaderFilterMode;
        public string ParamName { get; set; }
        public string Parameter { get; set; }
        public MaterialParameterType ParamType
        {
            get;
            set;
        }
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
                                 MaterialParameterType type,
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
        static public List<MaterialParameterType> materialParameterTypeList = new List<MaterialParameterType>()
        {
            new MaterialParameterType("Integer", "integer", typeof(int)),
            new MaterialParameterType("String", "string", typeof(string)),
            new MaterialParameterType("Bool", "boolean", typeof(int)),
            new MaterialParameterType("Vector 3", "vector3", typeof(string)),
            new MaterialParameterType("Material Proxy", "proxy", typeof(string), "proxy", new string[] { "key","value" }),
            new MaterialParameterType("Random Choice", "choices", typeof(string), "choice")
        };
        
        private readonly string ParameterName;
        private readonly string ParameterInternalName;
        private readonly Type ParameterType;
        public readonly string ArrayElementKeys;
        public readonly string[] AttributeKeys;

        public MaterialParameterType(string parameterName,
                                     string parameterInternalName,
                                     Type parameterType,
                                     string arrayElementKeys = null,
                                     string[] attributeKeys = null
                                     )
        {
            ParameterName = parameterName;
            ParameterInternalName = parameterInternalName;
            ParameterType = parameterType;
            ArrayElementKeys = arrayElementKeys;
            AttributeKeys = attributeKeys;
        }

        public bool UsesArrays
        {
            get
            {
                return ArrayElementKeys != null;
            }
        }

        public bool UsesAttributes
        {
            get
            {
                return AttributeKeys != null;
            }
        }

        public static MaterialParameterType GetMaterialParameterType(string input)
        {
            return materialParameterTypeList.Find(x => x.ParameterInternalName == input);
        }

        public override string ToString()
        {
            return ParameterInternalName;
        }
    }
}
