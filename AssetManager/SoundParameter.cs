using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager
{
    public enum SoundActions
    {
        ReplaceFileEntry,
        ModifySoundscript,
        ReplaceFileDirect
    }

    public class SoundParameter
    {
        public string ParamName { get; set; }
        public string Regex { get; set; }
        public SoundActions Actions { get; set; }
        public List<SoundFileEntry> Sounds { get; set; }
        //Redundant in the event that sound files aren't required. No stranger to this by now though.
        public SoundscriptEntry? Entry { get; set; }
        //The redundancy is set to be resolved soon, so no need to worry about any hacky methods used to change this entry
        //It is forcing it to be nullable, after all, of course hacky methods being used
        public bool ReplaceUsingRndWave { get; set; }
        public int RandomizerChance { get; set; }
        public int RandomizerChanceSeed { get; set; }

        public SoundParameter(string name,
                              string regex,
                              SoundActions actions,
                              SoundscriptEntry? soundscriptEntry = null,
                              List<SoundFileEntry> sounds = null,
                              bool replaceUsingRndWave = false,
                              int chance = 100,
                              int chanceSeed = -1)
        {
            ParamName = name;
            Regex = regex;
            Actions = actions;
            RandomizerChance = chance;
            ReplaceUsingRndWave = replaceUsingRndWave;
            Entry = soundscriptEntry;
            RandomizerChanceSeed = chanceSeed;
            if (sounds == null)
            {
                Sounds = new List<SoundFileEntry>();
            }
            else
            {
                Sounds = sounds;
            }
        }
    }

    public class SoundParameterType
    {
        static public List<SoundParameterType> soundParameterTypeList = new List<SoundParameterType>()
        {
            new SoundParameterType("Replace Soundscript Entry Files", "replacesoundscript"),
            new SoundParameterType("Modify Soundscript Values", "modifysoundscript"),
            new SoundParameterType("Replace Sound File", "replacesoundfile")
        };

        public string ParameterName { get; }
        public string ParameterInternalName { get; }
        public Type ParameterType { get; }

        public SoundParameterType(string parameterName,
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

    public struct SoundFileEntry
    {
        //TODO: This "id" has ambiguous use, and is currently being flung around without any meaning.
        public int id;
        public string fileLocation;
    }
}
