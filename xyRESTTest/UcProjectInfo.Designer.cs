namespace xyRESTTest
{
    partial class UcProjectInfo
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
            tableLayoutPanel1 = new TableLayoutPanel();
            LbRootUrl = new Label();
            TxtRootUrl = new TextBox();
            LbPrjName = new Label();
            TxtPrjName = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LbRootUrl, 0, 1);
            tableLayoutPanel1.Controls.Add(TxtRootUrl, 1, 1);
            tableLayoutPanel1.Controls.Add(LbPrjName, 0, 0);
            tableLayoutPanel1.Controls.Add(TxtPrjName, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(388, 58);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // LbRootUrl
            // 
            LbRootUrl.AutoSize = true;
            LbRootUrl.Dock = DockStyle.Right;
            LbRootUrl.Location = new Point(3, 29);
            LbRootUrl.Name = "LbRootUrl";
            LbRootUrl.Size = new Size(38, 29);
            LbRootUrl.TabIndex = 2;
            LbRootUrl.Text = "label2";
            LbRootUrl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TxtRootUrl
            // 
            TxtRootUrl.Dock = DockStyle.Top;
            TxtRootUrl.Location = new Point(47, 32);
            TxtRootUrl.Name = "TxtRootUrl";
            TxtRootUrl.Size = new Size(338, 23);
            TxtRootUrl.TabIndex = 3;
            // 
            // LbPrjName
            // 
            LbPrjName.AutoSize = true;
            LbPrjName.Dock = DockStyle.Right;
            LbPrjName.Location = new Point(3, 0);
            LbPrjName.Name = "LbPrjName";
            LbPrjName.Size = new Size(38, 29);
            LbPrjName.TabIndex = 0;
            LbPrjName.Text = "label1";
            LbPrjName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TxtPrjName
            // 
            TxtPrjName.Dock = DockStyle.Top;
            TxtPrjName.Location = new Point(47, 3);
            TxtPrjName.Name = "TxtPrjName";
            TxtPrjName.Size = new Size(338, 23);
            TxtPrjName.TabIndex = 1;
            // 
            // UcProjectInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UcProjectInfo";
            Size = new Size(388, 298);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label LbRootUrl;
        private TextBox TxtRootUrl;
        private Label LbPrjName;
        private TextBox TxtPrjName;
    }
}
