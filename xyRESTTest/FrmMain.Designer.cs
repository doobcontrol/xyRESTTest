namespace xyRESTTest
{
    partial class FrmMain
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
            panel1 = new Panel();
            PnTestcases = new TableLayoutPanel();
            PnPrj = new Panel();
            LbPrjName = new Label();
            toolStrip1 = new ToolStrip();
            TsbNewProject = new ToolStripButton();
            TsbOpenProject = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            TsbAddCase = new ToolStripButton();
            TsbDelCase = new ToolStripButton();
            panel2 = new Panel();
            toolStrip2 = new ToolStrip();
            toolStripSeparator2 = new ToolStripSeparator();
            TsbRun = new ToolStripButton();
            panel1.SuspendLayout();
            PnPrj.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(PnTestcases);
            panel1.Controls.Add(PnPrj);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 2;
            // 
            // PnTestcases
            // 
            PnTestcases.AutoScroll = true;
            PnTestcases.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnTestcases.ColumnCount = 1;
            PnTestcases.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            PnTestcases.Dock = DockStyle.Fill;
            PnTestcases.Location = new Point(0, 70);
            PnTestcases.Name = "PnTestcases";
            PnTestcases.RowCount = 1;
            PnTestcases.RowStyles.Add(new RowStyle());
            PnTestcases.Size = new Size(248, 378);
            PnTestcases.TabIndex = 2;
            // 
            // PnPrj
            // 
            PnPrj.Controls.Add(LbPrjName);
            PnPrj.Dock = DockStyle.Top;
            PnPrj.Location = new Point(0, 27);
            PnPrj.Name = "PnPrj";
            PnPrj.Padding = new Padding(0, 3, 0, 0);
            PnPrj.Size = new Size(248, 43);
            PnPrj.TabIndex = 1;
            // 
            // LbPrjName
            // 
            LbPrjName.Dock = DockStyle.Top;
            LbPrjName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbPrjName.Location = new Point(0, 3);
            LbPrjName.Name = "LbPrjName";
            LbPrjName.Size = new Size(248, 28);
            LbPrjName.TabIndex = 0;
            LbPrjName.Text = "New Test";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbNewProject, TsbOpenProject, toolStripSeparator1, TsbAddCase, TsbDelCase, toolStripSeparator2, TsbRun });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(248, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbNewProject
            // 
            TsbNewProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbNewProject.Image = Properties.Resources.New;
            TsbNewProject.ImageTransparentColor = Color.Magenta;
            TsbNewProject.Name = "TsbNewProject";
            TsbNewProject.Size = new Size(29, 24);
            TsbNewProject.Text = "New test";
            TsbNewProject.Click += TsbNewProject_Click;
            // 
            // TsbOpenProject
            // 
            TsbOpenProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbOpenProject.Image = Properties.Resources.Open;
            TsbOpenProject.ImageTransparentColor = Color.Magenta;
            TsbOpenProject.Name = "TsbOpenProject";
            TsbOpenProject.Size = new Size(29, 24);
            TsbOpenProject.Text = "Open a test";
            TsbOpenProject.Click += TsbOpenProject_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // TsbAddCase
            // 
            TsbAddCase.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddCase.Image = Properties.Resources.Add;
            TsbAddCase.ImageTransparentColor = Color.Magenta;
            TsbAddCase.Name = "TsbAddCase";
            TsbAddCase.Size = new Size(29, 24);
            TsbAddCase.Text = "Add a test case";
            TsbAddCase.Click += TsbAddCase_Click;
            // 
            // TsbDelCase
            // 
            TsbDelCase.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelCase.Image = Properties.Resources.Delete;
            TsbDelCase.ImageTransparentColor = Color.Magenta;
            TsbDelCase.Name = "TsbDelCase";
            TsbDelCase.Size = new Size(29, 24);
            TsbDelCase.Text = "Delete selected test case";
            TsbDelCase.Click += TsbDelCase_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(toolStrip2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 450);
            panel2.TabIndex = 3;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(548, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // TsbRun
            // 
            TsbRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbRun.Image = Properties.Resources.Run;
            TsbRun.ImageTransparentColor = Color.Magenta;
            TsbRun.Name = "TsbRun";
            TsbRun.Size = new Size(29, 24);
            TsbRun.Text = "toolStripButton1";
            TsbRun.Click += TsbRun_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmMain";
            Text = "FrmMain";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PnPrj.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbNewProject;
        private Panel panel2;
        private ToolStrip toolStrip2;
        private ToolStripButton TsbOpenProject;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton TsbAddCase;
        private ToolStripButton TsbDelCase;
        private Panel PnPrj;
        private Label LbPrjName;
        private TableLayoutPanel PnTestcases;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton TsbRun;
    }
}