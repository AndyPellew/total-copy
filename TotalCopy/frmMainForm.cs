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
            DirectoryInfo Source = new DirectoryInfo(tbSourceDir.Text);
            DirectoryInfo[] Targets;
            Targets = new DirectoryInfo[tbTargetDirList.Lines.Count()];

            int DirCount = 0;
            foreach (string Line in tbTargetDirList.Lines)
            {
                Targets[DirCount] = new DirectoryInfo(tbTargetDirList.Lines[DirCount]);
                DirCount = DirCount + 1;
            }
            file.CopyDirectory(Source, Targets, tbSourceDir.Text, tbMemoryDir.Text);
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TotalCopy.Properties.Settings.Default.SourceDir = tbSourceDir.Text;
            TotalCopy.Properties.Settings.Default.TargetDir = tbTargetDirList.Text;
            TotalCopy.Properties.Settings.Default.MemoryDir = tbMemoryDir.Text;
            TotalCopy.Properties.Settings.Default.Save();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            tbSourceDir.Text = TotalCopy.Properties.Settings.Default.SourceDir;
            tbTargetDirList.Text = TotalCopy.Properties.Settings.Default.TargetDir;
            tbMemoryDir.Text = TotalCopy.Properties.Settings.Default.MemoryDir;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
