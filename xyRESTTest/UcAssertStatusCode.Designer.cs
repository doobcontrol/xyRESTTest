namespace xyRESTTest
{
    partial class UcAssertStatusCode
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
            TxtExpected = new TextBox();
            SuspendLayout();
            // 
            // TxtExpected
            // 
            TxtExpected.Dock = DockStyle.Top;
            TxtExpected.Location = new Point(0, 0);
            TxtExpected.Name = "TxtExpected";
            TxtExpected.PlaceholderText = "Expected status code";
            TxtExpected.Size = new Size(146, 27);
            TxtExpected.TabIndex = 1;
            // 
            // UcAssertStatusCode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(TxtExpected);
            MinimumSize = new Size(148, 27);
            Name = "UcAssertStatusCode";
            Size = new Size(146, 27);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TxtExpected;
    }
}
