using Gameloop.Vdf;
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
        static public void Export(string executableDirectory, bool useCustomFiles, List<string> customFiles, MainWindow exportWindow)
        {
            DirectoryInfo exportPath = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileNameWithoutExtension(Properties.Settings.Default.VpkLocation)));
            Dictionary<string,string> materialVpkData = ReadMaterialFiles(executableDirectory, useCustomFiles, customFiles, exportWindow);
            MaterialModifyAndExport(materialVpkData, exportWindow, exportPath);
            exportWindow.WriteMessage("Packaging file to VPK.");
            VPKInteraction.PackageToVpk(executableDirectory, exportPath);
        }

        static private Dictionary<string,string> ReadMaterialFiles(string executableDirectory, bool useCustomFiles, List<string> customFiles, MainWindow exportWindow)
        {
            Dictionary<string, string> returnedData;
            returnedData = VPKInteraction.ExtractSpecificFileTypeFromVPK(Path.Combine(executableDirectory, "tf\\tf2_misc_dir.vpk"), "vmt");
            exportWindow.WriteMessage("Found " + returnedData.Count + " assets to edit.");
            if (useCustomFiles)
            {
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
                        returnedData.Add(customFile.Key, customFile.Value); //TODO: Maybe use enumerables...
                    }
                }
                Dictionary<string, string> customReturnedDataFromVpk = new Dictionary<string, string>();
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
                                returnedData.Add(customFile.Key, customFile.Value); //TODO: Maybe use enumerables...
                            }
                        }
                    }
                }
                exportWindow.WriteMessage("Found " + customReturnedData.Count + " custom assets (Excluding VPKs).");
                //TODO: Maybe instead of creating two different functions for VPKs and folders... Merge them?
            }
            return returnedData;
        }

        static private void MaterialModifyAndExport(Dictionary<string,string> materialVpkData, MainWindow exportWindow, DirectoryInfo exportPath)
        {
            List<MaterialParameter> EnabledParameters = exportWindow.GetEnabledMaterialParameters();
            foreach (var a in materialVpkData)
            {
                try
                {
                    VdfSerializerSettings settings = new VdfSerializerSettings
                    {
                        UsesEscapeSequences = false
                    };
                    dynamic conversion = VdfConvert.Deserialize(materialVpkData[a.Key], settings);
                    Random randomNumGenerator = new Random();
                    foreach(MaterialParameter enabledParameter in EnabledParameters)
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
                            && randomNumGenerator.Next(1, 101) >= enabledParameter.RandomizerChance + 1) //Confirm this is accurate..?
                        {
                            continue;
                        }

                        float valueOffset = enabledParameter.RandomizerOffset;
                        if (enabledParameter.RandomizerOffset != 0.0f)
                        {
                            valueOffset *= (float)(randomNumGenerator.NextDouble() * 2.0 - 1.0);
                        }
                        switch (enabledParameter.ParamType.ToString())
                        {
                            //TODO: Interpret float values
                            //case "vector3-float":
                            //    VMTInteraction.InsertVector3IntoMaterial(conversion,
                            //                                             enabledParameter.Parameter,
                            //                                             VMTInteraction.ConvertStringToVector3Float(enabledParameter.ParamValue));
                            //    break;
                            case "vector3":
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
                                conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, Int32.Parse(enabledParameter.ParamValue));
                                break;
                            case "integer":
                                conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, Int32.Parse(enabledParameter.ParamValue) + (int)Math.Ceiling(valueOffset));
                                break;
                            case "string":
                                conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue);
                                break;
                            case "float":
                                conversion = VMTInteraction.InsertValueIntoMaterial(conversion, enabledParameter.Parameter, float.Parse(enabledParameter.ParamValue + valueOffset));
                                break;
                            case "proxy":
                                conversion = VMTInteraction.InsertProxyIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue);
                                break;
                            case "choices":
                                conversion = VMTInteraction.InsertRandomChoiceIntoMaterial(conversion, enabledParameter.Parameter, enabledParameter.ParamValue);
                                break;
                            default:
                                break; //Unimplemented type.
                        } 
                    }
                    DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(exportPath.FullName, a.Key)));
                    di.Create();
                    try
                    {
                        File.AppendAllText(Path.Combine(exportPath.FullName, a.Key), VdfConvert.Serialize(conversion, settings));
                    }
                    catch (FileNotFoundException)
                    {
                        exportWindow.WriteMessage("The file " + a.Key + " could not be modified since the file path is too long.");
                    }
                }
                catch (VdfException)
                {
                    exportWindow.WriteMessage("The file " + a.Key + " could not be modified due to an faulty data structure.");
                }
            }
        }
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
        /// Performs a test on a materialFile to see if a proxy exists, and returns the result of the filter. TODO: Simplify.
        /// </summary>
        /// <param name="filterMode">Set to 0 if it should NOT be used, set to 1 if it SHOULD ONLY be used.</param>
        /// <param name="materialFile"></param>
        /// <param name="proxyFilterArray"></param>
        /// <returns>True if the parameter be included, false if not.</returns>
        static private bool TestForFilteredProxies(int filterMode, dynamic materialFile, List<string> proxyFilterArray) //Any possible simplifications?
        {
            if (filterMode == 0)
            {
                foreach (string proxyFilter in proxyFilterArray)
                {
                    if (VMTInteraction.ContainsProxy(materialFile, proxyFilter))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (string proxyFilter in proxyFilterArray)
                {
                    if (VMTInteraction.ContainsProxy(materialFile, proxyFilter))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
