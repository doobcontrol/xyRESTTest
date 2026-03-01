namespace xyRESTTest
{
    partial class UcOctetStreamBody
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
            panel1 = new Panel();
            LbFile = new Label();
            panel2 = new Panel();
            BtnBrowseFile = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(LbFile);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.MinimumSize = new Size(150, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 24);
            panel1.TabIndex = 0;
            // 
            // LbFile
            // 
            LbFile.BorderStyle = BorderStyle.FixedSingle;
            LbFile.Dock = DockStyle.Top;
            LbFile.Location = new Point(27, 0);
            LbFile.Name = "LbFile";
            LbFile.Size = new Size(123, 24);
            LbFile.TabIndex = 1;
            LbFile.Text = "label1";
            LbFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(BtnBrowseFile);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(27, 24);
            panel2.TabIndex = 0;
            // 
            // BtnBrowseFile
            // 
            BtnBrowseFile.Location = new Point(0, 0);
            BtnBrowseFile.Name = "BtnBrowseFile";
            BtnBrowseFile.Size = new Size(24, 24);
            BtnBrowseFile.TabIndex = 0;
            BtnBrowseFile.Text = "...";
            BtnBrowseFile.UseVisualStyleBackColor = true;
            BtnBrowseFile.Click += BtnBrowseFile_Click;
            // 
            // UcOctetStreamBody
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            MinimumSize = new Size(150, 24);
            Name = "UcOctetStreamBody";
            Size = new Size(150, 24);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label LbFile;
        private Panel panel2;
        private Button BtnBrowseFile;
    }
}
