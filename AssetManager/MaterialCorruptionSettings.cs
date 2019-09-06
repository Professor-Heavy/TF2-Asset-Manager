using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager
{
    public class MaterialCorruptionSettings
    {
        private enum CorruptionTypes
        {
            SwapParameters
        }
        public int CorruptionType { get; set; }
        public bool Enabled { get; set; }
        public int Probability { get; set; }
        public string Arguments { get; set; }
        public List<string> ShaderFilterArray { get; set; }
        public int ShaderFilterMode { get; set; }
        public List<string> ParameterFilterArray { get; set; }
        public int ParameterFilterMode { get; set; }

        public MaterialCorruptionSettings()
        {

        }
    }
}
