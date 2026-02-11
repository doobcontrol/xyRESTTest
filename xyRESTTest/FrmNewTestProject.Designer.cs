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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TxtProjectName = new TextBox();
            TxtProjectFolder = new TextBox();
            BtnBrowser = new Button();
            TxtProjectSaveName = new TextBox();
            BtnOk = new Button();
            BtnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Project Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 1;
            label2.Text = "Project Save Folder:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 77);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 2;
            label3.Text = "Project Save Name:";
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
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmNewTestProject";
            Text = "New Test Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TxtProjectName;
        private TextBox TxtProjectFolder;
        private Button BtnBrowser;
        private TextBox TxtProjectSaveName;
        private Button BtnOk;
        private Button BtnCancel;
    }
}