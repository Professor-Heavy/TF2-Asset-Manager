using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;


namespace AssetManager
{
    public class WAVInteraction
    {
        public enum SoundType
        {
            Wave,
            MP3,
            Unknown
        }
        static SoundType currentType;
        static string fileLocation;
        static bool isPlaying;

        static WaveOutEvent outputDevice;
        static AudioFileReader audioFile;

        /// <summary>
        /// Assign a sound to the singleton sound player. Returns false if the sound is already playing.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static bool AssignNewSound(string location)
        {
            if (fileLocation == location && isPlaying)
            {
                return false;
            }
            currentType = GetSoundType(location);
            fileLocation = location;
            return true;
        }

        public static void PlaySound()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(fileLocation);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
            isPlaying = true;
        }

        public static void StopSound()
        {
            outputDevice.Stop();
        }

        private static void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            isPlaying = false;
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        public static SoundType GetSoundType(string location)
        {
            switch (System.IO.Path.GetExtension(location))
            {
                case ".wav":
                    return SoundType.Wave;
                case ".mp3":
                    return SoundType.MP3;
                default:
                    return SoundType.Unknown;
            }
        }

        public static int CheckSampleRate(string location)
        {
            try
            {
                SoundType inputType = GetSoundType(location);

                switch (inputType)
                {
                    case SoundType.Wave:
                        WaveFileReader wavReader = new WaveFileReader(location);
                        return wavReader.WaveFormat.SampleRate;
                    case SoundType.MP3:
                        Mp3FileReader mp3Reader = new Mp3FileReader(location);
                        return mp3Reader.Mp3WaveFormat.SampleRate;
                    case SoundType.Unknown:
                        break;
                    default:
                        break;
                }
                return -2;
            }
            catch
            {
                return -2;
            }
        }

        public static int CheckBitRate(string location)
        {
            try
            {
                SoundType inputType = GetSoundType(location);
                switch (inputType)
                {
                    case SoundType.Wave:
                        WaveFileReader wavReader = new WaveFileReader(location);
                        return wavReader.WaveFormat.BitsPerSample;
                    case SoundType.MP3:
                        Mp3FileReader mp3Reader = new Mp3FileReader(location);
                        return mp3Reader.Mp3WaveFormat.BitsPerSample;
                    case SoundType.Unknown:
                        break;
                    default:
                        break;
                }
                return -1;
            }
            catch
            {
                return -2;
            }
        }
    }
}
