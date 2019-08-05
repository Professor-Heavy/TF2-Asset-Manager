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
