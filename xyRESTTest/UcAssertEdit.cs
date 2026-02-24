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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace xyRESTTest
{
    public partial class UcAssertEdit : UserControl
    {
        AssertInfo assertInfo;
        public event EventHandler<EventArgs>? Edited;
        private Control assertValueEdit;
        ContextMenuStrip contextMenuStrip;

        public UcAssertEdit(AssertInfo assertInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();
            this.contextMenuStrip = contextMenuStrip;
            LoadStringResources();
            UiTools.FillCbWithEnum(comboBox1, typeof(AssertType));
            Leave += (s, e) => { Hide(); };

            this.assertInfo = assertInfo;

            comboBox1.Text = this.assertInfo.assertType;
        }
        public void LoadStringResources()
        {
            BtnOk.Text = Resources.strOk;
            BtnCancel.Text = Resources.strCancel;
            if (panel3.Controls.Count > 0)
            {
                var assertEdit = panel3.Controls[0];
                if (assertEdit is UcAssertStatusCode uasc)
                {
                    uasc.LoadStringResources();
                }
                else if (assertEdit is UcAssertJsonContent uajc)
                {
                    uajc.LoadStringResources();
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Edited?.Invoke(this, new EventArgs());

            Hide();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            assertInfo.assertType = comboBox1.Text;
            if (comboBox1.Text == nameof(AssertType.StatusCode))
            {
                assertValueEdit = new UcAssertStatusCode(assertInfo, contextMenuStrip)
                { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(assertValueEdit);
                this.Refresh();
            }
            else if (comboBox1.Text == nameof(AssertType.JsonContent))
            {
                assertValueEdit = new UcAssertJsonContent(assertInfo, contextMenuStrip)
                { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(assertValueEdit);
                this.Refresh();
            }
        }
    }
}
