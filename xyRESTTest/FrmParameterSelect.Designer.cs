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
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Top;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(283, 144);
            listBox1.TabIndex = 0;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(139, 150);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(63, 29);
            BtnCancel.TabIndex = 4;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(208, 150);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(63, 29);
            BtnOk.TabIndex = 3;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // FrmParameterSelect
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 187);
            ControlBox = false;
            Controls.Add(listBox1);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOk);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmParameterSelect";
            ShowInTaskbar = false;
            Text = "Parameter Select";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button BtnCancel;
        private Button BtnOk;
    }
}