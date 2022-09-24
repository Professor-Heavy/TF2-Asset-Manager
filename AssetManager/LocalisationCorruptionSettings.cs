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
    public enum OutOfRangeSolvers
    {
        StrictEnforce,
        Round,
        Bounce
    }
    public struct AsciiSettings
    {
        public int OffsetLow { get; set; }
        public int OffsetHigh { get; set; }
        public bool LowBoundEnabled { get; set; }
        public bool HighBoundEnabled { get; set; }
        public int LowBoundValue { get; set; }
        public int HighBoundValue { get; set; }
        public OutOfRangeSolvers OutOfRangeSolver { get; set; }
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
        public int ProbabilitySeed { get; set; }
        public int RandomSeed { get; set; }
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
