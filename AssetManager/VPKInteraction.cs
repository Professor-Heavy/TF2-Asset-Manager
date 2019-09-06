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
        static public Dictionary<string, string> ExtractSpecificFileTypeFromVPK(string vpkPath, string extensionType)
        {
            using (Package package = new Package())
            {
                package.Read(vpkPath);
                Dictionary<string, string> data = new Dictionary<string, string>();
                foreach (var a in package.Entries) //Consider this recursion.
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
        static public Dictionary<string, string> ExtractSpecificFileTypesFromCustomDirectory(string customDirectoryPath, string extensionType, List<string> filter)
        {
            string[] directories = Directory.GetFiles(customDirectoryPath, "*." + extensionType, SearchOption.AllDirectories);
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (string file in directories)
            {
                string relativePath = GetRelativePath(file, customDirectoryPath);
                string firstFilePath = relativePath.Split('/')[1];
                if (filter.Contains(firstFilePath))
                {
                    relativePath = relativePath.Substring(relativePath.IndexOf('/', relativePath.IndexOf('/') + 1) + 1);
                    data.Add(relativePath, File.ReadAllText(file));
                }
            }
            return data;
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
                        if (b.DirectoryName != " ")
                        {
                            vpkContents.Add(b.DirectoryName);
                        }
                    }
                }
            }
        }
        static public string PackageToVpk(string pathToVpkTool, DirectoryInfo pathToPackageDirectory)
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
                // if (ct.IsCancellationRequested)
                // {
                //     pProcess.Kill();
                //     pProcess.Close();
                //     ct.ThrowIfCancellationRequested();
                // }
                string output = pProcess.StandardOutput.ReadToEnd();
                pProcess.WaitForExit();
                return output;
            }
        }

        /// <summary>
        /// Gets the relative path of two absolute paths, with the first path being the longer path.
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        static public string GetRelativePath(string path1, string path2)
        {
            Uri uri1 = new Uri(path2);
            Uri uri2 = new Uri(path1);
            return uri1.MakeRelativeUri(uri2).ToString().Replace("%20", " ");
        }
    }
}
