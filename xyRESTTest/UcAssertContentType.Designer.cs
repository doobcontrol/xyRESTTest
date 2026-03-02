namespace xyRESTTest
{
    partial class UcAssertContentType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CbContentType = new ComboBox();
            panel1 = new Panel();
            PnlFile = new Panel();
            LbFile = new Label();
            BtnBrowseFile = new Button();
            panel2 = new Panel();
            cbSaveFile = new CheckBox();
            panel1.SuspendLayout();
            PnlFile.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // CbContentType
            // 
            CbContentType.Dock = DockStyle.Top;
            CbContentType.FormattingEnabled = true;
            CbContentType.Location = new Point(0, 0);
            CbContentType.Name = "CbContentType";
            CbContentType.Size = new Size(159, 23);
            CbContentType.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(PnlFile);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 23);
            panel1.MinimumSize = new Size(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(156, 24);
            panel1.TabIndex = 1;
            // 
            // PnlFile
            // 
            PnlFile.AutoSize = true;
            PnlFile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlFile.Controls.Add(LbFile);
            PnlFile.Controls.Add(BtnBrowseFile);
            PnlFile.Dock = DockStyle.Left;
            PnlFile.Location = new Point(85, 0);
            PnlFile.Name = "PnlFile";
            PnlFile.Size = new Size(71, 24);
            PnlFile.TabIndex = 1;
            // 
            // LbFile
            // 
            LbFile.AutoSize = true;
            LbFile.Location = new Point(30, 5);
            LbFile.Name = "LbFile";
            LbFile.Size = new Size(38, 15);
            LbFile.TabIndex = 0;
            LbFile.Text = "label1";
            // 
            // BtnBrowseFile
            // 
            BtnBrowseFile.Dock = DockStyle.Left;
            BtnBrowseFile.Location = new Point(0, 0);
            BtnBrowseFile.Name = "BtnBrowseFile";
            BtnBrowseFile.Size = new Size(24, 24);
            BtnBrowseFile.TabIndex = 0;
            BtnBrowseFile.Text = "...";
            BtnBrowseFile.UseVisualStyleBackColor = true;
            BtnBrowseFile.Click += BtnBrowseFile_Click;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(cbSaveFile);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(85, 24);
            panel2.TabIndex = 0;
            // 
            // cbSaveFile
            // 
            cbSaveFile.AutoSize = true;
            cbSaveFile.Dock = DockStyle.Left;
            cbSaveFile.Location = new Point(0, 0);
            cbSaveFile.Name = "cbSaveFile";
            cbSaveFile.Padding = new Padding(3, 0, 0, 0);
            cbSaveFile.Size = new Size(85, 24);
            cbSaveFile.TabIndex = 0;
            cbSaveFile.Text = "checkBox1";
            cbSaveFile.UseVisualStyleBackColor = true;
            cbSaveFile.CheckedChanged += cbSaveFile_CheckedChanged;
            // 
            // UcAssertContentType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            Controls.Add(CbContentType);
            MinimumSize = new Size(150, 47);
            Name = "UcAssertContentType";
            Size = new Size(159, 50);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PnlFile.ResumeLayout(false);
            PnlFile.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CbContentType;
        private Panel panel1;
        private Panel panel2;
        private CheckBox cbSaveFile;
        private Panel PnlFile;
        private Button BtnBrowseFile;
        private Label LbFile;
    }
}
