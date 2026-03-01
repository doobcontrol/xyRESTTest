using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTest.Properties;
using xyRESTTestLib;

namespace xyRESTTest
{
    public partial class UcOctetStreamBody : UserControl
    {
        ContentInfo contentInfo;
        public event EventHandler<EventArgs>? Edited;
        ContextMenuStrip contextMenuStrip;
        public UcOctetStreamBody(ContentInfo? contentInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();

            this.contextMenuStrip = contextMenuStrip;
            this.contentInfo = contentInfo ?? new ContentInfo();
            LbFile.Text = this.contentInfo.fileDatas[0];
        }

        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;
                if (contentInfo.fileDatas.Contains(filePath))
                {
                    MessageBox.Show(Resources.strFileAlreadyAdded);
                    return;
                }

                contentInfo.fileDatas[0] = filePath;
                LbFile.Text = filePath;

                Edited?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
