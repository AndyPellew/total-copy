namespace TotalCopy
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBeginCopy = new System.Windows.Forms.Button();
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.tbSourceDir = new System.Windows.Forms.TextBox();
            this.gbxTargetDirectories = new System.Windows.Forms.GroupBox();
            this.tbTargetDirList = new System.Windows.Forms.TextBox();
            this.lblMemoryDir = new System.Windows.Forms.Label();
            this.tbMemoryDir = new System.Windows.Forms.TextBox();
            this.gbxTargetDirectories.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBeginCopy
            // 
            this.btnBeginCopy.Location = new System.Drawing.Point(13, 190);
            this.btnBeginCopy.Name = "btnBeginCopy";
            this.btnBeginCopy.Size = new System.Drawing.Size(75, 23);
            this.btnBeginCopy.TabIndex = 0;
            this.btnBeginCopy.Text = "Begin";
            this.btnBeginCopy.UseVisualStyleBackColor = true;
            this.btnBeginCopy.Click += new System.EventHandler(this.btnBeginCopy_Click);
            // 
            // lblSourceDir
            // 
            this.lblSourceDir.AutoSize = true;
            this.lblSourceDir.Location = new System.Drawing.Point(14, 16);
            this.lblSourceDir.Name = "lblSourceDir";
            this.lblSourceDir.Size = new System.Drawing.Size(89, 13);
            this.lblSourceDir.TabIndex = 1;
            this.lblSourceDir.Text = "Source Directory:";
            // 
            // tbSourceDir
            // 
            this.tbSourceDir.Location = new System.Drawing.Point(109, 13);
            this.tbSourceDir.Name = "tbSourceDir";
            this.tbSourceDir.Size = new System.Drawing.Size(364, 20);
            this.tbSourceDir.TabIndex = 2;
            this.tbSourceDir.Text = "C:\\DOMAINADMIN\\";
            // 
            // gbxTargetDirectories
            // 
            this.gbxTargetDirectories.Controls.Add(this.tbTargetDirList);
            this.gbxTargetDirectories.Location = new System.Drawing.Point(13, 68);
            this.gbxTargetDirectories.Name = "gbxTargetDirectories";
            this.gbxTargetDirectories.Size = new System.Drawing.Size(460, 116);
            this.gbxTargetDirectories.TabIndex = 3;
            this.gbxTargetDirectories.TabStop = false;
            this.gbxTargetDirectories.Text = "Target Directories:";
            // 
            // tbTargetDirList
            // 
            this.tbTargetDirList.AcceptsReturn = true;
            this.tbTargetDirList.Location = new System.Drawing.Point(6, 19);
            this.tbTargetDirList.Multiline = true;
            this.tbTargetDirList.Name = "tbTargetDirList";
            this.tbTargetDirList.Size = new System.Drawing.Size(448, 91);
            this.tbTargetDirList.TabIndex = 0;
            this.tbTargetDirList.Text = "C:\\DOMAINADMIN_1\\\r\nC:\\DOMAINADMIN_2\\";
            this.tbTargetDirList.WordWrap = false;
            // 
            // lblMemoryDir
            // 
            this.lblMemoryDir.AutoSize = true;
            this.lblMemoryDir.Location = new System.Drawing.Point(14, 41);
            this.lblMemoryDir.Name = "lblMemoryDir";
            this.lblMemoryDir.Size = new System.Drawing.Size(92, 13);
            this.lblMemoryDir.TabIndex = 4;
            this.lblMemoryDir.Text = "Memory Directory:";
            this.lblMemoryDir.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbMemoryDir
            // 
            this.tbMemoryDir.Location = new System.Drawing.Point(109, 39);
            this.tbMemoryDir.Name = "tbMemoryDir";
            this.tbMemoryDir.Size = new System.Drawing.Size(364, 20);
            this.tbMemoryDir.TabIndex = 5;
            this.tbMemoryDir.Text = "C:\\DOMAINADMIN\\";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 225);
            this.Controls.Add(this.tbMemoryDir);
            this.Controls.Add(this.lblMemoryDir);
            this.Controls.Add(this.gbxTargetDirectories);
            this.Controls.Add(this.tbSourceDir);
            this.Controls.Add(this.lblSourceDir);
            this.Controls.Add(this.btnBeginCopy);
            this.Name = "frmMainForm";
            this.Text = "Total Copy V0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.gbxTargetDirectories.ResumeLayout(false);
            this.gbxTargetDirectories.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginCopy;
        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.TextBox tbSourceDir;
        private System.Windows.Forms.GroupBox gbxTargetDirectories;
        private System.Windows.Forms.TextBox tbTargetDirList;
        private System.Windows.Forms.Label lblMemoryDir;
        private System.Windows.Forms.TextBox tbMemoryDir;
    }
}

