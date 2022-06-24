using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            Random randomNumGenerator = new Random();
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
                        && randomNumGenerator.Next(1, 101) >= enabledParameter.RandomizerChance + 1) //TODO: Confirm this is accurate..?
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
                                    valueOffset[i] *= (float)(randomNumGenerator.NextDouble() * 2.0 - 1.0);
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
                            conversion = VMTInteraction.InsertRandomChoiceIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue);
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

            Random randomNumGenerator = new Random();
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
                            && randomNumGenerator.Next(1, 101) >= currentSetting.Probability + 1) //TODO: Confirm this is accurate too..?
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
                                        string swapTargetName = parameterOccurrences[randomNumGenerator.Next(0, parameterOccurrences.Count)];
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
                                    string swapTargetName = parameterOccurrences[randomNumGenerator.Next(0, parameterOccurrences.Count)];
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
                            && randomNumGenerator.Next(1, 101) >= currentSetting.Probability + 1) //TODO: Confirm this is accurate too..?
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
                                            VValue vvalue = new VValue(value + randomNumGenerator.Next(int.Parse(currentSetting.Arguments["OffsetLow"]), int.Parse(currentSetting.Arguments["OffsetHigh"])));
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
                                            VValue vvalue = new VValue(value + randomNumGenerator.Next(int.Parse(currentSetting.Arguments["OffsetLow"]), int.Parse(currentSetting.Arguments["OffsetHigh"])));
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
            Random randomNumGenerator = new Random();
            foreach (var token in tokens)
            {
                string modifiedString = token.Value;
                foreach (LocalisationParameter enabledParameter in localisationParameters)
                {
                    if (enabledParameter.RandomizerChance != 100
                            && randomNumGenerator.Next(1, 101) >= enabledParameter.RandomizerChance + 1
                            && (modifiedString.Length > enabledParameter.LetterCountFilterMax || modifiedString.Length < enabledParameter.LetterCountFilterMin)) //TODO: Seriously, do some small tests.
                    {
                        continue;
                    }
                    modifiedString = TXTInteraction.ModifyWithRegex(modifiedString, enabledParameter);
                }
                modifiedData.Add(token.Key, modifiedString);
            }
            return modifiedData;
        }

        static private Dictionary<string, string> LocalisationCorrupt(Dictionary<string, string> tokens, LocalisationCorruptionSettings[] settings, MainWindow exportWindow)
        {
            Dictionary<string, string> modifiedData = tokens;
            Random randomNumGenerator = new Random();
            Dictionary<string, string> leftoverData = tokens;
            foreach (LocalisationCorruptionSettings enabledParameter in settings)
            {
                Dictionary<string, string> filteredData = new Dictionary<string, string>();

                Dictionary<LanguageSettings, Dictionary<string, string>> secondaryLanguage = null;
                float languageMaxWeight = 0.0f;
                if (enabledParameter.RegularExpressionEnabled)
                {
                    filteredData = LocalisationRunRegexFilter(tokens, enabledParameter.RegularExpressionMode, enabledParameter.RegularExpressionPattern, enabledParameter.SafeMode, enabledParameter.IgnoreNewlines);
                }
                else
                {
                    filteredData = LocalisationRunRegexFilter(tokens, enabledParameter.RegularExpressionMode, string.Empty, enabledParameter.SafeMode, enabledParameter.IgnoreNewlines);
                }
                if (enabledParameter.Enabled == false)
                {
                    continue;
                }
                if (enabledParameter.Probability != 100
                        && randomNumGenerator.Next(1, 101) >= enabledParameter.Probability + 1) //TODO: Come on... Confirm it already.
                {
                    continue;
                }
                switch (enabledParameter.CorruptionType)
                {
                    case LocalisationCorruptionSettings.CorruptionTypes.SwapEntries:
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
                                value = filteredData.ElementAt(randomNumGenerator.Next(0, filteredData.Count));
                                modifiedString = value.Value;
                                modifiedData[token.Key] = modifiedString;
                                modifiedData[value.Key] = token.Value;
                            }
                            else
                            {
                                //TODO: This is acceptable for now.
                                do
                                {
                                    value = modifiedData.ElementAt(randomNumGenerator.Next(0, modifiedData.Count));
                                } while (enabledParameter.SafeMode && TXTInteraction.SpecialCharacterCheck(value.Value, true, enabledParameter.IgnoreNewlines));
                                modifiedString = value.Value;
                                modifiedData[token.Key] = modifiedString;
                                modifiedData[value.Key] = token.Value;
                            }
                        }
                    break;
                    case LocalisationCorruptionSettings.CorruptionTypes.SwapLanguage:
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
                                };                                    secondaryLanguage.Add(languageSetting, ReadLocalisationFiles(Properties.Settings.Default.GameLocation, languageSetting.Language, exportWindow));
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
                            float currentWeight = (float)randomNumGenerator.NextDouble() * languageMaxWeight;
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
                    default:
                        break;
                }
            }
            return modifiedData;
        }
        static private Dictionary<string,string> LocalisationRunRegexFilter(Dictionary<string, string> inputData, int filterMode, string regex, bool safeMode, bool ignoreNewLines)
        {
            Dictionary<string, string> outputData = new Dictionary<string, string>();

            foreach (var token in inputData)
            {
                if (safeMode && TXTInteraction.SpecialCharacterCheck(token.Value, true, ignoreNewLines))
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