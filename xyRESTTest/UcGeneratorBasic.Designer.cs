namespace xyRESTTest
{
    partial class UcGeneratorBasic
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
            DgvRecords = new DataGridView();
            LbTableTitle = new Label();
            toolStrip4 = new ToolStrip();
            TsbAddRecord = new ToolStripButton();
            TsbDelRecord = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DgvRecords).BeginInit();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // DgvRecords
            // 
            DgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvRecords.Dock = DockStyle.Fill;
            DgvRecords.Location = new Point(0, 44);
            DgvRecords.Margin = new Padding(3, 2, 3, 2);
            DgvRecords.Name = "DgvRecords";
            DgvRecords.RowHeadersWidth = 51;
            DgvRecords.Size = new Size(302, 68);
            DgvRecords.TabIndex = 9;
            DgvRecords.CellEndEdit += DgvRecords_CellEndEdit;
            // 
            // LbTableTitle
            // 
            LbTableTitle.Dock = DockStyle.Top;
            LbTableTitle.Location = new Point(0, 27);
            LbTableTitle.Name = "LbTableTitle";
            LbTableTitle.Size = new Size(302, 17);
            LbTableTitle.TabIndex = 8;
            LbTableTitle.Text = "Test Data Records";
            LbTableTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toolStrip4
            // 
            toolStrip4.ImageScalingSize = new Size(20, 20);
            toolStrip4.Items.AddRange(new ToolStripItem[] { TsbAddRecord, TsbDelRecord });
            toolStrip4.Location = new Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(302, 27);
            toolStrip4.Stretch = true;
            toolStrip4.TabIndex = 7;
            toolStrip4.Text = "toolStrip4";
            // 
            // TsbAddRecord
            // 
            TsbAddRecord.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddRecord.Image = Properties.Resources.Add;
            TsbAddRecord.ImageTransparentColor = Color.Magenta;
            TsbAddRecord.Name = "TsbAddRecord";
            TsbAddRecord.Size = new Size(24, 24);
            TsbAddRecord.Text = "Add a test data record";
            TsbAddRecord.Click += TsbAddRecord_Click;
            // 
            // TsbDelRecord
            // 
            TsbDelRecord.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelRecord.Image = Properties.Resources.Delete;
            TsbDelRecord.ImageTransparentColor = Color.Magenta;
            TsbDelRecord.Name = "TsbDelRecord";
            TsbDelRecord.Size = new Size(24, 24);
            TsbDelRecord.Text = "Delete selected data record";
            TsbDelRecord.Click += TsbDelRecord_Click;
            // 
            // UcGeneratorBasic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DgvRecords);
            Controls.Add(LbTableTitle);
            Controls.Add(toolStrip4);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UcGeneratorBasic";
            Size = new Size(302, 112);
            ((System.ComponentModel.ISupportInitialize)DgvRecords).EndInit();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvRecords;
        private Label LbTableTitle;
        private ToolStrip toolStrip4;
        private ToolStripButton TsbAddRecord;
        private ToolStripButton TsbDelRecord;
    }
}
