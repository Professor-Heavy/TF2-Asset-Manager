using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using NAudio.MediaFoundation;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    class ExportProcess
    {
        public class ExportSettings
        {
            public MaterialParameter[] MaterialParameters { get; set; }
            public LocalisationParameter[] LocalisationParameters { get; set; }
            public MaterialCorruptionSettings[] MaterialCorruptionSettings { get; set; }
            public LocalisationCorruptionSettings[] LocalisationCorruptionSettings { get; set; }
            public SoundParameter[] SoundParameters { get; set; }
            public ExportSettings()
            {

            }
        }
        static public async Task<bool> Export(string executableDirectory, bool useCustomFiles, List<string> customFiles, MainWindow exportWindow, ExportSettings exportSettings)
        {
            DirectoryInfo exportPath = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileNameWithoutExtension(Properties.Settings.Default.VpkLocation)));
            bool actionsPerformed = false;
            if (exportSettings.MaterialParameters.Length != 0 || exportSettings.MaterialCorruptionSettings != null)
            {
                Dictionary<string, string> materialVpkData = await Task.Run(() => ReadMaterialFiles(executableDirectory, useCustomFiles, customFiles, exportWindow));
                if (exportSettings.MaterialParameters.Length != 0)
                {
                    materialVpkData = await Task.Run(() => MaterialModify(materialVpkData, exportWindow, exportSettings.MaterialParameters));
                }
                if (exportSettings.MaterialCorruptionSettings != null)
                {
                    materialVpkData = await Task.Run(() => MaterialCorrupt(materialVpkData, exportWindow, exportSettings.MaterialCorruptionSettings));
                }
                actionsPerformed = true;
                exportWindow.WriteMessage("Writing all material corruptions to temp folder. The application may hang during the process.");
                ExportMaterialsToTemporaryStorage(materialVpkData, exportWindow, exportPath);
            }
            if (exportSettings.LocalisationParameters.Length != 0 || exportSettings.LocalisationCorruptionSettings != null)
            {
                Dictionary<string, string> localisationData = await Task.Run(() => ReadLocalisationFiles(executableDirectory, "english", exportWindow));
                Dictionary<string, string> modifiedLocalisationData = null;
                if (exportSettings.LocalisationParameters.Length != 0)
                {
                    modifiedLocalisationData = LocalisationModify(localisationData, exportSettings.LocalisationParameters, exportWindow);
                }
                if (exportSettings.LocalisationCorruptionSettings != null)
                {
                    modifiedLocalisationData = LocalisationCorrupt(localisationData, exportSettings.LocalisationCorruptionSettings, exportWindow);
                }
                actionsPerformed = true;
                string assembledLocalisationData = BuildLocalisationFile(modifiedLocalisationData);
                ExportLocalisationFile(assembledLocalisationData, exportWindow, exportPath);
            }
            if (exportSettings.SoundParameters.Length != 0 )
            {
                Dictionary<string, string> soundscriptData = await Task.Run(() => ReadSoundscriptFiles(executableDirectory, exportWindow));
                Dictionary<string, string> modifiedSoundscriptData = null;
                if (exportSettings.SoundParameters.Length != 0)
                {
                    MediaFoundationApi.Startup();
                    modifiedSoundscriptData = SoundscriptModify(soundscriptData, exportWindow, exportSettings.SoundParameters);
                    ExportAudioFilesToTemporaryStorage(exportWindow, exportPath, exportSettings.SoundParameters);
                }
                BuildAndExportSoundscriptFiles(modifiedSoundscriptData, exportWindow, exportPath);
                actionsPerformed = true;
            }
            if (actionsPerformed == false)
            {
                exportWindow.WriteMessage("ERROR: No parameters of any type have been enabled.", MainWindow.ExportState.ErrorFatal);
                return false;
            }
            else
            {
                exportWindow.WriteMessage("Packaging file to VPK.");
                await Task.Run(() => VPKInteraction.PackageToVpk(executableDirectory, exportPath));
                return true;
            }
        }

        #region Material Process

        static private Dictionary<string, string> ReadMaterialFiles(string executableDirectory, bool useCustomFiles, List<string> customFiles, MainWindow exportWindow)
        {
            exportWindow.WriteMessage("Searching for materials...");
            Dictionary<string, string> returnedData;
            returnedData = VPKInteraction.ExtractSpecificFileTypeFromVPK(Path.Combine(executableDirectory, "tf\\tf2_misc_dir.vpk"), "vmt");
            exportWindow.WriteMessage("Found " + returnedData.Count + " material assets.");
            if (useCustomFiles)
            {
                exportWindow.WriteMessage("Searching for materials in custom files...");
                Dictionary<string, string> customReturnedData = VPKInteraction.ExtractSpecificFileTypesFromCustomDirectory(Path.Combine(executableDirectory, "tf\\custom"), "vmt", customFiles);
                foreach (var customFile in customReturnedData)
                {
                    if (returnedData.ContainsKey(customFile.Key)) //TODO: This is a large dictionary. Is this a good idea?
                    {
                        exportWindow.WriteMessage("Found custom file: " + customFile.Key + ". This custom file has overwritten another asset.");
                        returnedData[customFile.Key] = customFile.Value;
                    }
                    else
                    {
                        exportWindow.WriteMessage("Found custom file: " + customFile.Key + ".");
                        returnedData.Add(customFile.Key, customFile.Value); //TODO: Would it be possible to use enumerables?
                    }
                }
                string[] files = Directory.GetFiles(Path.Combine(executableDirectory, "tf\\custom"), "*.vpk");
                foreach (string file in files)
                {
                    if (customFiles.Contains(Path.GetFileName(file)))
                    {
                        Dictionary<string, string> extractedVpk = VPKInteraction.ExtractSpecificFileTypeFromVPK(file, "vmt");
                        foreach (var customFile in extractedVpk)
                        {
                            if (returnedData.ContainsKey(customFile.Key)) //TODO: This is a large dictionary. Is this a good idea?
                            {
                                exportWindow.WriteMessage("Found custom file: " + customFile.Key + " in a VPK. This custom file has overwritten another asset.\r\n");
                                returnedData[customFile.Key] = customFile.Value;
                            }
                            else
                            {
                                exportWindow.WriteMessage("Found custom file: " + customFile.Key + " in a VPK.");
                                returnedData.Add(customFile.Key, customFile.Value); //TODO: Would it be possible to use enumerables?
                            }
                        }
                    }
                }
                exportWindow.WriteMessage("Found " + customReturnedData.Count + " custom assets (Excluding VPKs).");
            }
            return returnedData;
        }

        static private Dictionary<string, VProperty> ParseMaterialDictionary(Dictionary<string, string> materialVpkData, MainWindow exportWindow)
        {
            Dictionary<string, VProperty> parsedData = new Dictionary<string, VProperty>();
            VdfSerializerSettings settings = new VdfSerializerSettings
            {
                UsesEscapeSequences = false
            };
            foreach (var a in materialVpkData)
            {
                try
                {
                    VProperty conversion = VdfConvert.Deserialize(materialVpkData[a.Key], settings);
                    parsedData.Add(a.Key, conversion);
                }
                catch (Exception ex)
                {
                    exportWindow.WriteMessage("The file " + a.Key + " could not be corrupted.");
                }
            }
            return parsedData;
        }

        static private Dictionary<string, string> RestoreMaterialDictionary(Dictionary<string, VProperty> materialVpkData)
        {
            Dictionary<string, string> parsedData = new Dictionary<string, string>();
            VdfSerializerSettings settings = new VdfSerializerSettings
            {
                UsesEscapeSequences = false
            };
            foreach (var a in materialVpkData)
            {
                parsedData.Add(a.Key, VdfConvert.Serialize(a.Value, settings));
            }
            return parsedData;
        }

        static private Dictionary<string, List<string>> MaterialSearchForRepeatedParameters(Dictionary<string, VProperty> parsedData)
        {
            Dictionary<string, List<string>> parameterListing = new Dictionary<string, List<string>>();
            foreach (var data in parsedData)
            {
                foreach (var child in data.Value.Value.Children())
                {
                    if(parameterListing.ContainsKey(child.Key.ToLower()))
                    {
                        parameterListing[child.Key.ToLower()].Add(data.Key);
                    }
                    else
                    {
                        parameterListing.Add(child.Key.ToLower(), new List<string> { data.Key });
                    }
                }
            }
            return parameterListing;
        }

        static private Dictionary<string, VProperty> MaterialRunShaderFilter(Dictionary<string, VProperty> parsedData, int filterMode, List<string> filterArray)
        {
            Dictionary<string, VProperty> filteredData = new Dictionary<string, VProperty>();
            foreach (var entry in parsedData)
            {
                if (TestForFilteredShaders(filterMode, entry.Value, filterArray))
                {
                    filteredData.Add(entry.Key, entry.Value);
                }
            }
            return filteredData;
        }

        static private Dictionary<string, VProperty> MaterialRunProxyFilter(Dictionary<string, VProperty> parsedData, int filterMode, List<string> filterArray)
        {
            Dictionary<string, VProperty> filteredData = new Dictionary<string, VProperty>();
            foreach (var entry in parsedData)
            {
                if (TestForFilteredProxies(filterMode, entry.Value, filterArray))
                {
                    filteredData.Add(entry.Key, entry.Value);
                }
            }
            return filteredData;
        }

        static private Dictionary<string, string> MaterialModify(Dictionary<string, string> materialVpkData, MainWindow exportWindow, MaterialParameter[] materialParameters)
        {
            Dictionary<string, VProperty> parsedData = ParseMaterialDictionary(materialVpkData, exportWindow);
            Dictionary<string, VProperty> modifiedData = new Dictionary<string, VProperty>();
            Random randomChanceGen = new Random();
            Random randomOffsetGen = new Random();
            Random randomChoiceGen = new Random();
            foreach (MaterialParameter enabledParameter in materialParameters)
            {
                Dictionary<string, VProperty> filteredData = MaterialRunShaderFilter(parsedData, enabledParameter.ShaderFilterMode, enabledParameter.ShaderFilterArray);
                filteredData = MaterialRunProxyFilter(filteredData, enabledParameter.ProxyFilterMode, enabledParameter.ProxyFilterArray);

                foreach (var parsedEntry in filteredData)
                {
                    bool entryAlreadyModified = false;
                    VProperty conversion = null;
                    if (modifiedData.ContainsKey(parsedEntry.Key))
                    {
                        conversion = modifiedData[parsedEntry.Key];
                        entryAlreadyModified = true;
                    }
                    else
                    {
                        conversion = parsedEntry.Value;
                    }

                    if (enabledParameter.RandomizerChance != 100
                        && randomChanceGen.Next(1, 101) >= enabledParameter.RandomizerChance + 1) //TODO: Confirm this is accurate..?
                    {
                        continue;
                    }
                    float[] valueOffset = enabledParameter.RandomizerOffset;
                    switch (enabledParameter.ParamType.ToString())
                    {
                        case "vector3":

                            for (int i = 0; i < valueOffset.Length; i++)
                            {
                                if (enabledParameter.RandomizerOffset[i] != 0.0f)
                                {
                                    valueOffset[i] *= (float)(randomOffsetGen.NextDouble() * 2.0 - 1.0);
                                }
                            }

                            if (enabledParameter.Parameter == "$color" || enabledParameter.Parameter == "$color2")
                            {
                                conversion = VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                                      VMTInteraction.PerformColorChecks(conversion.Key),
                                                                                      VMTInteraction.ConvertStringToVector3Int(enabledParameter.ParamValue));
                            }
                            else
                            {
                                conversion = VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                                      enabledParameter.Parameter,
                                                                                      VMTInteraction.ConvertStringToVector3Int(enabledParameter.ParamValue));
                            }
                            break;
                        case "boolean":
                            conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, int.Parse(enabledParameter.ParamValue));
                            break;
                        case "integer":
                            conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, int.Parse(enabledParameter.ParamValue) + (int)Math.Ceiling(valueOffset[0]));
                            break;
                        case "string":
                            conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue);
                            break;
                        case "float":
                            conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, float.Parse(enabledParameter.ParamValue + valueOffset[0]));
                            break;
                        case "proxy":
                            conversion = VMTInteraction.InsertProxyIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue);
                            break;
                        case "choices":
                            conversion = VMTInteraction.InsertRandomChoiceIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue, randomChoiceGen);
                            break;
                        default:
                            exportWindow.WriteMessage("Found unimplemented type: " + enabledParameter.ParamType.ToString());
                            break; //Unimplemented type.
                    }
                    if(entryAlreadyModified)
                    {
                        modifiedData[parsedEntry.Key] = conversion;
                    }
                    else
                    {
                        modifiedData.Add(parsedEntry.Key, conversion);
                    }
                }
            }
            exportWindow.WriteMessage("Out of " + materialVpkData.Count + " assets, " + modifiedData.Count + " were modified.");
            return RestoreMaterialDictionary(modifiedData);
        }

        static private Dictionary<string, string> MaterialCorrupt(Dictionary<string, string> materialVpkData, MainWindow exportWindow, MaterialCorruptionSettings[] settings)
        {
            Dictionary<string, VProperty> parsedData = ParseMaterialDictionary(materialVpkData, exportWindow);
            Dictionary<string, VProperty> modifiedData = new Dictionary<string, VProperty>();
            Dictionary<string, List<string>> repeatedParameters = MaterialSearchForRepeatedParameters(parsedData); //We gained speed, but we lost RAM.

            Random randomChanceGen = new Random();
            Random randomChoiceGen = new Random();
            Random randomOffsetGen = new Random();
            for (int i = 0; i < settings.Length; i++)
            {
                MaterialCorruptionSettings currentSetting = settings[i];
                Dictionary<string, VProperty> filteredData = MaterialRunShaderFilter(parsedData, currentSetting.ShaderFilterMode, currentSetting.ShaderFilterArray);
                Dictionary<string, List<string>> filteredParameterOccurrences = new Dictionary<string, List<string>>(); //HACK: It's like going from one extreme to the other. Actual stability at the cost of RAM.
                List<string> filteredFileNames = filteredData.Select(x => x.Key).ToList();
                foreach (var repeatedParameter in repeatedParameters)
                {
                    //TODO: Is this correct?
                    filteredParameterOccurrences.Add(repeatedParameter.Key, repeatedParameter.Value.Intersect(filteredFileNames).ToList());
                }
                foreach (var parsedEntry in filteredData)
                {
                    if (currentSetting.Enabled == false)
                    {
                        continue;
                    }
                    bool changed = false;
                    VProperty conversion = null;
                    if (modifiedData.ContainsKey(parsedEntry.Key))
                    {
                        conversion = modifiedData[parsedEntry.Key];
                    }
                    else
                    {
                        conversion = parsedEntry.Value;
                    }

                    switch (currentSetting.CorruptionType)
                    {
                        case (int)MaterialCorruptionSettings.CorruptionTypes.SwapParameters:
                            if (currentSetting.Probability != 100
                            && randomChanceGen.Next(1, 101) >= currentSetting.Probability + 1) //TODO: Confirm this is accurate too..?
                            {
                                continue;
                            }
                            if (currentSetting.ParameterFilterMode == 1)
                            {
                                foreach (string parameter in currentSetting.ParameterFilterArray)
                                {
                                    if (VMTInteraction.CaseInsensitiveParameterCheck(conversion.Value, parameter).Value != null)
                                    {
                                        List<string> parameterOccurrences = filteredParameterOccurrences[parameter.ToLower()];
                                        string swapTargetName = parameterOccurrences[randomChoiceGen.Next(0, parameterOccurrences.Count)];
                                        VProperty swapTarget = filteredData[swapTargetName];

                                        VProperty[] swappedParams = SwapMaterialParameters(conversion, swapTarget, parameter);
                                        changed = true;
                                        conversion = swappedParams[0];

                                        if (modifiedData.ContainsKey(swapTargetName))
                                        {
                                            modifiedData[swapTargetName] = swappedParams[1];
                                        }
                                        else
                                        {
                                            modifiedData.Add(swapTargetName, swappedParams[1]);
                                        }
                                    };
                                }
                            }
                            else
                            {
                                foreach (VProperty vValue in conversion.Value)
                                {
                                    List<string> parameterOccurrences = filteredParameterOccurrences[vValue.Key.ToLower()];
                                    if (parameterOccurrences.Count == 1)
                                    {
                                        exportWindow.WriteMessage("Could only find one occurrence of parameter " + vValue.Key.ToLower() + " from file " + parsedEntry.Key + ". Skipping...");
                                        continue;
                                    }
                                    string swapTargetName = parameterOccurrences[randomChoiceGen.Next(0, parameterOccurrences.Count)];
                                    VProperty swapTarget = filteredData[swapTargetName];

                                    bool containsExcludedParam = false;
                                    foreach (string parameter in currentSetting.ParameterFilterArray)
                                    {
                                        if (string.Equals(vValue.Key, parameter, StringComparison.OrdinalIgnoreCase))
                                        {
                                            containsExcludedParam = true;
                                        }
                                    }
                                    if (containsExcludedParam == true)
                                    {
                                        continue;
                                    }
                                    VProperty[] swappedParams = SwapMaterialParameters(conversion, swapTarget, vValue.Key);

                                    changed = true;
                                    conversion = swappedParams[0];

                                    if (modifiedData.ContainsKey(swapTargetName))
                                    {
                                        modifiedData[swapTargetName] = swappedParams[1];
                                    }
                                    else
                                    {
                                        modifiedData.Add(swapTargetName, swappedParams[1]);
                                    }
                                }
                            }
                            break;
                        case MaterialCorruptionSettings.CorruptionTypes.OffsetValues:
                            if (currentSetting.Probability != 100
                            && randomChanceGen.Next(1, 101) >= currentSetting.Probability + 1) //TODO: Confirm this is accurate too..?
                            {
                                continue;
                            }
                            if (currentSetting.ParameterFilterMode == 1)
                            {
                                foreach (string parameter in currentSetting.ParameterFilterArray)
                                {
                                    VProperty caseMatchedParameter = VMTInteraction.CaseInsensitiveParameterCheck(conversion.Value, parameter);
                                    if (caseMatchedParameter.Value != null)
                                    {
                                        if (float.TryParse(conversion.Value[caseMatchedParameter.Key].ToString(), out float value))
                                        {
                                            float newValue = value + randomOffsetGen.Next(int.Parse(currentSetting.Arguments["OffsetLow"]), int.Parse(currentSetting.Arguments["OffsetHigh"]));
                                            if(currentSetting.Arguments["LowBoundEnabled"] == "1" && newValue < int.Parse(currentSetting.Arguments["LowBoundValue"]))
                                            {
                                                newValue = int.Parse(currentSetting.Arguments["LowBoundValue"]);
                                            }
                                            if (currentSetting.Arguments["HighBoundEnabled"] == "1" && newValue > int.Parse(currentSetting.Arguments["HighBoundValue"]))
                                            {
                                                newValue = int.Parse(currentSetting.Arguments["HighBoundValue"]);
                                            }
                                            VValue vvalue = new VValue(newValue);
                                            conversion.Value[caseMatchedParameter.Key] = vvalue;
                                            changed = true;
                                        }
                                    };
                                }
                            }
                            else
                            {
                                foreach (VProperty vValue in conversion.Value)
                                {
                                    bool containsExcludedParam = false;
                                    foreach (string parameter in currentSetting.ParameterFilterArray)
                                    {
                                        if (string.Equals(vValue.Key, parameter, StringComparison.OrdinalIgnoreCase))
                                        {
                                            containsExcludedParam = true;
                                        }
                                    }
                                    if (containsExcludedParam == true)
                                    {
                                        continue;
                                    }

                                    VProperty caseMatchedParameter = VMTInteraction.CaseInsensitiveParameterCheck(conversion.Value, vValue.Key);
                                    if (caseMatchedParameter.Value != null)
                                    {
                                        if (float.TryParse(conversion.Value[caseMatchedParameter.Key].ToString(), out float value))
                                        {
                                            float newValue = value + randomOffsetGen.Next(int.Parse(currentSetting.Arguments["OffsetLow"]), int.Parse(currentSetting.Arguments["OffsetHigh"]));
                                            if (currentSetting.Arguments["LowBoundEnabled"] == "1" && newValue < int.Parse(currentSetting.Arguments["LowBoundValue"]))
                                            {
                                                newValue = int.Parse(currentSetting.Arguments["LowBoundValue"]);
                                            }
                                            if (currentSetting.Arguments["HighBoundEnabled"] == "1" && newValue > int.Parse(currentSetting.Arguments["HighBoundValue"]))
                                            {
                                                newValue = int.Parse(currentSetting.Arguments["HighBoundValue"]);
                                            }
                                            VValue vvalue = new VValue(newValue);
                                            conversion.Value[caseMatchedParameter.Key] = vvalue;
                                            changed = true;
                                        }
                                    };
                                }
                            }
                            break;
                    }
                    if (modifiedData.ContainsKey(parsedEntry.Key))
                    {
                        modifiedData[parsedEntry.Key] = conversion;
                    }
                    else
                    {
                        if(changed)
                        {
                            modifiedData.Add(parsedEntry.Key, conversion);
                        }
                    }
                }
            }

            exportWindow.WriteMessage("Out of " + materialVpkData.Count + " assets, " + modifiedData.Count + " were corrupted.");
            return RestoreMaterialDictionary(modifiedData);
        }

        static private VProperty[] SwapMaterialParameters(dynamic materialFile, dynamic secondaryMaterialFile, string parameter)
        {
            string primaryParameter = VMTInteraction.CaseInsensitiveParameterCheck(materialFile.Value, parameter).Key;
            string secondaryParameter = VMTInteraction.CaseInsensitiveParameterCheck(secondaryMaterialFile.Value, parameter).Key;
            dynamic temporaryValue = materialFile.Value[primaryParameter];
            materialFile.Value[primaryParameter] = secondaryMaterialFile.Value[secondaryParameter];
            secondaryMaterialFile.Value[secondaryParameter] = temporaryValue;
            return new VProperty[] { materialFile, secondaryMaterialFile };
        }

        /// <summary>
        /// Performs a test on a materialFile to see if the shader is being used, and returns the result of the filter.
        /// </summary>
        /// <param name="filterMode">Set to 0 if it should NOT be used, set to 1 if it SHOULD ONLY be used.</param>
        /// <param name="materialFile"></param>
        /// <param name="shaderFilterArray"></param>
        /// <returns>True if the parameter be included, false if not.</returns>
        static private bool TestForFilteredShaders(int filterMode, dynamic materialFile, List<string> shaderFilterArray)
        {
            foreach (string shaderFilter in shaderFilterArray)
            {
                //FilterMode == 1 returns false if the filter mode is set to exclusion.
                //materialFile.Key.Equals(shaderFilter, StringComparison.OrdinalIgnoreCase) compares the two regardless of case.
                if (materialFile.Key.Equals(shaderFilter, StringComparison.OrdinalIgnoreCase) == (filterMode == 0))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Performs a test on a materialFile to see if a proxy exists, and returns the result of the filter. TODO: Verify if this code is valid..
        /// </summary>
        /// <param name="filterMode">Set to 0 if it should NOT be used, set to 1 if it SHOULD ONLY be used.</param>
        /// <param name="materialFile"></param>
        /// <param name="proxyFilterArray"></param>
        /// <returns>True if the parameter can be included, false if not.</returns>
        static private bool TestForFilteredProxies(int filterMode, dynamic materialFile, List<string> proxyFilterArray)
        {
            bool inclusive = filterMode == 1; //If it should only be used, this will equal true!
            bool proxyFound = false;
            foreach (string proxyFilter in proxyFilterArray)
            {
                if (VMTInteraction.ContainsProxy(materialFile, proxyFilter))
                {
                    proxyFound = true;
                }
            }
            //If the mode is inclusive and a proxy is found, both of these values should match.
            //If the mode is exclusive and a proxy isn't found, both of these values should match.
            return inclusive == proxyFound;
        }
        #endregion

        #region Localisation Process

        static private Dictionary<string, string> ReadLocalisationFiles(string executableDirectory, string language, MainWindow exportWindow)
        {
            exportWindow.WriteMessage("Searching for " + language + " localisation entries...");
            Dictionary<string, string> returnedData;
            string rawString;
            try
            {
                rawString = File.ReadAllText(Path.Combine(executableDirectory, "tf\\resource\\tf_" + language + ".txt"));
            }
            catch
            {
                exportWindow.WriteMessage("An unknown error occurred when trying to load localisation files. Please update your localisation files and verify your TF2 installation.", MainWindow.ExportState.Error);
                return null;
            }
            returnedData = TXTInteraction.PerformRegexTest(rawString);
            exportWindow.WriteMessage("Found " + returnedData.Count + " assets to edit.");
            return returnedData;
        }

        static private Dictionary<string, string> LocalisationModify(Dictionary<string, string> tokens, LocalisationParameter[] localisationParameters, MainWindow exportWindow)
        {
            Dictionary<string, string> modifiedData = new Dictionary<string, string>();
            Random randomChanceGen = new Random();
            foreach (var token in tokens)
            {
                string modifiedString = token.Value;
                foreach (LocalisationParameter enabledParameter in localisationParameters)
                {
                    if (enabledParameter.RandomizerChance != 100
                            && randomChanceGen.Next(1, 101) >= enabledParameter.RandomizerChance + 1
                            && (modifiedString.Length > enabledParameter.LetterCountFilterMax || modifiedString.Length < enabledParameter.LetterCountFilterMin)) //TODO: Seriously, do some small tests.
                    {
                        continue;
                    }
                    modifiedString = TXTInteraction.ModifyWithRegex(modifiedString, enabledParameter, randomChanceGen);
                }
                modifiedData.Add(token.Key, modifiedString);
            }
            return modifiedData;
        }

        static private Dictionary<string, string> LocalisationCorrupt(Dictionary<string, string> tokens, LocalisationCorruptionSettings[] settings, MainWindow exportWindow)
        {
            Dictionary<string, string> modifiedData = tokens;
            Random randomChanceGen = new Random();
            Dictionary<string, string> leftoverData = tokens;
            foreach (LocalisationCorruptionSettings enabledParameter in settings)
            {
                Dictionary<string, string> filteredData = new Dictionary<string, string>();

                Dictionary<LanguageSettings, Dictionary<string, string>> secondaryLanguage = null;
                float languageMaxWeight = 0.0f;
                if (enabledParameter.RegularExpressionEnabled)
                {
                    filteredData = LocalisationRunRegexFilter(tokens, enabledParameter.RegularExpressionMode, enabledParameter.RegularExpressionPattern, enabledParameter.SafeMode, enabledParameter.IgnoreNewlines, enabledParameter.SkipUnsafeEntries);
                }
                else
                {
                    filteredData = LocalisationRunRegexFilter(tokens, enabledParameter.RegularExpressionMode, string.Empty, enabledParameter.SafeMode, enabledParameter.IgnoreNewlines, enabledParameter.SkipUnsafeEntries);
                }
                if (enabledParameter.Enabled == false)
                {
                    continue;
                }
                if (enabledParameter.Probability != 100
                        && randomChanceGen.Next(1, 101) >= enabledParameter.Probability + 1) //TODO: Come on... Confirm it already.
                {
                    continue;
                }
                Random randomChoiceGen = new Random();
                switch (enabledParameter.CorruptionType)
                {
                    case LocalisationCorruptionSettings.CorruptionTypes.SwapEntries:
                        randomChoiceGen = new Random();
                        //Choosing to ignore newline in this check because it won't be that catastrophic if they're allowed.
                        //The only reason why this Safe Mode ignores these things entirely is because there are cases in where important
                        //localisation tokens for "formats" are overwritten entirely and I can't prevent that.

                        //We won't work around the regex either in this particular corruption.
                        foreach (var token in filteredData)
                        {
                            string modifiedString = token.Value;
                            bool regexAffectSwaps = enabledParameter.Arguments["RegexForMatchesAndSwaps"] == "true";
                            KeyValuePair<string, string> value;
                            if (regexAffectSwaps && enabledParameter.RegularExpressionEnabled)
                            {
                                value = filteredData.ElementAt(randomChoiceGen.Next(0, filteredData.Count));
                                modifiedString = value.Value;
                                modifiedData[token.Key] = modifiedString;
                                modifiedData[value.Key] = token.Value;
                            }
                            else
                            {
                                //TODO: This is acceptable for now.
                                do
                                {
                                    value = modifiedData.ElementAt(randomChoiceGen.Next(0, modifiedData.Count));
                                } while (enabledParameter.SafeMode && TXTInteraction.SpecialCharacterCheck(value.Value, true, enabledParameter.IgnoreNewlines));
                                modifiedString = value.Value;
                                modifiedData[token.Key] = modifiedString;
                                modifiedData[value.Key] = token.Value;
                            }
                        }
                    break;
                    case LocalisationCorruptionSettings.CorruptionTypes.SwapLanguage:
                        randomChoiceGen = new Random();
                        //TODO: For the time being, this code does not "swap" languages.
                        //Rather, it pulls an entry from another language, leaving the original entry intact.
                        //In addition, this does not actually use the regex value...
                        if (secondaryLanguage == null)
                        {
                            secondaryLanguage = new Dictionary<LanguageSettings, Dictionary<string, string>>();

                            string[] languagesEnabled = enabledParameter.Arguments["LanguagesEnabled"].Split(',');
                            string[] overrideRegexEnabled = enabledParameter.Arguments["OverrideRegexEnabled"].Split(',');
                            string[] overrideRegexValues = enabledParameter.Arguments["OverrideRegexValues"].Split(',');
                            string[] overrideWeightEnabled = enabledParameter.Arguments["OverrideWeightEnabled"].Split(',');
                            string[] overrideWeightValues = enabledParameter.Arguments["OverrideWeightValues"].Split(',');
                            
                            for (int j = 0; j < languagesEnabled.Length; j++)
                            {
                                LanguageSettings languageSetting = new LanguageSettings
                                {
                                    Language = languagesEnabled[j],
                                    OverrideRegex = overrideRegexEnabled[j] == "1",
                                    OverrideRegexString = overrideRegexValues[j],
                                    OverrideWeight = overrideRegexEnabled[j] == "1",
                                    OverrideWeightValue = float.Parse(overrideWeightValues[j])
                                };
                                secondaryLanguage.Add(languageSetting, ReadLocalisationFiles(Properties.Settings.Default.GameLocation, languageSetting.Language, exportWindow));
                            }
                        }
                        foreach (var token in filteredData)
                        {
                            string modifiedString = token.Value;
                            languageMaxWeight = 0.0f;
                            //A considerably long function to have, but necessary to check just in case.
                            List<LanguageSettings> validLanguages = new List<LanguageSettings>();
                            if (enabledParameter.Arguments["IgnoreNoMatchingTokens"] == "0")
                            {
                                //If the setting to enforce token matches is disabled, it doesn't matter what we use.
                                //Just default to English if there was no match.
                                validLanguages = secondaryLanguage.Keys.ToList();
                                foreach (var language in validLanguages)
                                {
                                    languageMaxWeight += language.OverrideWeight ? language.OverrideWeightValue : 1.0f;
                                }
                            }
                            else
                            {
                                foreach (var language in secondaryLanguage)
                                {
                                    if (language.Value.ContainsKey(token.Key))
                                    {
                                        if (enabledParameter.Arguments["IgnoreRepeatingTokens"] == "1" && secondaryLanguage[language.Key][token.Key] == token.Value)
                                        {
                                            //The user has clearly specified that they don't want repeated tokens.
                                            continue;
                                        }
                                        validLanguages.Add(language.Key);
                                        languageMaxWeight += language.Key.OverrideWeight ? language.Key.OverrideWeightValue : 1.0f;
                                    }
                                }
                            }
                            if(validLanguages.Count == 0)
                            {
                                exportWindow.WriteMessage("Swap Languages: Could not find a corresponding localisation token for " + token.Key + " in any selected languages.");
                                continue;
                            }
                            //I'm assuming this is how weights work idk
                            float currentWeight = (float)randomChoiceGen.NextDouble() * languageMaxWeight;
                            float weightMatch = 0.0f;
                            string selectedLanguageName = null;
                            foreach (var language in validLanguages)
                            {
                                float lastWeight = weightMatch;
                                weightMatch += language.OverrideWeight ? language.OverrideWeightValue : 1.0f;
                                if (weightMatch > lastWeight && weightMatch > currentWeight)
                                {
                                    selectedLanguageName = language.ToString();
                                    break;
                                }
                            }
                            if (selectedLanguageName == null)
                            {
                                exportWindow.WriteMessage("Swap Languages: The Swap Language corruption encountered an error.");
                            }
                            LanguageSettings selectedLanguage = validLanguages.First(x => x.Language == selectedLanguageName);
                            if (enabledParameter.Arguments["IgnoreNoMatchingTokens"] == "0" && !secondaryLanguage[selectedLanguage].ContainsKey(token.Key))
                            {
                                exportWindow.WriteMessage("Swap Languages: Could not find a corresponding localisation token for " + token.Key + " in " + selectedLanguageName + ".");
                                continue;
                            }
                            modifiedString = secondaryLanguage[selectedLanguage][token.Key];
                            modifiedData[token.Key] = modifiedString;
                        }
                        break;
                    case LocalisationCorruptionSettings.CorruptionTypes.OffsetAscii:
                        randomChoiceGen = new Random();
                        //Unlike the last two corruptions, it's actually possible to filter around this one if Safe Mode is enabled.
                        AsciiSettings asciiSettings = new AsciiSettings
                        {
                            OffsetLow = int.Parse(enabledParameter.Arguments["OffsetLow"]),
                            OffsetHigh = int.Parse(enabledParameter.Arguments["OffsetHigh"]),
                            LowBoundEnabled = enabledParameter.Arguments["LowBoundEnabled"] == "1",
                            HighBoundEnabled = enabledParameter.Arguments["HighBoundEnabled"] == "1",
                            LowBoundValue = int.Parse(enabledParameter.Arguments["LowBoundValue"]),
                            HighBoundValue = int.Parse(enabledParameter.Arguments["HighBoundValue"])
                        };
                        foreach (var token in filteredData)
                        {
                            string modifiedString = token.Value;

                            //Effectively the same principle as the replacement regex.
                            List<string> specialCharacter = new List<string>();
                            List<string> segmentedInput = new List<string>();
                            int lastPoint = 0;
                            bool specialChracterFound = false;
                            System.Text.RegularExpressions.MatchCollection matches = TXTInteraction.RegexSearch(modifiedString, TXTInteraction.localisationSpecialCharacters);
                            foreach (System.Text.RegularExpressions.Match m in matches)
                            {
                                specialChracterFound = true;
                                segmentedInput.Add(modifiedString.Substring(lastPoint, m.Index - lastPoint));
                                specialCharacter.Add(modifiedString.Substring(m.Index, m.Length));
                                lastPoint = m.Index + m.Length;
                            }
                            if (specialChracterFound)
                            {
                                List<string> segmentedOutput = new List<string>();
                                foreach (string segment in segmentedInput)
                                {
                                    segmentedOutput.Add(TXTInteraction.OffsetStringDecimal(segment, enabledParameter.RegularExpressionPattern, asciiSettings, false, randomChoiceGen));
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
                                modifiedString = assembledOutput;
                            }
                            else
                            {
                                modifiedString = TXTInteraction.OffsetStringDecimal(modifiedString, enabledParameter.RegularExpressionPattern, asciiSettings, false, randomChoiceGen);
                            }
                            modifiedData[token.Key] = modifiedString;
                        }
                        break;
                    default:
                        break;
                }
            }
            return modifiedData;
        }
        static private Dictionary<string,string> LocalisationRunRegexFilter(Dictionary<string, string> inputData, int filterMode, string regex, bool safeMode, bool ignoreNewLines, bool skipUnsafeEntries)
        {
            Dictionary<string, string> outputData = new Dictionary<string, string>();

            foreach (var token in inputData)
            {
                if (safeMode && TXTInteraction.SpecialCharacterCheck(token.Value, true, ignoreNewLines) && skipUnsafeEntries)
                {
                    continue;
                }
                if (regex != string.Empty)
                {
                    if (TXTInteraction.RegexSearch(token.Value, regex).Count > 0 == (filterMode == 0))
                    {
                        continue;
                    }
                }
                outputData.Add(token.Key, token.Value);
            }
            return outputData;
        }

        static private string BuildLocalisationFile(Dictionary<string, string> tokens)
        {
            string encoding = ""; //BOM already specified within THE encoding. This is no longer necessary, but it wouldn't hurt.
            string assembledString = encoding + "\"lang\"\n{\n\"Language\" \"English\"\n\"Tokens\"\n{\n";
            foreach (var token in tokens)
            {
                assembledString += "\"" + token.Key + "\"" + " \"" + token.Value + "\"\n";
            }
            assembledString += "}\n}\n";
            return assembledString;
        }

        static private void ExportLocalisationFile(string fileData, MainWindow exportWindow, DirectoryInfo exportPath)
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(exportPath.FullName, "resource\\tf_english.txt")));
            di.Create();
            File.AppendAllText(Path.Combine(exportPath.FullName, "resource\\tf_english.txt"), fileData, new UnicodeEncoding(false, true, true));
        }

        #endregion

        #region Sound Process

        static private Dictionary<string, string> ReadSoundscriptFiles(string executableDirectory, MainWindow exportWindow)
        {
            exportWindow.WriteMessage("Searching for soundscript files...");
            Dictionary<string, string> returnedData;
            returnedData = VPKInteraction.ExtractSpecificFileTypeFromVPK(Path.Combine(executableDirectory, "tf\\tf2_misc_dir.vpk"), "txt");
            Dictionary<string, string> soundscriptData = returnedData.Where(x => x.Key.Contains("game_sounds")).ToDictionary(x => x.Key, x => x.Value);
            if (soundscriptData.ContainsKey("scripts/game_sounds_manifest.txt"))
            {
                //This should not be in here.
                soundscriptData.Remove("scripts/game_sounds_manifest.txt");
            }
            if (soundscriptData.ContainsKey("scripts/game_sounds_vo_phonemes.txt"))
            {
                //This should not be in here either.
                soundscriptData.Remove("scripts/game_sounds_vo_phonemes.txt");
            }
            exportWindow.WriteMessage("Found " + soundscriptData.Count + " soundscript files.");
            return soundscriptData;
        }

        static KeyValuePair<string,string> SeparateSoundscriptEntryKey(string key)
        {
            //Using a control character  to ensure they no regular characters could ever cause issues.
            string[] splitKey = key.Split('');
            return new KeyValuePair<string,string>(splitKey[0], splitKey[1]);
        }

        static string CreateSoundscriptEntryKey(string fileName, string entry)
        {
            return fileName + "" + entry;
        }

        static List<SoundscriptEntry> ParseSoundscriptEntries(string soundscriptFile)
        {
            List<SoundscriptEntry> allSoundscriptEntries;
            using (SoundscriptReader soundscriptReader = new SoundscriptReader(soundscriptFile))
            {
                allSoundscriptEntries = soundscriptReader.ReadToEnd().ToList();
            }
            return allSoundscriptEntries;
            //The lack of /X as a character in regex makes this hard.
            //string pattern = @"^""(.*?)""[\s\S]*?{[\s\S]*?(?(?=}\n)}|})";
        }

        static string RestoreSoundscriptEntry(SoundscriptEntry entry)
        {
            string assembledEntry = string.Concat('"', entry.name, "\"\n{\n",
                "\"channel\" \"", entry.channel.ToString(), "\"\n",
                "\"volume\" \"", entry.volume, "\"\n",
                "\"pitch\" \"", entry.pitch, "\"\n",
                "\"soundlevel\" \"", entry.soundlevel, "\"\n"
                );
            if(entry.isRndWave)
            {
                string rndWaveAssemble = string.Empty;
                foreach (string rndWave in entry.rndWave)
                {
                    rndWaveAssemble = string.Concat(rndWaveAssemble, "\"wave\" \"", rndWave, "\"\n");
                }
                assembledEntry = string.Concat(assembledEntry, "\"rndwave\" \n{\n", rndWaveAssemble, "}\n}");
            }
            else
            {
                assembledEntry = string.Concat(assembledEntry, "\"wave\" \"", entry.wave, "\"\n}");
            }
            return assembledEntry;
        }

        static Dictionary<string, string> SoundscriptModify(Dictionary<string, string> soundscriptData, MainWindow exportWindow, SoundParameter[] soundParameters)
        {
            //Dictionary<string, VProperty> parsedData = ParseSoundscriptDictionary(soundscriptData, exportWindow);
            Dictionary<string, SoundscriptEntry> allSoundscriptEntries = new Dictionary<string, SoundscriptEntry>();
            
            foreach (var item in soundscriptData)
            {
                List<SoundscriptEntry> soundscriptEntries = ParseSoundscriptEntries(item.Value);
                foreach (SoundscriptEntry entry in soundscriptEntries)
                {
                    if(allSoundscriptEntries.ContainsKey(CreateSoundscriptEntryKey(item.Key, entry.name)))
                    {
                        //Dear Valve. Please stop adding duplicates to VDFs. Much love, me.
                        continue;
                    }
                    allSoundscriptEntries.Add(CreateSoundscriptEntryKey(item.Key, entry.name), entry);
                }
            }
            exportWindow.WriteMessage("Found " + allSoundscriptEntries.Count + " soundscript entries.");
            Dictionary<string, SoundscriptEntry> modifiedData = new Dictionary<string, SoundscriptEntry>();
            Random randomChanceGen = new Random();
            
            foreach (var parsedEntry in allSoundscriptEntries)
            {
                SoundscriptEntry modifiedEntry = parsedEntry.Value;
                foreach (SoundParameter enabledParameter in soundParameters)
                {
                    if (enabledParameter.Regex != null && !Regex.IsMatch(modifiedEntry.name, enabledParameter.Regex, RegexOptions.Multiline))
                    {
                        continue;
                    }
                    switch (enabledParameter.Actions)
                    {
                        case SoundActions.ReplaceFileEntry:
                            modifiedEntry = SoundscriptInteraction.ReplaceSoundscriptFileEntry(modifiedEntry, enabledParameter);
                            break;
                        case SoundActions.ModifySoundscript:
                            break;
                        default:
                            break;
                    }
                }
                modifiedData.Add(parsedEntry.Key, modifiedEntry);
            }
            allSoundscriptEntries = null;
            //TODO: Is there any secondary approach instead of just converting it back?
            Dictionary<string,string> restoredData = new Dictionary<string,string>();
            foreach(var entry in modifiedData)
            {
                restoredData.Add(entry.Key, RestoreSoundscriptEntry(entry.Value));
            }
            return restoredData;
        }

        static void WriteFile(string inputFile, string outputFile)
        {
            //TODO: Had to make a lot of public stuff in WAVInteraction for this. This isn't a correct approach.
            WAVInteraction.SoundType inputType = WAVInteraction.GetSoundType(inputFile);
            switch (inputType)
            {
                case WAVInteraction.SoundType.Wave:
                    var reader = new WaveFileReader(inputFile);
                    if (reader.WaveFormat.SampleRate != 44100)
                    {
                        using (var waveReader = new WaveFileReader(inputFile))
                        {
                            var outFormat = new WaveFormat(44100, waveReader.WaveFormat.Channels);
                            using (var resampler = new MediaFoundationResampler(waveReader, outFormat))
                            {
                                WaveFileWriter.CreateWaveFile(outputFile, resampler);
                            }
                        }
                    }
                    else
                    {
                        using (var waveReader = new Mp3FileReader(inputFile))
                        {
                            WaveFileWriter.CreateWaveFile(outputFile, waveReader);
                        }
                    }
                    break;
                case WAVInteraction.SoundType.MP3:
                    var mp3Reader = new Mp3FileReader(inputFile);
                    if (mp3Reader.WaveFormat.SampleRate != 44100)
                    {
                        using (var mp3FileReader = new Mp3FileReader(inputFile))
                        {
                            var outFormat = new WaveFormat(44100, mp3FileReader.WaveFormat.Channels);
                            using (var resampler = new MediaFoundationResampler(mp3FileReader, outFormat))
                            {
                                MediaFoundationEncoder.EncodeToMp3(resampler, outputFile, mp3Reader.WaveFormat.BitsPerSample);
                            }
                        }
                    }
                    else
                    {
                        using (var mp3FileReader = new Mp3FileReader(inputFile))
                        {
                            MediaFoundationEncoder.EncodeToMp3(mp3FileReader, outputFile, mp3Reader.WaveFormat.BitsPerSample);
                        }
                    }
                    break;
                case WAVInteraction.SoundType.Unknown:
                    break;
                default:
                    break;
            }
        }

        static private void ExportAudioFilesToTemporaryStorage(MainWindow exportWindow, DirectoryInfo exportPath, SoundParameter[] soundParameters)
        {
            List<SoundFileEntry> exportedSounds = new List<SoundFileEntry>();
            foreach (SoundParameter param in soundParameters)
            {
                foreach (SoundFileEntry entry in param.Sounds)
                {
                    if(exportedSounds.Select(x => x.id == entry.id).Count() == 0)
                    {
                        string inputFileName = Path.GetFileName(entry.fileLocation);
                        DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(exportPath.FullName, "sound\\exported\\", inputFileName)));
                        di.Create();
                        exportedSounds.Add(entry);
                        try
                        {
                            WriteFile(entry.fileLocation, Path.Combine(exportPath.FullName, "sound\\exported\\", inputFileName));
                        }
                        catch (FileNotFoundException)
                        {
                            exportWindow.WriteMessage("The sound file " + inputFileName + " could not be written because the temporary directory is inaccessible.");
                        }
                        catch (IOException e)
                        {
                            exportWindow.WriteMessage("The sound file " + inputFileName + " could not be written:" + e.Message);
                        }
                    }
                }
            }
        }

        static private void BuildAndExportSoundscriptFiles(Dictionary<string, string> soundscriptData, MainWindow exportWindow, DirectoryInfo exportPath)
        {
            Dictionary<string, string> files = new Dictionary<string, string>();
            foreach (var entry in soundscriptData)
            {
                string relativeLocation = SeparateSoundscriptEntryKey(entry.Key).Key;
                if(files.ContainsKey(relativeLocation))
                {
                    files[relativeLocation] = string.Concat(files[relativeLocation], '\n', entry.Value);
                }
                else
                {
                    files[relativeLocation] = entry.Value;
                }
                
            }
            foreach (var file in files)
            {
                DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(exportPath.FullName, file.Key)));
                di.Create();
                try
                {
                    File.AppendAllText(Path.Combine(exportPath.FullName, file.Key), file.Value);
                }
                catch (FileNotFoundException)
                {
                    exportWindow.WriteMessage("The file " + file.Key + " could not be modified because the temporary directory is inaccessible.");
                }
            }
        }
        #endregion

        static private void ExportMaterialsToTemporaryStorage(Dictionary<string, string> materialVpkData, MainWindow exportWindow, DirectoryInfo exportPath)
        {
            foreach (var a in materialVpkData)
            {
                VdfSerializerSettings settings = new VdfSerializerSettings
                {
                    UsesEscapeSequences = false
                };
                DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(exportPath.FullName, a.Key)));
                di.Create();
                try
                {
                    File.AppendAllText(Path.Combine(exportPath.FullName, a.Key), a.Value);
                }
                catch (FileNotFoundException)
                {
                    exportWindow.WriteMessage("The file " + a.Key + " could not be modified because the temporary directory is inaccessible.");
                }
            }
        }
    }
}