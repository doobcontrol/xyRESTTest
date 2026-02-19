using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTestLib;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace xyRESTTest
{
    public partial class UcTestCase : UserControl
    {
        TestTask testTask;
        public TestTask TestTask { get => testTask; }
        public UcTestCase(TestTask testTask)
        {
            InitializeComponent();
            this.testTask = testTask;
            LbCaseName.BackColor = UcTestCaseItem.selectedBackColor;
            LbCaseName.Text = testTask.name;
            toolTip1.SetToolTip(LbCaseName, "Double-click to edit");

            TxtUrl.Leave += (s, e) =>
            {
                if (TxtUrl.Text != testTask.requestInfo?.url)
                {
                    this.testTask.requestInfo.url = TxtUrl.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            };
            TxtUrl.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter && TxtUrl.Text != testTask.requestInfo?.url)
                {
                    this.testTask.requestInfo.url = TxtUrl.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            };
            splitter1.Visible = false;
            GbBody.Visible = false;
            UiTools.FillCbWithEnum(CmbMethod, typeof(ReqMethod));
            CmbMethod.TextChanged += (s, e) =>
            {
                if (
                    CmbMethod.Text == nameof(ReqMethod.GET)
                    || CmbMethod.Text == nameof(ReqMethod.DELETE))
                {
                    PnlBody.Controls.Clear();
                    testTask.requestInfo.body = null;
                    splitter1.Visible = false;
                    GbBody.Visible = false;
                }
                else
                {
                    splitter1.Visible = true;
                    GbBody.Visible = true;
                }
                if (CmbMethod.Text != testTask.requestInfo.method)
                {
                    this.testTask.requestInfo.method = CmbMethod.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            };

            CmbBodyType.Items.Clear();
            CmbBodyType.Items.Add(xyTest.CT_app_json);

            deplopData();
        }

        private void TsbAddHeader_Click(object sender, EventArgs e)
        {
            if (testTask.requestInfo.headers == null)
            {
                testTask.requestInfo.headers = new Dictionary<string, object>();
            }

            var uhi = new UcHeaderItem(null, this);
            uhi.Dock = DockStyle.Top;
            uhi.Edited += Header_edited;
            uhi.Selected += UcHeaderItem_Selected;
            TlpHeaders.Controls.Add(uhi);
        }
        public event EventHandler<EventArgs>? Edited;
        private void Header_edited(object? sender, EventArgs e)
        {
            if (sender is UcHeaderItem uhi)
            {
                testTask.requestInfo.headers[uhi.HeaderName] = uhi.HeaderValue;

                Edited?.Invoke(this, new EventArgs());
            }
        }

        private void deplopData()
        {
            TxtUrl.Text = testTask.requestInfo?.url;
            CmbMethod.Text = testTask.requestInfo?.method;

            if (testTask.requestInfo.headers != null)
            {
                foreach (var header in testTask.requestInfo.headers)
                {
                    var uhi = new UcHeaderItem(header, this);
                    uhi.Dock = DockStyle.Top;
                    uhi.Edited += Header_edited;
                    uhi.Selected += UcHeaderItem_Selected;
                    TlpHeaders.Controls.Add(uhi);
                }
            }
            if (testTask.requestInfo.body != null)
            {
                CmbBodyType.Text = testTask.requestInfo.body.ctype;
            }

            foreach (var assertInfo in testTask.assertInfos)
            {
                var uai = new UcAssertItem(assertInfo, this);
                uai.Dock = DockStyle.Top;
                uai.Edited += Assert_edited;
                uai.Selected += UcAssertItem_Selected;
                PnlAssertItems.Controls.Add(uai);
            }
        }

        private void EditCaseName(bool startEdit)
        {
            LbCaseName.Visible = !startEdit;
            TxtCaseName.Visible = startEdit;
            if (startEdit)
            {
                TxtCaseName.Text = LbCaseName.Text;
                TxtCaseName.Focus();
                TxtCaseName.SelectAll();
            }
            else
            {
                if (TxtCaseName.Text != testTask.name)
                {
                    testTask.name = TxtCaseName.Text;
                    LbCaseName.Text = TxtCaseName.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            }
        }

        private void LbCaseName_DoubleClick(object sender, EventArgs e)
        {
            EditCaseName(true);
        }

        private void TxtCaseName_Leave(object sender, EventArgs e)
        {
            EditCaseName(false);
        }

        private void TxtCaseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditCaseName(false);
            }
        }

        private void CmbBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CmbBodyType.Text)
            {
                case xyTest.CT_app_json:
                    if (testTask.requestInfo.body == null)
                    {
                        testTask.requestInfo.body = new ContentInfo()
                        {
                            recordData = new Dictionary<string, string>(),
                            ctype = CmbBodyType.Text
                        };
                    }
                    var ujb = new UcJsonBody(testTask.requestInfo.body);
                    ujb.Edited += (s, ev) =>
                    {
                        Edited?.Invoke(this, new EventArgs());
                    };
                    ujb.Dock = DockStyle.Fill;
                    PnlBody.Controls.Clear();
                    PnlBody.Controls.Add(ujb);
                    break;
                default:
                    break;
            }
        }

        private void TsbAddAssert_Click(object sender, EventArgs e)
        {
            var uai = new UcAssertItem(null, this);
            uai.Dock = DockStyle.Top;
            uai.Edited += Assert_edited;
            uai.Selected += UcAssertItem_Selected;
            PnlAssertItems.Controls.Add(uai);
        }
        private void Assert_edited(object? sender, EventArgs e)
        {
            if (sender is UcAssertItem uai)
            {
                if (!testTask.assertInfos.Contains(uai.AssertInfo))
                {
                    testTask.assertInfos.Add(uai.AssertInfo);
                }
                Edited?.Invoke(this, new EventArgs());
            }
        }

        private void TsbDelAssert_Click(object sender, EventArgs e)
        {
            if (selectedAssertItem != null)
            {
                PnlAssertItems.Controls.Remove(selectedAssertItem);
                testTask.assertInfos.Remove(selectedAssertItem.AssertInfo);
                Edited?.Invoke(this, new EventArgs());
            }
        }

        private void TsbDelHeader_Click(object sender, EventArgs e)
        {
            if (selectedHeaderItem != null)
            {
                TlpHeaders.Controls.Remove(selectedHeaderItem);
                testTask.requestInfo.headers.Remove(selectedHeaderItem.HeaderName);
                Edited?.Invoke(this, new EventArgs());
            }
        }

        UcHeaderItem? selectedHeaderItem;
        private void UcHeaderItem_Selected(object? sender, EventArgs e)
        {
            foreach (Control control in TlpHeaders.Controls)
            {
                if (control is UcHeaderItem item)
                {
                    item.SetSelected(item == sender);
                }
            }
            if (sender is UcHeaderItem selected)
            {
                selectedHeaderItem = selected;
            }
        }

        UcAssertItem? selectedAssertItem;
        private void UcAssertItem_Selected(object? sender, EventArgs e)
        {
            foreach (Control control in PnlAssertItems.Controls)
            {
                if (control is UcAssertItem item)
                {
                    item.SetSelected(item == sender);
                }
            }
            if (sender is UcAssertItem selected)
            {
                selectedAssertItem = selected;
            }
        }
    }
}
