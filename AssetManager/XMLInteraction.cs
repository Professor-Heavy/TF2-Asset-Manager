using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AssetManager
{
    public class XMLInteraction
    {
        /// <summary>
        /// The current version of the XML file. Changes between versions.
        /// </summary>
        public const string version = "0.5.4";
        public const string autosaveFile = "\\parameterAutosave.xml";

        public static BindingList<MaterialParameter> materialParametersList = new BindingList<MaterialParameter>();
        public static List<MaterialCorruptionSettings> materialCorruptionSettings = new List<MaterialCorruptionSettings>();

        public static BindingList<LocalisationParameter> localisationParametersList = new BindingList<LocalisationParameter>();
        public static List<LocalisationCorruptionSettings> localisationCorruptionSettings = new List<LocalisationCorruptionSettings>();

        public static BindingList<SoundParameter> soundParametersList = new BindingList<SoundParameter>();
        public static List<SoundFileEntry> soundFilesList = new List<SoundFileEntry>();

        private static Dictionary<string,string> materialParameterKeys = new Dictionary<string,string>
        {
            {"paramName","Name" },
            {"parameter","Parameter"},
            {"paramType","integer" },
            {"paramValue","" },
            {"paramForce","0" },
            {"randomChance","100" },
            {"randomOffset","0" },
            {"randomChanceSeed","-1" },
            {"randomOffsetSeed","-1" },
            {"shaderFilterArray","" },
            {"proxyFilterArray","" }
        };

        private static Dictionary<string, string> localisationParameterKeys = new Dictionary<string, string>
        {
            {"paramName","Name" },
            {"regexExpression",""},
            {"matchType","0" },
            //{"replaceString","" }, Not required for now.
            {"randomChance","100" },
            {"randomIndividualChance","100" },
            {"letterCountFilter","0" },
            {"letterCountFilterMin","0" },
            {"letterCountFilterMax","0" },
            {"safeMode","1" },
            {"usesRegex","0" },
        };

        /// <summary>
        /// Adds default parameters to the ArrayList of MaterialParameters.
        /// </summary>
        static async public Task InsertDefaultParameters()
        {
            materialParametersList.Add(new MaterialParameter("Solid Color", "$color", MaterialParameterType.GetMaterialParameterType("vector3"), "255,255,255"));
            //MaterialParametersArrayList.Add(new MaterialParameter("Pulsing Rainbow", "Sine", MaterialParameterType.GetMaterialParameterType("proxy"), "add"));
            materialParametersList.Add(new MaterialParameter("No Phong Shading", "$phong", MaterialParameterType.GetMaterialParameterType("boolean"), "0"));
            materialParametersList.Add(new MaterialParameter("All Phong Shading", "$phong", MaterialParameterType.GetMaterialParameterType("boolean"), "1"));
            materialParametersList.Add(new MaterialParameter("Extreme Phong Boost", "$phongboost", MaterialParameterType.GetMaterialParameterType("integer"), "500"));
            localisationParametersList.Add(new LocalisationParameter("Single Character", ".", MatchActions.Replace, "A"));
            localisationParametersList.Add(new LocalisationParameter("Invert Case", ".", MatchActions.InvertCase));
            await WriteXmlParameters(MainWindow.completeUserDataPath);
        }

        static async public Task InsertDefaultCorruptions()
        {
            materialCorruptionSettings.Add(new MaterialCorruptionSettings()
            {
                CorruptionType = MaterialCorruptionSettings.CorruptionTypes.SwapParameters,
                Enabled = true,
                Arguments = new Dictionary<string, string>()
                {
                    {"AffectSimilarShaders", "false"},
                },
                Probability = 100,
                ProbabilitySeed = -1,
                ParameterFilterArray = new List<string> { "$basetexture" },
                ParameterFilterMode = 1,
                ShaderFilterArray = new List<string>()
            });
            materialCorruptionSettings.Add(new MaterialCorruptionSettings()
            {
                CorruptionType = MaterialCorruptionSettings.CorruptionTypes.OffsetValues,
                Enabled = true,
                Arguments = new Dictionary<string, string>()
                {
                    {"OffsetLow", "-25"},
                    {"OffsetHigh", "25"},
                    {"LowBoundEnabled", "0"},
                    {"HighBoundEnabled", "0"},
                    {"LowBoundValue", "0"},
                    {"HighBoundValue", "0"}
                },
                Probability = 100,
                ProbabilitySeed = -1,
                ParameterFilterArray = new List<string> { "$phongboost" },
                ParameterFilterMode = 1,
                ShaderFilterArray = new List<string>()
            });
            localisationCorruptionSettings.Add(new LocalisationCorruptionSettings()
            {
                CorruptionType = LocalisationCorruptionSettings.CorruptionTypes.SwapEntries,
                Enabled = true,
                KeyFilterArray = new List<string> { "ItemNameFormat" },
                KeyFilterMode = 0,
                RegularExpressionEnabled = false,
                RegularExpressionPattern = "",
                RegularExpressionMode = 1,
                SafeMode = true,
                SkipUnsafeEntries = true, //The illusion of choice.
                IgnoreNewlines = true,
                Arguments = new Dictionary<string, string>()
                {
                    {"RegexForMatchesAndSwaps", "true"}
                },
                Probability = 100,
            });
            localisationCorruptionSettings.Add(new LocalisationCorruptionSettings()
            {
                CorruptionType = LocalisationCorruptionSettings.CorruptionTypes.SwapLanguage,
                Enabled = true,
                KeyFilterArray = new List<string>(),
                KeyFilterMode = 0,
                RegularExpressionEnabled = false,
                RegularExpressionPattern = "",
                RegularExpressionMode = 1,
                SafeMode = true,
                SkipUnsafeEntries = true,
                IgnoreNewlines = true,
                Arguments = new Dictionary<string, string>()
                {
                    {"GlobalRegexEnabled", "0"},
                    {"GlobalRegex", ""},
                    {"GlobalWeight", "1"},
                    {"LanguagesEnabled", "french,german"},
                    {"OverrideRegexEnabled", "0,0"},
                    {"OverrideRegexValues", ","},
                    {"OverrideWeightEnabled", "0,0"},
                    {"OverrideWeightValues", "0.5,1"},
                    {"IgnoreNoMatchingTokens", "1"},
                    {"IgnoreRepeatingTokens", "1"}
                },
                Probability = 100,
            });
            localisationCorruptionSettings.Add(new LocalisationCorruptionSettings()
            {
                CorruptionType = LocalisationCorruptionSettings.CorruptionTypes.OffsetAscii,
                Enabled = true,
                KeyFilterArray = new List<string>(),
                KeyFilterMode = 0,
                RegularExpressionEnabled = false,
                RegularExpressionPattern = "",
                RegularExpressionMode = 1,
                SafeMode = true,
                SkipUnsafeEntries = true,
                IgnoreNewlines = true,
                Arguments = new Dictionary<string, string>()
                {
                    {"OffsetLow", "-25"},
                    {"OffsetHigh", "25"},
                    {"LowBoundEnabled", "0"},
                    {"HighBoundEnabled", "0"},
                    {"LowBoundValue", "0"},
                    {"HighBoundValue", "0"}
                },
                Probability = 100,
            });
            await WriteXmlCorruptionParameters(MainWindow.completeUserDataPath);
        }

        static string ConfirmXmlVersion(XDocument doc, bool assumeEarlyVersion = true)
        {
            var versionElement = doc.Root.Elements("version");
            
            if (versionElement.Count() == 0)
            {
                return assumeEarlyVersion ? "0.5.0": null; //XML versions were implemented in 0.5.0
            }
            else
            {
                return versionElement.First().Value;
            }
        }

        static public bool CheckAutosave(string xmlPath)
        {
            return File.Exists(xmlPath + autosaveFile);
        }

        static async public void CreateAutosave(string xmlPath)
        {
            if(Properties.Settings.Default.AutosaveEnabled)
            {
                await WriteXmlParameters(xmlPath + autosaveFile, false);
            }
        }

        static public void DeleteAutosave(string xmlPath)
        {
            File.Delete(xmlPath + autosaveFile);
        }

        static public string ConfirmXmlVersion(string xmlPath)
        {
            XDocument xDoc;
            xDoc = XDocument.Load(xmlPath);
            return ConfirmXmlVersion(xDoc, false);
        }

        static public void InitialiseParameterListings(string completeUserDataPath, bool forceRefresh, bool fromAutosave = false)
        {
            if (forceRefresh)
            {
                materialParametersList.Clear();
            }
            if(fromAutosave)
            {
                AddParametersToList(ReadXmlMaterialParameters(completeUserDataPath + autosaveFile));
                AddParametersToList(ReadXmlLocalisationParameters(completeUserDataPath + autosaveFile));
                AddParametersToList(ReadXmlSoundParameters(completeUserDataPath + autosaveFile));
            }
            else
            {
                AddParametersToList(ReadXmlMaterialParameters(completeUserDataPath + "\\parameterStorage.xml"));
                AddParametersToList(ReadXmlLocalisationParameters(completeUserDataPath + "\\parameterStorage.xml"));
                AddParametersToList(ReadXmlSoundParameters(completeUserDataPath + "\\parameterStorage.xml"));
            }
        }

        static public void AddParametersToList(MaterialParameter[] materialParameters)
        {
            foreach (MaterialParameter param in materialParameters)
            {
                materialParametersList.Add(param);
            }
        }

        static public void AddParametersToList(LocalisationParameter[] localisationParameters)
        {
            foreach (LocalisationParameter param in localisationParameters)
            {
                localisationParametersList.Add(param);
            }
        }

        static public void AddParametersToList(SoundParameter[] soundParameters)
        {
            foreach (SoundParameter param in soundParameters)
            {
                soundParametersList.Add(param);
            }
        }

        /// <summary>
        /// Refreshes the list of parameters and reads the XML file, updating the parameter lists in memory.
        /// </summary>
        /// <param name="xmlPath">The directory where the XML file is stored.</param>
        static public MaterialParameter[] ReadXmlMaterialParameters(string xmlPath)
        {
            XDocument xDoc;
            xDoc = XDocument.Load(xmlPath);
            string version = ConfirmXmlVersion(xDoc);
           
            IEnumerable<XElement> materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            List<MaterialParameter> parsedMaterialParamList = new List<MaterialParameter>();
            foreach (XElement param in materialParamList) //We need to ignore proxies until they're ready too..
            {
                try
                {
                    parsedMaterialParamList.Add(ParseMaterialElementIntoParam(param));
                    //If it's erroneous, then the application may have picked up on it by now and attempted to fix it.
                    //It may be worth checking for these in future.
                }
                catch
                {
                    continue;
                }
            }
            return parsedMaterialParamList.ToArray();
            
        }

        static public LocalisationParameter[] ReadXmlLocalisationParameters(string completeUserDataPath)
        {
            XDocument xDoc;
            xDoc = XDocument.Load(completeUserDataPath);
            string version = ConfirmXmlVersion(xDoc);

            IEnumerable<XElement> localisationParamList = xDoc.Elements("parameterSettings").Elements("localisationParameterList").Elements("localisationParameter");
            List<LocalisationParameter> parsedLocalisationParamList = new List<LocalisationParameter>();
            foreach (XElement param in localisationParamList)
            {
                try
                {
                    parsedLocalisationParamList.Add(ParseLocalisationElementIntoParam(param));
                }
                catch
                {
                    continue;
                }
            }
            return parsedLocalisationParamList.ToArray();
        }

        static public SoundParameter[] ReadXmlSoundParameters(string completeUserDataPath)
        {
            XDocument xDoc;
            xDoc = XDocument.Load(completeUserDataPath);
            string version = ConfirmXmlVersion(xDoc);

            IEnumerable<XElement> soundParamList = xDoc.Elements("parameterSettings").Elements("soundParameterList").Elements("soundParameter");
            List<SoundParameter> parsedSoundParamList = new List<SoundParameter>();
            foreach (XElement param in soundParamList)
            {
                try
                {
                    parsedSoundParamList.Add(ParseSoundElementIntoParam(param));
                }
                catch
                {
                    continue;
                }
            }
            return parsedSoundParamList.ToArray();
        }

        static public void ReadXmlCorruptionParameters(string completeUserDataPath, bool fromAutosave = false)
        {
            materialCorruptionSettings.Clear();
            XDocument xDoc;
            xDoc = XDocument.Load(completeUserDataPath + (/*fromAutosave ? autosaveFile : */"\\corruptionStorage.xml"));
            string version = ConfirmXmlVersion(xDoc);

            IEnumerable<XElement> corruptionList = xDoc.Elements("corruptionSettings").Elements("materialCorruptions").Elements("settingGroup");
            foreach (XElement param in corruptionList)
            {
                MaterialCorruptionSettings.CorruptionTypes corruptionType = (MaterialCorruptionSettings.CorruptionTypes)Enum.Parse(typeof(MaterialCorruptionSettings.CorruptionTypes), param.Element("corruptionType").Value);
                int probability = ParseParameterType<int>(param.Element("probability").Value);
                int probabilitySeed = -1;
                if (param.Element("probabilitySeed") != null)
                {
                    probabilitySeed = ParseParameterType<int>(param.Element("probabilitySeed").Value);
                }
                Dictionary<string, string> arguments = new Dictionary<string, string>();
                foreach (XElement child in param.Elements("arguments"))
                {
                    XNode[] childrenAttributes = child.Nodes().ToArray();
                    foreach(XNode argument in childrenAttributes)
                    {
                        arguments.Add((argument as XElement).Name.ToString(), (argument as XElement).Value);
                    }
                }
                List<string> parameterShaderFilters = ReadParameterValueChildren(param.Element("shaderFilterArray"), "filter");
                int parameterShaderFilterMode = ParseParameterType<int>(param.Element("shaderFilterArray").Attribute("shaderFilterMode").Value);
                List<string> parameterParamFilters = ReadParameterValueChildren(param.Element("parameterFilterArray"), "filter");
                int parameterParamFilterMode = ParseParameterType<int>(param.Element("parameterFilterArray").Attribute("parameterFilterMode").Value);

                materialCorruptionSettings.Add(new MaterialCorruptionSettings()
                {
                    CorruptionType = corruptionType,
                    Enabled = true,
                    Probability = probability,
                    ProbabilitySeed = probabilitySeed,
                    Arguments = arguments,
                    ParameterFilterArray = parameterParamFilters,
                    ParameterFilterMode = parameterParamFilterMode,
                    ShaderFilterArray = parameterShaderFilters,
                    ShaderFilterMode = parameterShaderFilterMode
                });
            }
            corruptionList = xDoc.Elements("corruptionSettings").Elements("localisationCorruptions").Elements("settingGroup");
            foreach (XElement param in corruptionList)
            {
                LocalisationCorruptionSettings.CorruptionTypes corruptionType = (LocalisationCorruptionSettings.CorruptionTypes)Enum.Parse(typeof(LocalisationCorruptionSettings.CorruptionTypes), param.Element("corruptionType").Value);
                int probability = ParseParameterType<int>(param.Element("probability").Value);
                int probabilitySeed = -1;
                int randomSeed = -1;
                if (param.Element("probabilitySeed") != null)
                {
                    probabilitySeed = ParseParameterType<int>(param.Element("probabilitySeed").Value);
                    randomSeed = ParseParameterType<int>(param.Element("randomSeed").Value);
                }

                Dictionary<string, string> arguments = new Dictionary<string, string>();
                foreach (XElement child in param.Elements("arguments"))
                {
                    XNode[] childrenAttributes = child.Nodes().ToArray();
                    foreach (XNode argument in childrenAttributes)
                    {
                        arguments.Add((argument as XElement).Name.ToString(), (argument as XElement).Value);
                    }
                }

                List<string> parameterKeyFilters = ReadParameterValueChildren(param.Element("keyFilterArray"), "filter");
                int parameterKeyFilterMode = ParseParameterType<int>(param.Element("keyFilterArray").Attribute("keyFilterMode").Value);
                bool regexEnabled = param.Element("regexEnabled").Value == "1";
                string regexPattern = param.Element("regexPattern").Value;
                int regexMode = ParseParameterType<int>(param.Element("regexMode").Value);
                bool safeMode = param.Element("safeMode").Value == "1";
                bool ignoreNewLines = param.Element("ignoreNewlines").Value == "1";
                bool skipUnsafeEntries = param.Element("skipUnsafeEntries").Value == "1";

                localisationCorruptionSettings.Add(new LocalisationCorruptionSettings()
                {
                    CorruptionType = corruptionType,
                    Enabled = true,
                    Probability = probability,
                    ProbabilitySeed = probabilitySeed,
                    RandomSeed = randomSeed,
                    Arguments = arguments,
                    KeyFilterArray = parameterKeyFilters,
                    KeyFilterMode = parameterKeyFilterMode,
                    SafeMode = safeMode,
                    IgnoreNewlines = ignoreNewLines,
                    SkipUnsafeEntries = skipUnsafeEntries,
                    RegularExpressionEnabled = regexEnabled,
                    RegularExpressionPattern = regexPattern,
                    RegularExpressionMode = regexMode
                });
            }
            return;
        }

        static public async Task WriteXmlParameters(string xmlPath, bool appendDefaultName = true)
        {
            await WriteXmlParameters(xmlPath, appendDefaultName, materialParametersList.ToArray(), localisationParametersList.ToArray(), soundParametersList.ToArray());
        }

        static public async Task WriteXmlParameters(string xmlPath, bool appendDefaultName, MaterialParameter[] materialParameters, LocalisationParameter[] localisationParameters, SoundParameter[] soundParameters)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Async = true
            };
            if(appendDefaultName)
            {
                xmlPath += "\\parameterStorage.xml";
            }
            XmlWriter textWriter = XmlWriter.Create(xmlPath, settings);
            using (textWriter)
            {
                await textWriter.WriteStartDocumentAsync();
                await textWriter.WriteStartElementAsync(null, "parameterSettings", null);
                await textWriter.WriteElementStringAsync(null, "version", null, version);
                await textWriter.WriteStartElementAsync(null, "materialParameterList", null);
                foreach (MaterialParameter param in materialParameters)
                {
                    await textWriter.WriteStartElementAsync(null, "materialParameter", null);
                    await textWriter.WriteElementStringAsync(null, "paramName", null, param.ParamName);
                    await textWriter.WriteElementStringAsync(null, "parameter", null, param.Parameter);
                    await textWriter.WriteElementStringAsync(null, "paramType", null, param.ParamType.ToString());
                    if (param.ParamType.UsesArrays)
                    {
                        await textWriter.WriteStartElementAsync(null, "paramValue", null);
                        if (param.ParamType.Delimiter)
                        {
                            if(param.ParamValue is IList)
                            {
                                foreach (var childParam in param.ParamValue)
                                {
                                    await textWriter.WriteElementStringAsync(null, param.ParamType.ArrayElementKeys, null, childParam);
                                }
                            }
                            else
                            {
                                foreach (var childParam in param.ParamValue.Split(','))
                                {
                                    await textWriter.WriteElementStringAsync(null, param.ParamType.ArrayElementKeys, null, childParam);
                                }
                            }
                        }
                        else
                        {
                            foreach (var childParam in param.ParamValue)
                            {
                                if (param.ParamType.UsesAttributes)
                                {
                                    await textWriter.WriteStartElementAsync(null, param.ParamType.ArrayElementKeys, null);
                                    for (int i = 0; i < childParam.Length; i++)
                                    {
                                        await textWriter.WriteAttributeStringAsync(null, param.ParamType.AttributeKeys[i], null, childParam[i]);
                                    }
                                    await textWriter.WriteEndElementAsync();
                                }
                                else
                                {
                                    await textWriter.WriteElementStringAsync(null, param.ParamType.ArrayElementKeys, null, childParam);
                                }
                            }
                        }
                        await textWriter.WriteEndElementAsync();
                    }
                    else
                    {
                        await textWriter.WriteElementStringAsync(null, "paramValue", null, param.ParamValue);
                    }
                    await textWriter.WriteElementStringAsync(null, "paramForce", null, param.ParamForce.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomChance", null, param.RandomizerChance.ToString());
                    if (param.ParamType.ToString() == "vector3")
                    {
                        await textWriter.WriteElementStringAsync(null, "randomOffset", null, string.Join(",", param.RandomizerOffset));
                    }
                    else
                    {
                        await textWriter.WriteElementStringAsync(null, "randomOffset", null, param.RandomizerOffset[0].ToString());
                    }
                    await textWriter.WriteElementStringAsync(null, "randomChanceSeed", null, param.RandomizerChanceSeed.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomOffsetSeed", null, param.RandomizerOffsetSeed.ToString());
                    await textWriter.WriteStartElementAsync(null, "shaderFilterArray", null);
                    await textWriter.WriteAttributeStringAsync(null, "shaderFilterMode", null, param.ShaderFilterMode.ToString());
                    foreach (string shaderFilter in param.ShaderFilterArray)
                    {
                        await textWriter.WriteElementStringAsync(null, "filter", null, shaderFilter);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteStartElementAsync(null, "proxyFilterArray", null);
                    await textWriter.WriteAttributeStringAsync(null, "proxyFilterMode", null, param.ProxyFilterMode.ToString());
                    foreach (string proxyFilter in param.ProxyFilterArray)
                    {
                        await textWriter.WriteElementStringAsync(null, "filter", null, proxyFilter);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteEndElementAsync();
                }
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteStartElementAsync(null, "localisationParameterList", null);
                foreach (LocalisationParameter param in localisationParameters)
                {
                    await textWriter.WriteStartElementAsync(null, "localisationParameter", null);
                    await textWriter.WriteElementStringAsync(null, "paramName", null, param.ParamName);
                    await textWriter.WriteElementStringAsync(null, "regexExpression", null, param.Regex);
                    await textWriter.WriteElementStringAsync(null, "matchType", null, ((int)param.Actions).ToString());
                    if(param.Actions == MatchActions.Replace)
                    {
                        await textWriter.WriteElementStringAsync(null, "replaceString", null, param.ReplaceString);
                    }
                    await textWriter.WriteElementStringAsync(null, "randomChance", null, param.RandomizerChance.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomIndividualChance", null, param.RandomizerIndividualChance.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomChanceSeed", null, param.RandomizerChanceSeed.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomIndividualChanceSeed", null, param.RandomizerIndividualChanceSeed.ToString());
                    await textWriter.WriteElementStringAsync(null, "letterCountFilter", null, param.LetterCountFilterMode ? "1" : "0");
                    await textWriter.WriteElementStringAsync(null, "letterCountFilterMin", null, param.LetterCountFilterMin.ToString());
                    await textWriter.WriteElementStringAsync(null, "letterCountFilterMax", null, param.LetterCountFilterMax.ToString());
                    await textWriter.WriteElementStringAsync(null, "safeMode", null, param.SafeMode ? "1" : "0");
                    await textWriter.WriteElementStringAsync(null, "usesRegex", null, param.UsesRegex ? "1" : "0");
                    await textWriter.WriteEndElementAsync();
                }
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteStartElementAsync(null, "soundParameterList", null);
                foreach (SoundParameter param in soundParameters)
                {
                    await textWriter.WriteStartElementAsync(null, "soundParameter", null);
                    await textWriter.WriteElementStringAsync(null, "paramName", null, param.ParamName);
                    await textWriter.WriteElementStringAsync(null, "regexExpression", null, param.Regex);
                    await textWriter.WriteElementStringAsync(null, "paramType", null, ((int)param.Actions).ToString());
                    await textWriter.WriteStartElementAsync(null, "soundArray", null);
                    foreach (SoundFileEntry sound in param.Sounds)
                    {
                        await textWriter.WriteElementStringAsync(null, "location", null, sound.fileLocation);
                    }
                    await textWriter.WriteEndElementAsync();
                    if(param.Entry.HasValue)
                    {
                        await textWriter.WriteStartElementAsync(null, "soundscriptEntry", null);
                        await textWriter.WriteElementStringAsync(null, "channel", null, ((int)param.Entry.Value.channel).ToString());
                        await textWriter.WriteElementStringAsync(null, "volume", null, param.Entry.Value.volume);
                        await textWriter.WriteElementStringAsync(null, "pitch", null, param.Entry.Value.pitch);
                        await textWriter.WriteElementStringAsync(null, "soundlevel", null, param.Entry.Value.soundlevel);
                        await textWriter.WriteEndElementAsync();
                    }
                    await textWriter.WriteElementStringAsync(null, "randomChance", null, param.RandomizerChance.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomChanceSeed", null, param.RandomizerChanceSeed.ToString());
                    await textWriter.WriteElementStringAsync(null, "replaceRndWave", null, param.ReplaceUsingRndWave ? "1" : "0");
                    await textWriter.WriteEndElementAsync();
                }
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteEndDocumentAsync();
                return;
            }
        }

        static public async Task WriteXmlCorruptionParameters(string completeUserDataPath)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Async = true
            };
            XmlWriter textWriter = XmlWriter.Create(completeUserDataPath + "\\corruptionStorage.xml", settings);
            using (textWriter)
            {
                await textWriter.WriteStartDocumentAsync();
                await textWriter.WriteStartElementAsync(null, "corruptionSettings", null);
                await textWriter.WriteElementStringAsync(null, "version", null, version);
                await textWriter.WriteStartElementAsync(null, "materialCorruptions", null);
                foreach (MaterialCorruptionSettings corruptionSettings in materialCorruptionSettings)
                {
                    await textWriter.WriteStartElementAsync(null, "settingGroup", null);
                    await textWriter.WriteElementStringAsync(null, "corruptionType", null, corruptionSettings.CorruptionType.ToString());
                    await textWriter.WriteElementStringAsync(null, "probability", null, corruptionSettings.Probability.ToString());
                    await textWriter.WriteElementStringAsync(null, "probabilitySeed", null, corruptionSettings.ProbabilitySeed.ToString());
                    await textWriter.WriteStartElementAsync(null, "arguments", null);
                    foreach (KeyValuePair<string, string> argument in corruptionSettings.Arguments)
                    {
                        await textWriter.WriteElementStringAsync(null, argument.Key, null, argument.Value);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteStartElementAsync(null, "parameterFilterArray", null);
                    await textWriter.WriteAttributeStringAsync(null, "parameterFilterMode", null, corruptionSettings.ParameterFilterMode.ToString());
                    foreach (string paramFilter in corruptionSettings.ParameterFilterArray)
                    {
                        await textWriter.WriteElementStringAsync(null, "filter", null, paramFilter);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteStartElementAsync(null, "shaderFilterArray", null);
                    await textWriter.WriteAttributeStringAsync(null, "shaderFilterMode", null, corruptionSettings.ShaderFilterMode.ToString());
                    foreach (string shaderFilter in corruptionSettings.ShaderFilterArray)
                    {
                        await textWriter.WriteElementStringAsync(null, "filter", null, shaderFilter);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteEndElementAsync();
                }
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteStartElementAsync(null, "localisationCorruptions", null);
                foreach (LocalisationCorruptionSettings corruptionSettings in localisationCorruptionSettings)
                {
                    await textWriter.WriteStartElementAsync(null, "settingGroup", null);
                    await textWriter.WriteElementStringAsync(null, "corruptionType", null, corruptionSettings.CorruptionType.ToString());
                    await textWriter.WriteElementStringAsync(null, "probability", null, corruptionSettings.Probability.ToString());
                    await textWriter.WriteElementStringAsync(null, "probabilitySeed", null, corruptionSettings.ProbabilitySeed.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomSeed", null, corruptionSettings.RandomSeed.ToString());
                    await textWriter.WriteStartElementAsync(null, "arguments", null);
                    foreach (KeyValuePair<string, string> argument in corruptionSettings.Arguments)
                    {
                        await textWriter.WriteElementStringAsync(null, argument.Key, null, argument.Value);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteStartElementAsync(null, "keyFilterArray", null);
                    await textWriter.WriteAttributeStringAsync(null, "keyFilterMode", null, corruptionSettings.KeyFilterMode.ToString());
                    foreach (string shaderFilter in corruptionSettings.KeyFilterArray)
                    {
                        await textWriter.WriteElementStringAsync(null, "filter", null, shaderFilter);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteElementStringAsync(null, "regexEnabled", null, corruptionSettings.RegularExpressionEnabled ? "1" : "0");
                    await textWriter.WriteElementStringAsync(null, "regexPattern", null, corruptionSettings.RegularExpressionPattern.ToString());
                    await textWriter.WriteElementStringAsync(null, "regexMode", null, corruptionSettings.RegularExpressionMode.ToString());
                    await textWriter.WriteElementStringAsync(null, "safeMode", null, corruptionSettings.SafeMode ? "1" : "0");
                    await textWriter.WriteElementStringAsync(null, "ignoreNewlines", null, corruptionSettings.IgnoreNewlines ? "1" : "0");
                    await textWriter.WriteElementStringAsync(null, "skipUnsafeEntries", null, corruptionSettings.SkipUnsafeEntries ? "1" : "0");
                    await textWriter.WriteEndElementAsync();
                }
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteEndDocumentAsync();
            }
            return;
        }

        static dynamic ParseParameterType<T>(dynamic input)
        {
            try { return TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(input); }
            catch(Exception) { return default(T); }
        }

        /// <summary>
        /// Performs multiple checks on the XML file to make sure that the structural integrity and formats are consistent.
        /// </summary>
        /// <param name="completeUserDataPath"></param>
        /// <returns></returns>
        public static List<string> VerifyXMLIntegrity(string completeUserDataPath)
        {
            List<string> errorList = new List<string>();
            string parameterStoragePath = completeUserDataPath + "\\parameterStorage.xml";
            string corruptionStoragePath = completeUserDataPath + "\\corruptionStorage.xml";
            XDocument xDoc;
            
            //File Exist Check
            if (!File.Exists(parameterStoragePath))
            {
                MessageBox.Show("The modification configuration file is missing.\nA new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsertDefaultParameters();
            }

            if (!File.Exists(corruptionStoragePath))
            {
                MessageBox.Show("The corruption configuration file is missing.\nA new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsertDefaultCorruptions();
            }

            //Structure Check
            try
            {
                xDoc = XDocument.Load(parameterStoragePath);
            }
            catch(XmlException ex)
            {
                DialogResult result = MessageBox.Show("The configuration file has a broken XML structure that cannot be recovered.\n" + ex.Message + "\nWould you like to create a new one?", "Configuration File Error", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    InsertDefaultParameters();
                    xDoc = XDocument.Load(parameterStoragePath);
                    errorList.Add(string.Format("Internal Error: Severe corruption in XML {0}. File set to default.", parameterStoragePath));
                }
                return errorList;
            }
            //NOTE: This is being kept in code for the meantime although the necessity of it is questionable at best.
            /*
            IEnumerable<XElement> materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            foreach (XElement param in materialParamList)
            {
                bool resolvedErrorInCurrentParam = false;
                //First, verify the integrity of any keys that may be missing.
                foreach (KeyValuePair<string,string> key in materialParameterKeys)
                {
                    int keyCheck = VerifyEntryIntegrity(param, key.Key);
                    if (keyCheck != -1)
                    {
                        errorList.Add(OutputCriticalIntegrityError(param, key.Key, keyCheck));
                        param.Add(new XElement(key.Key, key.Value));
                        resolvedErrorInCurrentParam = true;
                    }
                }

                //Second, parse the parameter and read the values to see if any are incorrect.
                MaterialParameter parsedParam = ParseMaterialElementIntoParam(param);
                MaterialParameterType parameterType = MaterialParameterType.GetMaterialParameterType(param.Element("paramType").Value);
                switch (parameterType.ToString())
                {
                    case "vector3":
                        break;
                    case "proxy":
                        List<string[]> parameterChildren = ReadParameterValueChildren(param.Element("paramValue"), parameterType.ArrayElementKeys, parameterType.AttributeKeys);
                        if (parameterChildren.Count() > 6)
                        {
                            errorList.Add(string.Format("Warning in Parameter {0}: Proxy contains more than the maximum parameters.", parsedParam.ParamName));
                        }
                        foreach (string[] parameterKey in parameterChildren)
                        {
                            if (string.IsNullOrEmpty(parameterKey[0]))
                            {
                                errorList.Add(string.Format("Warning in Parameter {0}: A proxy key is empty.", parsedParam.ParamName));
                            }
                            if (string.IsNullOrEmpty(parameterKey[1]))
                            {
                                errorList.Add(string.Format("Warning in Parameter {0}: {1} is empty", parsedParam.ParamName, parameterKey[0]));
                            }
                        }
                        break;
                    case "boolean":
                        int boolValue = ParseParameterType<int>(parsedParam.ParamValue);
                        if (boolValue > 1 || boolValue < 0)
                        {
                            errorList.Add(string.Format("Warning in Parameter {0}: Boolean value must be 0 or 1. {0} may have undesired results when used.", parsedParam.ParamName));
                        }
                        break;
                    case "Random Choice Array":
                        break;
                }

                if (resolvedErrorInCurrentParam == true)
                {
                    materialParametersList.Add(parsedParam);
                }
            }
            IEnumerable<XElement> localisationParamList = xDoc.Elements("parameterSettings").Elements("localisationParameterList").Elements("localisationParameter");
            foreach (XElement param in localisationParamList)
            {
                bool resolvedErrorInCurrentParam = false;
                foreach (KeyValuePair<string, string> key in localisationParameterKeys)
                {
                    int keyCheck = VerifyEntryIntegrity(param, key.Key);
                    if (keyCheck != -1)
                    {
                        resolvedErrorInCurrentParam = true;
                        errorList.Add(OutputCriticalIntegrityError(param, key.Key, keyCheck));
                        param.Add(new XElement(key.Key, key.Value));
                    }
                }

                LocalisationParameter parsedParam = ParseLocalisationElementIntoParam(param);

                if (resolvedErrorInCurrentParam == true)
                {
                    localisationParametersList.Add(parsedParam);
                }
            }
            */
            return errorList;
        }

        /// <summary>
        /// Reads an XElement entry and returns an error code if an error occurs.
        /// -1 means there was no error.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static int VerifyEntryIntegrity(XElement param, string name)
        {
            try
            {
                if(param.Element(name) == null)
                {
                    if(param.Element("paramName") != null)
                    {
                        return 0; //Parameter name was readable. Can display information.
                    }
                    else
                    {
                        return 1; //Parameter name could not be read.
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                return 2; //Like that's ever gonna happen.
            }
        }

        private static string OutputCriticalIntegrityError(XElement param, string name, int result)
        {
            switch (result)
            {
                case 0:
                    return string.Format("Internal Error in Parameter {0}: XML value {1} missing. Setting to default value.", param.Element("paramName").Value, name);
                case 1:
                    return string.Format("Internal Error: Parameter has unreadable name. Setting to default name.");
                default:
                    return "Unknown error in Parameter. Error code: " + result;
            }
        }

        //private static string VerifyVector3Integrity<T>(string vector3Input)
        //{
        //    if (vector3Input.Split(',').Length != 3) //Check that it contains 3 values only.
        //    {
        //        return "Length of value is not 3.";
        //    }
        //    string[] splitStringTest = vector3Input.Split(',');
        //    if (TypeDescriptor.GetConverter(typeof(T)).CanConvertFrom(splitStringTest.GetType()))
        //    {
        //        return "One or more of the values do not match with their types.";
        //    }
        //    return null;
        //}
        
        private static MaterialParameter ParseMaterialElementIntoParam(XElement element)
        {
            string parameterName = element.Element("paramName").Value;
            string parameter = element.Element("parameter").Value;
            MaterialParameterType parameterType = MaterialParameterType.GetMaterialParameterType(element.Element("paramType").Value);
            dynamic parameterValue;
            int parameterForce = ParseParameterType<int>(element.Element("paramForce").Value);
            int parameterRandomChance = ParseParameterType<int>(element.Element("randomChance").Value);
            float[] parameterRandomOffset = new float[3];
            int parameterRandomChanceSeed = -1;
            int parameterRandomOffsetSeed = -1;
            if (element.Element("randomChanceSeed") != null)
            {
                //HACK: Since this runs before version checking, and since integrity checks were disabled,
                //this won't exist in 0.5.0 and before, and will throw an error.
                //The check will remain until proper versioning/integrity checks are implemented.
                parameterRandomChanceSeed = ParseParameterType<int>(element.Element("randomChanceSeed").Value);

                //If randomChanceSeed is missing, then while this is stupid to assume, it'll have to work for now.
                parameterRandomOffsetSeed = ParseParameterType<int>(element.Element("randomOffsetSeed").Value);
            }

            if (parameterType.ToString() != "vector3")
            {
               parameterRandomOffset[0] = ParseParameterType<float>(element.Element("randomOffset").Value);
            }
            else
            {
                //I'm having an aneurysm.
                parameterRandomOffset =
                    ((string)ParseParameterType<string>(element.Element("randomOffset").Value))
                    .Split(',')
                    .Select(x => (float)ParseParameterType<float>(x))
                    .ToArray();
            }
            

            if (parameterType.UsesArrays)
            {
                if (parameterType.UsesAttributes)
                {
                    parameterValue = ReadParameterValueChildren(element.Element("paramValue"), parameterType.ArrayElementKeys, parameterType.AttributeKeys);
                }
                else
                {
                    parameterValue = ReadParameterValueChildren(element.Element("paramValue"), parameterType.ArrayElementKeys);
                }
                if (parameterType.Delimiter)
                {
                    parameterValue = ReadParameterValueChildren(element.Element("paramValue"), parameterType.ArrayElementKeys).ToList();
                }
            }
            else
            {
                parameterValue = element.Element("paramValue").Value;
            }

            List<string> parameterShaderFilters = ReadParameterValueChildren(element.Element("shaderFilterArray"), "filter");
            int parameterShaderFilterMode = ParseParameterType<int>(element.Element("shaderFilterArray").Attribute("shaderFilterMode").Value);

            List<string> parameterProxyFilters = ReadParameterValueChildren(element.Element("proxyFilterArray"), "filter");
            int parameterProxyFilterMode = ParseParameterType<int>(element.Element("proxyFilterArray").Attribute("proxyFilterMode").Value);

            return new MaterialParameter(parameterName,
                                         parameter,
                                         parameterType,
                                         parameterValue,
                                         parameterForce,
                                         parameterRandomChance,
                                         parameterRandomOffset,
                                         parameterRandomChanceSeed,
                                         parameterRandomOffsetSeed,
                                         parameterShaderFilters,
                                         parameterShaderFilterMode,
                                         parameterProxyFilters,
                                         parameterProxyFilterMode);
        }

        private static LocalisationParameter ParseLocalisationElementIntoParam(XElement element)
        {
            string parameterName = element.Element("paramName").Value;
            string parameterRegex = element.Element("regexExpression").Value;
            int.TryParse(element.Element("matchType").Value, out int matchTypeIntVal);
            MatchActions parameterMatchType = (MatchActions)matchTypeIntVal;
            string parameterReplaceString = null;
            if (parameterMatchType == MatchActions.Replace)
            {
                parameterReplaceString = element.Element("replaceString").Value;
            }
            int parameterRandomChance = ParseParameterType<int>(element.Element("randomChance").Value);
            int parameterRandomIndividualChance = ParseParameterType<int>(element.Element("randomIndividualChance").Value);
            int parameterRandomChanceSeed = -1;
            int parameterRandomIndividualChanceSeed = -1;
            if (element.Element("randomChanceSeed") != null)
            {
                parameterRandomChanceSeed = ParseParameterType<int>(element.Element("randomChanceSeed").Value);
                parameterRandomIndividualChanceSeed = ParseParameterType<int>(element.Element("randomIndividualChanceSeed").Value);
            }
            bool parameterLetterCountFilter = element.Element("letterCountFilter").Value == "1";
            int parameterLetterCountMin = ParseParameterType<int>(element.Element("letterCountFilterMin").Value);
            int parameterLetterCountMax = ParseParameterType<int>(element.Element("letterCountFilterMax").Value);
            bool parameterSafeMode = element.Element("safeMode").Value == "1";
            bool parameterUsesRegex = element.Element("usesRegex").Value == "1";

            return new LocalisationParameter(parameterName,
                                             parameterRegex,
                                             parameterMatchType,
                                             parameterReplaceString,
                                             parameterRandomChance,
                                             parameterRandomIndividualChance,
                                             parameterRandomChanceSeed,
                                             parameterRandomIndividualChanceSeed,
                                             parameterLetterCountFilter,
                                             parameterLetterCountMin,
                                             parameterLetterCountMax,
                                             parameterSafeMode,
                                             parameterUsesRegex
                                             );
        }

        private static SoundParameter ParseSoundElementIntoParam(XElement element)
        {
            string parameterName = element.Element("paramName").Value;
            string parameterRegex = element.Element("regexExpression").Value;
            int.TryParse(element.Element("paramType").Value, out int matchTypeIntVal);
            SoundActions parameterType = (SoundActions)matchTypeIntVal;
            List<SoundFileEntry> parameterSounds = ReadParameterValueChildren(element.Element("soundArray"), "location").Select(x => new SoundFileEntry() { id = 0, fileLocation = x }).ToList();
            SoundscriptEntry parameterEntry = new SoundscriptEntry();
            if (parameterType == SoundActions.ModifySoundscript && element.Element("soundscriptEntry") != null)
            {
                XContainer soundscriptEntry = element.Element("soundscriptEntry");
                int.TryParse(soundscriptEntry.Element("channel").Value, out int channelIntVal);
                parameterEntry.channel = (Channels)channelIntVal;
                parameterEntry.volume = soundscriptEntry.Element("volume").Value;
                parameterEntry.pitch = soundscriptEntry.Element("pitch").Value;
                parameterEntry.soundlevel = soundscriptEntry.Element("soundlevel").Value;
            }
            bool parameterReplaceRndWave = element.Element("replaceRndWave").Value == "1";
            int parameterRandomChance = ParseParameterType<int>(element.Element("randomChance").Value);
            int parameterRandomChanceSeed = ParseParameterType<int>(element.Element("randomChanceSeed").Value);

            return new SoundParameter(parameterName,
                                      parameterRegex,
                                      parameterType,
                                      parameterEntry,
                                      parameterSounds,
                                      parameterReplaceRndWave,
                                      parameterRandomChance,
                                      parameterRandomChanceSeed);
        }

        /// <summary>
        /// Reads the child nodes of a parameter, and returns a string list of the element values.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="childrenName"></param>
        /// <returns></returns>
        private static List<string> ReadParameterValueChildren(XElement element, XName childrenName)
        {
            List<string> childList = new List<string>();
            
            foreach (XElement child in element.Elements(childrenName))
            {
                childList.Add(child.Value);
            }
            return childList;
        }

        public static List<string> ReadParameterValueChildren(string element, XName childrenName)
        {
            return ReadParameterValueChildren(new XElement(element), childrenName);
        }

        /// <summary>
        /// Reads the child nodes of an XML parameter, and returns a string array list of the attribute values of each child key.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="childrenName"></param>
        /// <returns></returns>
        private static List<string[]> ReadParameterValueChildren(XElement element, XName childrenName, params string[] attributeKeys)
        {
            List<string[]> childList = new List<string[]>();

            foreach (XElement child in element.Elements(childrenName))
            {
                XAttribute[] childrenAttributes = child.Attributes().ToArray();
                string[] attrArray = new string[childrenAttributes.Count()];

                for(int i = 0; i < attributeKeys.Count(); i++)
                {
                    attrArray[i] = childrenAttributes[i].Value;
                }
                childList.Add(attrArray);
            }
            return childList;
        }

        public static List<string[]> ReadParameterValueChildren(string element, XName childrenName, params string[] attributeKeys)
        {
            return ReadParameterValueChildren(new XElement(element), childrenName, attributeKeys);
        }

        public static int CheckVersioning(string xmlPath)
        {
            string parameterStorageVersion = ConfirmXmlVersion(xmlPath + "\\parameterStorage.xml");
            string corruptionStorageVersion = ConfirmXmlVersion(xmlPath + "\\corruptionStorage.xml");
            
            if (parameterStorageVersion == "0.5.0")
            {
                //0.5.4:
                // - Added random seed values to materials.
                foreach (MaterialParameter item in materialParametersList)
                {
                    item.RandomizerChanceSeed = -1;
                    item.RandomizerOffsetSeed = -1;
                }
            }
            if (corruptionStorageVersion == "0.5.0")
            {
                //Note: The development process of adding these is to decide on the features first, then increase the version as these new features are added.
                //While the works for releases, releases after 0.5.4 will need to adhere to consistency with new features.

                //0.5.4:
                // - Introduced Swap Language. While this was inserted into the XML file initially, this was missing from it.
                // - Default value of IgnoreNoMatchingTokens set to 1.
                // - Added 4 new values to Material Corruption OffsetValue.
                // - Added a new corruption method.
                localisationCorruptionSettings[1].Arguments.Add("IgnoreRepeatingTokens", "1");
                localisationCorruptionSettings[1].Arguments["IgnoreNoMatchingTokens"] = "1";
                materialCorruptionSettings[1].Arguments.Add("LowBoundEnabled", "1");
                materialCorruptionSettings[1].Arguments.Add("HighBoundEnabled", "1");
                materialCorruptionSettings[1].Arguments.Add("LowBoundValue", "0");
                materialCorruptionSettings[1].Arguments.Add("HighBoundValue", "100");
                
                localisationCorruptionSettings.Add(new LocalisationCorruptionSettings()
                {
                    CorruptionType = LocalisationCorruptionSettings.CorruptionTypes.OffsetAscii,
                    Enabled = true,
                    KeyFilterArray = new List<string>(),
                    KeyFilterMode = 0,
                    RegularExpressionEnabled = false,
                    RegularExpressionPattern = "",
                    RegularExpressionMode = 1,
                    SafeMode = true,
                    SkipUnsafeEntries = true,
                    IgnoreNewlines = true,
                    Arguments = new Dictionary<string, string>()
                    {
                        {"OffsetLow", "-25"},
                        {"OffsetHigh", "25"},
                        {"LowBoundEnabled", "0"},
                        {"HighBoundEnabled", "0"},
                        {"LowBoundValue", "0"},
                        {"HighBoundValue", "0"}
                    },
                    Probability = 100,
                });

                WriteXmlCorruptionParameters(xmlPath);
                return 1; //Resolved mismatch.
            }
            if (parameterStorageVersion == version && corruptionStorageVersion == version)
            {
                return -1; //No mismatch detected.
            }
            return 0; //Version unknown. Cannot resolve mismatch.
        }
    }
}
