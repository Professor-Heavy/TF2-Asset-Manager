using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AssetManager
{
    public enum MatchActions
    {
        Replace,
        UpperCase,
        LowerCase,
        InvertCase
    }
    public class LocalisationParameter
    {
        public string ParamName { get; set; }
        public string Regex { get; set; }
        public MatchActions Actions { get; set; }
        public string ReplaceString { get; set; }
        public int RandomizerChance { get; set; }
        public int RandomizerIndividualChance { get; set; }
        public bool LetterCountFilterMode { get; set; }
        public int LetterCountFilterMin { get; set; }
        public int LetterCountFilterMax { get; set; }
        public bool SafeMode { get; set; }
        public bool UsesRegex { get; set; }

        public LocalisationParameter(string name,
                                     string regex,
                                     MatchActions actions,
                                     string replaceString = null,
                                     int chance = 100,
                                     int individualChance = 100,
                                     bool letterCountFilterMode = false,
                                     int letterCountFilterMin = 0,
                                     int letterCountFilterMax = 0,
                                     bool safeMode = true,
                                     bool usesRegex = true)
        {
            ParamName = name;
            Regex = regex;
            Actions = actions; //TODO: Come back to this and find out exactly why I used an enumerator rather than the type thing I did for Materials...
            ReplaceString = replaceString;
            RandomizerChance = chance;
            RandomizerIndividualChance = individualChance;
            LetterCountFilterMode = letterCountFilterMode;
            LetterCountFilterMin = letterCountFilterMin;
            LetterCountFilterMax = letterCountFilterMax;
            SafeMode = safeMode;
            UsesRegex = usesRegex;
        }
    }
    public class LocalisationParameterType
    {
        static public List<LocalisationParameterType> localisationParameterTypeList = new List<LocalisationParameterType>()
        {
            new LocalisationParameterType("Replace Characters", "replacechar"),
            new LocalisationParameterType("Replace with Upper Case", "uppercase"),
            new LocalisationParameterType("Replace with Lower Case", "lowercase"),
            new LocalisationParameterType("Invert Case", "invertcase")
        };

        public string ParameterName { get; }
        public string ParameterInternalName { get; }
        public Type ParameterType { get; }
        public readonly string ArrayElementKeys;
        public readonly string[] AttributeKeys;
        public bool Delimiter { get; }

        public LocalisationParameterType(string parameterName,
                                     string parameterInternalName)
        {
            ParameterName = parameterName;
            ParameterInternalName = parameterInternalName;
        }

        public override string ToString()
        {
            return ParameterInternalName;
        }
    }
}
