namespace xyRESTTest
{
    partial class FrmNewTestProject
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
            LbProjectName = new Label();
            LbProjectSaveFolder = new Label();
            LbProjectSaveName = new Label();
            TxtProjectName = new TextBox();
            TxtProjectFolder = new TextBox();
            BtnBrowser = new Button();
            TxtProjectSaveName = new TextBox();
            BtnOk = new Button();
            BtnCancel = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // LbProjectName
            // 
            LbProjectName.AutoSize = true;
            LbProjectName.Location = new Point(13, 14);
            LbProjectName.Name = "LbProjectName";
            LbProjectName.Size = new Size(82, 15);
            LbProjectName.TabIndex = 0;
            LbProjectName.Text = "Project Name:";
            // 
            // LbProjectSaveFolder
            // 
            LbProjectSaveFolder.AutoSize = true;
            LbProjectSaveFolder.Location = new Point(13, 40);
            LbProjectSaveFolder.Name = "LbProjectSaveFolder";
            LbProjectSaveFolder.Size = new Size(110, 15);
            LbProjectSaveFolder.TabIndex = 1;
            LbProjectSaveFolder.Text = "Project Save Folder:";
            // 
            // LbProjectSaveName
            // 
            LbProjectSaveName.AutoSize = true;
            LbProjectSaveName.Location = new Point(13, 65);
            LbProjectSaveName.Name = "LbProjectSaveName";
            LbProjectSaveName.Size = new Size(109, 15);
            LbProjectSaveName.TabIndex = 2;
            LbProjectSaveName.Text = "Project Save Name:";
            // 
            // TxtProjectName
            // 
            TxtProjectName.Location = new Point(150, 11);
            TxtProjectName.Margin = new Padding(3, 2, 3, 2);
            TxtProjectName.Name = "TxtProjectName";
            TxtProjectName.Size = new Size(364, 23);
            TxtProjectName.TabIndex = 3;
            // 
            // TxtProjectFolder
            // 
            TxtProjectFolder.Location = new Point(150, 37);
            TxtProjectFolder.Margin = new Padding(3, 2, 3, 2);
            TxtProjectFolder.Name = "TxtProjectFolder";
            TxtProjectFolder.Size = new Size(364, 23);
            TxtProjectFolder.TabIndex = 4;
            // 
            // BtnBrowser
            // 
            BtnBrowser.Location = new Point(518, 37);
            BtnBrowser.Margin = new Padding(3, 2, 3, 2);
            BtnBrowser.Name = "BtnBrowser";
            BtnBrowser.Size = new Size(25, 22);
            BtnBrowser.TabIndex = 5;
            BtnBrowser.Text = "...";
            BtnBrowser.UseVisualStyleBackColor = true;
            BtnBrowser.Click += BtnBrowser_Click;
            // 
            // TxtProjectSaveName
            // 
            TxtProjectSaveName.Location = new Point(150, 63);
            TxtProjectSaveName.Margin = new Padding(3, 2, 3, 2);
            TxtProjectSaveName.Name = "TxtProjectSaveName";
            TxtProjectSaveName.ReadOnly = true;
            TxtProjectSaveName.Size = new Size(364, 23);
            TxtProjectSaveName.TabIndex = 6;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(99, 11);
            BtnOk.Margin = new Padding(3, 2, 3, 2);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(82, 22);
            BtnOk.TabIndex = 7;
            BtnOk.Text = "Create";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(11, 11);
            BtnCancel.Margin = new Padding(3, 2, 3, 2);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(82, 22);
            BtnCancel.TabIndex = 8;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(574, 42);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnOk);
            panel2.Controls.Add(BtnCancel);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(358, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(216, 42);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(LbProjectName);
            panel3.Controls.Add(LbProjectSaveFolder);
            panel3.Controls.Add(TxtProjectSaveName);
            panel3.Controls.Add(LbProjectSaveName);
            panel3.Controls.Add(BtnBrowser);
            panel3.Controls.Add(TxtProjectName);
            panel3.Controls.Add(TxtProjectFolder);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(574, 131);
            panel3.TabIndex = 10;
            // 
            // FrmNewTestProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(574, 173);
            ControlBox = false;
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimumSize = new Size(576, 175);
            Name = "FrmNewTestProject";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Test Project";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label LbProjectName;
        private Label LbProjectSaveFolder;
        private Label LbProjectSaveName;
        private TextBox TxtProjectName;
        private TextBox TxtProjectFolder;
        private Button BtnBrowser;
        private TextBox TxtProjectSaveName;
        private Button BtnOk;
        private Button BtnCancel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}