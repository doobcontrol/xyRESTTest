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
            label5 = new Label();
            toolStrip4 = new ToolStrip();
            TsbAddRecord = new ToolStripButton();
            TsbDelRecord = new ToolStripButton();
            TsbDataFile = new ToolStripButton();
            TslDataFile = new ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)DgvRecords).BeginInit();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // DgvRecords
            // 
            DgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvRecords.Dock = DockStyle.Fill;
            DgvRecords.Location = new Point(0, 50);
            DgvRecords.Name = "DgvRecords";
            DgvRecords.RowHeadersWidth = 51;
            DgvRecords.Size = new Size(231, 100);
            DgvRecords.TabIndex = 9;
            DgvRecords.CellEndEdit += DgvRecords_CellEndEdit;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(0, 27);
            label5.Name = "label5";
            label5.Size = new Size(231, 23);
            label5.TabIndex = 8;
            label5.Text = "Test Data Records";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toolStrip4
            // 
            toolStrip4.ImageScalingSize = new Size(20, 20);
            toolStrip4.Items.AddRange(new ToolStripItem[] { TsbAddRecord, TsbDelRecord, TsbDataFile, TslDataFile });
            toolStrip4.Location = new Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(231, 27);
            toolStrip4.TabIndex = 7;
            toolStrip4.Text = "toolStrip4";
            // 
            // TsbAddRecord
            // 
            TsbAddRecord.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddRecord.Image = Properties.Resources.Add;
            TsbAddRecord.ImageTransparentColor = Color.Magenta;
            TsbAddRecord.Name = "TsbAddRecord";
            TsbAddRecord.Size = new Size(29, 24);
            TsbAddRecord.Text = "Add a test data record";
            TsbAddRecord.Click += TsbAddRecord_Click;
            // 
            // TsbDelRecord
            // 
            TsbDelRecord.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelRecord.Image = Properties.Resources.Delete;
            TsbDelRecord.ImageTransparentColor = Color.Magenta;
            TsbDelRecord.Name = "TsbDelRecord";
            TsbDelRecord.Size = new Size(29, 24);
            TsbDelRecord.Text = "Delete selected data record";
            TsbDelRecord.Click += TsbDelRecord_Click;
            // 
            // TsbDataFile
            // 
            TsbDataFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDataFile.Image = Properties.Resources.OpenFile;
            TsbDataFile.ImageTransparentColor = Color.Magenta;
            TsbDataFile.Name = "TsbDataFile";
            TsbDataFile.Size = new Size(29, 24);
            TsbDataFile.Text = "Set test data file";
            TsbDataFile.Click += TsbDataFile_Click;
            // 
            // TslDataFile
            // 
            TslDataFile.Name = "TslDataFile";
            TslDataFile.Overflow = ToolStripItemOverflow.Never;
            TslDataFile.Size = new Size(111, 24);
            TslDataFile.Text = "toolStripLabel1";
            // 
            // UcGeneratorBasic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DgvRecords);
            Controls.Add(label5);
            Controls.Add(toolStrip4);
            Name = "UcGeneratorBasic";
            Size = new Size(231, 150);
            ((System.ComponentModel.ISupportInitialize)DgvRecords).EndInit();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvRecords;
        private Label label5;
        private ToolStrip toolStrip4;
        private ToolStripButton TsbAddRecord;
        private ToolStripButton TsbDelRecord;
        private ToolStripButton TsbDataFile;
        private ToolStripLabel TslDataFile;
    }
}
