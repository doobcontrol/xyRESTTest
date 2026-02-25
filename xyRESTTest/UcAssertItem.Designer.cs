namespace xyRESTTest
{
    partial class UcAssertItem
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
            lbInfo = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(lbInfo);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(132, 18);
            panel1.TabIndex = 2;
            // 
            // lbInfo
            // 
            lbInfo.Dock = DockStyle.Top;
            lbInfo.Location = new Point(0, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(112, 18);
            lbInfo.TabIndex = 0;
            lbInfo.Text = "label1";
            lbInfo.TextAlign = ContentAlignment.MiddleLeft;
            lbInfo.Click += lbInfo_Click;
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.drop_down;
            panel2.BackgroundImageLayout = ImageLayout.Center;
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(112, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(20, 18);
            panel2.TabIndex = 1;
            // 
            // UcAssertItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(132, 18);
            Name = "UcAssertItem";
            Size = new Size(132, 18);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbInfo;
        private Panel panel2;
    }
}
