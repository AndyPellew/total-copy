﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Web;

namespace TotalCopy
{
    class file
    {
        public static string BuildMD5FromFile(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            string Result = "";
            for (int index = 0; index < retVal.Length; index++)
                Result = Result + @"\" + retVal[index].ToString("X").PadLeft(2, '0');
            Result = Result.Substring(1);

            return Result;
        }

        public static void RecordCopy(string MemoryDir, string FileName)
        {
            LogText("MemoryDir: " + MemoryDir + ", Filename: " + FileName);
            FileInfo fiFile = new FileInfo(FileName);

            string MemoryFile = MemoryDir + @"\" + fiFile.Length.ToString() + @"\" + BuildMD5FromFile(FileName) + ".check";
            Directory.CreateDirectory(Path.GetDirectoryName(MemoryFile));
            TextWriter tw = new StreamWriter(MemoryFile);
            tw.WriteLine("  ");
            tw.Close();
        }

        public static bool FullCopyCheck(long FileSize, string MemoryDir, string FileMD5)
        {
            // Date: 08-AUG-2011
            // Description: This checks to see if the file has already been copied based on an MD5 of the
            //   file and the length of the file
            bool Result = false;
            if (Directory.Exists(MemoryDir + @"\" + FileSize.ToString()))
                if (File.Exists(MemoryDir + @"\" + FileSize.ToString() + @"\" + FileMD5 + ".check"))
                    Result = true;

            return Result;
        }

        public static bool PartialCopyCheck(long FileSize, string MemoryDir, string FileMD5)
        {
            // Date: 08-AUG-2011
            // Description: This checks to see if the file has already been copied based on just the
            //   length of the file
            bool Result = false;
            if (Directory.Exists(MemoryDir + @"\" + FileSize.ToString()))
                Result = true;

            return Result;
        }

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

        public static void CopyDirectory(DirectoryInfo Source, DirectoryInfo[] Targets, String RootDir, String MemoryDir)
        {
            LogText("START:" + Source.FullName);

            // Copy all files
            FileInfo[] files = Source.GetFiles();
            LogText("  Number of files in Source Directory: " + files.Count().ToString());
            foreach (FileInfo file in files)
            {
                // Define the MemoryFile (the file we will use to allow us to track the details of a file we have
                // previously copyied in the event that the destination is not available when we next do a
                // backup).
                // Directories are created just so that the number of files in the Memory directory does not
                // become so large it affects performance.
                String MemoryFile =
                    file.FullName.Replace(RootDir, "").Replace(":", "").Replace(@"\", "");
                if (MemoryFile.Length > 14)
                    MemoryFile = MemoryFile.Insert(14, @"\");
                MemoryFile = MemoryDir + MemoryFile + ".txt";
                Directory.CreateDirectory(Path.GetDirectoryName(MemoryFile));
                LogText("  MemoryFile: " + MemoryFile);

                // Get information on the file we are copying
                FileInfo fiFile = new FileInfo(file.FullName);
                LogText("  File info for existing file: Length=" + fiFile.Length.ToString());

                Boolean Exists = File.Exists(MemoryFile); // Does the memory file already exist?
                if (Exists) // ... If it does 
                {
                    // Read the info of the file we've already copied
                    TextReader tr = new StreamReader(MemoryFile);
                    long lFileLength = Int64.Parse(tr.ReadLine());
                    tr.Close();
                    LogText("  Memory file contents: Length=" + lFileLength.ToString());
                    if (lFileLength == fiFile.Length) // Is the stored file length the same as the current file length?
                        Exists = false;
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

                                LogText("  ... Saving the file length for the source file into the MemoryFile");
                                RecordCopy(MemoryDir,
                                    file.FullName);

                                if (File.Exists(MemoryFile)) // If file exists ...
                                    File.Delete(MemoryFile); // ... delete it

                                // Format for the memory file; Line 1 = File size
                                TextWriter tw = new StreamWriter(MemoryFile);
                                tw.WriteLine(fiFile.Length.ToString());
                                tw.Close();

                                Copied = true;
                            }
                            catch
                            {
                                LogText("  ... File copy failed, further files will be attempted");
                            }
                        }
                    }
            }

            // Process subdirectories (if any)
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
