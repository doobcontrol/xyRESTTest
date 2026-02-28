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
            LbContentType = new Label();
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
            tabData = new TabPage();
            PnlGenerator = new Panel();
            PnlRecords = new Panel();
            splitter2 = new Splitter();
            PnlParameters = new Panel();
            DgvParameters = new DataGridView();
            LbParameters = new Label();
            toolStrip3 = new ToolStrip();
            TsbAddParam = new ToolStripButton();
            TsbDelParam = new ToolStripButton();
            panel4 = new Panel();
            CbGeneratorType = new ComboBox();
            CbDataGenerator = new CheckBox();
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
            tabData.SuspendLayout();
            PnlGenerator.SuspendLayout();
            PnlParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvParameters).BeginInit();
            toolStrip3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LbCaseName
            // 
            LbCaseName.BorderStyle = BorderStyle.FixedSingle;
            LbCaseName.Dock = DockStyle.Top;
            LbCaseName.Location = new Point(0, 23);
            LbCaseName.Name = "LbCaseName";
            LbCaseName.Size = new Size(607, 24);
            LbCaseName.TabIndex = 0;
            LbCaseName.Text = "label1";
            LbCaseName.TextAlign = ContentAlignment.MiddleCenter;
            LbCaseName.DoubleClick += LbCaseName_DoubleClick;
            // 
            // TxtCaseName
            // 
            TxtCaseName.Dock = DockStyle.Top;
            TxtCaseName.Location = new Point(0, 0);
            TxtCaseName.Margin = new Padding(3, 2, 3, 2);
            TxtCaseName.Name = "TxtCaseName";
            TxtCaseName.Size = new Size(607, 23);
            TxtCaseName.TabIndex = 2;
            TxtCaseName.TextAlign = HorizontalAlignment.Center;
            TxtCaseName.Visible = false;
            TxtCaseName.KeyDown += TxtCaseName_KeyDown;
            TxtCaseName.Leave += TxtCaseName_Leave;
            // 
            // TxtUrl
            // 
            TxtUrl.Location = new Point(79, 2);
            TxtUrl.Margin = new Padding(3, 2, 3, 2);
            TxtUrl.Name = "TxtUrl";
            TxtUrl.Size = new Size(500, 23);
            TxtUrl.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 4);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 3;
            label3.Text = "Url:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabRequest);
            tabControl1.Controls.Add(tabAssert);
            tabControl1.Controls.Add(tabData);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 47);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(607, 257);
            tabControl1.TabIndex = 5;
            // 
            // tabRequest
            // 
            tabRequest.Controls.Add(splitter1);
            tabRequest.Controls.Add(GbBody);
            tabRequest.Controls.Add(groupBox1);
            tabRequest.Controls.Add(panel2);
            tabRequest.Location = new Point(4, 24);
            tabRequest.Margin = new Padding(3, 2, 3, 2);
            tabRequest.Name = "tabRequest";
            tabRequest.Padding = new Padding(3, 2, 3, 2);
            tabRequest.Size = new Size(599, 229);
            tabRequest.TabIndex = 0;
            tabRequest.Text = "Request Information";
            tabRequest.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new Point(3, 101);
            splitter1.Margin = new Padding(3, 2, 3, 2);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(593, 3);
            splitter1.TabIndex = 10;
            splitter1.TabStop = false;
            // 
            // GbBody
            // 
            GbBody.Controls.Add(PnlBody);
            GbBody.Controls.Add(panel3);
            GbBody.Dock = DockStyle.Fill;
            GbBody.Location = new Point(3, 101);
            GbBody.Margin = new Padding(3, 2, 3, 2);
            GbBody.Name = "GbBody";
            GbBody.Padding = new Padding(3, 2, 3, 2);
            GbBody.Size = new Size(593, 126);
            GbBody.TabIndex = 9;
            GbBody.TabStop = false;
            GbBody.Text = "Body";
            // 
            // PnlBody
            // 
            PnlBody.Dock = DockStyle.Fill;
            PnlBody.Location = new Point(3, 40);
            PnlBody.Margin = new Padding(3, 2, 3, 2);
            PnlBody.Name = "PnlBody";
            PnlBody.Size = new Size(587, 84);
            PnlBody.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(CmbBodyType);
            panel3.Controls.Add(LbContentType);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 18);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(587, 22);
            panel3.TabIndex = 3;
            // 
            // CmbBodyType
            // 
            CmbBodyType.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbBodyType.FormattingEnabled = true;
            CmbBodyType.Location = new Point(94, 0);
            CmbBodyType.Margin = new Padding(3, 2, 3, 2);
            CmbBodyType.Name = "CmbBodyType";
            CmbBodyType.Size = new Size(298, 23);
            CmbBodyType.TabIndex = 1;
            CmbBodyType.SelectedIndexChanged += CmbBodyType_SelectedIndexChanged;
            // 
            // LbContentType
            // 
            LbContentType.AutoSize = true;
            LbContentType.Location = new Point(3, 2);
            LbContentType.Name = "LbContentType";
            LbContentType.Size = new Size(81, 15);
            LbContentType.TabIndex = 0;
            LbContentType.Text = "Content Type:";
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(TlpHeaders);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 54);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.MinimumSize = new Size(0, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(593, 47);
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
            TlpHeaders.Location = new Point(3, 45);
            TlpHeaders.Margin = new Padding(3, 2, 3, 2);
            TlpHeaders.Name = "TlpHeaders";
            TlpHeaders.RowCount = 1;
            TlpHeaders.RowStyles.Add(new RowStyle());
            TlpHeaders.Size = new Size(587, 0);
            TlpHeaders.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbAddHeader, TsbDelHeader });
            toolStrip1.Location = new Point(3, 18);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(587, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbAddHeader
            // 
            TsbAddHeader.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddHeader.Image = Properties.Resources.Add;
            TsbAddHeader.ImageTransparentColor = Color.Magenta;
            TsbAddHeader.Name = "TsbAddHeader";
            TsbAddHeader.Size = new Size(24, 24);
            TsbAddHeader.Text = "Add a header";
            TsbAddHeader.Click += TsbAddHeader_Click;
            // 
            // TsbDelHeader
            // 
            TsbDelHeader.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelHeader.Image = Properties.Resources.Delete;
            TsbDelHeader.ImageTransparentColor = Color.Magenta;
            TsbDelHeader.Name = "TsbDelHeader";
            TsbDelHeader.Size = new Size(24, 24);
            TsbDelHeader.Text = "Delete selected header";
            TsbDelHeader.Click += TsbDelHeader_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(CmbMethod);
            panel2.Controls.Add(TxtUrl);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(593, 52);
            panel2.TabIndex = 7;
            // 
            // CmbMethod
            // 
            CmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbMethod.FormattingEnabled = true;
            CmbMethod.Location = new Point(79, 27);
            CmbMethod.Margin = new Padding(3, 2, 3, 2);
            CmbMethod.Name = "CmbMethod";
            CmbMethod.Size = new Size(133, 23);
            CmbMethod.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 29);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 5;
            label4.Text = "Method:";
            // 
            // tabAssert
            // 
            tabAssert.Controls.Add(PnlAssertItems);
            tabAssert.Controls.Add(toolStrip2);
            tabAssert.Location = new Point(4, 24);
            tabAssert.Margin = new Padding(3, 2, 3, 2);
            tabAssert.Name = "tabAssert";
            tabAssert.Padding = new Padding(3, 2, 3, 2);
            tabAssert.Size = new Size(599, 232);
            tabAssert.TabIndex = 1;
            tabAssert.Text = "Assertion Information";
            tabAssert.UseVisualStyleBackColor = true;
            // 
            // PnlAssertItems
            // 
            PnlAssertItems.Dock = DockStyle.Fill;
            PnlAssertItems.Location = new Point(3, 29);
            PnlAssertItems.Margin = new Padding(3, 2, 3, 2);
            PnlAssertItems.Name = "PnlAssertItems";
            PnlAssertItems.Size = new Size(593, 201);
            PnlAssertItems.TabIndex = 3;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Items.AddRange(new ToolStripItem[] { TsbAddAssert, TsbDelAssert });
            toolStrip2.Location = new Point(3, 2);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(593, 27);
            toolStrip2.TabIndex = 2;
            toolStrip2.Text = "toolStrip2";
            // 
            // TsbAddAssert
            // 
            TsbAddAssert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddAssert.Image = Properties.Resources.Add;
            TsbAddAssert.ImageTransparentColor = Color.Magenta;
            TsbAddAssert.Name = "TsbAddAssert";
            TsbAddAssert.Size = new Size(24, 24);
            TsbAddAssert.Text = "Add an assertion";
            TsbAddAssert.Click += TsbAddAssert_Click;
            // 
            // TsbDelAssert
            // 
            TsbDelAssert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelAssert.Image = Properties.Resources.Delete;
            TsbDelAssert.ImageTransparentColor = Color.Magenta;
            TsbDelAssert.Name = "TsbDelAssert";
            TsbDelAssert.Size = new Size(24, 24);
            TsbDelAssert.Text = "Delete selected assertion";
            TsbDelAssert.Click += TsbDelAssert_Click;
            // 
            // tabData
            // 
            tabData.Controls.Add(PnlGenerator);
            tabData.Controls.Add(panel4);
            tabData.Location = new Point(4, 24);
            tabData.Margin = new Padding(3, 2, 3, 2);
            tabData.Name = "tabData";
            tabData.Size = new Size(599, 232);
            tabData.TabIndex = 2;
            tabData.Text = "Data Generator";
            tabData.UseVisualStyleBackColor = true;
            // 
            // PnlGenerator
            // 
            PnlGenerator.Controls.Add(PnlRecords);
            PnlGenerator.Controls.Add(splitter2);
            PnlGenerator.Controls.Add(PnlParameters);
            PnlGenerator.Dock = DockStyle.Fill;
            PnlGenerator.Location = new Point(0, 34);
            PnlGenerator.Margin = new Padding(3, 2, 3, 2);
            PnlGenerator.Name = "PnlGenerator";
            PnlGenerator.Size = new Size(599, 198);
            PnlGenerator.TabIndex = 1;
            PnlGenerator.Visible = false;
            // 
            // PnlRecords
            // 
            PnlRecords.BorderStyle = BorderStyle.FixedSingle;
            PnlRecords.Dock = DockStyle.Fill;
            PnlRecords.Location = new Point(178, 0);
            PnlRecords.Margin = new Padding(3, 2, 3, 2);
            PnlRecords.Name = "PnlRecords";
            PnlRecords.Size = new Size(421, 198);
            PnlRecords.TabIndex = 3;
            // 
            // splitter2
            // 
            splitter2.Location = new Point(174, 0);
            splitter2.Margin = new Padding(3, 2, 3, 2);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(4, 198);
            splitter2.TabIndex = 2;
            splitter2.TabStop = false;
            // 
            // PnlParameters
            // 
            PnlParameters.BorderStyle = BorderStyle.FixedSingle;
            PnlParameters.Controls.Add(DgvParameters);
            PnlParameters.Controls.Add(LbParameters);
            PnlParameters.Controls.Add(toolStrip3);
            PnlParameters.Dock = DockStyle.Left;
            PnlParameters.Location = new Point(0, 0);
            PnlParameters.Margin = new Padding(3, 2, 3, 2);
            PnlParameters.Name = "PnlParameters";
            PnlParameters.Size = new Size(174, 198);
            PnlParameters.TabIndex = 1;
            // 
            // DgvParameters
            // 
            DgvParameters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvParameters.Dock = DockStyle.Fill;
            DgvParameters.Location = new Point(0, 44);
            DgvParameters.Margin = new Padding(3, 2, 3, 2);
            DgvParameters.Name = "DgvParameters";
            DgvParameters.RowHeadersWidth = 51;
            DgvParameters.Size = new Size(172, 152);
            DgvParameters.TabIndex = 3;
            DgvParameters.CellEndEdit += DgvParameters_CellEndEdit;
            // 
            // LbParameters
            // 
            LbParameters.Dock = DockStyle.Top;
            LbParameters.Location = new Point(0, 27);
            LbParameters.Name = "LbParameters";
            LbParameters.Size = new Size(172, 17);
            LbParameters.TabIndex = 2;
            LbParameters.Text = "Parameters";
            LbParameters.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toolStrip3
            // 
            toolStrip3.ImageScalingSize = new Size(20, 20);
            toolStrip3.Items.AddRange(new ToolStripItem[] { TsbAddParam, TsbDelParam });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(172, 27);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
            // 
            // TsbAddParam
            // 
            TsbAddParam.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddParam.Image = Properties.Resources.Add;
            TsbAddParam.ImageTransparentColor = Color.Magenta;
            TsbAddParam.Name = "TsbAddParam";
            TsbAddParam.Size = new Size(24, 24);
            TsbAddParam.Text = "Add a parameter";
            TsbAddParam.Click += TsbAddParam_Click;
            // 
            // TsbDelParam
            // 
            TsbDelParam.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelParam.Image = Properties.Resources.Delete;
            TsbDelParam.ImageTransparentColor = Color.Magenta;
            TsbDelParam.Name = "TsbDelParam";
            TsbDelParam.Size = new Size(24, 24);
            TsbDelParam.Text = "Delete selected parameter";
            TsbDelParam.Click += TsbDelParam_Click;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(CbGeneratorType);
            panel4.Controls.Add(CbDataGenerator);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(599, 34);
            panel4.TabIndex = 2;
            // 
            // CbGeneratorType
            // 
            CbGeneratorType.DropDownStyle = ComboBoxStyle.DropDownList;
            CbGeneratorType.FormattingEnabled = true;
            CbGeneratorType.Location = new Point(228, 5);
            CbGeneratorType.Margin = new Padding(3, 2, 3, 2);
            CbGeneratorType.Name = "CbGeneratorType";
            CbGeneratorType.Size = new Size(133, 23);
            CbGeneratorType.TabIndex = 1;
            CbGeneratorType.Visible = false;
            CbGeneratorType.SelectedIndexChanged += CbGeneratorType_SelectedIndexChanged;
            // 
            // CbDataGenerator
            // 
            CbDataGenerator.AutoSize = true;
            CbDataGenerator.Location = new Point(17, 8);
            CbDataGenerator.Margin = new Padding(3, 2, 3, 2);
            CbDataGenerator.Name = "CbDataGenerator";
            CbDataGenerator.Size = new Size(188, 19);
            CbDataGenerator.TabIndex = 0;
            CbDataGenerator.Text = "Dynamically generate test case";
            CbDataGenerator.UseVisualStyleBackColor = true;
            CbDataGenerator.CheckedChanged += CbDataGenerator_CheckedChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(LbCaseName);
            panel1.Controls.Add(TxtCaseName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(607, 47);
            panel1.TabIndex = 6;
            // 
            // UcTestCase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UcTestCase";
            Size = new Size(607, 304);
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
            tabData.ResumeLayout(false);
            PnlGenerator.ResumeLayout(false);
            PnlParameters.ResumeLayout(false);
            PnlParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvParameters).EndInit();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private Label LbContentType;
        private Panel PnlAssertItems;
        private ToolStrip toolStrip2;
        private ToolStripButton TsbAddAssert;
        private ToolStripButton TsbDelAssert;
        private ToolStripButton TsbDelHeader;
        private TabPage tabData;
        private CheckBox CbDataGenerator;
        private Panel PnlGenerator;
        private Panel PnlParameters;
        private Label LbParameters;
        private ToolStrip toolStrip3;
        private ToolStripButton TsbDelParam;
        private ToolStripButton TsbAddParam;
        private DataGridView DgvParameters;
        private Splitter splitter2;
        private Panel PnlRecords;
        private Panel panel4;
        private ComboBox CbGeneratorType;
    }
}
