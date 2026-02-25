namespace xyRESTTest
{
    partial class UcTestCaseItem
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
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 18);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Run;
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(111, 0);
            panel1.Margin = new Padding(3, 0, 3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(20, 18);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 0, 3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(111, 18);
            panel2.TabIndex = 2;
            // 
            // UcTestCaseItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 0, 3, 0);
            MinimumSize = new Size(88, 18);
            Name = "UcTestCaseItem";
            Size = new Size(131, 18);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
    }
}
