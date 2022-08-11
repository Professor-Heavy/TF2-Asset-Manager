using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace AssetManager
{
    class VMTInteraction
    {
        private enum MaterialProxies //TODO: Saved for the future as part of an accessibility update.
        {
            Sine
        }

        /// <summary>
        /// Checks the validity of a MaterialParameter to make sure that none of the fields are invalid.
        /// </summary>
        /// <param name="parameter">Parameter to verify.</param>
        /// <returns>Returns true if the parameter is valid, or false if the check fails.</returns>
        static public int VerifyParameter(MaterialParameter parameter)
        {
            if(parameter.ParamValue is List<string>)
            {
                if(parameter.ParamValue.Count == 1 && parameter.ParamValue[0] == string.Empty
                    || parameter.Parameter.Length == 0) //No value assigned to the parameter or paramvalue.
                {
                    return 0;
                }
            }
            else
            {
                if (parameter.ParamValue.Length == 0
                    || (parameter.Parameter.Length == 0 && parameter.ParamType.ToString() != "proxy")) //No value assigned to the parameter or paramvalue.
                {
                    return 0;
                }
            }
            if (parameter.ParamType.ToString() == "integer" && !Int32.TryParse(parameter.ParamValue, out int num)) //Parameter does nt match the type.
            {
                return 1;
            }
            else if (parameter.ParamType.ToString().Contains("vector3") && parameter.ParamValue.Count != 3) //Check that it contains 3 values only.
            {
                return 2;
            }
            else if(parameter.ParamType.ToString().Contains("vector3") && ResolveAmbiguousType(parameter.ParamValue) == null)
            {
                return 3;
            }
            return -1;
        }

        static public string PerformColorChecks(string shader) //VertexLitGeneric shaders only work with $color2.
        {
            if (shader.Equals("vertexlitgeneric", StringComparison.OrdinalIgnoreCase))
            {
                return "$color2";
            }
            else
            {
                return "$color";
            }
        }

        static Type ResolveAmbiguousType(List<string> values)
        {
            bool possibleInt = false;
            foreach (string value in values)
            {
                if(value.Contains("."))
                {
                    return typeof(float);
                }
                if (double.TryParse(value, out double dblConversion))
                {
                    if (Math.Round(dblConversion) != (double)dblConversion)
                    {
                        return typeof(float);
                    }
                }
                if (int.TryParse(value, out int intConversion))
                {
                    possibleInt = true;
                }
            }
            if(possibleInt)
            {
                return typeof(int);   
            }
            return null;
            //throw new ArgumentException("Unable to determine ambiguous type.");
        }
        static public VProperty InsertVector3IntoMaterial(dynamic Material, string parameter, List<string> values, float[] offset)
        {
            Type type = ResolveAmbiguousType(values);
            List<dynamic> convertedValues = values.ConvertAll(x => System.ComponentModel.TypeDescriptor.GetConverter(type).ConvertFrom(x));
            List<float> offsetValues = new List<float>
            {
                convertedValues[0] + offset[0],
                convertedValues[1] + offset[1],
                convertedValues[2] + offset[2]
            };
            VValue vvalue = new VValue((type == typeof(float) ? "[" : "{") + string.Join(" ", values) + (type == typeof(float) ? "]" : "}"));
            VProperty propertyToWrite = CaseInsensitiveParameterCheck(Material.Value, parameter);
            propertyToWrite.Value = vvalue;
            Material.Value.Add(propertyToWrite);
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertVector3IntoMaterial(dynamic Material, string parameter, float[] values)
        {
            VValue vvalue = new VValue("[" + string.Join(" ", values) + "]");
            VProperty propertyToWrite = CaseInsensitiveParameterCheck(Material.Value, parameter);
            propertyToWrite.Value = vvalue;
            Material.Value.Add(propertyToWrite);
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertValueIntoMaterial<T>(dynamic Material, string parameter, T value)
        {
            VValue vvalue = new VValue(value);
            VProperty propertyToWrite = CaseInsensitiveParameterCheck(Material.Value, parameter);
            propertyToWrite.Value = vvalue;
            Material.Value.Add(propertyToWrite);
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertProxyIntoMaterial(dynamic Material, string parameter, List<string[]> proxyParameterArray)
        {
            VObject proxy = new VObject();
            foreach (string[] proxyParameter in proxyParameterArray)
            {
                if (string.IsNullOrEmpty(proxyParameter[0]) || string.IsNullOrEmpty(proxyParameter[1]))
                {
                    continue;
                }
                proxy.Add(proxyParameter[0], new VValue(proxyParameter[1]));
            }
            string proxyKeyName = CaseInsensitiveProxyCheck(Material);
            if (proxyKeyName == null)
            {
                proxyKeyName = "Proxies";
                VObject proxies = new VObject();
                Material.Value[proxyKeyName] = proxies;
            }
            if (Material.Value[proxyKeyName].ContainsKey(parameter))
            {
                Material.Value[proxyKeyName].Add(new VProperty(parameter, proxy));
            }
            else
            {
                Material.Value[proxyKeyName][parameter] = proxy;
            }
            return Material;
        }

        static public VProperty InsertRandomChoiceIntoMaterial(dynamic Material, string parameter, List<string> valueArray, Random randomChoiceGen)
        {
            return InsertValueIntoMaterial<string>(Material, parameter, valueArray[randomChoiceGen.Next(0, valueArray.Count)]);
        }

        static public VProperty RemoveProxiesWithOverridingMaterialParameters(dynamic Material, string OverridingParameter)
        {
            string proxyKeyName = CaseInsensitiveProxyCheck(Material);
            if (proxyKeyName == null)
            {
                return Material;
            }
            foreach (var a in Material.Value[proxyKeyName])
            {
                if (Material.Value[proxyKeyName][a.Key].ContainsKey("resultVar") && Material.Value[proxyKeyName][a.Key].resultVar.ToString() == OverridingParameter)
                {
                    Material.Value[proxyKeyName][a.Key].Clear();
                }
            }
            return Material;
        }

        /// <summary>
        /// Checks a material object for matching proxies. Returns the matching proxy.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        static public bool ContainsProxy(dynamic material, string proxy)
        {
            string proxyKey = CaseInsensitiveProxyCheck(material);
            if(proxyKey == null)
            {
                return false;
            }
            VObject objectValue = material.Value[proxyKey];
            IEnumerable<VProperty> match = objectValue.Children().Where(x => x.Key.Equals(proxy, StringComparison.OrdinalIgnoreCase));
            if (match.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string CaseInsensitiveProxyCheck(dynamic material)
        {
            if (material.Value.ContainsKey("proxies"))
            {
                return "proxies";
            }
            else if (material.Value.ContainsKey("Proxies"))
            {
                return "Proxies";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks for a particular parameter (stringToCheck) in vObject, ignoring case.
        /// </summary>
        /// <param name="vObject"></param>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        static public VProperty CaseInsensitiveParameterCheck(VToken vObject, string stringToCheck)
        {
            IEnumerable<VProperty> match = vObject.Children().Where(x => x.Key.Equals(stringToCheck, StringComparison.OrdinalIgnoreCase));
            if(match.Count() > 0)
            {
                return match.First();
            }
            //throw new Exception();
            return new VProperty(stringToCheck, null);
        }

        static public VProperty InsertRandomChoiceIntoMaterial(dynamic Material, string parameterArray)
        {
            return Material;
        }
    }
}
