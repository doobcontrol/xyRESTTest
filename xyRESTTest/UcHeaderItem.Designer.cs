namespace xyRESTTest
{
    partial class UcHeaderItem
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
            lbInfo = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            btnDropDown = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lbInfo
            // 
            lbInfo.Dock = DockStyle.Top;
            lbInfo.Location = new Point(0, 0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(112, 18);
            lbInfo.TabIndex = 0;
            lbInfo.Text = "label1";
            lbInfo.TextAlign = ContentAlignment.MiddleLeft;
            lbInfo.Click += lbInfo_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(lbInfo);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(132, 18);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDropDown);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(112, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(20, 18);
            panel2.TabIndex = 1;
            // 
            // btnDropDown
            // 
            btnDropDown.Dock = DockStyle.Right;
            btnDropDown.Image = Properties.Resources.drop_down;
            btnDropDown.Location = new Point(0, 0);
            btnDropDown.Margin = new Padding(3, 2, 3, 2);
            btnDropDown.MinimumSize = new Size(0, 18);
            btnDropDown.Name = "btnDropDown";
            btnDropDown.Size = new Size(20, 18);
            btnDropDown.TabIndex = 0;
            btnDropDown.UseVisualStyleBackColor = true;
            btnDropDown.Click += btnDropDown_Click;
            // 
            // UcHeaderItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(132, 18);
            Name = "UcHeaderItem";
            Size = new Size(132, 18);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbInfo;
        private Panel panel1;
        private Panel panel2;
        private Button btnDropDown;
    }
}
