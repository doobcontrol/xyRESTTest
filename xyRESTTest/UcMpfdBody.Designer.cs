namespace xyRESTTest
{
    partial class UcMpfdBody
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
            TlpFiles = new TableLayoutPanel();
            panel3 = new Panel();
            TxtFileKeyName = new TextBox();
            LbUploadFileKeyName = new Label();
            toolStrip1 = new ToolStrip();
            TsbAddFile = new ToolStripButton();
            TsbDelFile = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            TslFiles = new ToolStripLabel();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            toolStrip2 = new ToolStrip();
            TsbAddFormData = new ToolStripButton();
            TsbDelFormData = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            TslFormData = new ToolStripLabel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(TlpFiles);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 57);
            panel1.TabIndex = 0;
            // 
            // TlpFiles
            // 
            TlpFiles.AutoSize = true;
            TlpFiles.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpFiles.ColumnCount = 1;
            TlpFiles.ColumnStyles.Add(new ColumnStyle());
            TlpFiles.Dock = DockStyle.Top;
            TlpFiles.Location = new Point(0, 57);
            TlpFiles.Name = "TlpFiles";
            TlpFiles.RowCount = 1;
            TlpFiles.RowStyles.Add(new RowStyle());
            TlpFiles.Size = new Size(287, 0);
            TlpFiles.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(TxtFileKeyName);
            panel3.Controls.Add(LbUploadFileKeyName);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 32);
            panel3.TabIndex = 1;
            // 
            // TxtFileKeyName
            // 
            TxtFileKeyName.Location = new Point(84, 6);
            TxtFileKeyName.Name = "TxtFileKeyName";
            TxtFileKeyName.Size = new Size(195, 23);
            TxtFileKeyName.TabIndex = 1;
            // 
            // LbUploadFileKeyName
            // 
            LbUploadFileKeyName.AutoSize = true;
            LbUploadFileKeyName.Location = new Point(3, 9);
            LbUploadFileKeyName.Name = "LbUploadFileKeyName";
            LbUploadFileKeyName.Size = new Size(64, 15);
            LbUploadFileKeyName.TabIndex = 0;
            LbUploadFileKeyName.Text = "Key Name:";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbAddFile, TsbDelFile, toolStripSeparator1, TslFiles });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(287, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbAddFile
            // 
            TsbAddFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddFile.Image = Properties.Resources.Add;
            TsbAddFile.ImageTransparentColor = Color.Magenta;
            TsbAddFile.Name = "TsbAddFile";
            TsbAddFile.Size = new Size(23, 22);
            TsbAddFile.Text = "toolStripButton1";
            TsbAddFile.Click += TsbAddFile_Click;
            // 
            // TsbDelFile
            // 
            TsbDelFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelFile.Image = Properties.Resources.Delete;
            TsbDelFile.ImageTransparentColor = Color.Magenta;
            TsbDelFile.Name = "TsbDelFile";
            TsbDelFile.Size = new Size(23, 22);
            TsbDelFile.Text = "toolStripButton2";
            TsbDelFile.Click += TsbDelFile_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // TslFiles
            // 
            TslFiles.Name = "TslFiles";
            TslFiles.Size = new Size(44, 22);
            TslFiles.Text = "TslFiles";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(toolStrip2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(287, 174);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(287, 149);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { TsbAddFormData, TsbDelFormData, toolStripSeparator2, TslFormData });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(287, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // TsbAddFormData
            // 
            TsbAddFormData.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddFormData.Image = Properties.Resources.Add;
            TsbAddFormData.ImageTransparentColor = Color.Magenta;
            TsbAddFormData.Name = "TsbAddFormData";
            TsbAddFormData.Size = new Size(23, 22);
            TsbAddFormData.Text = "toolStripButton1";
            TsbAddFormData.Click += TsbAddFormData_Click;
            // 
            // TsbDelFormData
            // 
            TsbDelFormData.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelFormData.Image = Properties.Resources.Delete;
            TsbDelFormData.ImageTransparentColor = Color.Magenta;
            TsbDelFormData.Name = "TsbDelFormData";
            TsbDelFormData.Size = new Size(23, 22);
            TsbDelFormData.Text = "toolStripButton2";
            TsbDelFormData.Click += TsbDelFormData_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // TslFormData
            // 
            TslFormData.Name = "TslFormData";
            TslFormData.Size = new Size(73, 22);
            TslFormData.Text = "TslFormData";
            // 
            // UcMpfdBody
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(287, 231);
            Name = "UcMpfdBody";
            Size = new Size(287, 231);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton TsbAddFile;
        private ToolStripButton TsbDelFile;
        private ToolStripLabel TslFiles;
        private Panel panel2;
        private ToolStrip toolStrip2;
        private ToolStripButton TsbAddFormData;
        private ToolStripButton TsbDelFormData;
        private ToolStripLabel TslFormData;
        private Panel panel3;
        private TextBox TxtFileKeyName;
        private Label LbUploadFileKeyName;
        private DataGridView dataGridView1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private TableLayoutPanel TlpFiles;
    }
}
