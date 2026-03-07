namespace xyRESTTest
{
    partial class FrmSimpleImageCaptcha
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
            panel2 = new Panel();
            BtnOk = new Button();
            panel3 = new Panel();
            textBox1 = new TextBox();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 161);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 36);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnOk);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(295, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(89, 36);
            panel2.TabIndex = 0;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(3, 3);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(75, 23);
            BtnOk.TabIndex = 0;
            BtnOk.Text = "button1";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 125);
            panel3.Name = "panel3";
            panel3.Size = new Size(384, 36);
            panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(pictureBox1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(384, 125);
            panel4.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(10);
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmSimpleImageCaptcha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(384, 197);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            MinimumSize = new Size(400, 236);
            Name = "FrmSimpleImageCaptcha";
            Text = "FrmSimpleImageCaptcha";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button BtnOk;
        private Panel panel3;
        private TextBox textBox1;
        private Panel panel4;
        private PictureBox pictureBox1;
    }
}