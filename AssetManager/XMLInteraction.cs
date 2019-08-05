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
            foreach (XElement param in xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter")) //We need to ignore proxies until they're ready too..
            {
                //Console.WriteLine(param);
            }
            var materialParamList = xDoc.Elements("parameterSettings").Elements("materialParameterList").Elements("materialParameter");
            foreach (XElement param in materialParamList) //We need to ignore proxies until they're ready too..
            {
                Console.WriteLine(param);
                MaterialParametersArrayList.Add(new MaterialParameter(param.Attribute("paramName").Value,
                                                                      param.Attribute("parameter").Value,
                                                                      param.Attribute("paramType").Value,
                                                                      param.Attribute("paramValue").Value));
            }
        }
        static public bool WriteXmlParameters(string completeUserDataPath) //Returns true or false depending on the status of the write
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };
            XmlWriter textWriter = XmlWriter.Create(completeUserDataPath + "\\parameterStorage.xml", settings);

            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("parameterSettings");
            textWriter.WriteStartElement("materialParameterList");
            foreach (MaterialParameter param in MaterialParametersArrayList)
            {
                textWriter.WriteStartElement("materialParameter");
                textWriter.WriteAttributeString("paramName", param.ParamName);
                textWriter.WriteAttributeString("parameter", param.Parameter);
                textWriter.WriteAttributeString("paramType", param.ParamType);
                textWriter.WriteAttributeString("paramValue", param.ParamValue);
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("soundParameters");
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            textWriter.Flush();
            return true;
        }
    }
}
