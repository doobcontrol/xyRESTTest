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
            TxtToken = new TextBox();
            TlpBasic = new TableLayoutPanel();
            LbUserName = new Label();
            TxtUsername = new TextBox();
            TxtPassword = new TextBox();
            LbPassword = new Label();
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
            TlpBearer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            TlpBearer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpBearer.Controls.Add(label3, 0, 0);
            TlpBearer.Controls.Add(TxtToken, 1, 0);
            TlpBearer.Dock = DockStyle.Top;
            TlpBearer.Location = new Point(0, 66);
            TlpBearer.Name = "TlpBearer";
            TlpBearer.RowCount = 1;
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
            // TxtToken
            // 
            TxtToken.Dock = DockStyle.Top;
            TxtToken.Location = new Point(103, 3);
            TxtToken.Name = "TxtToken";
            TxtToken.Size = new Size(242, 27);
            TxtToken.TabIndex = 2;
            // 
            // TlpBasic
            // 
            TlpBasic.AutoSize = true;
            TlpBasic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpBasic.ColumnCount = 2;
            TlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            TlpBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpBasic.Controls.Add(LbUserName, 0, 0);
            TlpBasic.Controls.Add(TxtUsername, 1, 0);
            TlpBasic.Controls.Add(TxtPassword, 1, 1);
            TlpBasic.Controls.Add(LbPassword, 0, 1);
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
            // LbUserName
            // 
            LbUserName.AutoSize = true;
            LbUserName.Dock = DockStyle.Left;
            LbUserName.Location = new Point(3, 0);
            LbUserName.Name = "LbUserName";
            LbUserName.Size = new Size(93, 33);
            LbUserName.TabIndex = 0;
            LbUserName.Text = "Login Name:";
            LbUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtUsername
            // 
            TxtUsername.Dock = DockStyle.Top;
            TxtUsername.Location = new Point(103, 3);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(242, 27);
            TxtUsername.TabIndex = 2;
            // 
            // TxtPassword
            // 
            TxtPassword.Dock = DockStyle.Top;
            TxtPassword.Location = new Point(103, 36);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(242, 27);
            TxtPassword.TabIndex = 3;
            // 
            // LbPassword
            // 
            LbPassword.AutoSize = true;
            LbPassword.Dock = DockStyle.Left;
            LbPassword.Location = new Point(3, 33);
            LbPassword.Name = "LbPassword";
            LbPassword.Size = new Size(75, 33);
            LbPassword.TabIndex = 1;
            LbPassword.Text = "password:";
            LbPassword.TextAlign = ContentAlignment.MiddleLeft;
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
        private Label LbUserName;
        private TextBox TxtUsername;
        private TextBox TxtPassword;
        private Label LbPassword;
        private TableLayoutPanel TlpBearer;
        private Label label3;
        private TextBox TxtToken;
    }
}
