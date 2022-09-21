using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager
{
    public enum Channels
    {
        CHAN_AUTO,
        CHAN_WEAPON,
        CHAN_VOICE,
        CHAN_ITEM,
        CHAN_BODY,
        CHAN_STREAM,
        CHAN_STATIC,
        CHAN_VOICE2,
        Unchanged
    }
    public struct SoundscriptEntry
    {
        public string name;
        public Channels channel;
        public string volume;
        public string pitch;
        public string soundlevel;
        public bool isRndWave;
        public string wave;
        public string[] rndWave;
    }

    internal class SoundscriptReader : IDisposable
    {
        StringReader sr;

        //As far as I know, the VDF application is only capable of reading a single VDF structure.
        //Not too knowledgable on readers, and this seems to be a poor implementation.
        enum CurrentState
        {
            Start,
            Seeking,
            Name,
            Reading,
            Key,
            SeekingMatchingValue,
            Value,
            Previous,
            End
        }

        enum CurrentKey
        {
            Channel,
            Volume,
            Pitch,
            SoundLevel,
            RndWave,
            Wave,
            Unknown
        }

        CurrentState state;
        CurrentKey key;
        bool searchingForMultWaves;
        string keyString;
        List<string> rndWaveList;
        List<SoundscriptEntry> soundscriptEntries;
        SoundscriptEntry currentSoundscriptEntry;

        public SoundscriptReader(string input)
        {
            sr = new StringReader(input);
            soundscriptEntries = new List<SoundscriptEntry>();
            InitializeSoundscriptEntry();
        }

        char[] buffer = new char[512];
        char[] entryBuffer = new char[256]; //Tokens cannot exceed this. Surely.

        int bufferLength = 0;
        int bufferPos = 0;
        int entryLength = 0;

        public SoundscriptEntry[] ReadToEnd()
        {
            state = CurrentState.Seeking;
            Read();
            return soundscriptEntries.ToArray();
        }

        /// <summary>
        /// Reads a character. Returns true if there's something to read, false if EOF.
        /// </summary>
        /// <returns></returns>
        void Read()
        {
            while (ContinueBuffer())
            {
                Seek();
            }
        }

        void Seek()
        {
            char bufferedChar = buffer[bufferPos];
            //HACK: We CANNOT skip ahead in the buffer.
            //This will be limited.to a single slash, which should hopefully never be found outside tokens.
            if (bufferedChar == '/')
            {
                bufferPos++;
                SkipToNewline();
            }
            if (bufferedChar == '{')
            {
                bufferPos++;
                if(state == CurrentState.SeekingMatchingValue)
                {
                    //If we're already seeking a value, this will appear if there's a rndwave.
                    searchingForMultWaves = true;
                }
                state = CurrentState.Reading;
            }
            if (bufferedChar == '}')
            {
                bufferPos++;
                if (searchingForMultWaves)
                {
                    searchingForMultWaves = false;
                    currentSoundscriptEntry.rndWave = rndWaveList.ToArray();
                }
                else
                {
                    RefreshSoundscriptEntry();
                    state = CurrentState.Seeking;
                }
            }
            if (bufferedChar == '"')
            {
                if(state == CurrentState.SeekingMatchingValue)
                {
                    state = CurrentState.Value;
                }
                if (state == CurrentState.Reading)
                {
                    state = CurrentState.Key;
                }
                if (state == CurrentState.Seeking)
                {
                    state = CurrentState.Name;
                }
                if (ReadEntry())
                {
                    switch (state)
                    {
                        case CurrentState.Name:
                            state = CurrentState.Seeking;
                            break;
                        case CurrentState.Key:
                            state = CurrentState.SeekingMatchingValue;
                            break;
                        case CurrentState.Value:
                            state = CurrentState.Reading;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                bufferPos++;
            }
        }

        bool ReadEntry()
        {
            entryLength = 0;
            bufferPos++;
            while (ContinueBuffer())
            {
                char bufferedChar = buffer[bufferPos];
                //It could fail any kind of case in where Valve for some reason inserts a comment inside of the entry, but... Valve. Don't.
                if (bufferedChar == '"')
                {
                    if (state == CurrentState.Name)
                    {
                        currentSoundscriptEntry.name = new string(entryBuffer, 0, entryLength);
                    }
                    if (state == CurrentState.Key)
                    {
                        AssignKey(new string(entryBuffer, 0, entryLength));
                    }
                    if(state == CurrentState.Value)
                    {
                        AssignValue(new string(entryBuffer, 0, entryLength));
                    }
                    bufferPos++;
                    return true;
                }
                entryBuffer[entryLength++] = bufferedChar;
                bufferPos++;
            }
            return false;
        }

        /// <summary>
        /// Skips to the newline.
        /// </summary>
        /// <returns></returns>
        bool SkipToNewline()
        {
            while (ContinueBuffer())
            {
                char bufferedChar = buffer[bufferPos];
                bufferPos++;
                if (bufferedChar == '\n' || bufferedChar == '\r')
                {
                    return true;
                }
            }
            return false;
        }

        bool ContinueBuffer()
        {
            if(bufferPos < bufferLength)
            {
                return true;
            }
            bufferLength = sr.Read(buffer, 0, 512);
            bufferPos = 0;
            return bufferLength != 0;
        }

        void RefreshSoundscriptEntry()
        {
            soundscriptEntries.Add(currentSoundscriptEntry);
            currentSoundscriptEntry = new SoundscriptEntry();
            InitializeSoundscriptEntry();
        }

        void InitializeSoundscriptEntry()
        {
            currentSoundscriptEntry.channel = Channels.CHAN_AUTO;
            currentSoundscriptEntry.pitch = "100";
            currentSoundscriptEntry.volume = "1";
            currentSoundscriptEntry.soundlevel = "SNDLVL_NORM";
        }

        Channels ValueToChannelEnum(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "chan_auto":
                    return Channels.CHAN_AUTO;
                case "chan_weapon":
                    return Channels.CHAN_WEAPON;
                case "chan_voice":
                    return Channels.CHAN_VOICE;
                case "chan_item":
                    return Channels.CHAN_ITEM;
                case "chan_body":
                    return Channels.CHAN_BODY;
                case "chan_stream":
                    return Channels.CHAN_STREAM;
                case "chan_static":
                    return Channels.CHAN_STATIC;
                case "chan_voice2":
                    return Channels.CHAN_VOICE2;
                default:
                    Console.WriteLine("Usding default for unknown channel " + value);
                    return Channels.CHAN_AUTO;
            }
        }

        void AssignKey(string keyString)
        {
            string keyCaseInsensitive = keyString.ToLowerInvariant();
            switch (keyCaseInsensitive)
            {
                case "channel":
                    key = CurrentKey.Channel;
                    break;
                case "volume":
                    key = CurrentKey.Volume;
                    break;
                case "pitch":
                    key = CurrentKey.Pitch;
                    break;
                case "soundlevel":
                case "attenuation":
                    //Attenuation and soundlevel are interchangable and yet they're used in certain files.
                    key = CurrentKey.SoundLevel;
                    break;
                case "rndwave":
                    key = CurrentKey.RndWave;
                    currentSoundscriptEntry.isRndWave = true;
                    rndWaveList = new List<string>();
                    break;
                case "wave":
                    key = CurrentKey.Wave;
                    break;
                default:
                    key = CurrentKey.Unknown;
                    break;
            }
        }

        void AssignValue(string value)
        {
            try
            {
                switch (key)
                {
                    case CurrentKey.Channel:
                        currentSoundscriptEntry.channel = ValueToChannelEnum(value);
                        break;
                    case CurrentKey.Volume:
                        currentSoundscriptEntry.volume = value;
                        break; 
                    case CurrentKey.Pitch:
                        currentSoundscriptEntry.pitch = value;
                        break;
                    case CurrentKey.SoundLevel:
                        currentSoundscriptEntry.soundlevel = value;
                        break;
                    case CurrentKey.RndWave:
                        break;
                    case CurrentKey.Wave:
                        if (currentSoundscriptEntry.isRndWave)
                        {
                            rndWaveList.Add(value);
                        }
                        else
                        {
                            currentSoundscriptEntry.wave = value;
                        }
                        break;
                    case CurrentKey.Unknown:
                        throw new Exception("Found an unknown key in soundscript.");
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            sr.Dispose();
        }
    }
}
