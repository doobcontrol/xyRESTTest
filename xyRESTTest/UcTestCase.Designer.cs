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
            GbBody = new GroupBox();
            PnlBody = new Panel();
            panel3 = new Panel();
            CmbBodyType = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            TlpHeaders = new TableLayoutPanel();
            toolStrip1 = new ToolStrip();
            TsbAddHeader = new ToolStripButton();
            TsbDelHeader = new ToolStripButton();
            panel2 = new Panel();
            CmbMethod = new ComboBox();
            label4 = new Label();
            tabAssert = new TabPage();
            PnlAssertItems = new Panel();
            toolStrip2 = new ToolStrip();
            TsbAddAssert = new ToolStripButton();
            TsbDelAssert = new ToolStripButton();
            panel1 = new Panel();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabRequest.SuspendLayout();
            GbBody.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            tabAssert.SuspendLayout();
            toolStrip2.SuspendLayout();
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
            TxtUrl.Location = new Point(90, 3);
            TxtUrl.Name = "TxtUrl";
            TxtUrl.Size = new Size(571, 27);
            TxtUrl.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 6);
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
            tabRequest.Controls.Add(GbBody);
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
            splitter1.Location = new Point(3, 125);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(680, 4);
            splitter1.TabIndex = 10;
            splitter1.TabStop = false;
            // 
            // GbBody
            // 
            GbBody.Controls.Add(PnlBody);
            GbBody.Controls.Add(panel3);
            GbBody.Dock = DockStyle.Fill;
            GbBody.Location = new Point(3, 125);
            GbBody.Name = "GbBody";
            GbBody.Size = new Size(680, 183);
            GbBody.TabIndex = 9;
            GbBody.TabStop = false;
            GbBody.Text = "Body";
            // 
            // PnlBody
            // 
            PnlBody.Dock = DockStyle.Fill;
            PnlBody.Location = new Point(3, 53);
            PnlBody.Name = "PnlBody";
            PnlBody.Size = new Size(674, 127);
            PnlBody.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(CmbBodyType);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 23);
            panel3.Name = "panel3";
            panel3.Size = new Size(674, 30);
            panel3.TabIndex = 3;
            // 
            // CmbBodyType
            // 
            CmbBodyType.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbBodyType.FormattingEnabled = true;
            CmbBodyType.Location = new Point(108, 0);
            CmbBodyType.Name = "CmbBodyType";
            CmbBodyType.Size = new Size(151, 28);
            CmbBodyType.TabIndex = 1;
            CmbBodyType.SelectedIndexChanged += CmbBodyType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Content Type:";
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(TlpHeaders);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 72);
            groupBox1.MinimumSize = new Size(0, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(680, 53);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Headers";
            // 
            // TlpHeaders
            // 
            TlpHeaders.AutoSize = true;
            TlpHeaders.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpHeaders.ColumnCount = 1;
            TlpHeaders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpHeaders.Dock = DockStyle.Top;
            TlpHeaders.Location = new Point(3, 50);
            TlpHeaders.Name = "TlpHeaders";
            TlpHeaders.RowCount = 1;
            TlpHeaders.RowStyles.Add(new RowStyle());
            TlpHeaders.Size = new Size(674, 0);
            TlpHeaders.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbAddHeader, TsbDelHeader });
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
            // TsbDelHeader
            // 
            TsbDelHeader.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelHeader.Image = Properties.Resources.Delete;
            TsbDelHeader.ImageTransparentColor = Color.Magenta;
            TsbDelHeader.Name = "TsbDelHeader";
            TsbDelHeader.Size = new Size(29, 24);
            TsbDelHeader.Text = "toolStripButton1";
            TsbDelHeader.Click += TsbDelHeader_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(CmbMethod);
            panel2.Controls.Add(TxtUrl);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 69);
            panel2.TabIndex = 7;
            // 
            // CmbMethod
            // 
            CmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbMethod.FormattingEnabled = true;
            CmbMethod.Location = new Point(90, 36);
            CmbMethod.Name = "CmbMethod";
            CmbMethod.Size = new Size(151, 28);
            CmbMethod.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 39);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 5;
            label4.Text = "Method:";
            // 
            // tabAssert
            // 
            tabAssert.Controls.Add(PnlAssertItems);
            tabAssert.Controls.Add(toolStrip2);
            tabAssert.Location = new Point(4, 29);
            tabAssert.Name = "tabAssert";
            tabAssert.Padding = new Padding(3);
            tabAssert.Size = new Size(686, 311);
            tabAssert.TabIndex = 1;
            tabAssert.Text = "Assertion Information";
            tabAssert.UseVisualStyleBackColor = true;
            // 
            // PnlAssertItems
            // 
            PnlAssertItems.Dock = DockStyle.Fill;
            PnlAssertItems.Location = new Point(3, 30);
            PnlAssertItems.Name = "PnlAssertItems";
            PnlAssertItems.Size = new Size(680, 278);
            PnlAssertItems.TabIndex = 3;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Items.AddRange(new ToolStripItem[] { TsbAddAssert, TsbDelAssert });
            toolStrip2.Location = new Point(3, 3);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(680, 27);
            toolStrip2.TabIndex = 2;
            toolStrip2.Text = "toolStrip2";
            // 
            // TsbAddAssert
            // 
            TsbAddAssert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddAssert.Image = Properties.Resources.Add;
            TsbAddAssert.ImageTransparentColor = Color.Magenta;
            TsbAddAssert.Name = "TsbAddAssert";
            TsbAddAssert.Size = new Size(29, 24);
            TsbAddAssert.Text = "toolStripButton1";
            TsbAddAssert.Click += TsbAddAssert_Click;
            // 
            // TsbDelAssert
            // 
            TsbDelAssert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelAssert.Image = Properties.Resources.Delete;
            TsbDelAssert.ImageTransparentColor = Color.Magenta;
            TsbDelAssert.Name = "TsbDelAssert";
            TsbDelAssert.Size = new Size(29, 24);
            TsbDelAssert.Text = "toolStripButton1";
            TsbDelAssert.Click += TsbDelAssert_Click;
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
            tabRequest.PerformLayout();
            GbBody.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabAssert.ResumeLayout(false);
            tabAssert.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
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
        private ComboBox CmbMethod;
        private Label label4;
        private GroupBox GbBody;
        private GroupBox groupBox1;
        private Panel panel2;
        private Splitter splitter1;
        private TableLayoutPanel TlpHeaders;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbAddHeader;
        private ToolTip toolTip1;
        private Panel PnlBody;
        private Panel panel3;
        private ComboBox CmbBodyType;
        private Label label1;
        private Panel PnlAssertItems;
        private ToolStrip toolStrip2;
        private ToolStripButton TsbAddAssert;
        private ToolStripButton TsbDelAssert;
        private ToolStripButton TsbDelHeader;
    }
}
