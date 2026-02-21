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
            toolStrip1 = new ToolStrip();
            TsbRun = new ToolStripButton();
            panel2 = new Panel();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 24);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(107, 0);
            panel1.Margin = new Padding(3, 0, 3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(43, 24);
            panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbRun });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(43, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbRun
            // 
            TsbRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbRun.Image = Properties.Resources.Run;
            TsbRun.ImageTransparentColor = Color.Magenta;
            TsbRun.Name = "TsbRun";
            TsbRun.Size = new Size(29, 24);
            TsbRun.Text = "Run this test case";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 0, 3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(107, 24);
            panel2.TabIndex = 2;
            // 
            // UcTestCaseItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 0, 3, 0);
            MinimumSize = new Size(100, 24);
            Name = "UcTestCaseItem";
            Size = new Size(150, 24);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbRun;
        private Panel panel2;
    }
}
