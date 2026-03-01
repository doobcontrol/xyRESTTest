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
            SuspendLayout();
            // 
            // CbContentType
            // 
            CbContentType.Dock = DockStyle.Top;
            CbContentType.FormattingEnabled = true;
            CbContentType.Location = new Point(0, 0);
            CbContentType.Name = "CbContentType";
            CbContentType.Size = new Size(150, 23);
            CbContentType.TabIndex = 0;
            // 
            // UcAssertContentType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(CbContentType);
            MinimumSize = new Size(150, 23);
            Name = "UcAssertContentType";
            Size = new Size(150, 23);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CbContentType;
    }
}
