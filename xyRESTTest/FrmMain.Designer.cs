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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            PnTestcases = new TableLayoutPanel();
            PnPrj = new Panel();
            TxtPrjName = new TextBox();
            LbPrjName = new Label();
            PnlTestCase = new Panel();
            PnlWork = new Panel();
            PnlRun = new Panel();
            lbRunningInfo = new Label();
            panel3 = new Panel();
            btnHideRunWindow = new Button();
            splitter1 = new Splitter();
            toolStrip1 = new ToolStrip();
            TsbNewProject = new ToolStripButton();
            TsbOpenProject = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            TsbAddCase = new ToolStripButton();
            TsbDelCase = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            TsbRun = new ToolStripButton();
            TscbLang = new ToolStripComboBox();
            TsbMoveUp = new ToolStripButton();
            TsbMoveDown = new ToolStripButton();
            panel1.SuspendLayout();
            PnPrj.SuspendLayout();
            PnlWork.SuspendLayout();
            PnlRun.SuspendLayout();
            panel3.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(PnTestcases);
            panel1.Controls.Add(PnPrj);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 361);
            panel1.TabIndex = 2;
            // 
            // PnTestcases
            // 
            PnTestcases.AutoScroll = true;
            PnTestcases.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnTestcases.ColumnCount = 1;
            PnTestcases.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            PnTestcases.Dock = DockStyle.Fill;
            PnTestcases.Location = new Point(0, 47);
            PnTestcases.Margin = new Padding(3, 2, 3, 2);
            PnTestcases.Name = "PnTestcases";
            PnTestcases.RowCount = 1;
            PnTestcases.RowStyles.Add(new RowStyle());
            PnTestcases.Size = new Size(196, 312);
            PnTestcases.TabIndex = 2;
            // 
            // PnPrj
            // 
            PnPrj.AutoSize = true;
            PnPrj.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnPrj.BorderStyle = BorderStyle.FixedSingle;
            PnPrj.Controls.Add(TxtPrjName);
            PnPrj.Controls.Add(LbPrjName);
            PnPrj.Dock = DockStyle.Top;
            PnPrj.Location = new Point(0, 0);
            PnPrj.Margin = new Padding(3, 2, 3, 2);
            PnPrj.MinimumSize = new Size(2, 21);
            PnPrj.Name = "PnPrj";
            PnPrj.Padding = new Padding(0, 2, 0, 0);
            PnPrj.Size = new Size(196, 47);
            PnPrj.TabIndex = 1;
            // 
            // TxtPrjName
            // 
            TxtPrjName.Dock = DockStyle.Top;
            TxtPrjName.Location = new Point(0, 22);
            TxtPrjName.Margin = new Padding(3, 2, 3, 2);
            TxtPrjName.Name = "TxtPrjName";
            TxtPrjName.Size = new Size(194, 23);
            TxtPrjName.TabIndex = 1;
            TxtPrjName.Visible = false;
            // 
            // LbPrjName
            // 
            LbPrjName.Dock = DockStyle.Top;
            LbPrjName.Font = new Font("Segoe UI", 9F);
            LbPrjName.Location = new Point(0, 2);
            LbPrjName.Name = "LbPrjName";
            LbPrjName.Size = new Size(194, 20);
            LbPrjName.TabIndex = 0;
            LbPrjName.Text = "New Test";
            // 
            // PnlTestCase
            // 
            PnlTestCase.BorderStyle = BorderStyle.FixedSingle;
            PnlTestCase.Dock = DockStyle.Fill;
            PnlTestCase.Location = new Point(198, 0);
            PnlTestCase.Margin = new Padding(3, 2, 3, 2);
            PnlTestCase.Name = "PnlTestCase";
            PnlTestCase.Size = new Size(602, 361);
            PnlTestCase.TabIndex = 3;
            // 
            // PnlWork
            // 
            PnlWork.Controls.Add(PnlTestCase);
            PnlWork.Controls.Add(panel1);
            PnlWork.Dock = DockStyle.Fill;
            PnlWork.Location = new Point(0, 27);
            PnlWork.Margin = new Padding(3, 2, 3, 2);
            PnlWork.Name = "PnlWork";
            PnlWork.Size = new Size(800, 361);
            PnlWork.TabIndex = 4;
            // 
            // PnlRun
            // 
            PnlRun.Controls.Add(lbRunningInfo);
            PnlRun.Controls.Add(panel3);
            PnlRun.Dock = DockStyle.Bottom;
            PnlRun.Location = new Point(0, 391);
            PnlRun.Margin = new Padding(3, 2, 3, 2);
            PnlRun.Name = "PnlRun";
            PnlRun.Size = new Size(800, 59);
            PnlRun.TabIndex = 5;
            // 
            // lbRunningInfo
            // 
            lbRunningInfo.Dock = DockStyle.Fill;
            lbRunningInfo.Location = new Point(0, 16);
            lbRunningInfo.Name = "lbRunningInfo";
            lbRunningInfo.Size = new Size(800, 43);
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
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 16);
            panel3.TabIndex = 1;
            // 
            // btnHideRunWindow
            // 
            btnHideRunWindow.Dock = DockStyle.Right;
            btnHideRunWindow.Image = Properties.Resources.Close;
            btnHideRunWindow.Location = new Point(780, 0);
            btnHideRunWindow.Margin = new Padding(3, 2, 3, 2);
            btnHideRunWindow.Name = "btnHideRunWindow";
            btnHideRunWindow.Size = new Size(18, 14);
            btnHideRunWindow.TabIndex = 0;
            btnHideRunWindow.UseVisualStyleBackColor = true;
            btnHideRunWindow.Click += btnHideRunWindow_Click;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Bottom;
            splitter1.Location = new Point(0, 388);
            splitter1.Margin = new Padding(3, 2, 3, 2);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(800, 3);
            splitter1.TabIndex = 6;
            splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbNewProject, TsbOpenProject, toolStripSeparator1, TsbAddCase, TsbDelCase, TsbMoveUp, TsbMoveDown, toolStripSeparator2, TsbRun, TscbLang });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbNewProject
            // 
            TsbNewProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbNewProject.Image = Properties.Resources.New;
            TsbNewProject.ImageTransparentColor = Color.Magenta;
            TsbNewProject.Name = "TsbNewProject";
            TsbNewProject.Size = new Size(24, 24);
            TsbNewProject.Text = "New test";
            TsbNewProject.Click += TsbNewProject_Click;
            // 
            // TsbOpenProject
            // 
            TsbOpenProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbOpenProject.Image = Properties.Resources.Open;
            TsbOpenProject.ImageTransparentColor = Color.Magenta;
            TsbOpenProject.Name = "TsbOpenProject";
            TsbOpenProject.Size = new Size(24, 24);
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
            TsbAddCase.Size = new Size(24, 24);
            TsbAddCase.Text = "Add a test case";
            TsbAddCase.Click += TsbAddCase_Click;
            // 
            // TsbDelCase
            // 
            TsbDelCase.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelCase.Image = Properties.Resources.Delete;
            TsbDelCase.ImageTransparentColor = Color.Magenta;
            TsbDelCase.Name = "TsbDelCase";
            TsbDelCase.Size = new Size(24, 24);
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
            TsbRun.Size = new Size(24, 24);
            TsbRun.Text = "toolStripButton1";
            TsbRun.Click += TsbRun_Click;
            // 
            // TscbLang
            // 
            TscbLang.Alignment = ToolStripItemAlignment.Right;
            TscbLang.DropDownStyle = ComboBoxStyle.DropDownList;
            TscbLang.Name = "TscbLang";
            TscbLang.Size = new Size(106, 27);
            TscbLang.SelectedIndexChanged += TscbLang_SelectedIndexChanged;
            // 
            // TsbMoveUp
            // 
            TsbMoveUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbMoveUp.Image = Properties.Resources.Upload;
            TsbMoveUp.ImageTransparentColor = Color.Magenta;
            TsbMoveUp.Name = "TsbMoveUp";
            TsbMoveUp.Size = new Size(24, 24);
            TsbMoveUp.Text = "toolStripButton1";
            TsbMoveUp.Click += TsbMoveUp_Click;
            // 
            // TsbMoveDown
            // 
            TsbMoveDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbMoveDown.Image = Properties.Resources.Download;
            TsbMoveDown.ImageTransparentColor = Color.Magenta;
            TsbMoveDown.Name = "TsbMoveDown";
            TsbMoveDown.Size = new Size(24, 24);
            TsbMoveDown.Text = "toolStripButton2";
            TsbMoveDown.Click += TsbMoveDown_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PnlWork);
            Controls.Add(toolStrip1);
            Controls.Add(splitter1);
            Controls.Add(PnlRun);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            Text = "FrmMain";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PnPrj.ResumeLayout(false);
            PnPrj.PerformLayout();
            PnlWork.ResumeLayout(false);
            PnlRun.ResumeLayout(false);
            panel3.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel PnlTestCase;
        private Panel PnPrj;
        private Label LbPrjName;
        private TableLayoutPanel PnTestcases;
        private Panel PnlWork;
        private Panel PnlRun;
        private Splitter splitter1;
        private Label lbRunningInfo;
        private Panel panel3;
        private Button btnHideRunWindow;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbNewProject;
        private ToolStripButton TsbOpenProject;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton TsbAddCase;
        private ToolStripButton TsbDelCase;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton TsbRun;
        private ToolStripComboBox TscbLang;
        private TextBox TxtPrjName;
        private ToolStripButton TsbMoveUp;
        private ToolStripButton TsbMoveDown;
    }
}