namespace xyRESTTest
{
    partial class UcHeaderEdit
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
            BtnOk = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            BtnCancel = new Button();
            PnlEditor = new Panel();
            PnlEditorSelector = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
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
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(148, 35);
            panel1.TabIndex = 2;
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
            // PnlEditor
            // 
            PnlEditor.AutoSize = true;
            PnlEditor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlEditor.Dock = DockStyle.Fill;
            PnlEditor.Location = new Point(0, 0);
            PnlEditor.Name = "PnlEditor";
            PnlEditor.Size = new Size(148, 0);
            PnlEditor.TabIndex = 3;
            // 
            // PnlEditorSelector
            // 
            PnlEditorSelector.AutoSize = true;
            PnlEditorSelector.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlEditorSelector.Dock = DockStyle.Top;
            PnlEditorSelector.Location = new Point(0, 0);
            PnlEditorSelector.Name = "PnlEditorSelector";
            PnlEditorSelector.Size = new Size(148, 0);
            PnlEditorSelector.TabIndex = 4;
            // 
            // UcHeaderEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(PnlEditor);
            Controls.Add(PnlEditorSelector);
            Controls.Add(panel1);
            MinimumSize = new Size(150, 0);
            Name = "UcHeaderEdit";
            Size = new Size(148, 35);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnOk;
        private Panel panel1;
        private Panel panel2;
        private Button BtnCancel;
        private Panel PnlEditor;
        private Panel PnlEditorSelector;
    }
}
