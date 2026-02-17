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
                    if (testTask.requestInfo == null)
                    {
                        testTask.requestInfo = new RequestInfo();
                    }
                    testTask.requestInfo.url = TxtUrl.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            };
            TxtUrl.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter && TxtUrl.Text != testTask.requestInfo?.url)
                {
                    if (testTask.requestInfo == null)
                    {
                        testTask.requestInfo = new RequestInfo();
                    }
                    testTask.requestInfo.url = TxtUrl.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            };
            CmbMethod.TextChanged += (s, e) =>
            {
                if (CmbMethod.Text != testTask.requestInfo?.method)
                {
                    if (testTask.requestInfo == null)
                    {
                        testTask.requestInfo = new RequestInfo();
                    }
                    testTask.requestInfo.method = CmbMethod.Text;
                    Edited?.Invoke(this, new EventArgs());
                }
            };

            deplopData();
        }

        private void TsbAddHeader_Click(object sender, EventArgs e)
        {
            if (testTask.requestInfo == null)
            {
                testTask.requestInfo = new RequestInfo()
                {
                    headers = new Dictionary<string, object>()
                };
            }
            if (testTask.requestInfo.headers == null)
            {
                testTask.requestInfo.headers = new Dictionary<string, object>();
            }

            var uhi = new UcHeaderItem(null, this);
            uhi.Dock = DockStyle.Top;
            uhi.Edited += Header_edited;
            TlpHeaders.Controls.Add(uhi);
        }
        public event EventHandler<EventArgs>? Edited;
        private void Header_edited(object? sender, EventArgs e)
        {
            if (sender is UcHeaderItem uhi)
            {
                if (uhi.HeaderName != null)
                {
                    if (testTask.requestInfo.headers.ContainsKey(uhi.HeaderName))
                    {
                        testTask.requestInfo.headers[uhi.HeaderName] = uhi.HeaderValue;
                    }
                    else
                    {
                        testTask.requestInfo.headers.Add(uhi.HeaderName, uhi.HeaderValue);
                    }

                    Edited?.Invoke(this, new EventArgs());
                }
            }
        }

        private void deplopData()
        {
            if (testTask != null)
            {
                TxtUrl.Text = testTask.requestInfo?.url;
                CmbMethod.Text = testTask.requestInfo?.method;
                if (testTask.requestInfo != null)
                {
                    if (testTask.requestInfo.headers != null)
                    {
                        foreach (var header in testTask.requestInfo.headers)
                        {
                            var uhi = new UcHeaderItem(header, this);
                            uhi.Dock = DockStyle.Top;
                            uhi.Edited += Header_edited;
                            TlpHeaders.Controls.Add(uhi);
                        }
                    }
                    if (testTask.requestInfo.body != null)
                    {
                        CmbBodyType.Text = testTask.requestInfo.body.ctype;
                    }
                }
                if (testTask.assertInfos != null)
                {
                    foreach (var assertInfo in testTask.assertInfos)
                    {
                        var uai = new UcAssertItem(assertInfo, this);
                        uai.Dock = DockStyle.Top;
                        uai.Edited += Assert_edited;
                        PnlAssertItems.Controls.Add(uai);
                    }
                }
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
                case "application/json":
                    if (testTask.requestInfo.body == null)
                    {
                        testTask.requestInfo.body = new ContentInfo()
                        {
                            recordData = new Dictionary<string, string>(),
                            ctype = "application/json"
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
            if (testTask.assertInfos == null)
            {
                testTask.assertInfos = new List<AssertInfo>();
            }

            var uai = new UcAssertItem(null, this);
            uai.Dock = DockStyle.Top;
            uai.Edited += Assert_edited;
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

        }
    }
}
