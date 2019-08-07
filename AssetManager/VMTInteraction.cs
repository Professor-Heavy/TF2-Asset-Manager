using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
        static public int[] ConvertStringToVector3(string value)
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
            // if (Material.Value.ContainsKey("$basetexture") && Material.Value["$basetexture"].ToString() == "models/weapons/c_models/c_minigun/c_minigun")
            // {
            //     System.Diagnostics.Debugger.Break();
            // }
            VValue vvalue = new VValue("{" + string.Join(" ", values) + "}");
            Material.Value[parameter] = vvalue; //VValue is a value, VObject is an object.
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
        }

        static public VProperty InsertIntIntoMaterial(dynamic Material, string parameter, int value)
        {
            VValue vvalue = new VValue(value);
            Material.Value[parameter] = vvalue; //VValue is a value, VObject is an object.
            return RemoveProxiesWithOverridingMaterialParameters(Material, parameter);
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

        static public VProperty AddProxy(dynamic Material, string Proxy, List<KeyValuePair<string, string>> ParameterList)
        {
            if (Enum.IsDefined(typeof(MaterialProxies), Proxy))
            {
                if (!Material.Value.ContainsKey("Proxies"))
                {
                    Material.Value.Add(); //This is a vproperty, how do I even go about this..?
                }
            }
            else
            {
                throw new ArgumentException("The defined proxy does not exist, or is not currently available.");
            }
            return Material;
        }
    }
}
