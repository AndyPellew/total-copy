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
            this.gbxFirstTarget = new System.Windows.Forms.GroupBox();
            this.tbFirstTargetDirList = new System.Windows.Forms.TextBox();
            this.gbxSecondTarget = new System.Windows.Forms.GroupBox();
            this.tbSecondTargetDirList = new System.Windows.Forms.TextBox();
            this.gbxFirstTarget.SuspendLayout();
            this.gbxSecondTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBeginCopy
            // 
            this.btnBeginCopy.Location = new System.Drawing.Point(12, 161);
            this.btnBeginCopy.Name = "btnBeginCopy";
            this.btnBeginCopy.Size = new System.Drawing.Size(107, 23);
            this.btnBeginCopy.TabIndex = 0;
            this.btnBeginCopy.Text = "Start Filecopy";
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
            // gbxFirstTarget
            // 
            this.gbxFirstTarget.Controls.Add(this.tbFirstTargetDirList);
            this.gbxFirstTarget.Location = new System.Drawing.Point(13, 39);
            this.gbxFirstTarget.Name = "gbxFirstTarget";
            this.gbxFirstTarget.Size = new System.Drawing.Size(365, 116);
            this.gbxFirstTarget.TabIndex = 3;
            this.gbxFirstTarget.TabStop = false;
            this.gbxFirstTarget.Text = "Target Directories (Set 1):";
            // 
            // tbFirstTargetDirList
            // 
            this.tbFirstTargetDirList.AcceptsReturn = true;
            this.tbFirstTargetDirList.Location = new System.Drawing.Point(6, 19);
            this.tbFirstTargetDirList.Multiline = true;
            this.tbFirstTargetDirList.Name = "tbFirstTargetDirList";
            this.tbFirstTargetDirList.Size = new System.Drawing.Size(353, 91);
            this.tbFirstTargetDirList.TabIndex = 0;
            this.tbFirstTargetDirList.Text = "C:\\DOMAINADMIN_1\\\r\nC:\\DOMAINADMIN_2\\";
            this.tbFirstTargetDirList.WordWrap = false;
            // 
            // gbxSecondTarget
            // 
            this.gbxSecondTarget.Controls.Add(this.tbSecondTargetDirList);
            this.gbxSecondTarget.Location = new System.Drawing.Point(384, 39);
            this.gbxSecondTarget.Name = "gbxSecondTarget";
            this.gbxSecondTarget.Size = new System.Drawing.Size(365, 116);
            this.gbxSecondTarget.TabIndex = 6;
            this.gbxSecondTarget.TabStop = false;
            this.gbxSecondTarget.Text = "Target Directories (Set 2):";
            // 
            // tbSecondTargetDirList
            // 
            this.tbSecondTargetDirList.AcceptsReturn = true;
            this.tbSecondTargetDirList.Location = new System.Drawing.Point(6, 19);
            this.tbSecondTargetDirList.Multiline = true;
            this.tbSecondTargetDirList.Name = "tbSecondTargetDirList";
            this.tbSecondTargetDirList.Size = new System.Drawing.Size(353, 91);
            this.tbSecondTargetDirList.TabIndex = 0;
            this.tbSecondTargetDirList.Text = "C:\\DOMAINADMIN_1\\\r\nC:\\DOMAINADMIN_2\\";
            this.tbSecondTargetDirList.WordWrap = false;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 192);
            this.Controls.Add(this.gbxSecondTarget);
            this.Controls.Add(this.gbxFirstTarget);
            this.Controls.Add(this.tbSourceDir);
            this.Controls.Add(this.lblSourceDir);
            this.Controls.Add(this.btnBeginCopy);
            this.Name = "frmMainForm";
            this.Text = "Total Copy V0.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.gbxFirstTarget.ResumeLayout(false);
            this.gbxFirstTarget.PerformLayout();
            this.gbxSecondTarget.ResumeLayout(false);
            this.gbxSecondTarget.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginCopy;
        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.TextBox tbSourceDir;
        private System.Windows.Forms.GroupBox gbxFirstTarget;
        private System.Windows.Forms.TextBox tbFirstTargetDirList;
        private System.Windows.Forms.GroupBox gbxSecondTarget;
        private System.Windows.Forms.TextBox tbSecondTargetDirList;
    }
}

