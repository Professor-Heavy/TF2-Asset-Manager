using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssetManager
{
    public class SoundscriptInteraction
    {

        static public SoundscriptEntry ReplaceSoundscriptFileEntry(SoundscriptEntry input, SoundParameter soundParameter, Random random)
        {
            if(input.isRndWave)
            {
                if (soundParameter.ReplaceUsingRndWave)
                {
                    input.rndWave = soundParameter.Sounds.Select(x => ConvertLocationToRelative(x.fileLocation)).ToArray();
                }
                else
                {
                    for(int i = 0; i < input.rndWave.Length; i++)
                    {
                        input.rndWave[i] = ConvertLocationToRelative(soundParameter.Sounds[random.Next(0, soundParameter.Sounds.Count)].fileLocation);
                    }
                }
            }
            else
            {
                if(soundParameter.ReplaceUsingRndWave)
                {
                    input.isRndWave = true;
                    input.rndWave = soundParameter.Sounds.Select(x => ConvertLocationToRelative(x.fileLocation)).ToArray();
                }
                else
                {
                    input.wave = ConvertLocationToRelative(soundParameter.Sounds[random.Next(0, soundParameter.Sounds.Count)].fileLocation);
                }
            }
            return input;
        }

        static string ConvertLocationToRelative(string soundLocation)
        {
            return "exported\\" + System.IO.Path.GetFileName(soundLocation);
        }
    }
}
