using SteamDatabase.ValvePak;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AssetManager
{
    class VPKInteraction
    {
        static public Dictionary<string, string> extractSpecificFileTypeFromVPK(string vpkPath, string extensionType)
        {
            DirectoryInfo path = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Temp"));
            using (Package package = new Package())
            {
                package.Read(vpkPath);
                using (SHA1 sha1 = SHA1.Create())
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    foreach (var a in package.Entries)
                    {
                        foreach (var b in a.Value)
                        {
                            if (b.TypeName != extensionType)
                            {
                                continue;
                            }
                            package.ReadEntry(b, out var entry);
                            data.Add("temp/" + b.DirectoryName + "/" + b.FileName + "." + b.TypeName, Encoding.UTF8.GetString(entry));
                        }
                    }
                    return data;
                }
            }
        }
    }
}
