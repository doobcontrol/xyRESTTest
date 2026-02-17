namespace xyRESTTest
{
    partial class UcJsonBody
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
            comboBox1 = new ComboBox();
            PnlJsonEditor = new Panel();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Top;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // PnlJsonEditor
            // 
            PnlJsonEditor.Dock = DockStyle.Fill;
            PnlJsonEditor.Location = new Point(0, 28);
            PnlJsonEditor.Name = "PnlJsonEditor";
            PnlJsonEditor.Size = new Size(151, 0);
            PnlJsonEditor.TabIndex = 1;
            // 
            // UcJsonBody
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(PnlJsonEditor);
            Controls.Add(comboBox1);
            MinimumSize = new Size(151, 28);
            Name = "UcJsonBody";
            Size = new Size(151, 28);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Panel PnlJsonEditor;
    }
}
