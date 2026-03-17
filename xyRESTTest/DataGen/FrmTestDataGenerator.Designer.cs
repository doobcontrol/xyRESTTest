namespace xyRESTTest.DataGen
{
    partial class FrmTestDataGenerator
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
            LbQuantityToGenerate = new Label();
            BtnOk = new Button();
            NudQuantityToGenerate = new NumericUpDown();
            BtnCancel = new Button();
            panel3 = new Panel();
            TlpParameters = new TableLayoutPanel();
            splitter1 = new Splitter();
            panel4 = new Panel();
            PnlGenerateTypeEditor = new Panel();
            DgvParsEditor = new DataGridView();
            CbDataGenerateType = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NudQuantityToGenerate).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            PnlGenerateTypeEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvParsEditor).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 286);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 31);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(LbQuantityToGenerate);
            panel2.Controls.Add(BtnOk);
            panel2.Controls.Add(NudQuantityToGenerate);
            panel2.Controls.Add(BtnCancel);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(200, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 31);
            panel2.TabIndex = 5;
            // 
            // LbQuantityToGenerate
            // 
            LbQuantityToGenerate.AutoSize = true;
            LbQuantityToGenerate.Location = new Point(7, 5);
            LbQuantityToGenerate.Name = "LbQuantityToGenerate";
            LbQuantityToGenerate.Size = new Size(38, 15);
            LbQuantityToGenerate.TabIndex = 7;
            LbQuantityToGenerate.Text = "label1";
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(351, 4);
            BtnOk.Margin = new Padding(3, 2, 3, 2);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(55, 22);
            BtnOk.TabIndex = 3;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // NudQuantityToGenerate
            // 
            NudQuantityToGenerate.Location = new Point(163, 4);
            NudQuantityToGenerate.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NudQuantityToGenerate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NudQuantityToGenerate.Name = "NudQuantityToGenerate";
            NudQuantityToGenerate.Size = new Size(120, 23);
            NudQuantityToGenerate.TabIndex = 6;
            NudQuantityToGenerate.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(291, 4);
            BtnCancel.Margin = new Padding(3, 2, 3, 2);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(55, 22);
            BtnCancel.TabIndex = 4;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(TlpParameters);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 2, 0, 0);
            panel3.Size = new Size(200, 286);
            panel3.TabIndex = 1;
            // 
            // TlpParameters
            // 
            TlpParameters.AutoSize = true;
            TlpParameters.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpParameters.ColumnCount = 1;
            TlpParameters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpParameters.Dock = DockStyle.Top;
            TlpParameters.Location = new Point(0, 2);
            TlpParameters.Name = "TlpParameters";
            TlpParameters.RowCount = 1;
            TlpParameters.RowStyles.Add(new RowStyle());
            TlpParameters.Size = new Size(198, 0);
            TlpParameters.TabIndex = 0;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(200, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 286);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(PnlGenerateTypeEditor);
            panel4.Controls.Add(CbDataGenerateType);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(203, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(410, 286);
            panel4.TabIndex = 3;
            // 
            // PnlGenerateTypeEditor
            // 
            PnlGenerateTypeEditor.Controls.Add(DgvParsEditor);
            PnlGenerateTypeEditor.Dock = DockStyle.Fill;
            PnlGenerateTypeEditor.Location = new Point(0, 23);
            PnlGenerateTypeEditor.Name = "PnlGenerateTypeEditor";
            PnlGenerateTypeEditor.Size = new Size(408, 261);
            PnlGenerateTypeEditor.TabIndex = 1;
            // 
            // DgvParsEditor
            // 
            DgvParsEditor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvParsEditor.Dock = DockStyle.Fill;
            DgvParsEditor.Location = new Point(0, 0);
            DgvParsEditor.Name = "DgvParsEditor";
            DgvParsEditor.Size = new Size(408, 261);
            DgvParsEditor.TabIndex = 0;
            DgvParsEditor.CellEndEdit += DgvParsEditor_CellEndEdit;
            // 
            // CbDataGenerateType
            // 
            CbDataGenerateType.Dock = DockStyle.Top;
            CbDataGenerateType.DropDownStyle = ComboBoxStyle.DropDownList;
            CbDataGenerateType.FormattingEnabled = true;
            CbDataGenerateType.Location = new Point(0, 0);
            CbDataGenerateType.Name = "CbDataGenerateType";
            CbDataGenerateType.Size = new Size(408, 23);
            CbDataGenerateType.TabIndex = 0;
            // 
            // FrmTestDataGenerator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 317);
            Controls.Add(panel4);
            Controls.Add(splitter1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmTestDataGenerator";
            Text = "FrmTestDataGenerator";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NudQuantityToGenerate).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            PnlGenerateTypeEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvParsEditor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button BtnOk;
        private Button BtnCancel;
        private Panel panel3;
        private Splitter splitter1;
        private Panel panel4;
        private TableLayoutPanel TlpParameters;
        private Label LbQuantityToGenerate;
        private NumericUpDown NudQuantityToGenerate;
        private ComboBox CbDataGenerateType;
        private Panel PnlGenerateTypeEditor;
        private DataGridView DgvParsEditor;
    }
}