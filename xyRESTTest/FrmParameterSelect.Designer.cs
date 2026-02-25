namespace xyRESTTest
{
    partial class FrmParameterSelect
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
            listBox1 = new ListBox();
            BtnCancel = new Button();
            BtnOk = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(246, 138);
            listBox1.TabIndex = 0;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(17, 4);
            BtnCancel.Margin = new Padding(3, 2, 3, 2);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 4;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(98, 4);
            BtnOk.Margin = new Padding(3, 2, 3, 2);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(75, 23);
            BtnOk.TabIndex = 3;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 138);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 29);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnCancel);
            panel2.Controls.Add(BtnOk);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(61, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(185, 29);
            panel2.TabIndex = 0;
            // 
            // FrmParameterSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(246, 167);
            ControlBox = false;
            Controls.Add(listBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FrmParameterSelect";
            ShowInTaskbar = false;
            Text = "Parameter Select";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button BtnCancel;
        private Button BtnOk;
        private Panel panel1;
        private Panel panel2;
    }
}