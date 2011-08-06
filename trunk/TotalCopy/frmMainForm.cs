using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TotalCopy
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void btnBeginCopy_Click(object sender, EventArgs e)
        {
            File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + @"\Log.txt");

            DirectoryInfo Source = new DirectoryInfo(tbSourceDir.Text);
            DirectoryInfo[] Targets;
            Targets = new DirectoryInfo[tbFirstTargetDirList.Lines.Count()];

            int DirCount = 0;
            foreach (string Line in tbFirstTargetDirList.Lines)
            {
                Targets[DirCount] = new DirectoryInfo(tbFirstTargetDirList.Lines[DirCount]);
                DirCount = DirCount + 1;
            }
            file.CopyDirectory(Source, Targets, tbSourceDir.Text, Path.GetDirectoryName(Application.ExecutablePath) + @"\Memory\1\");

            Source = new DirectoryInfo(tbSourceDir.Text);
            Targets = new DirectoryInfo[tbSecondTargetDirList.Lines.Count()];

            DirCount = 0;
            foreach (string Line in tbFirstTargetDirList.Lines)
            {
                Targets[DirCount] = new DirectoryInfo(tbSecondTargetDirList.Lines[DirCount]);
                DirCount = DirCount + 1;
            }
            file.CopyDirectory(Source, Targets, tbSourceDir.Text, Path.GetDirectoryName(Application.ExecutablePath) + @"\Memory\2\");

        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TotalCopy.Properties.Settings.Default.SourceDir = tbSourceDir.Text;
            TotalCopy.Properties.Settings.Default.FirstTargetDir = tbFirstTargetDirList.Text;
            TotalCopy.Properties.Settings.Default.SecondTargetDir = tbSecondTargetDirList.Text;
            TotalCopy.Properties.Settings.Default.Save();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            tbSourceDir.Text = TotalCopy.Properties.Settings.Default.SourceDir;
            tbFirstTargetDirList.Text = TotalCopy.Properties.Settings.Default.FirstTargetDir;
            tbSecondTargetDirList.Text = TotalCopy.Properties.Settings.Default.SecondTargetDir;
        }

        private void bSourceDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = tbSourceDir.Text;
            DialogResult result = FolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                tbSourceDir.Text = FolderBrowserDialog.SelectedPath;
                
        }
    }
}
