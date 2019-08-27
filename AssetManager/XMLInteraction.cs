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
            MaterialParametersArrayList.Add(new MaterialParameter("Solid Color", "$color", "vector3-color", "255,255,255"));
            MaterialParametersArrayList.Add(new MaterialParameter("Pulsing Rainbow", "proxy", "proxy", "add"));
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
                MessageBox.Show("The parameter configuration file is corrupt, or uses a different version. A new one will be created.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ImplementDefaultParameters();
                await WriteXmlParameters(completeUserDataPath);
                xDoc = XDocument.Load(completeUserDataPath + "\\parameterStorage.xml");
            }
            MaterialParametersArrayList.Clear();
            var materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            foreach (XElement param in materialParamList) //We need to ignore proxies until they're ready too..
            {
                string parameterName = param.Element("paramName").Value;
                string parameter = param.Element("parameter").Value;
                string parameterType = param.Element("paramType").Value;
                string parameterValue = param.Element("paramValue").Value;
                int parameterForce = ParseInt(param.Element("paramValue").Value);
                int parameterRandomChance = ParseInt(param.Element("randomChance").Value);
                float parameterRandomOffset = ParseFloat(param.Element("randomOffset").Value);

                List<string[]> parameterProxyParameters = null;
                if(parameterType == "proxy")
                {
                    parameterProxyParameters = new List<string[]>();
                    foreach (XElement shader in param.Element("proxyParameters").Elements("proxyParameter"))
                    {
                        parameterProxyParameters.Add(new string[] {shader.Attribute("key").Value, shader.Attribute("value").Value});
                    }
                }

                List<string> parameterShaderFilters = new List<string>();
                foreach(XElement shader in param.Element("shaderArray").Elements("filter"))
                {
                    parameterShaderFilters.Add(shader.Value);
                }

                int parameterShaderFilterMode = ParseInt(param.Element("shaderArray").Attribute("shaderFilterMode").Value);
                MaterialParametersArrayList.Add(new MaterialParameter(parameterName,
                                                                      parameter,
                                                                      parameterType,
                                                                      parameterValue,
                                                                      parameterForce,
                                                                      parameterRandomChance,
                                                                      parameterRandomOffset,
                                                                      parameterProxyParameters,
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
            await textWriter.WriteStartDocumentAsync();
            await textWriter.WriteStartElementAsync(null, "parameterSettings", null);
            await textWriter.WriteStartElementAsync(null, "materialParameterList", null);
            foreach (MaterialParameter param in MaterialParametersArrayList)
            {
                await textWriter.WriteStartElementAsync(null, "materialParameter", null);
                await textWriter.WriteElementStringAsync(null, "paramName", null, param.ParamName);
                await textWriter.WriteElementStringAsync(null, "parameter", null, param.Parameter); 
                await textWriter.WriteElementStringAsync(null, "paramType", null, param.ParamType);
                await textWriter.WriteElementStringAsync(null, "paramValue", null, param.ParamValue);
                await textWriter.WriteElementStringAsync(null, "paramForce", null, param.ParamForce.ToString());
                await textWriter.WriteElementStringAsync(null, "randomChance", null, param.RandomizerChance.ToString());
                await textWriter.WriteElementStringAsync(null, "randomOffset", null, param.RandomizerOffset.ToString());
                if (param.ParamType == "proxy")
                {
                    await textWriter.WriteStartElementAsync(null, "proxyParameters", null);
                    foreach(string[] proxyParameter in param.ProxyParameterArray)
                    {
                        await textWriter.WriteStartElementAsync(null, "proxyParameter", null);
                        await textWriter.WriteAttributeStringAsync(null, "key", null, proxyParameter[0]);
                        await textWriter.WriteAttributeStringAsync(null, "value", null, proxyParameter[1]);
                        await textWriter.WriteEndElementAsync();
                    }
                    await textWriter.WriteEndElementAsync();
                }
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
            await textWriter.WriteStartElementAsync(null,"soundParameters",null);
            await textWriter.WriteEndElementAsync();
            await textWriter.WriteEndElementAsync();
            await textWriter.WriteEndDocumentAsync();
            await textWriter.FlushAsync();
            textWriter.Close();
            return;
        }

        static int ParseInt(dynamic input)
        {
            try
            { input = Convert.ToInt32(input); } //Not my usual identation style, but it looks nice.
            catch (FormatException)
            {input = 0;} //Throw it back out with a reset value.
            return input;
        }
        static float ParseFloat(dynamic input)
        {
            try
            { input = float.Parse(input); }
            catch (FormatException)
            {input = 0.0f;}
            return input;
        }
    }
}
