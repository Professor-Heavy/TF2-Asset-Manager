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
        static public List<DirectoryInfo> vpkContents = new List<DirectoryInfo>();
        static public Dictionary<string, string> extractSpecificFileTypeFromVPK(string vpkPath, string extensionType)
        {
            using (Package package = new Package())
            {
                package.Read(vpkPath);
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
                        data.Add(b.DirectoryName + "/" + b.FileName + "." + b.TypeName, Encoding.UTF8.GetString(entry));
                    }
                }
                return data;
            }
        }
        static public void readVpk(string vpkPath)
        {
            using (Package package = new Package())
            {
                package.Read(vpkPath);
                foreach (var a in package.Entries)
                {
                    foreach (var b in a.Value)
                    {
                        vpkContents.Add(new DirectoryInfo(b.DirectoryName + "/" + b.FileName + "." + b.TypeName));
                    }
                }
            }
        }
    }
}
