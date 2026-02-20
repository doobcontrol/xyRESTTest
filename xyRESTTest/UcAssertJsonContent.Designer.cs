namespace xyRESTTest
{
    partial class UcAssertJsonContent
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
            DgvAssert = new DataGridView();
            TsAssert = new ToolStrip();
            TsbAddAssertList = new ToolStripButton();
            TsbDelAssertList = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            panel2 = new Panel();
            DgvRead = new DataGridView();
            TsRead = new ToolStrip();
            TsbAddReadList = new ToolStripButton();
            TsbDelReadList = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAssert).BeginInit();
            TsAssert.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvRead).BeginInit();
            TsRead.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(DgvAssert);
            panel1.Controls.Add(TsAssert);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 27);
            panel1.TabIndex = 1;
            // 
            // DgvAssert
            // 
            DgvAssert.AllowUserToAddRows = false;
            DgvAssert.AllowUserToDeleteRows = false;
            DgvAssert.AllowUserToResizeRows = false;
            DgvAssert.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvAssert.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAssert.Dock = DockStyle.Top;
            DgvAssert.Location = new Point(0, 27);
            DgvAssert.Name = "DgvAssert";
            DgvAssert.RowHeadersVisible = false;
            DgvAssert.RowHeadersWidth = 51;
            DgvAssert.Size = new Size(212, 0);
            DgvAssert.TabIndex = 3;
            // 
            // TsAssert
            // 
            TsAssert.ImageScalingSize = new Size(20, 20);
            TsAssert.Items.AddRange(new ToolStripItem[] { TsbAddAssertList, TsbDelAssertList, toolStripSeparator1, toolStripLabel2 });
            TsAssert.Location = new Point(0, 0);
            TsAssert.Name = "TsAssert";
            TsAssert.Size = new Size(212, 27);
            TsAssert.TabIndex = 2;
            TsAssert.Text = "toolStrip1";
            // 
            // TsbAddAssertList
            // 
            TsbAddAssertList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddAssertList.Image = Properties.Resources.Add;
            TsbAddAssertList.ImageTransparentColor = Color.Magenta;
            TsbAddAssertList.Name = "TsbAddAssertList";
            TsbAddAssertList.Size = new Size(29, 24);
            TsbAddAssertList.Text = "Add an assertion";
            TsbAddAssertList.Click += TsbAddAssertList_Click;
            // 
            // TsbDelAssertList
            // 
            TsbDelAssertList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelAssertList.Image = Properties.Resources.Delete;
            TsbDelAssertList.ImageTransparentColor = Color.Magenta;
            TsbDelAssertList.Name = "TsbDelAssertList";
            TsbDelAssertList.Size = new Size(29, 24);
            TsbDelAssertList.Text = "Delete selected assertion";
            TsbDelAssertList.Click += TsbDelAssertList_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(96, 24);
            toolStripLabel2.Text = "Assertion List";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(DgvRead);
            panel2.Controls.Add(TsRead);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(212, 27);
            panel2.TabIndex = 2;
            // 
            // DgvRead
            // 
            DgvRead.AllowUserToAddRows = false;
            DgvRead.AllowUserToDeleteRows = false;
            DgvRead.AllowUserToResizeRows = false;
            DgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvRead.Dock = DockStyle.Top;
            DgvRead.Location = new Point(0, 27);
            DgvRead.Name = "DgvRead";
            DgvRead.RowHeadersVisible = false;
            DgvRead.RowHeadersWidth = 51;
            DgvRead.Size = new Size(212, 0);
            DgvRead.TabIndex = 3;
            // 
            // TsRead
            // 
            TsRead.ImageScalingSize = new Size(20, 20);
            TsRead.Items.AddRange(new ToolStripItem[] { TsbAddReadList, TsbDelReadList, toolStripSeparator2, toolStripLabel1 });
            TsRead.Location = new Point(0, 0);
            TsRead.Name = "TsRead";
            TsRead.Size = new Size(212, 27);
            TsRead.TabIndex = 2;
            TsRead.Text = "toolStrip2";
            // 
            // TsbAddReadList
            // 
            TsbAddReadList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddReadList.Image = Properties.Resources.Add;
            TsbAddReadList.ImageTransparentColor = Color.Magenta;
            TsbAddReadList.Name = "TsbAddReadList";
            TsbAddReadList.Size = new Size(29, 24);
            TsbAddReadList.Text = "Add a read data item";
            TsbAddReadList.Click += TsbAddReadList_Click;
            // 
            // TsbDelReadList
            // 
            TsbDelReadList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelReadList.Image = Properties.Resources.Delete;
            TsbDelReadList.ImageTransparentColor = Color.Magenta;
            TsbDelReadList.Name = "TsbDelReadList";
            TsbDelReadList.Size = new Size(29, 24);
            TsbDelReadList.Text = "Delete selected read data item";
            TsbDelReadList.Click += TsbDelReadList_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(105, 24);
            toolStripLabel1.Text = "Read Data List";
            // 
            // UcAssertJsonContent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(214, 0);
            Name = "UcAssertJsonContent";
            Size = new Size(212, 54);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvAssert).EndInit();
            TsAssert.ResumeLayout(false);
            TsAssert.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvRead).EndInit();
            TsRead.ResumeLayout(false);
            TsRead.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView DgvAssert;
        private ToolStrip TsAssert;
        private ToolStripButton TsbAddAssertList;
        private ToolStripButton TsbDelAssertList;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private Panel panel2;
        private DataGridView DgvRead;
        private ToolStrip TsRead;
        private ToolStripButton TsbAddReadList;
        private ToolStripButton TsbDelReadList;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel1;
    }
}
