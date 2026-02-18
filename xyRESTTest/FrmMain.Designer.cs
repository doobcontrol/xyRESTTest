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
            toolStripSeparator2 = new ToolStripSeparator();
            TsbRun = new ToolStripButton();
            panel2 = new Panel();
            toolStrip2 = new ToolStrip();
            PnlWork = new Panel();
            PnlRun = new Panel();
            lbRunningInfo = new Label();
            panel3 = new Panel();
            btnHideRunWindow = new Button();
            splitter1 = new Splitter();
            panel1.SuspendLayout();
            PnPrj.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            PnlWork.SuspendLayout();
            PnlRun.SuspendLayout();
            panel3.SuspendLayout();
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
            panel1.Size = new Size(226, 367);
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
            PnTestcases.Size = new Size(224, 295);
            PnTestcases.TabIndex = 2;
            // 
            // PnPrj
            // 
            PnPrj.Controls.Add(LbPrjName);
            PnPrj.Dock = DockStyle.Top;
            PnPrj.Location = new Point(0, 27);
            PnPrj.Name = "PnPrj";
            PnPrj.Padding = new Padding(0, 3, 0, 0);
            PnPrj.Size = new Size(224, 43);
            PnPrj.TabIndex = 1;
            // 
            // LbPrjName
            // 
            LbPrjName.Dock = DockStyle.Top;
            LbPrjName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbPrjName.Location = new Point(0, 3);
            LbPrjName.Name = "LbPrjName";
            LbPrjName.Size = new Size(224, 28);
            LbPrjName.TabIndex = 0;
            LbPrjName.Text = "New Test";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbNewProject, TsbOpenProject, toolStripSeparator1, TsbAddCase, TsbDelCase, toolStripSeparator2, TsbRun });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(224, 27);
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
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(toolStrip2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(226, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(574, 367);
            panel2.TabIndex = 3;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(572, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // PnlWork
            // 
            PnlWork.Controls.Add(panel2);
            PnlWork.Controls.Add(panel1);
            PnlWork.Dock = DockStyle.Fill;
            PnlWork.Location = new Point(0, 0);
            PnlWork.Name = "PnlWork";
            PnlWork.Size = new Size(800, 367);
            PnlWork.TabIndex = 4;
            // 
            // PnlRun
            // 
            PnlRun.Controls.Add(lbRunningInfo);
            PnlRun.Controls.Add(panel3);
            PnlRun.Dock = DockStyle.Bottom;
            PnlRun.Location = new Point(0, 371);
            PnlRun.Name = "PnlRun";
            PnlRun.Size = new Size(800, 79);
            PnlRun.TabIndex = 5;
            // 
            // lbRunningInfo
            // 
            lbRunningInfo.Dock = DockStyle.Fill;
            lbRunningInfo.Location = new Point(0, 20);
            lbRunningInfo.Name = "lbRunningInfo";
            lbRunningInfo.Size = new Size(800, 59);
            lbRunningInfo.TabIndex = 0;
            lbRunningInfo.Text = "Running test ...";
            lbRunningInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnHideRunWindow);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 20);
            panel3.TabIndex = 1;
            // 
            // btnHideRunWindow
            // 
            btnHideRunWindow.Dock = DockStyle.Right;
            btnHideRunWindow.Image = Properties.Resources.Close;
            btnHideRunWindow.Location = new Point(778, 0);
            btnHideRunWindow.Name = "btnHideRunWindow";
            btnHideRunWindow.Size = new Size(20, 18);
            btnHideRunWindow.TabIndex = 0;
            btnHideRunWindow.UseVisualStyleBackColor = true;
            btnHideRunWindow.Click += btnHideRunWindow_Click;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Bottom;
            splitter1.Location = new Point(0, 367);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(800, 4);
            splitter1.TabIndex = 6;
            splitter1.TabStop = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PnlWork);
            Controls.Add(splitter1);
            Controls.Add(PnlRun);
            Name = "FrmMain";
            Text = "FrmMain";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PnPrj.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            PnlWork.ResumeLayout(false);
            PnlRun.ResumeLayout(false);
            panel3.ResumeLayout(false);
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
        private Panel PnlWork;
        private Panel PnlRun;
        private Splitter splitter1;
        private Label lbRunningInfo;
        private Panel panel3;
        private Button btnHideRunWindow;
    }
}