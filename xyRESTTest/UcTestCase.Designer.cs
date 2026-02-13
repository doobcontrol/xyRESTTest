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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            tabControl1 = new TabControl();
            tabRequest = new TabPage();
            splitter1 = new Splitter();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            toolStrip1 = new ToolStrip();
            TlpHeaders = new TableLayoutPanel();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label4 = new Label();
            tabAssert = new TabPage();
            panel1 = new Panel();
            TsbAddHeader = new ToolStripButton();
            tabControl1.SuspendLayout();
            tabRequest.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(694, 34);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 40);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(374, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(133, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(534, 27);
            textBox2.TabIndex = 4;
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
            tabControl1.Location = new Point(0, 79);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(694, 326);
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
            tabRequest.Size = new Size(686, 293);
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
            groupBox2.Size = new Size(680, 86);
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
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 90);
            panel2.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(133, 48);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
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
            tabAssert.Size = new Size(686, 293);
            tabAssert.TabIndex = 1;
            tabAssert.Text = "Assertion Information";
            tabAssert.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(694, 79);
            panel1.TabIndex = 6;
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
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabRequest;
        private TabPage tabAssert;
        private Panel panel1;
        private ComboBox comboBox1;
        private Label label4;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Panel panel2;
        private Splitter splitter1;
        private TableLayoutPanel TlpHeaders;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbAddHeader;
    }
}
