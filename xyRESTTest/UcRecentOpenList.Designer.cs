namespace xyRESTTest
{
    partial class UcRecentOpenList
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
            LbTitle = new Label();
            TlpProjectsList = new TableLayoutPanel();
            SuspendLayout();
            // 
            // LbTitle
            // 
            LbTitle.Dock = DockStyle.Top;
            LbTitle.Location = new Point(0, 0);
            LbTitle.Name = "LbTitle";
            LbTitle.Size = new Size(150, 20);
            LbTitle.TabIndex = 0;
            LbTitle.Text = "label1";
            LbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TlpProjectsList
            // 
            TlpProjectsList.AutoSize = true;
            TlpProjectsList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TlpProjectsList.ColumnCount = 1;
            TlpProjectsList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpProjectsList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpProjectsList.Dock = DockStyle.Top;
            TlpProjectsList.Location = new Point(0, 20);
            TlpProjectsList.Name = "TlpProjectsList";
            TlpProjectsList.RowCount = 1;
            TlpProjectsList.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TlpProjectsList.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TlpProjectsList.Size = new Size(150, 0);
            TlpProjectsList.TabIndex = 1;
            // 
            // UcRecentOpenList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TlpProjectsList);
            Controls.Add(LbTitle);
            Name = "UcRecentOpenList";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbTitle;
        private TableLayoutPanel TlpProjectsList;
    }
}
