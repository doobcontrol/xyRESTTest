namespace xyRESTTest
{
    partial class UcTestCase
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
            components = new System.ComponentModel.Container();
            LbCaseName = new Label();
            TxtCaseName = new TextBox();
            TxtUrl = new TextBox();
            label3 = new Label();
            tabControl1 = new TabControl();
            tabRequest = new TabPage();
            splitter1 = new Splitter();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            TlpHeaders = new TableLayoutPanel();
            toolStrip1 = new ToolStrip();
            TsbAddHeader = new ToolStripButton();
            panel2 = new Panel();
            CmbMothod = new ComboBox();
            label4 = new Label();
            tabAssert = new TabPage();
            panel1 = new Panel();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabRequest.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LbCaseName
            // 
            LbCaseName.Dock = DockStyle.Top;
            LbCaseName.Location = new Point(0, 27);
            LbCaseName.Name = "LbCaseName";
            LbCaseName.Size = new Size(694, 34);
            LbCaseName.TabIndex = 0;
            LbCaseName.Text = "label1";
            LbCaseName.TextAlign = ContentAlignment.MiddleCenter;
            LbCaseName.DoubleClick += LbCaseName_DoubleClick;
            // 
            // TxtCaseName
            // 
            TxtCaseName.Dock = DockStyle.Top;
            TxtCaseName.Location = new Point(0, 0);
            TxtCaseName.Name = "TxtCaseName";
            TxtCaseName.Size = new Size(694, 27);
            TxtCaseName.TabIndex = 2;
            TxtCaseName.TextAlign = HorizontalAlignment.Center;
            TxtCaseName.Visible = false;
            TxtCaseName.KeyDown += TxtCaseName_KeyDown;
            TxtCaseName.Leave += TxtCaseName_Leave;
            // 
            // TxtUrl
            // 
            TxtUrl.Location = new Point(133, 15);
            TxtUrl.Name = "TxtUrl";
            TxtUrl.Size = new Size(534, 27);
            TxtUrl.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 18);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 3;
            label3.Text = "Url:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabRequest);
            tabControl1.Controls.Add(tabAssert);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 61);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(694, 344);
            tabControl1.TabIndex = 5;
            // 
            // tabRequest
            // 
            tabRequest.Controls.Add(splitter1);
            tabRequest.Controls.Add(groupBox2);
            tabRequest.Controls.Add(groupBox1);
            tabRequest.Controls.Add(panel2);
            tabRequest.Location = new Point(4, 29);
            tabRequest.Name = "tabRequest";
            tabRequest.Padding = new Padding(3);
            tabRequest.Size = new Size(686, 311);
            tabRequest.TabIndex = 0;
            tabRequest.Text = "Request Information";
            tabRequest.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new Point(3, 204);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(680, 4);
            splitter1.TabIndex = 10;
            splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 204);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(680, 104);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Body";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TlpHeaders);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(680, 111);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Headers";
            // 
            // TlpHeaders
            // 
            TlpHeaders.ColumnCount = 1;
            TlpHeaders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpHeaders.Dock = DockStyle.Top;
            TlpHeaders.Location = new Point(3, 50);
            TlpHeaders.Name = "TlpHeaders";
            TlpHeaders.RowCount = 1;
            TlpHeaders.RowStyles.Add(new RowStyle());
            TlpHeaders.Size = new Size(674, 32);
            TlpHeaders.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbAddHeader });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(674, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbAddHeader
            // 
            TsbAddHeader.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddHeader.Image = Properties.Resources.Add;
            TsbAddHeader.ImageTransparentColor = Color.Magenta;
            TsbAddHeader.Name = "TsbAddHeader";
            TsbAddHeader.Size = new Size(29, 24);
            TsbAddHeader.Text = "toolStripButton1";
            TsbAddHeader.Click += TsbAddHeader_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(CmbMothod);
            panel2.Controls.Add(TxtUrl);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 90);
            panel2.TabIndex = 7;
            // 
            // CmbMothod
            // 
            CmbMothod.FormattingEnabled = true;
            CmbMothod.Items.AddRange(new object[] { "GET", "POST", "PUT", "DELETE" });
            CmbMothod.Location = new Point(133, 48);
            CmbMothod.Name = "CmbMothod";
            CmbMothod.Size = new Size(151, 28);
            CmbMothod.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 51);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 5;
            label4.Text = "Method:";
            // 
            // tabAssert
            // 
            tabAssert.Location = new Point(4, 29);
            tabAssert.Name = "tabAssert";
            tabAssert.Padding = new Padding(3);
            tabAssert.Size = new Size(686, 311);
            tabAssert.TabIndex = 1;
            tabAssert.Text = "Assertion Information";
            tabAssert.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(LbCaseName);
            panel1.Controls.Add(TxtCaseName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(694, 61);
            panel1.TabIndex = 6;
            // 
            // UcTestCase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "UcTestCase";
            Size = new Size(694, 405);
            tabControl1.ResumeLayout(false);
            tabRequest.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbCaseName;
        private TextBox TxtCaseName;
        private TextBox TxtUrl;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabRequest;
        private TabPage tabAssert;
        private Panel panel1;
        private ComboBox CmbMothod;
        private Label label4;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Panel panel2;
        private Splitter splitter1;
        private TableLayoutPanel TlpHeaders;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbAddHeader;
        private ToolTip toolTip1;
    }
}
