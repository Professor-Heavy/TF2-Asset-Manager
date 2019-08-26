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
        static public List<string> vpkContents = new List<string>();
        static public Dictionary<string, string> ExtractSpecificFileTypeFromVPK(string vpkPath, string extensionType, System.Threading.CancellationToken ct)
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
                ct.ThrowIfCancellationRequested();
                return data;
            }
        }
        static public void ReadVpk(string vpkPath)
        {
            using (Package package = new Package())
            {
                package.Read(vpkPath);
                foreach (var a in package.Entries)
                {
                    foreach (var b in a.Value)
                    {
                        vpkContents.Add(b.DirectoryName);
                    }
                }
            }
        }
        static public string PackageToVpk(string pathToVpkTool, DirectoryInfo pathToPackageDirectory, System.Threading.CancellationToken ct)
        {
            using (Process pProcess = new Process())
            {
                pProcess.StartInfo.FileName = Path.Combine(pathToVpkTool, "bin\\vpk.exe");
                pProcess.StartInfo.Arguments = Path.GetDirectoryName(pathToPackageDirectory.FullName + "/");
                pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.Start();
                if (ct.IsCancellationRequested)
                {
                    pProcess.Kill();
                    pProcess.Close();
                    ct.ThrowIfCancellationRequested();
                }
                string output = pProcess.StandardOutput.ReadToEnd();
                pProcess.WaitForExit();
                return output;
            }
        }
    }
}
