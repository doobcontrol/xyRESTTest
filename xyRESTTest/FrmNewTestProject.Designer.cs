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
            SuspendLayout();
            // 
            // LbProjectName
            // 
            LbProjectName.AutoSize = true;
            LbProjectName.Location = new Point(12, 9);
            LbProjectName.Name = "LbProjectName";
            LbProjectName.Size = new Size(102, 20);
            LbProjectName.TabIndex = 0;
            LbProjectName.Text = "Project Name:";
            // 
            // LbProjectSaveFolder
            // 
            LbProjectSaveFolder.AutoSize = true;
            LbProjectSaveFolder.Location = new Point(12, 44);
            LbProjectSaveFolder.Name = "LbProjectSaveFolder";
            LbProjectSaveFolder.Size = new Size(139, 20);
            LbProjectSaveFolder.TabIndex = 1;
            LbProjectSaveFolder.Text = "Project Save Folder:";
            // 
            // LbProjectSaveName
            // 
            LbProjectSaveName.AutoSize = true;
            LbProjectSaveName.Location = new Point(12, 77);
            LbProjectSaveName.Name = "LbProjectSaveName";
            LbProjectSaveName.Size = new Size(137, 20);
            LbProjectSaveName.TabIndex = 2;
            LbProjectSaveName.Text = "Project Save Name:";
            // 
            // TxtProjectName
            // 
            TxtProjectName.Location = new Point(168, 6);
            TxtProjectName.Name = "TxtProjectName";
            TxtProjectName.Size = new Size(415, 27);
            TxtProjectName.TabIndex = 3;
            // 
            // TxtProjectFolder
            // 
            TxtProjectFolder.Location = new Point(168, 40);
            TxtProjectFolder.Name = "TxtProjectFolder";
            TxtProjectFolder.Size = new Size(415, 27);
            TxtProjectFolder.TabIndex = 4;
            // 
            // BtnBrowser
            // 
            BtnBrowser.Location = new Point(589, 40);
            BtnBrowser.Name = "BtnBrowser";
            BtnBrowser.Size = new Size(29, 29);
            BtnBrowser.TabIndex = 5;
            BtnBrowser.Text = "...";
            BtnBrowser.UseVisualStyleBackColor = true;
            BtnBrowser.Click += BtnBrowser_Click;
            // 
            // TxtProjectSaveName
            // 
            TxtProjectSaveName.Location = new Point(168, 74);
            TxtProjectSaveName.Name = "TxtProjectSaveName";
            TxtProjectSaveName.ReadOnly = true;
            TxtProjectSaveName.Size = new Size(415, 27);
            TxtProjectSaveName.TabIndex = 6;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(448, 146);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(94, 29);
            BtnOk.TabIndex = 7;
            BtnOk.Text = "Create";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(348, 146);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(94, 29);
            BtnCancel.TabIndex = 8;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // FrmNewTestProject
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 190);
            ControlBox = false;
            Controls.Add(BtnCancel);
            Controls.Add(BtnOk);
            Controls.Add(TxtProjectSaveName);
            Controls.Add(BtnBrowser);
            Controls.Add(TxtProjectFolder);
            Controls.Add(TxtProjectName);
            Controls.Add(LbProjectSaveName);
            Controls.Add(LbProjectSaveFolder);
            Controls.Add(LbProjectName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmNewTestProject";
            ShowInTaskbar = false;
            Text = "New Test Project";
            ResumeLayout(false);
            PerformLayout();
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
    }
}