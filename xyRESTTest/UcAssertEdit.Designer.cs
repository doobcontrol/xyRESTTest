namespace xyRESTTest
{
    partial class UcAssertEdit
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
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            BtnOk = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            BtnCancel = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 28);
            panel3.Name = "panel3";
            panel3.Size = new Size(148, 0);
            panel3.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Top;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "StatusCode", "JsonContent" });
            comboBox1.Location = new Point(0, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(72, 3);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(63, 29);
            BtnOk.TabIndex = 1;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(148, 35);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnCancel);
            panel2.Controls.Add(BtnOk);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(9, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(139, 35);
            panel2.TabIndex = 0;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(3, 3);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(63, 29);
            BtnCancel.TabIndex = 2;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // UcAssertEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel3);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            MinimumSize = new Size(150, 0);
            Name = "UcAssertEdit";
            Size = new Size(148, 63);
            VisibleChanged += UcAssertEdit_VisibleChanged;
            MouseDown += UcAssertEdit_MouseDown;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private ComboBox comboBox1;
        private Button BtnOk;
        private Panel panel1;
        private Panel panel2;
        private Button BtnCancel;
    }
}
