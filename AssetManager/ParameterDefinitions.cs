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
        private string paramForce;
        // 0 = Only overwrite existing parameters- do not write to file if the parameter isn't there.
        // 1 = If compatible with the shader used, ALWAYS use this parameter.
        public string ParamName { get => paramName; set => paramName = value; }
        public string Parameter { get => parameter; set => parameter = value; }
        public string ParamType { get => paramType; set => paramType = value; }
        public string ParamValue { get => paramValue; set => paramValue = value; }
        public MaterialParameter(string name, string parameter, string type, string value)
        {
            this.paramName = name;
            this.parameter = parameter;
            this.paramType = type;
            this.paramValue = value;
        }
    }
}
