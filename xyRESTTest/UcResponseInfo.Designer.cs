namespace xyRESTTest
{
    partial class UcResponseInfo
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
            CbResponses = new ComboBox();
            TlpResponse = new TableLayoutPanel();
            SuspendLayout();
            // 
            // CbResponses
            // 
            CbResponses.Dock = DockStyle.Top;
            CbResponses.FormattingEnabled = true;
            CbResponses.Location = new Point(0, 0);
            CbResponses.Name = "CbResponses";
            CbResponses.Size = new Size(150, 23);
            CbResponses.TabIndex = 0;
            CbResponses.SelectedIndexChanged += CbResponses_SelectedIndexChanged;
            // 
            // TlpResponse
            // 
            TlpResponse.ColumnCount = 2;
            TlpResponse.ColumnStyles.Add(new ColumnStyle());
            TlpResponse.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpResponse.Dock = DockStyle.Fill;
            TlpResponse.Location = new Point(0, 23);
            TlpResponse.Name = "TlpResponse";
            TlpResponse.RowCount = 4;
            TlpResponse.RowStyles.Add(new RowStyle());
            TlpResponse.RowStyles.Add(new RowStyle());
            TlpResponse.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpResponse.RowStyles.Add(new RowStyle());
            TlpResponse.Size = new Size(150, 127);
            TlpResponse.TabIndex = 1;
            // 
            // UcResponseInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TlpResponse);
            Controls.Add(CbResponses);
            Name = "UcResponseInfo";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CbResponses;
        private TableLayoutPanel TlpResponse;
    }
}
