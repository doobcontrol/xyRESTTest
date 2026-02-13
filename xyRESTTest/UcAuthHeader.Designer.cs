namespace xyRESTTest
{
    partial class UcAuthHeader
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
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            TlpBearer = new TableLayoutPanel();
            label3 = new Label();
            textBox3 = new TextBox();
            TlpBasic = new TableLayoutPanel();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            TlpBearer.SuspendLayout();
            TlpBasic.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.MinimumSize = new Size(150, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 101);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Top;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Basic", "Bearer" });
            comboBox1.Location = new Point(0, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(TlpBearer);
            panel2.Controls.Add(TlpBasic);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(150, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 101);
            panel2.TabIndex = 1;
            // 
            // TlpBearer
            // 
            TlpBearer.AutoSize = true;
            TlpBearer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpBearer.ColumnCount = 2;
            TlpBearer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            TlpBearer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpBearer.Controls.Add(label3, 0, 0);
            TlpBearer.Controls.Add(textBox3, 1, 0);
            TlpBearer.Dock = DockStyle.Top;
            TlpBearer.Location = new Point(0, 66);
            TlpBearer.Name = "TlpBearer";
            TlpBearer.RowCount = 1;
            TlpBearer.RowStyles.Add(new RowStyle());
            TlpBearer.RowStyles.Add(new RowStyle());
            TlpBearer.Size = new Size(348, 33);
            TlpBearer.TabIndex = 1;
            TlpBearer.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(49, 33);
            label3.TabIndex = 0;
            label3.Text = "token:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Top;
            textBox3.Location = new Point(93, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(252, 27);
            textBox3.TabIndex = 2;
            // 
            // TlpBasic
            // 
            TlpBasic.AutoSize = true;
            TlpBasic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpBasic.ColumnCount = 2;
            TlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            TlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpBasic.Controls.Add(label1, 0, 0);
            TlpBasic.Controls.Add(textBox1, 1, 0);
            TlpBasic.Controls.Add(textBox2, 1, 1);
            TlpBasic.Controls.Add(label2, 0, 1);
            TlpBasic.Dock = DockStyle.Top;
            TlpBasic.Location = new Point(0, 0);
            TlpBasic.Name = "TlpBasic";
            TlpBasic.RowCount = 2;
            TlpBasic.RowStyles.Add(new RowStyle());
            TlpBasic.RowStyles.Add(new RowStyle());
            TlpBasic.Size = new Size(348, 66);
            TlpBasic.TabIndex = 0;
            TlpBasic.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 33);
            label1.TabIndex = 0;
            label1.Text = "username:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Top;
            textBox1.Location = new Point(93, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(252, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Top;
            textBox2.Location = new Point(93, 36);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(252, 27);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Location = new Point(3, 33);
            label2.Name = "label2";
            label2.Size = new Size(75, 33);
            label2.TabIndex = 1;
            label2.Text = "password:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UcAuthHeader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(500, 28);
            Name = "UcAuthHeader";
            Size = new Size(500, 101);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            TlpBearer.ResumeLayout(false);
            TlpBearer.PerformLayout();
            TlpBasic.ResumeLayout(false);
            TlpBasic.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Panel panel2;
        private TableLayoutPanel TlpBasic;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TableLayoutPanel TlpBearer;
        private Label label3;
        private TextBox textBox3;
    }
}
