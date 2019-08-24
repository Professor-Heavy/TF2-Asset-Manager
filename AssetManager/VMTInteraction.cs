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
        private enum MaterialProxies
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
            if (parameter.ParamType.Length == 0 || parameter.ParamValue.Length == 0 || parameter.Parameter.Length == 0)
            {
                return 0;
            }
            if (parameter.ParamType == "integer" && !Int32.TryParse(parameter.ParamValue, out int num))
            {
                return 1;
            }
            else if (parameter.ParamType.Contains("vector3") && parameter.ParamValue.Split(',').Length != 3) //Check that it contains 3 values only.
            {
                return 1;
            }
            return -1; //Consider implementing a more verbose system.
        }
        static public int[] ConvertStringToVector3Int(string value) //Need a more efficient way to work with types...
        {
            if (value.Length > 2)
            {
                return Array.ConvertAll<string, int>(value.Split(','), int.Parse);
            }
            else
            {
                return new int[] { 0, 0, 0 };
            }
        }

        static public float[] ConvertStringToVector3Float(string value) //Need a more efficient way to work with types...
        {
            if (value.Length > 2)
            {
                return Array.ConvertAll<string, float>(value.Split(','), float.Parse);
            }
            else
            {
                return new float[] { 0.0f, 0.0f, 0.0f };
            }
        }

        static public string PerformColorChecks(string shader)
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
        static public VProperty InsertVector3IntoMaterial(dynamic Material, string parameter, int[] values)
        {
            VValue vvalue = new VValue("{" + string.Join(" ", values) + "}");
            Material.Value[parameter] = vvalue; //VValue is a value, VObject is an object.
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertVector3IntoMaterial(dynamic Material, string parameter, float[] values)
        {
            VValue vvalue = new VValue("[" + string.Join(" ", values) + "]");
            Material.Value[parameter] = vvalue; //VValue is a value, VObject is an object.
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertValueIntoMaterial<T>(dynamic Material, string parameter, T value)
        {
            VValue vvalue = new VValue(value);
            Material.Value[parameter] = vvalue; //VValue is a value, VObject is an object.
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertProxyIntoMaterial(dynamic Material, string parameter, List<string[]> proxyParameterArray)
        {
            VObject proxy = new VObject();
            foreach (string[] proxyParameter in proxyParameterArray)
            {
                if(String.IsNullOrEmpty(proxyParameter[0]) || String.IsNullOrEmpty(proxyParameter[1]))
                {
                    continue;
                }
                proxy.Add(proxyParameter[0], new VValue(proxyParameter[1]));
            }
            string proxyKeyName = "Proxies";
            if(Material.Value.ContainsKey("proxies"))
            {
                proxyKeyName = "proxies";
            }
            else if(Material.Value.ContainsKey("Proxies"))
            {
                proxyKeyName = "Proxies";
            }
            else
            {
                VObject proxies = new VObject();
                Material.Value[proxyKeyName] = proxies;
            }
            if (Material.Value[proxyKeyName].ContainsKey(parameter))
            {
                VToken token = proxy;
                Material.Value[proxyKeyName].Add(new VProperty(parameter, proxy));
            }
            else
            {
                Material.Value[proxyKeyName][parameter] = proxy;
            }
            //proxy.Value["basetexture"] = "yes";
            return Material;
        }

        static public VProperty RemoveProxiesWithOverridingMaterialParameters(dynamic Material, string OverridingParameter)
        {
            if (Material.Value.ContainsKey("Proxies"))
            {
                PropertyInfo propertyinfo = Material.Value.Proxies.GetType().GetProperty("Count");
                int name = (int)(propertyinfo.GetValue(Material.Value.Proxies, null));
                foreach(var a in Material.Value.Proxies)
                {
                    if (Material.Value.Proxies[a.Key].ContainsKey("resultVar") && Material.Value.Proxies[a.Key].resultVar.ToString() == OverridingParameter)
                    {
                        Material.Value.Proxies[a.Key].Clear();
                    }
                }
            }
            return Material;
        }
    }
}
