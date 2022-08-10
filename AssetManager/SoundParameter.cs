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
        ModifySoundscript
    }

    public class SoundParameter
    {
        public string ParamName { get; set; }
        public string Regex { get; set; }
        public SoundActions Actions { get; set; }
        public List<SoundFileEntry> Sounds { get; set; }
        //Redundant in the event that sound files aren't required. No stranger to this by now though.
        public bool ReplaceUsingRndWave { get; set; }
        public int RandomizerChance { get; set; }

        public SoundParameter(string name,
                              string regex,
                              SoundActions actions,
                              List<SoundFileEntry> sounds = null,
                              bool replaceUsingRndWave = false,
                              int chance = 100)
        {
            ParamName = name;
            Regex = regex;
            Actions = actions;
            RandomizerChance = chance;
            ReplaceUsingRndWave = replaceUsingRndWave;
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
            //new SoundParameterType("Modify Soundscript Values", "modifysoundscript")
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
        public int id;
        public string fileLocation;
    }
}
