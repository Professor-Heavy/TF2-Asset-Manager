using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager
{
    public class MaterialCorruptionSettings
    {
        public enum CorruptionTypes
        {
            SwapParameters,
            OffsetValues
        }
        public CorruptionTypes CorruptionType { get; set; }
        public bool Enabled { get; set; }
        public int Probability { get; set; }
        //Arguments are defined by a set of strings. It's possible that using another data structure may be better, like how all others use "options".
        public Dictionary<string, string> Arguments { get; set; }
        public List<string> ShaderFilterArray { get; set; }
        public int ShaderFilterMode { get; set; }
        public List<string> ParameterFilterArray { get; set; }
        public int ParameterFilterMode { get; set; }

        public MaterialCorruptionSettings()
        {
            if(Arguments == null)
            {
                Arguments = new Dictionary<string, string>();
            }
        }
    }
}
