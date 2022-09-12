using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssetManager
{
    class TXTInteraction
    {
        const string localisationGroupingPattern = @"""(.*?)""\s*""([^""\\]*(?:\\.[^""\\]*)*)"".*\n";
        //Note: This string uses specialised characters that will not be visible.
        /* Quoted from the localisation file:
          = 0x02 (STX) - Use team color up to the end of the player name.  This only works at the start of the string, and precludes using the other control characters.
          = 0x03 (ETX) - Use team color from this point forward
          = 0x04 (EOT) - Use location color from this point forward
          = 0x05 (ENQ) - Use achievement color from this point forward
          = 0x01 (SOH) - Use normal color from this point forward
        */
        public const string localisationSpecialCharacters = @"([\\][n]|%s[1-8]||||||%(?:[a-z]|_)*%)";
        public const string localisationSpecialCharactersExcludingNewline = @"(%s[1-8]||||||%(?:[a-z]|_)*%)";

        static public string[] CheckLanguages(string executableDirectory, bool fileNameOnly)
        {
            try
            {
                string[] files = Directory.GetFiles(Path.Combine(executableDirectory, "tf\\resource"), "tf_*.txt");
                List<string> languages = new List<string>();
                if(fileNameOnly)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if(files[i].Contains("tf_proto_") || files[i].Contains("tf_quests_"))
                        {
                            continue;
                        }
                        languages.Add(Path.GetFileName(files[i]));
                    }
                }
                else
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Contains("tf_proto_") || files[i].Contains("tf_quests_"))
                        {
                            continue;
                        }
                        languages.Add(files[i]);
                    }
                }

                return languages.ToArray();
            }
            catch(Exception ex)
            {
                throw ex; //Let's hope this never happens. But just in case it could...
                //return null; 
            }
        }
        static public int VerifyParameter(LocalisationParameter parameter)
        {
            if (parameter.Actions == MatchActions.Replace && (parameter.Regex == string.Empty || !parameter.UsesRegex))
            {
                return 0; //Missing fields.
            }
            if(parameter.UsesRegex)
            {
                try
                {
                    new Regex(parameter.Regex);
                }
                catch
                {
                    return 1; //Erroneous Regex
                }
            }
            if (parameter.LetterCountFilterMode && (parameter.LetterCountFilterMax < parameter.LetterCountFilterMin))
            {
                return 2; //Min letter count is greater than Max
            }
            return -1; //Consider implementing a more verbose system.
        }
        static public MatchCollection PerformSingleRegexTest(string input, string regex)
        {
            return Regex.Matches(input, regex, RegexOptions.Multiline);
        }
        static public Dictionary<string, string> PerformRegexTest(string input)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (Match m in Regex.Matches(input, localisationGroupingPattern, RegexOptions.Multiline))
            {
                //HACK TODO: Performing a check on a collection value just for a single case scenario is something I should... absolutely not do.
                //This is a high priority fix. Perhaps change the input to not include the first section in the first place.
                if (m.Groups[1].Value == "Language")
                {
                    continue;
                }
                if (results.ContainsKey(m.Groups[1].Value))
                {
                    //This is a weird occurrence.
                    Console.WriteLine("Localisation token " + m.Groups[1].Value + " was repeated in the localisation file. Ignoring.");
                    continue;
                }
                results.Add(m.Groups[1].Value, m.Groups[2].Value);
            }
            return results;
        }

        static public bool SpecialCharacterCheck(string input, bool emptyCheck, bool ignoreNewline = true)
        {
            if(emptyCheck)
            {
                emptyCheck = string.IsNullOrWhiteSpace(input);
                //By reassigning this variable, the code is confusing, but it saves having to make a new one.
                //Even if the empty check returns false, it's basically the same as if the check never existed at all.
            }
            if(Regex.Matches(input, ignoreNewline ? localisationSpecialCharactersExcludingNewline : localisationSpecialCharacters, RegexOptions.Multiline).Count > 0)
            {
                return true;
            }
            return emptyCheck;
        }

        static public string ModifyWithRegex(string input, LocalisationParameter parameter, Random randomChanceGen)
        {
            //TODO: The real size of this comes from the repetition of code, such as replacements and random individual match replacements.
            string outputString = input;
            //Safe mode scans for any format placeholders or special characters. 
            //If any have been found, the code will attempt to leave them intact.
            //That being said, this is very experimental and helter-skelter:
            //The program splits up the string into multiple segments.
            List<string> specialCharacter = new List<string>();
            List<string> segmentedInput = new List<string>();
            int lastPoint = 0;
            bool specialChracterFound = false;
            if(!parameter.UsesRegex)
            {
                parameter.Regex = ".*";
            }
            //If safe mode is turned on, break up the regex first.
            //Put any actual inputs in segmentedInput, and special characters/placeholders in specialCharacter.
            if (parameter.SafeMode)
            {
                foreach (Match m in Regex.Matches(outputString, localisationSpecialCharacters, RegexOptions.Multiline))
                {
                    specialChracterFound = true;
                    segmentedInput.Add(outputString.Substring(lastPoint, m.Index - lastPoint));
                    specialCharacter.Add(outputString.Substring(m.Index, m.Length));
                    lastPoint = m.Index + m.Length;
                }
            }
            //Continue matching anything else, if applicable.
            segmentedInput.Add(outputString.Substring(lastPoint, outputString.Length - lastPoint));
            switch (parameter.Actions)
            {
                case MatchActions.Replace:
                    if(specialChracterFound)
                    {
                        List<string> segmentedOutput = new List<string>();
                        foreach (string segment in segmentedInput)
                        {
                            if(parameter.RandomizerIndividualChance == 100)
                            {
                                segmentedOutput.Add(Regex.Replace(segment, parameter.Regex, parameter.ReplaceString));
                            }
                            else
                            {
                                int offset = 0;
                                string segmentCopy = segment;
                                foreach (Match match in Regex.Matches(segment, parameter.Regex))
                                {
                                    if (randomChanceGen.Next(1, 101) >= parameter.RandomizerIndividualChance + 1) //TODO: Seriously, do some small tests.
                                    {
                                        continue;
                                    }
                                    segmentCopy = ReplaceByPos(segmentCopy, match.Index + offset, match.Length, parameter.ReplaceString);
                                    offset += parameter.ReplaceString.Length - match.Length;
                                }
                                segmentedOutput.Add(segmentCopy);
                            }
                        }
                        string assembledOutput = string.Empty;
                        for (int i = 0; i < segmentedOutput.Count; i++)
                        {
                            assembledOutput += segmentedOutput[i];
                            if(i < specialCharacter.Count)
                            {
                                assembledOutput += specialCharacter[i];
                            }
                        }
                        outputString = assembledOutput;
                    }
                    else
                    {
                        if (parameter.RandomizerIndividualChance == 100)
                        {
                            outputString = Regex.Replace(outputString, parameter.Regex, parameter.ReplaceString);
                        }
                        else
                        {
                            int offset = 0;
                            string randomMatchString = outputString;
                            foreach (Match match in Regex.Matches(randomMatchString, parameter.Regex))
                            {
                                if (randomChanceGen.Next(1, 101) >= parameter.RandomizerIndividualChance + 1) //TODO: Seriously, do some small tests.
                                {
                                    continue;
                                }
                                randomMatchString = ReplaceByPos(randomMatchString, match.Index + offset, match.Length, parameter.ReplaceString);
                                offset += parameter.ReplaceString.Length - match.Length;
                            }
                            outputString = randomMatchString;
                        }
                    }
                    break;
                case MatchActions.UpperCase:
                    if (specialChracterFound)
                    {
                        List<string> segmentedOutput = new List<string>();
                        foreach (string segment in segmentedInput)
                        {
                            string alteredSegment = segment;
                            foreach (Match m in Regex.Matches(segment, parameter.Regex, RegexOptions.Multiline))
                            {
                                string matchedString = m.ToString();
                                alteredSegment = ReplaceByPos(alteredSegment, m.Index, m.Length, matchedString.ToUpper());
                            }
                            segmentedOutput.Add(Regex.Replace(alteredSegment, parameter.Regex, alteredSegment));
                        }
                        string assembledOutput = string.Empty;
                        for (int i = 0; i < segmentedOutput.Count; i++)
                        {
                            assembledOutput += segmentedOutput[i];
                            if (i < specialCharacter.Count)
                            {
                                assembledOutput += specialCharacter[i];
                            }
                        }
                        outputString = assembledOutput;
                    }
                    else
                    {
                        foreach (Match m in Regex.Matches(outputString, parameter.Regex, RegexOptions.Multiline))
                        {
                            string matchedString = m.ToString();
                            outputString = ReplaceByPos(outputString, m.Index, m.Length, matchedString.ToUpper());
                        }
                    }
                    break;
                case MatchActions.LowerCase:
                    if (specialChracterFound)
                    {
                        List<string> segmentedOutput = new List<string>();
                        foreach (string segment in segmentedInput)
                        {
                            string alteredSegment = segment;
                            foreach (Match m in Regex.Matches(segment, parameter.Regex, RegexOptions.Multiline))
                            {
                                string matchedString = m.ToString();
                                alteredSegment = ReplaceByPos(alteredSegment, m.Index, m.Length, matchedString.ToLower());
                            }
                            segmentedOutput.Add(Regex.Replace(alteredSegment, parameter.Regex, alteredSegment));
                        }
                        string assembledOutput = string.Empty;
                        for (int i = 0; i < segmentedOutput.Count; i++)
                        {
                            assembledOutput += segmentedOutput[i];
                            if (i < specialCharacter.Count)
                            {
                                assembledOutput += specialCharacter[i];
                            }
                        }
                        outputString = assembledOutput;
                    }
                    else
                    {
                        foreach (Match m in Regex.Matches(outputString, parameter.Regex, RegexOptions.Multiline))
                        {
                            string matchedString = m.ToString();
                            outputString = ReplaceByPos(outputString, m.Index, m.Length, matchedString.ToUpper());
                        }
                    }
                    break;
                case MatchActions.InvertCase:
                    if (specialChracterFound)
                    {
                        List<string> segmentedOutput = new List<string>();
                        foreach (string segment in segmentedInput)
                        {
                            string alteredSegment = segment;
                            foreach (Match m in Regex.Matches(segment, parameter.Regex, RegexOptions.Multiline))
                            {
                                string matchedString = m.ToString();
                                alteredSegment = ReplaceByPos(alteredSegment, m.Index, m.Length, InvertCase(matchedString));
                            }
                            segmentedOutput.Add(alteredSegment);
                        }
                        string assembledOutput = string.Empty;
                        for (int i = 0; i < segmentedOutput.Count; i++)
                        {
                            assembledOutput += segmentedOutput[i];
                            if (i < specialCharacter.Count)
                            {
                                assembledOutput += specialCharacter[i];
                            }
                        }
                        outputString = assembledOutput;
                    }
                    else
                    {
                        foreach (Match m in Regex.Matches(outputString, parameter.Regex, RegexOptions.Multiline))
                        {
                            string matchedString = m.ToString();
                            outputString = ReplaceByPos(outputString, m.Index, m.Length, InvertCase(matchedString));
                        }
                    }
                    break;
                default:
                    break;
            }
            //Return an error if a string is too long, and truncate it?
            return outputString;
        }
        static string ReplaceByPos(string input, int index, int length, string replace)
        {
            return input.Remove(index, length).Insert(index, replace);
        }

        static public string OffsetStringDecimal(string input, string regex, AsciiSettings settings, bool ignoreNewLines, Random randomGen = null)
        {
            Random random = randomGen;
            if(random == null)
            {
                random = new Random();
            }
            string modifiedExample = string.Empty;
            foreach (char character in input)
            {
                bool escapeNeeded = false;
                if (character == 10 && ignoreNewLines) //Newline
                {
                    modifiedExample += character;
                    continue;
                }
                int newCharacter = ResolveOutOfRangeValue(character, settings, random);
                
                if(settings.HighBoundEnabled && newCharacter > settings.HighBoundValue)
                {
                    newCharacter = settings.HighBoundValue;
                }
                if (settings.LowBoundEnabled && newCharacter < settings.LowBoundValue)
                {
                    newCharacter = settings.LowBoundValue;
                }
                if (newCharacter > char.MaxValue)
                {
                    newCharacter = char.MaxValue;
                }
                if (newCharacter < 0)
                {
                    newCharacter = char.MinValue;
                }
                if (newCharacter == 34) //Double quotation. No user setting can overwrite this... nor should it.
                {
                    escapeNeeded = true;
                }
                if (escapeNeeded)
                {
                    modifiedExample += '\\';
                }
                modifiedExample += Convert.ToChar(newCharacter);
            }
            return modifiedExample;
        }

        public static bool OffsetGoesBeyondRange(string input, string regex, AsciiSettings settings, bool ignoreNewLines, Random randomGen)
        {
            Random random = randomGen;
            if (random == null)
            {
                random = new Random();
            }
            foreach (char character in input)
            {
                int newCharacter = (int)character + random.Next(settings.OffsetLow, settings.OffsetHigh);
                if (newCharacter > char.MaxValue)
                {
                    return true;
                }
                if (newCharacter < 0)
                {
                    return true;
                }

            }
            return false;
        }

        static int ResolveOutOfRangeValue(char currentChar, AsciiSettings settings, Random randomGen)
        {
            int offset = 0;
            switch (settings.OutOfRangeSolver)
            {
                case OutOfRangeSolvers.StrictEnforce:
                    int enforcedOffsetLow = settings.OffsetLow;
                    int enforcedOffsetHigh = settings.OffsetHigh;
                    if(settings.LowBoundEnabled && currentChar - settings.OffsetLow < settings.LowBoundValue)
                    {
                        enforcedOffsetLow = currentChar - settings.LowBoundValue;
                    }
                    if (settings.HighBoundEnabled && currentChar + settings.OffsetHigh > settings.HighBoundValue)
                    {
                        enforcedOffsetHigh = settings.HighBoundValue - currentChar;
                    }
                    if(enforcedOffsetLow > enforcedOffsetHigh)
                    {
                        return settings.HighBoundValue;
                    }
                    if(enforcedOffsetHigh < enforcedOffsetLow)
                    {
                        return settings.LowBoundValue;
                    }
                    return currentChar + randomGen.Next(enforcedOffsetLow, enforcedOffsetHigh);
                case OutOfRangeSolvers.Round:
                    offset = currentChar + randomGen.Next(settings.OffsetLow, settings.OffsetHigh);
                    if (settings.LowBoundEnabled && offset < settings.LowBoundValue)
                    {
                        return settings.LowBoundValue;
                    }
                    if (settings.HighBoundEnabled && offset > settings.HighBoundValue)
                    {
                        return settings.HighBoundValue;
                    }
                    return offset;
                    break;
                case OutOfRangeSolvers.Bounce:
                    //Unimplemented.
                    return -1;
                default:
                    break;
            }
            return -1;
        }

        public static MatchCollection RegexSearch(string input, string regex)
        {
            return Regex.Matches(input, regex);
        }

        static string InvertCase(string input)
        {
            char[] returnValue = input.ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                returnValue[i] = char.IsUpper(letter) ? char.ToLower(letter) : char.ToUpper(letter);
            }
            return new string(returnValue);
        }
    }
}
