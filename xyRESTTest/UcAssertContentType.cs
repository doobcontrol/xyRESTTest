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
    public partial class UcAssertContentType : UserControl
    {
        AssertInfo assertInfo;
        public UcAssertContentType(AssertInfo assertInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();
            LoadStringResources();

            LbFile.Text = "";
            PnlFile.Visible = false;
            this.assertInfo = assertInfo;
            CbContentType.Text = assertInfo.expected;
            CbContentType.ContextMenuStrip = contextMenuStrip;
            if (assertInfo.saveFilePath != null)
            {
                cbSaveFile.Checked = assertInfo.saveFilePath != null;
                LbFile.Text = assertInfo.saveFilePath;
            }

            foreach (var item in xyTest.BinaryContentTypeList)
            {
                CbContentType.Items.Add(item);
            }
            CbContentType.TextChanged += (s, e) =>
            {
                assertInfo.expected = CbContentType.Text;
            };
        }
        public void LoadStringResources()
        {
            cbSaveFile.Text = Resources.strSaveToFile;
        }
        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string downloadFolder = 
                Path.Combine(Directory.GetCurrentDirectory(), xyTest.Download_file_dir);
            if (!Directory.Exists(downloadFolder)) { 
                Directory.CreateDirectory(downloadFolder);
            }
            sfd.InitialDirectory = downloadFolder;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;
                string projectDir = Directory.GetCurrentDirectory();
                if(UiTools.IsSubdirectoryOf(projectDir, fileName))
                {
                    fileName = Path.GetRelativePath(projectDir, fileName);
                }

                LbFile.Text = fileName;
                assertInfo.saveFilePath = fileName;
            }
        }

        private void cbSaveFile_CheckedChanged(object sender, EventArgs e)
        {
            PnlFile.Visible = cbSaveFile.Checked;
            if (!PnlFile.Visible)
            {
                LbFile.Text = "";
                assertInfo.saveFilePath = null;
            }
        }
    }
}
