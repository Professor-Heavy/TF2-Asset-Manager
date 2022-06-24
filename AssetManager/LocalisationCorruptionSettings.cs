using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager
{
    public struct LanguageSettings
    {
        public bool Enabled { get; set; }
        public string Language { get; set; }
        public bool OverrideRegex { get; set; }
        public string OverrideRegexString { get; set; }
        public bool OverrideWeight { get; set; }
        public float OverrideWeightValue { get; set; }
        public override string ToString()
        {
            return Language;
        }
    }
    public class LocalisationCorruptionSettings
    {
        public enum CorruptionTypes
        {
            SwapEntries,
            SwapLanguage,
            OffsetAscii,
            ScrambleString
        }
        public CorruptionTypes CorruptionType { get; set; }
        public bool Enabled { get; set; }
        public int Probability { get; set; }
        public Dictionary<string, string> Arguments { get; set; }
        public List<string> KeyFilterArray { get; set; }
        public int KeyFilterMode { get; set; }
        public bool RegularExpressionEnabled { get; set; }
        public string RegularExpressionPattern { get; set; }
        public int RegularExpressionMode { get; set; }
        public bool SafeMode { get; set; }
        public bool SkipUnsafeEntries { get; set; }
        public bool IgnoreNewlines { get; set; }

        public LocalisationCorruptionSettings()
        {
            if(Arguments == null)
            {
                Arguments = new Dictionary<string, string>();
            }
        }
    }
}
