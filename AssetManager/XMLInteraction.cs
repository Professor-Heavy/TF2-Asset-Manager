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
        static public void ImplementDefaultParameters()
        {
            MaterialParametersArrayList.Add(new MaterialParameter("Solid Color", "$color", "vector3", "255,255,255"));
            MaterialParametersArrayList.Add(new MaterialParameter("Pulsing Rainbow", "proxy", "proxy", ""));
            MaterialParametersArrayList.Add(new MaterialParameter("No Phong Shading", "$phong", "bool", "0"));
            MaterialParametersArrayList.Add(new MaterialParameter("All Phong Shading", "$phong", "bool", "1"));
            MaterialParametersArrayList.Add(new MaterialParameter("Extreme Phong Boost", "$phongboost", "integer", "500"));
        }
        /// <summary>
        /// Refreshes the list of parameters and reads the XML file, updating the parameter lists in memory.
        /// </summary>
        /// <param name="completeUserDataPath">The directory where parameterStorage.xml is stored.</param>
        static async public void ReadXmlParameters(string completeUserDataPath)
        {
            MaterialParametersArrayList.Clear();
            if(!File.Exists(completeUserDataPath + "\\parameterStorage.xml"))
            {
                MessageBox.Show("The parameter configuration file is missing.\nA new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ImplementDefaultParameters();
                await WriteXmlParameters(completeUserDataPath);
            }
            XDocument xDoc;
            try
            {
                 xDoc = XDocument.Load(completeUserDataPath + "\\parameterStorage.xml");
            }
            catch
            {
                MessageBox.Show("The parameter configuration file is corrupt. A new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ImplementDefaultParameters();
                await WriteXmlParameters(completeUserDataPath);
                xDoc = XDocument.Load(completeUserDataPath + "\\parameterStorage.xml");
            }
            MaterialParametersArrayList.Clear();
            var materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            foreach (XElement param in materialParamList) //We need to ignore proxies until they're ready too..
            {
                string parameterType = param.Attribute("paramType").Value;
                List<string[]> proxyParameters;
                if(parameterType == "proxy")
                {
                    proxyParameters = convertStringToProxyArray(param.Attribute("proxyParameters").Value);
                }
                else
                {
                    proxyParameters = null;
                }
                MaterialParametersArrayList.Add(new MaterialParameter(param.Attribute("paramName").Value,
                                                                      param.Attribute("parameter").Value,
                                                                      parameterType,
                                                                      param.Attribute("paramValue").Value,
                                                                      Convert.ToInt32(param.Attribute("paramForce").Value),
                                                                      Convert.ToInt32(param.Attribute("randomChance").Value),
                                                                      float.Parse(param.Attribute("randomOffset").Value),
                                                                      proxyParameters));
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
            await textWriter.WriteStartDocumentAsync();
            await textWriter.WriteStartElementAsync(null, "parameterSettings", null);
            await textWriter.WriteStartElementAsync(null, "materialParameterList", null);
            foreach (MaterialParameter param in MaterialParametersArrayList)
            {
                await textWriter.WriteStartElementAsync(null, "materialParameter", null);
                await textWriter.WriteAttributeStringAsync(null, "paramName", null, param.ParamName);
                await textWriter.WriteAttributeStringAsync(null, "parameter", null, param.Parameter); 
                await textWriter.WriteAttributeStringAsync(null, "paramType", null, param.ParamType);
                await textWriter.WriteAttributeStringAsync(null, "paramValue", null, param.ParamValue);
                await textWriter.WriteAttributeStringAsync(null, "paramForce", null, param.ParamForce.ToString());
                //TODO: Code in a case/switch that writes other formats depending on the ParamType.
                await textWriter.WriteAttributeStringAsync(null, "randomChance", null, param.RandomizerChance.ToString());
                await textWriter.WriteAttributeStringAsync(null, "randomOffset", null, param.RandomizerOffset.ToString());
                if(param.ParamType == "proxy")
                {
                    await textWriter.WriteAttributeStringAsync(null, "proxyParameters", null, convertProxyArrayToString(param.proxyParameterArray));
                }
                await textWriter.WriteEndElementAsync();
            }
            await textWriter.WriteEndElementAsync();
            await textWriter.WriteStartElementAsync(null,"soundParameters",null);
            await textWriter.WriteEndElementAsync();
            await textWriter.WriteEndElementAsync();
            await textWriter.WriteEndDocumentAsync();
            await textWriter.FlushAsync();
            textWriter.Close();
            return;
        }

        static public string convertProxyArrayToString(List<string[]> proxyArray)
        {
            List<string> innerArrays = new List<string>();
            foreach(string[] innerArray in proxyArray)
            {
                innerArrays.Add(String.Join(",", innerArray));
            }
            string joinedString = String.Join("|", innerArrays);
            Console.WriteLine(joinedString);
            return joinedString;
        }

        static public List<string[]> convertStringToProxyArray(string proxyArray)
        {
            List<string[]> finalArray = new List<string[]>();
            string[] outerArrays = proxyArray.Split('|');
            foreach(string innerArray in outerArrays)
            {
                finalArray.Add(innerArray.Split(','));
            }
            return finalArray;
        }
    }
}
