using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TotalCopy
{
    class file
    {
        public static void LogText(string Text)
        {
            String LogFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\Log.txt";
            StreamWriter sw;
            if (File.Exists(LogFile))
                sw = File.AppendText(LogFile);
            else
                sw = File.CreateText(LogFile);
            sw.WriteLine(Text);
            sw.Close();
        }

        public static string GetMD5HashFromFile(string FileName)
        {
            // The code is based on the tutorial "Calculate MD5 Checksum for a File" from
            // http://sharpertutorials.com/calculate-md5-checksum-file/
            //
            FileStream FS = new FileStream(FileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(FS);
            FS.Close();
            ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(retVal);
        }

        public static void CopyDirectory(DirectoryInfo Source, DirectoryInfo[] Targets, String RootDir, String MemoryDir)
        {
            LogText("START:" + Source.FullName);

            // Copy all files
            FileInfo[] files = Source.GetFiles();
            LogText("  Number of files in Source Directory: " + files.Count().ToString());
            foreach (FileInfo file in files)
            {
                String MemoryFile =
                    file.FullName.Replace(RootDir, "").Replace(":", "").Replace(@"\", "");
                if (MemoryFile.Length > 14)
                    MemoryFile = MemoryFile.Insert(14, @"\");
                MemoryFile = MemoryDir + MemoryFile + ".txt";
                Directory.CreateDirectory(Path.GetDirectoryName(MemoryFile));

                LogText("  MemoryFile: " + MemoryFile);

                Boolean Exists = File.Exists(MemoryFile);
                if (Exists)
                {
                    TextReader tr = new StreamReader(MemoryFile);
                    String MD5 = tr.ReadLine();
                    tr.Close();

                    LogText("  ... Comparing saved MD5 file with MD5 from source file");

                    Exists = (GetMD5HashFromFile(file.FullName) == MD5);
                }
                foreach (DirectoryInfo Target in Targets)
                    if (Target.Exists)
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
                                LogText("  ... Attempting to create directory: " + Target.FullName);
                                Directory.CreateDirectory(
                                    Target.FullName);

                                LogText("  ... Performing the actual file copy");
                                file.CopyTo(
                                    Path.Combine(
                                        Target.FullName,
                                        file.Name), 
                                    true);

                                LogText("  ... Saving the MD5 for the source file into the MemoryFile");
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

            LogText("END:" + Source.FullName);
        }
    }
}
