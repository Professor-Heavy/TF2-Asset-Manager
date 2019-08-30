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
        public static BindingList<MaterialParameter> MaterialParametersArrayList = new BindingList<MaterialParameter>();

        /// <summary>
        /// Adds default parameters to the ArrayList of MaterialParameters.
        /// </summary>
        static async public Task InsertDefaultParameters()
        {
            MaterialParametersArrayList.Add(new MaterialParameter("Solid Color", "$color", MaterialParameterType.GetMaterialParameterType("vector3"), "255,255,255"));
            //MaterialParametersArrayList.Add(new MaterialParameter("Pulsing Rainbow", "Sine", MaterialParameterType.GetMaterialParameterType("proxy"), "add"));
            MaterialParametersArrayList.Add(new MaterialParameter("No Phong Shading", "$phong", MaterialParameterType.GetMaterialParameterType("boolean"), "0"));
            MaterialParametersArrayList.Add(new MaterialParameter("All Phong Shading", "$phong", MaterialParameterType.GetMaterialParameterType("boolean"), "1"));
            MaterialParametersArrayList.Add(new MaterialParameter("Extreme Phong Boost", "$phongboost", MaterialParameterType.GetMaterialParameterType("integer"), "500"));
            await WriteXmlParameters(MainWindow.completeUserDataPath);
        }
        /// <summary>
        /// Refreshes the list of parameters and reads the XML file, updating the parameter lists in memory.
        /// </summary>
        /// <param name="completeUserDataPath">The directory where parameterStorage.xml is stored.</param>
        static public void ReadXmlParameters(string completeUserDataPath)
        {
            MaterialParametersArrayList.Clear();
            XDocument xDoc;
            xDoc = XDocument.Load(completeUserDataPath + "\\parameterStorage.xml");
            MaterialParametersArrayList.Clear();
            IEnumerable<XElement> materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            foreach (XElement param in materialParamList) //We need to ignore proxies until they're ready too..
            {
                string parameterName = param.Element("paramName").Value;
                string parameter = param.Element("parameter").Value;
                MaterialParameterType parameterType = MaterialParameterType.GetMaterialParameterType(param.Element("paramType").Value);
                dynamic parameterValue;
                int parameterForce = ParseParameterType<int>(param.Element("paramForce").Value);
                int parameterRandomChance = ParseParameterType<int>(param.Element("randomChance").Value);
                float parameterRandomOffset = ParseParameterType<float>(param.Element("randomOffset").Value);

                if (parameterType.UsesArrays)
                {
                    if (parameterType.UsesAttributes)
                    {
                        parameterValue = ReadParameterValueChildren(param.Element("paramValue"), parameterType.ArrayElementKeys, parameterType.AttributeKeys);
                    }
                    else
                    {
                        parameterValue = ReadParameterValueChildren(param.Element("paramValue"), parameterType.ArrayElementKeys);
                    }
                }
                else
                {
                    parameterValue = param.Element("paramValue").Value;
                }

                List<string> parameterShaderFilters = ReadParameterValueChildren(param.Element("shaderArray"), "filter");

                int parameterShaderFilterMode = ParseParameterType<int>(param.Element("shaderArray").Attribute("shaderFilterMode").Value);
                MaterialParametersArrayList.Add(new MaterialParameter(parameterName,
                                                                      parameter,
                                                                      parameterType,
                                                                      parameterValue,
                                                                      parameterForce,
                                                                      parameterRandomChance,
                                                                      parameterRandomOffset,
                                                                      parameterShaderFilters,
                                                                      parameterShaderFilterMode));
            }
        }
        static public async Task WriteXmlParameters(string completeUserDataPath)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Async = true
            };
            XmlWriter textWriter = XmlWriter.Create(completeUserDataPath + "\\parameterStorage.xml", settings);
            using (textWriter)
            {
                await textWriter.WriteStartDocumentAsync();
                await textWriter.WriteStartElementAsync(null, "parameterSettings", null);
                await textWriter.WriteStartElementAsync(null, "materialParameterList", null);
                foreach (MaterialParameter param in MaterialParametersArrayList)
                {
                    await textWriter.WriteStartElementAsync(null, "materialParameter", null);
                    await textWriter.WriteElementStringAsync(null, "paramName", null, param.ParamName);
                    await textWriter.WriteElementStringAsync(null, "parameter", null, param.Parameter);
                    await textWriter.WriteElementStringAsync(null, "paramType", null, param.ParamType.ToString());
                    if(param.ParamType.UsesArrays)
                    {
                        await textWriter.WriteStartElementAsync(null, "paramValue", null);
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
                        await textWriter.WriteEndElementAsync();
                    }
                    else
                    {
                        await textWriter.WriteElementStringAsync(null, "paramValue", null, param.ParamValue);
                    }
                    await textWriter.WriteElementStringAsync(null, "paramForce", null, param.ParamForce.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomChance", null, param.RandomizerChance.ToString());
                    await textWriter.WriteElementStringAsync(null, "randomOffset", null, param.RandomizerOffset.ToString());
                    await textWriter.WriteStartElementAsync(null, "shaderArray", null);
                    await textWriter.WriteAttributeStringAsync(null, "shaderFilterMode", null, param.ShaderFilterMode.ToString());
                    foreach (string shaderFilter in param.ShaderFilterArray)
                    {
                        await textWriter.WriteElementStringAsync(null, "filter", null, shaderFilter);
                    }
                    await textWriter.WriteEndElementAsync();
                    await textWriter.WriteEndElementAsync();
                }
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteStartElementAsync(null, "soundParameters", null);
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteEndElementAsync();
                await textWriter.WriteEndDocumentAsync();
                return;
            }
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
        public async static Task<List<string>> VerifyXMLIntegrity(string completeUserDataPath)
        {
            List<string> errorList = new List<string>();
            string fullFilePath = completeUserDataPath + "\\parameterStorage.xml";
            XDocument xDoc;
            
            //File Exist Check
            if (!File.Exists(fullFilePath))
            {
                MessageBox.Show("The configuration file is missing.\nA new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await InsertDefaultParameters();
            }

            //Structure Check
            try
            {
                xDoc = XDocument.Load(fullFilePath);
            }
            catch(XmlException)
            {
                MessageBox.Show("The configuration file is corrupt, or uses a different version. A new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await InsertDefaultParameters();
                xDoc = XDocument.Load(fullFilePath);
            }
            //IEnumerable<XElement> materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            //foreach (XElement param in materialParamList)
            //{
            //    string parameterName = param.Element("paramName").Value;
            //    string parameter = param.Element("parameter").Value;
            //    string parameterType = param.Element("paramType").Value;
            //    string parameterValue = param.Element("paramValue").Value;
            //    int parameterForce = ParseParameterType<int>(param.Element("paramForce").Value);
            //    int parameterRandomChance = ParseParameterType<int>(param.Element("randomChance").Value);
            //    float parameterRandomOffset = ParseParameterType<float>(param.Element("randomOffset").Value);
            //
            //    string vectorIntegrityResult;
            //    switch (parameterType)
            //    {
            //        case "vector3-float":
            //            vectorIntegrityResult = VerifyVector3Integrity<float>(parameterValue);
            //            if (vectorIntegrityResult != null)
            //            {
            //                errorList.Add(string.Format("Parameter Error: Parameter {0}: {1}", parameterName, vectorIntegrityResult));
            //            }
            //            break;
            //        case "vector3-integer":
            //        case "vector3-color":
            //            vectorIntegrityResult = VerifyVector3Integrity<int>(parameterValue);
            //            if (vectorIntegrityResult != null)
            //            {
            //                errorList.Add(string.Format("Parameter Error: Parameter {0}: {1}", parameterName, vectorIntegrityResult));
            //            }
            //            break;
            //        case "proxy":
            //            if (param.Element("proxyParameters").Elements("proxyParameter").Count() > 6)
            //            {
            //                errorList.Add(string.Format("Internal Error: Parameter {0}: Proxy contains more than the maximum parameters.", parameterName)); //I didn't though.
            //            }
            //            if (param.Element("proxyParameters") == null)
            //            {
            //                errorList.Add(string.Format("Internal Info: Parameter {0}: Proxy parameter list missing. Created a new list.", parameterName)); //I didn't though.
            //            }
            //            foreach (XAttribute proxyAttribute in param.Element("proxyParameters").Elements("proxyParameter").Attributes())
            //            {
            //                if (string.IsNullOrEmpty(proxyAttribute.Value))
            //                {
            //                    errorList.Add(string.Format("Warning: Parameter {0}: {1} is empty", parameterName, proxyAttribute.Name));
            //                }
            //            }
            //            break;
            //        case "bool":
            //            if (ParseParameterType<int>(parameterValue) > 1 || ParseParameterType<int>(parameterValue) < 0)
            //            {
            //                errorList.Add(string.Format("Parameter Error: Parameter {0}: Value must be 0 or 1.", parameterName));
            //            }
            //            break;
            //        case "Random Choice Array":
            //            break;
            //    }
            //
            //    List<string> parameterShaderFilters = new List<string>();
            //    foreach (XElement shader in param.Element("shaderArray").Elements("filter"))
            //    {
            //        parameterShaderFilters.Add(shader.Value);
            //    }
            //
            //    int parameterShaderFilterMode = ParseParameterType<int>(param.Element("shaderArray").Attribute("shaderFilterMode").Value);
            //}
            return errorList;
        }
        private static string VerifyVector3Integrity<T>(string vector3Input)
        {
            if (vector3Input.Split(',').Length != 3) //Check that it contains 3 values only.
            {
                return "Length of value is not 3.";
            }
            string[] splitStringTest = vector3Input.Split(',');
            if (TypeDescriptor.GetConverter(typeof(T)).CanConvertFrom(splitStringTest.GetType()))
            {
                return "One or more of the values do not match with their types.";
            }
            return null;
        }

        /// <summary>
        /// Reads the cihld nodes of a parameter, and returns a string list of the element values.
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
    }
}
