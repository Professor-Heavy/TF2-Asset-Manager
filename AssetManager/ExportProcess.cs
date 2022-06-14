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
                Dictionary<string, string> localisationData = await Task.Run(() => ReadLocalisationFiles(executableDirectory, exportWindow));
                Dictionary<string, string> modifiedLocalisationData = null;
                if (exportSettings.LocalisationParameters.Length != 0)
                {
                   modifiedLocalisationData = LocalisationModify(localisationData, exportSettings.LocalisationParameters, exportWindow);
                }
                if(exportSettings.LocalisationCorruptionSettings != null)
                {
                    modifiedLocalisationData = LocalisationCorrupt(localisationData, exportSettings.LocalisationCorruptionSettings, exportWindow);
                }
                actionsPerformed = true;
                string assembledLocalisationData = BuildLocalisationFile(modifiedLocalisationData);
                ExportLocalisationFile(assembledLocalisationData, exportWindow, exportPath);
            }
            if(actionsPerformed == false)
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

        static private Dictionary<string, string> MaterialModify(Dictionary<string, string> materialVpkData, MainWindow exportWindow, MaterialParameter[] materialParameters)
        {
            Dictionary<string, string> modifiedData = new Dictionary<string, string>();
            Random randomNumGenerator = new Random();
            foreach (var a in materialVpkData)
            {
                try
                {
                    VdfSerializerSettings settings = new VdfSerializerSettings
                    {
                        UsesEscapeSequences = false
                    };
                    dynamic conversion = VdfConvert.Deserialize(materialVpkData[a.Key], settings);
                    foreach (MaterialParameter enabledParameter in materialParameters)
                    {
                        if (!TestForFilteredShaders(enabledParameter.ShaderFilterMode, conversion, enabledParameter.ShaderFilterArray))
                        {
                            continue;
                        }
                        if (!TestForFilteredProxies(enabledParameter.ProxyFilterMode, conversion, enabledParameter.ProxyFilterArray))
                        {
                            continue;
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
                    }
                    modifiedData.Add(a.Key, VdfConvert.Serialize(conversion, settings));
                }
                catch (VdfException)
                {
                    exportWindow.WriteMessage("The file " + a.Key + " could not be modified due to an faulty data structure.");
                }
            }
            return modifiedData;
        }

        static private Dictionary<string, string> MaterialCorrupt(Dictionary<string, string> materialVpkData, MainWindow exportWindow, MaterialCorruptionSettings[] settings)
        {
            Dictionary<string, string> modifiedData = new Dictionary<string, string>();
            Random rng = new Random();
            foreach (var a in materialVpkData.ToList())
            {
                if (modifiedData.ContainsKey(a.Key))
                {
                    materialVpkData[a.Key] = modifiedData[a.Key];
                    modifiedData.Remove(a.Key);
                }
                VdfSerializerSettings vdfSettings = new VdfSerializerSettings
                {
                    UsesEscapeSequences = false
                };
                dynamic conversion = null;
                try
                {
                    conversion = VdfConvert.Deserialize(materialVpkData[a.Key], vdfSettings);
                }
                catch (VdfException e)
                {
                    exportWindow.WriteMessage("The file " + a.Key + " could not be corrupted due to an faulty data structure.");
                    continue;
                }
                for (int i = 0; i < settings.Length; i++)
                {
                    if (settings[i].Enabled == false)
                    {
                        continue;
                    }
                    switch (settings[i].CorruptionType)
                    {
                        case (int)MaterialCorruptionSettings.CorruptionTypes.SwapParameters:
                            if (TestForFilteredShaders(settings[i].ShaderFilterMode, conversion, settings[i].ShaderFilterArray))
                            {
                                if (settings[i].Probability != 100
                                && rng.Next(1, 101) >= settings[i].Probability + 1) //TODO: Confirm this is accurate too..?
                                {
                                    continue;
                                }
                                if (settings[i].ParameterFilterMode == 1)
                                {
                                    foreach (string parameter in settings[i].ParameterFilterArray)
                                    {
                                        if (VMTInteraction.CaseInsensitiveParameterCheck(conversion.Value, parameter).Value != null)
                                        {
                                            KeyValuePair<string, string> value = new KeyValuePair<string, string>();
                                            dynamic deserializedValue = null;
                                            bool validFile = false;
                                            do
                                            {
                                                try
                                                {
                                                    value = materialVpkData.ElementAt(rng.Next(0, materialVpkData.Count));
                                                    deserializedValue = VdfConvert.Deserialize(value.Value, vdfSettings);
                                                    validFile = true;
                                                }
                                                catch (VdfException)
                                                {

                                                }
                                            }
                                            while (!validFile);
                                            while (VMTInteraction.CaseInsensitiveParameterCheck(deserializedValue.Value, parameter).Value == null
                                                || (!deserializedValue.Key.Equals(conversion.Key, StringComparison.OrdinalIgnoreCase) && settings[i].Arguments["AffectSimilarShaders"] == "True"))
                                            {
                                                value = materialVpkData.ElementAt(rng.Next(0, materialVpkData.Count));
                                                deserializedValue = VdfConvert.Deserialize(value.Value, vdfSettings);
                                            }
                                            if (modifiedData.ContainsKey(value.Key))
                                            {
                                                deserializedValue = VdfConvert.Deserialize(modifiedData[value.Key], vdfSettings);
                                                modifiedData.Remove(value.Key);
                                            }
                                            if (modifiedData.ContainsKey(a.Key))
                                            {
                                                conversion = VdfConvert.Deserialize(modifiedData[a.Key], vdfSettings);
                                                modifiedData.Remove(a.Key);
                                            }
                                            dynamic[] swappedParams = SwapMaterialParameters(conversion, deserializedValue, parameter);
                                            try
                                            {
                                                modifiedData.Add(a.Key, VdfConvert.Serialize(swappedParams[0], vdfSettings));
                                                modifiedData.Add(value.Key, VdfConvert.Serialize(swappedParams[1], vdfSettings));
                                            }
                                            catch (ArgumentException e)
                                            {
                                                Console.WriteLine(e);
                                            }
                                        };
                                    }
                                }
                                else
                                {
                                    if (modifiedData.ContainsKey(a.Key))
                                    {
                                        conversion = VdfConvert.Deserialize(modifiedData[a.Key], vdfSettings);
                                        modifiedData.Remove(a.Key);
                                    }

                                    dynamic[] swappedParams = null;
                                    foreach (VProperty vValue in conversion.Value)
                                    {
                                        bool continueFlag = false;
                                        foreach (string parameter in settings[i].ParameterFilterArray)
                                        {
                                            if (string.Equals(vValue.Key, parameter, StringComparison.OrdinalIgnoreCase))
                                            {
                                                continueFlag = true;
                                                break;
                                            }
                                        }
                                        if (continueFlag == true)
                                        {
                                            continue;
                                        }
                                        KeyValuePair<string, string> value = new KeyValuePair<string, string>();
                                        dynamic deserializedValue = null;
                                        bool validFile = false;
                                        do
                                        {
                                            try
                                            {
                                                value = materialVpkData.ElementAt(rng.Next(0, materialVpkData.Count));
                                                deserializedValue = VdfConvert.Deserialize(value.Value, vdfSettings);
                                                validFile = true;
                                            }
                                            catch (VdfException)
                                            {
                                                
                                            }
                                        } 
                                        while (!validFile);
                                        while (VMTInteraction.CaseInsensitiveParameterCheck(deserializedValue.Value, vValue.Key).Value == null
                                            || (!deserializedValue.Key.Equals(conversion.Key, StringComparison.OrdinalIgnoreCase) && settings[i].Arguments["AffectSimilarShaders"] == "True"))
                                        {
                                            try
                                            {
                                                value = materialVpkData.ElementAt(rng.Next(materialVpkData.Count - 1));
                                                deserializedValue = VdfConvert.Deserialize(value.Value, vdfSettings);
                                            }
                                            catch (VdfException)
                                            {

                                            }
                                        }
                                        if (modifiedData.ContainsKey(value.Key))
                                        {
                                            deserializedValue = VdfConvert.Deserialize(modifiedData[value.Key], vdfSettings);
                                            modifiedData.Remove(value.Key);
                                        }
                                        swappedParams = SwapMaterialParameters(conversion, deserializedValue, vValue.Key);

                                        modifiedData.Add(value.Key, VdfConvert.Serialize(swappedParams[1], vdfSettings));
                                    }

                                    try
                                    {
                                        modifiedData.Add(a.Key, VdfConvert.Serialize(swappedParams[0], vdfSettings));
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e);
                                    }
                                }
                            }
                            break;
                        case MaterialCorruptionSettings.CorruptionTypes.OffsetValues:
                            if (TestForFilteredShaders(settings[i].ShaderFilterMode, conversion, settings[i].ShaderFilterArray))
                            {
                                if (settings[i].Probability != 100
                                && rng.Next(1, 101) >= settings[i].Probability + 1) //TODO: Confirm this is accurate too..?
                                {
                                    continue;
                                }
                                if (settings[i].ParameterFilterMode == 1)
                                {
                                    foreach (string parameter in settings[i].ParameterFilterArray)
                                    {
                                        VProperty caseMatchedParameter = VMTInteraction.CaseInsensitiveParameterCheck(conversion.Value, parameter);
                                        if (caseMatchedParameter.Value != null)
                                        {
                                            if (int.TryParse(conversion.Value[caseMatchedParameter.Key].Value, out int value))
                                            {
                                                conversion.Value[caseMatchedParameter.Key].Value = value + rng.Next(int.Parse(settings[i].Arguments["OffsetLow"]), int.Parse(settings[i].Arguments["OffsetHigh"]));
                                            }
                                        };
                                    }
                                }
                                else
                                {
                                    if (modifiedData.ContainsKey(a.Key))
                                    {
                                        conversion = VdfConvert.Deserialize(modifiedData[a.Key], vdfSettings);
                                        modifiedData.Remove(a.Key);
                                    }

                                    foreach (VProperty vValue in conversion.Value)
                                    {
                                        bool continueFlag = false;
                                        foreach (string parameter in settings[i].ParameterFilterArray)
                                        {
                                            if (string.Equals(vValue.Key, parameter, StringComparison.OrdinalIgnoreCase))
                                            {
                                                continueFlag = true;
                                                break;
                                            }
                                        }
                                        if (continueFlag == true)
                                        {
                                            continue;
                                        }

                                        VProperty caseMatchedParameter = VMTInteraction.CaseInsensitiveParameterCheck(conversion.Value, vValue.Key);
                                        if (caseMatchedParameter.Value != null)
                                        {
                                            //if(caseMatchedParameter.)
                                            //{
                                                if (int.TryParse(conversion.Value[caseMatchedParameter.Key].Value, out int value))
                                                {
                                                    conversion.Value[caseMatchedParameter.Key].Value = value + rng.Next(int.Parse(settings[i].Arguments["OffsetLow"]), int.Parse(settings[i].Arguments["OffsetHigh"]));
                                                }
                                            //}
                                        };
                                    }
                                }
                                try
                                {
                                    modifiedData.Add(a.Key, VdfConvert.Serialize(conversion, vdfSettings));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                            break;
                    }
                }
            }
            exportWindow.WriteMessage("Out of " + materialVpkData.Count + " assets, " + modifiedData.Count + " were corrupted.");
            return modifiedData;
        }

        static private dynamic[] SwapMaterialParameters(dynamic materialFile, dynamic secondaryMaterialFile, string parameter)
        {
            string primaryParameter = VMTInteraction.CaseInsensitiveParameterCheck(materialFile.Value, parameter).Key;
            string secondaryParameter = VMTInteraction.CaseInsensitiveParameterCheck(secondaryMaterialFile.Value, parameter).Key;
            dynamic temporaryValue = materialFile.Value[primaryParameter];
            materialFile.Value[primaryParameter] = secondaryMaterialFile.Value[secondaryParameter];
            secondaryMaterialFile.Value[secondaryParameter] = temporaryValue;
            return new dynamic[] { materialFile, secondaryMaterialFile };
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
                //HACK: FilterMode == 0 returns false
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

        static private Dictionary<string, string> ReadLocalisationFiles(string executableDirectory, MainWindow exportWindow)
        {
            exportWindow.WriteMessage("Searching for localisation entries...");
            Dictionary<string, string> returnedData;
            string rawString;
            try
            {
                rawString = File.ReadAllText(Path.Combine(executableDirectory, "tf\\resource\\tf_english.txt"));
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

        static private Dictionary<string, string> LocalisationModify(Dictionary<string,string> tokens, LocalisationParameter[] localisationParameters, MainWindow exportWindow)
        {
            Dictionary<string, string> modifiedData = new Dictionary<string, string>();
            Random randomNumGenerator = new Random();
            foreach (var token in tokens)
            {
                string modifiedString = token.Value;
                foreach (LocalisationParameter enabledParameter in localisationParameters)
                {
                    if (enabledParameter.RandomizerChance != 100
                            && randomNumGenerator.Next(1, 101) >= enabledParameter.RandomizerChance + 1) //TODO: Seriously, do some small tests.
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
            Dictionary<string, string> modifiedData = new Dictionary<string, string>();
            Random randomNumGenerator = new Random();
            foreach (var token in tokens)
            {
                string modifiedString = token.Value;
                foreach (LocalisationCorruptionSettings enabledParameter in settings)
                {
                    for (int i = 0; i < settings.Length; i++)
                    {
                        if (settings[i].Enabled == false)
                        {
                            continue;
                        }
                        if (enabledParameter.Probability != 100
                                && randomNumGenerator.Next(1, 101) >= enabledParameter.Probability + 1) //TODO: Come on... Confirm it already.
                        {
                            continue;
                        }
                        switch (settings[i].CorruptionType)
                        {
                            case LocalisationCorruptionSettings.CorruptionTypes.SwapEntries:
                                //Choosing to ignore newline in this check because it won't be that catastrophic if they're allowed.
                                //The only reason why Safe Mode ignores these things entirely is because there are cases in where important
                                //localisation tokens for "formats" are overwritten entirely and I can't prevent that.

                                //TODO: Maybe there is some kind of way to blacklist template and format tokens by default, as mentioned above.
                                if (settings[i].SafeMode && TXTInteraction.SpecialCharacterCheck(token.Value, true))
                                {
                                    //This is typically the part where we'd try to work around the regex, but that is not possible for this particular corruption type.
                                    modifiedData.Add(token.Key, modifiedString); //Just write it into the modified data, and onto the next one.
                                    continue;
                                }
                                if (settings[i].RegularExpressionEnabled)
                                {
                                    //TODO: By all accounts this should work...
                                    //If Regex matches and Exclude Mode is on, skip.
                                    //If regex doesn't match and exclude mode is on, continue.
                                    //If regex matches and Inclusion Mode is on, continue.
                                    //If regex doesn't match and Inclusion Mode is on, skip.
                                    if(TXTInteraction.RegexSearch(modifiedString, settings[i].RegularExpressionPattern).Count > 0 == (settings[i].RegularExpressionMode == 0))
                                    {
                                        modifiedData.Add(token.Key, modifiedString);
                                        continue;
                                    }
                                }
                                bool regexAffectSwaps = settings[i].Arguments["RegexForMatchesAndSwaps"] == "true";
                                KeyValuePair<string, string> value = tokens.ElementAt(randomNumGenerator.Next(0, tokens.Count));
                                if(settings[i].SafeMode)
                                {
                                    while (TXTInteraction.SpecialCharacterCheck(value.Value, settings[i].IgnoreNewlines) )
                                    {
                                        if (regexAffectSwaps && settings[i].RegularExpressionEnabled) 
                                        {
                                            //TODO: Top priority. Two while loops inside each other like this is extremely inefficient.
                                            while(TXTInteraction.RegexSearch(modifiedString, settings[i].RegularExpressionPattern).Count == 0 == (settings[i].RegularExpressionMode == 1))
                                            {
                                                value = tokens.ElementAt(randomNumGenerator.Next(0, tokens.Count));
                                            }
                                        }
                                        else
                                        {
                                            value = tokens.ElementAt(randomNumGenerator.Next(0, tokens.Count));
                                        }
                                    }
                                }
                                try
                                {
                                    modifiedString = value.Value;
                                    modifiedData[token.Key] = modifiedString;
                                    modifiedData[value.Key] = token.Value;
                                }
                                catch
                                {
                                    System.Diagnostics.Debugger.Break();
                                }
                                break;
                            case LocalisationCorruptionSettings.CorruptionTypes.SwapLanguage:
                                //So this is where it starts getting crazy. I suppose I should have expected this.
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return modifiedData;
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
