using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace TotalCopy
{
    class file
    {
        public static string GetMD5HashFromFile(string FileName)
        {
            FileStream FS = new FileStream(FileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(FS);
            FS.Close();
            ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(retVal);
        }

        public static void CopyDirectory(DirectoryInfo Source, DirectoryInfo[] Targets, String RootDir, String MemoryDir)
        {
            foreach (DirectoryInfo Target in Targets)
                if (!Target.Exists)
                    Target.Create();

            // Copy all files
            FileInfo[] files = Source.GetFiles();
            foreach (FileInfo file in files)
            {
                String MemoryFile =
                    MemoryDir + file.FullName.Replace(":", "").Replace(@"\", "") + ".txt";

                Boolean Exists = File.Exists(MemoryFile);
                if (Exists)
                {
                    TextReader tr = new StreamReader(MemoryFile);
                    String MD5 = tr.ReadLine();
                    tr.Close();

                    Exists = (GetMD5HashFromFile(file.FullName) == MD5);
                }
                foreach (DirectoryInfo Target in Targets)
                    foreach (FileInfo TargetFile in Target.GetFiles())
                        if (TargetFile.Name == file.Name)
                            Exists = true;

                Boolean Copied = false;
                if (!Exists)
                    foreach (DirectoryInfo Target in Targets)
                    {
                        if (!Copied)
                        {
                            try
                            {
                                file.CopyTo(
                                    Path.Combine(
                                        Target.FullName,
                                        file.Name), 
                                    true);

                                TextWriter tw = new StreamWriter(MemoryFile);
                                tw.WriteLine(GetMD5HashFromFile(file.FullName));
                                tw.Close();
                                Copied = true;

                            }
                            catch
                            {
                            }
                        }
                    }
            }

            // Process subdirectories.
            DirectoryInfo[] DirList = Source.GetDirectories();
            foreach (DirectoryInfo Dir in DirList)
            {
                DirectoryInfo[] NewTargets;
                NewTargets = new DirectoryInfo[Targets.Count()];

                int DirCount = 0;
                foreach (DirectoryInfo TargetDir in Targets)
                {
                    NewTargets[DirCount] = new DirectoryInfo(Path.Combine(Targets[DirCount].FullName, Dir.Name));
                    DirCount = DirCount + 1;
                }
                // Call CopyDirectory() recursively.
                CopyDirectory(Dir, NewTargets, RootDir, MemoryDir);
            }
            
        }
    }
}
