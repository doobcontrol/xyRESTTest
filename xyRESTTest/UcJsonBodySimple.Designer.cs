namespace xyRESTTest
{
    partial class UcJsonBodySimple
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
            toolStrip1 = new ToolStrip();
            TsbAddPar = new ToolStripButton();
            TsbDelPar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            TxtContent = new TextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TsbAddPar, TsbDelPar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(262, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // TsbAddPar
            // 
            TsbAddPar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbAddPar.Image = Properties.Resources.Add;
            TsbAddPar.ImageTransparentColor = Color.Magenta;
            TsbAddPar.Name = "TsbAddPar";
            TsbAddPar.Size = new Size(24, 24);
            TsbAddPar.Text = "Add a JSON value";
            TsbAddPar.Click += TsbAddPar_Click;
            // 
            // TsbDelPar
            // 
            TsbDelPar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TsbDelPar.Image = Properties.Resources.Delete;
            TsbDelPar.ImageTransparentColor = Color.Magenta;
            TsbDelPar.Name = "TsbDelPar";
            TsbDelPar.Size = new Size(24, 24);
            TsbDelPar.Text = "Delete selected JSON value";
            TsbDelPar.Click += TsbDelPar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(TxtContent);
            splitContainer1.Size = new Size(262, 85);
            splitContainer1.SplitterDistance = 150;
            splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(150, 85);
            dataGridView1.TabIndex = 0;
            // 
            // TxtContent
            // 
            TxtContent.Dock = DockStyle.Fill;
            TxtContent.Location = new Point(0, 0);
            TxtContent.Margin = new Padding(3, 2, 3, 2);
            TxtContent.Multiline = true;
            TxtContent.Name = "TxtContent";
            TxtContent.ReadOnly = true;
            TxtContent.Size = new Size(108, 85);
            TxtContent.TabIndex = 0;
            // 
            // UcJsonBodySimple
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(262, 112);
            Name = "UcJsonBodySimple";
            Size = new Size(262, 112);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton TsbAddPar;
        private SplitContainer splitContainer1;
        private ToolStripButton TsbDelPar;
        private DataGridView dataGridView1;
        private TextBox TxtContent;
    }
}
