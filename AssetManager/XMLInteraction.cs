using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AssetManager
{
    class XMLInteraction
    {
        public static BindingList<MaterialParameter> MaterialParametersArrayList = new BindingList<MaterialParameter>();

        /// <summary>
        /// Refreshes the list of parameters and reads the XML file, updating the parameter lists in memory.
        /// </summary>
        static public void ImplementDefaultParameters()
        {
            MaterialParametersArrayList.Add(new MaterialParameter("Solid Color", "$color", "vector3", "{255,255,255}"));
            MaterialParametersArrayList.Add(new MaterialParameter("Pulsing Rainbow", "proxy", "NOT IMPLEMENTED", "NOT IMPLEMENTED"));
            MaterialParametersArrayList.Add(new MaterialParameter("No Phong Shading", "$phong", "bool", "0"));
            MaterialParametersArrayList.Add(new MaterialParameter("All Phong Shading", "$phong", "bool", "1"));
            MaterialParametersArrayList.Add(new MaterialParameter("Extreme Phong Boost", "$phong", "integer", "500"));
        }
        /// <summary>
        /// Refreshes the list of parameters and reads the XML file, updating the parameter lists in memory.
        /// </summary>
        /// <param name="completeUserDataPath">The directory where parameterStorage.xml is stored.</param>
        static public void ReadXmlParameters(string completeUserDataPath)
        {
            MaterialParametersArrayList.Clear();
            XDocument xDoc = XDocument.Load(completeUserDataPath + "\\parameterStorage.xml");
            var materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            foreach (XElement param in materialParamList) //We need to ignore proxies until they're ready too..
            {
                MaterialParametersArrayList.Add(new MaterialParameter(param.Attribute("paramName").Value,
                                                                      param.Attribute("parameter").Value,
                                                                      param.Attribute("paramType").Value,
                                                                      param.Attribute("paramValue").Value));
            }
        }
        static public async Task WriteXmlParameters(string completeUserDataPath) //Returns true or false depending on the status of the write
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
                //TODO: Code in a case/switch that writes other formats depending on the ParamType.
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
    }
}
