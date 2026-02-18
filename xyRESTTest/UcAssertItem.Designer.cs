namespace xyRESTTest
{
    partial class UcAssertItem
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
            lbInfo = new Label();
            panel2 = new Panel();
            btnDropDown = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(lbInfo);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(148, 20);
            panel1.TabIndex = 2;
            // 
            // lbInfo
            // 
            lbInfo.Dock = DockStyle.Top;
            lbInfo.Location = new Point(0, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(126, 20);
            lbInfo.TabIndex = 0;
            lbInfo.Text = "label1";
            lbInfo.Click += lbInfo_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDropDown);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(126, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(22, 20);
            panel2.TabIndex = 1;
            // 
            // btnDropDown
            // 
            btnDropDown.Dock = DockStyle.Right;
            btnDropDown.Image = Properties.Resources.drop_down;
            btnDropDown.Location = new Point(-1, 0);
            btnDropDown.Name = "btnDropDown";
            btnDropDown.Size = new Size(23, 20);
            btnDropDown.TabIndex = 0;
            btnDropDown.UseVisualStyleBackColor = true;
            btnDropDown.Click += btnDropDown_Click;
            // 
            // UcAssertItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            MinimumSize = new Size(150, 0);
            Name = "UcAssertItem";
            Size = new Size(148, 20);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbInfo;
        private Panel panel2;
        private Button btnDropDown;
    }
}
