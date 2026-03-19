using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTest.Properties;
using xyRESTTestLib;

namespace xyRESTTest
{
    public partial class UcTestCase : UserControl
    {
        TestTask testTask;
        public TestTask TestTask { get => testTask; }
        ContextMenuStrip contextMenuStrip;

        public event EventHandler<EventArgs>? Edited;
        public event EventHandler<EditPermitCheckEventArgs>? PrepareEdited;

        public UcTestCase(
            TestTask testTask, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SuspendLayout();

            LoadStringResources();
            this.testTask = testTask;
            LbCaseName.BackColor = UcTestCaseItem.selectedBackColor;
            LbCaseName.Text = testTask.name;

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
            foreach (var ctype in xyTest.ContentTypeList)
            {
                CmbBodyType.Items.Add(ctype);
            }

            UiTools.FillCbWithEnum(CbGeneratorType, typeof(GeneratorType));
            DgvParameters.AllowUserToAddRows = false;
            DgvParameters.AllowUserToDeleteRows = false;
            DgvParameters.AllowUserToResizeRows = false;
            DgvParameters.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            DgvParameters.RowHeadersVisible = false;
            DgvParameters.ColumnHeadersVisible = false;
            DgvParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvParameters.MultiSelect = false;
            DgvParameters.Columns.Add("Parameter", "Parameter");

            editorSelector = new ComboBox();
            editorSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            editorSelector.Dock = DockStyle.Top;
            UiTools.FillCbWithEnum(editorSelector, typeof(HeaderType));
            editorSelector.SelectedIndexChanged += editorSelector_SelectedIndexChanged;

            this.contextMenuStrip = contextMenuStrip;
            TxtUrl.ContextMenuStrip = contextMenuStrip;

            CbHumanIntervention.CheckedChanged += (s, e) =>
            {
                PnlHumanInterventionSelector.Visible = CbHumanIntervention.Checked;
                if (CbHumanIntervention.Checked)
                {
                    if(testTask.HumanInterventions == null)
                    {
                        testTask.HumanInterventions = new List<string>();
                        Edited?.Invoke(this, new EventArgs());
                    }
                }
                else
                {
                    if (testTask.HumanInterventions != null)
                    {
                        testTask.HumanInterventions = null;
                        Edited?.Invoke(this, new EventArgs());
                    }
                }
            };
            PnlHumanInterventionSelector.Controls.Clear();
            Enum.GetNames(typeof(HumanInterventionType)).ToList().ForEach(name =>
            {
                var cb = new CheckBox()
                {
                    Text = name,
                    AutoSize = true,
                };
                cb.CheckedChanged += (s, e) =>
                {
                    var senderCb = s as CheckBox;
                    if (senderCb.Checked)
                    {
                        if (!testTask.HumanInterventions.Contains(name))
                        {
                            testTask.HumanInterventions.Add(senderCb.Text);
                            Edited?.Invoke(this, new EventArgs());
                        }
                    }
                    else
                    {
                        if (testTask.HumanInterventions.Contains(name))
                        {
                            testTask.HumanInterventions.Remove(senderCb.Text);
                            Edited?.Invoke(this, new EventArgs());
                        }
                    }
                };
                PnlHumanInterventionSelector.Controls.Add(cb);
            });

            deployData();
            this.ResumeLayout();
        }
        public void LoadStringResources()
        {
            toolTip1.SetToolTip(LbCaseName, Resources.strDoubleClickToEdit);
            toolTip1.ShowAlways = true;

            tabRequest.Text = Resources.strRequestInformation;
            tabAssert.Text = Resources.strAssertionInformation;
            tabHuman.Text = Resources.strHumanIntervention;
            tabData.Text = Resources.strDataGenerator;

            TsbAddHeader.ToolTipText = Resources.strAddHeader;
            TsbDelHeader.ToolTipText = Resources.strDeleteHeader;
            TsbAddAssert.ToolTipText = Resources.strAddAssertion;
            TsbDelAssert.ToolTipText = Resources.strDeleteAssertion;

            foreach(Control control in TlpHeaders.Controls)
            {
                if(control is UcHeaderItem uhi)
                {
                    uhi.LoadStringResources();
                }
            }
            foreach(Control control in PnlAssertItems.Controls)
            {
                if(control is UcAssertItem uai)
                {
                    uai.LoadStringResources();
                }
            }
            LbContentType.Text = Resources.strContentType;

            if (PnlBody.Controls.Count > 0)
            {
                if (PnlBody.Controls[0] is UcJsonBody ujb)
                {
                    ujb.LoadStringResources();
                }
                else if (PnlBody.Controls[0] is UcMpfdBody umb)
                {
                    umb.LoadStringResources();
                }
                else if (PnlBody.Controls[0] is UcOctetStreamBody uosb)
                {
                    uosb.LoadStringResources();
                }
            }
            CbDataGenerator.Text = Resources.strDynamicallyGenerateTestCase;
            LbParameters.Text = Resources.strParameters;
            TsbAddParam.ToolTipText = Resources.strAddParameter;
            TsbDelParam.ToolTipText = Resources.strDeleteParameter;
            if(PnlRecords.Controls.Count > 0)
            {
                if(PnlRecords.Controls[0] is UcGeneratorBasic ugb)
                {
                    ugb.LoadStringResources();
                }
            }

            if(responsePage != null)
            {
                responsePage.Text = Resources.strTestResponseResult;
            }

            CbHumanIntervention.Text = Resources.strHumanIntervention;
        }

        private void deployData()
        {
            TxtUrl.Text = testTask.requestInfo?.url;
            CmbMethod.Text = testTask.requestInfo?.method;

            if (testTask.requestInfo.headers != null)
            {
                TlpHeaders.SuspendLayout();
                foreach (var header in testTask.requestInfo.headers)
                {
                    editorSelector?.Items.Remove(header.Key);
                    TsbAddHeader.Visible = editorSelector.Items.Count > 0;
                    var uhi = new UcHeaderItem(header, editorSelector, contextMenuStrip, this);
                    uhi.Visible = false;
                    uhi.Dock = DockStyle.Top;
                    uhi.Edited += Header_edited;
                    uhi.Selected += UcHeaderItem_Selected;
                    TlpHeaders.Controls.Add(uhi);
                    uhi.Visible = true;
                }
                TlpHeaders.ResumeLayout();
            }
            if (testTask.requestInfo.body != null)
            {
                CmbBodyType.Text = testTask.requestInfo.body.ctype;
            }

            CbHumanIntervention.Checked = testTask.HumanInterventions != null;
            if (CbHumanIntervention.Checked)
            {
                var hicbEditDic = new Dictionary<CheckBox, bool>();
                foreach(var hi in testTask.HumanInterventions)
                {
                    foreach(var cb in PnlHumanInterventionSelector.Controls)
                    {
                        if(cb is CheckBox cbhi)
                        {
                            hicbEditDic[cbhi] = cbhi.Text == hi;
                        }
                    }
                }
                foreach(var hichEdit in hicbEditDic)
                {
                    hichEdit.Key.Checked = hichEdit.Value;
                }
            }

            deployAssertData();

            deployGeneratorData(); 
        }

        #region EditCaseName

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
                    var cea= new EditPermitCheckEventArgs(
                        EditPermitCheck.CaseNameDuplicate,
                        TxtCaseName.Text
                        ) ;
                    PrepareEdited?.Invoke(this, cea);
                    if (cea.Cancel)
                    {
                        TxtCaseName.Text = testTask.name;
                        return;
                    }
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
            else if (e.KeyCode == Keys.Escape)
            {
                TxtCaseName.Text = LbCaseName.Text;
                LbCaseName.Visible = true;
                TxtCaseName.Visible = false;
            }
        }

        #endregion

        #region Header

        private ComboBox? editorSelector;
        private void editorSelector_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (editorSelector.SelectedItem != null && editorSelector.Tag != null)
            {
                if (editorSelector.Tag is UcHeaderEdit uhe)
                {
                    uhe.setEditor();
                }
            }
        }
        private void TsbAddHeader_Click(object sender, EventArgs e)
        {
            if (testTask.requestInfo.headers == null)
            {
                testTask.requestInfo.headers = new Dictionary<string, object>();
            }

            var uhi = new UcHeaderItem(null, editorSelector, contextMenuStrip, this);
            uhi.Dock = DockStyle.Top;
            uhi.Edited += Header_edited;
            uhi.Selected += UcHeaderItem_Selected;
            uhi.Uhe.editorSelectorCountChanged += (s, ev) =>
            {
                TsbAddHeader.Visible = editorSelector.Items.Count > 0;
            };
            TlpHeaders.Controls.Add(uhi);
            TsbAddHeader.Visible = false;
        }
        private void Header_edited(object? sender, EventArgs e)
        {
            if (sender is UcHeaderItem uhi)
            {
                testTask.requestInfo.headers[uhi.HeaderName] = uhi.HeaderValue;

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
                if (!selectedHeaderItem.IsNew)
                {
                    editorSelector?.Items.Add(selectedHeaderItem.HeaderName);
                }
                TsbAddHeader.Visible = true;
                editorSelector.Tag = null;
                selectedHeaderItem.clear();
                selectedHeaderItem.Dispose();
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

        #endregion

        #region Body
        
        string? selectedBodyType = null;
        Dictionary<string, ContentInfo> bufferedContentInfos = new();

        private void CmbBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbBodyType.Text == selectedBodyType)
            {
                return;
            }
            switch (CmbBodyType.Text)
            {
                case xyTest.CT_app_json:
                    if(testTask.requestInfo.body == null 
                        || testTask.requestInfo.body.ctype != CmbBodyType.Text)
                    {
                        if (bufferedContentInfos.ContainsKey(CmbBodyType.Text))
                        {
                            testTask.requestInfo.body = bufferedContentInfos[CmbBodyType.Text];
                        }
                        else
                        {
                            testTask.requestInfo.body = new ContentInfo()
                            {
                                recordData = new Dictionary<string, string>(),
                                ctype = CmbBodyType.Text
                            };
                            bufferedContentInfos[CmbBodyType.Text] = testTask.requestInfo.body;
                        }
                    }
                    else if (testTask.requestInfo.body != null)
                    {
                        bufferedContentInfos[testTask.requestInfo.body.ctype] =
                            testTask.requestInfo.body;
                    }

                    var ujb = new UcJsonBody(testTask.requestInfo.body, contextMenuStrip);
                    ujb.Visible = false;
                    ujb.Edited += (s, ev) =>
                    {
                        Edited?.Invoke(this, new EventArgs());
                    };
                    ujb.Dock = DockStyle.Fill;
                    PnlBody.Controls.Clear();
                    PnlBody.Controls.Add(ujb);
                    ujb.Visible = true;
                    selectedBodyType = xyTest.CT_app_json;
                    break;
                case xyTest.CT_multipart_form_data:
                    if (testTask.requestInfo.body == null
                        || testTask.requestInfo.body.ctype != CmbBodyType.Text)
                    {
                        if (bufferedContentInfos.ContainsKey(CmbBodyType.Text))
                        {
                            testTask.requestInfo.body =
                                bufferedContentInfos[CmbBodyType.Text];
                        }
                        else
                        {
                            testTask.requestInfo.body = new ContentInfo()
                            {
                                recordData = new Dictionary<string, string>(),
                                fileDatas = new List<string>(),
                                ctype = CmbBodyType.Text,
                                fileKeyName = "files"
                            };
                            bufferedContentInfos[CmbBodyType.Text] =
                                testTask.requestInfo.body;
                        }
                    }
                    else if (testTask.requestInfo.body != null)
                    {
                        bufferedContentInfos[testTask.requestInfo.body.ctype] =
                            testTask.requestInfo.body;
                    }

                    var umb = new UcMpfdBody(testTask.requestInfo.body, contextMenuStrip);
                    umb.Visible = false;
                    umb.Edited += (s, ev) =>
                    {
                        Edited?.Invoke(this, new EventArgs());
                    };
                    umb.Dock = DockStyle.Fill;
                    PnlBody.Controls.Clear();
                    PnlBody.Controls.Add(umb);
                    umb.Visible = true;
                    selectedBodyType = xyTest.CT_multipart_form_data;
                    break;
                case xyTest.CT_application_octet_stream:
                    if (testTask.requestInfo.body == null
                        || testTask.requestInfo.body.ctype != CmbBodyType.Text)
                    {
                        if (bufferedContentInfos.ContainsKey(CmbBodyType.Text))
                        {
                            testTask.requestInfo.body =
                                bufferedContentInfos[CmbBodyType.Text];
                        }
                        else
                        {
                            testTask.requestInfo.body = new ContentInfo()
                            {
                                fileDatas = new List<string>(),
                                ctype = CmbBodyType.Text
                            };
                            bufferedContentInfos[CmbBodyType.Text] =
                                testTask.requestInfo.body;
                        }
                    }
                    else if (testTask.requestInfo.body != null)
                    {
                        bufferedContentInfos[testTask.requestInfo.body.ctype] =
                            testTask.requestInfo.body;
                    }

                    var uosb = new UcOctetStreamBody(
                        testTask.requestInfo.body, contextMenuStrip);
                    uosb.Visible = false;
                    uosb.Edited += (s, ev) =>
                    {
                        Edited?.Invoke(this, new EventArgs());
                    };
                    uosb.Dock = DockStyle.Top;
                    PnlBody.Controls.Clear();
                    PnlBody.Controls.Add(uosb);
                    uosb.Visible = true;
                    selectedBodyType = xyTest.CT_application_octet_stream;
                    break;
                default:
                    if(selectedBodyType != null)
                    {
                        CmbBodyType.Text = selectedBodyType;
                    }
                    else
                    {
                        testTask.requestInfo.body = null;
                        PnlBody.Controls.Clear();
                    }
                    break;
            }
        }

        #endregion

        #region Assert

        private void TsbAddAssert_Click(object sender, EventArgs e)
        {
            var uai = new UcAssertItem(null, contextMenuStrip, this);
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
                selectedAssertItem.clear();
                selectedAssertItem.Dispose();
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

        private void deployAssertData()
        {
            PnlAssertItems.SuspendLayout();
            foreach (var assertInfo in testTask.assertInfos)
            {
                var uai = new UcAssertItem(assertInfo, contextMenuStrip, this);
                uai.Visible = false;
                uai.Dock = DockStyle.Top;
                uai.Edited += Assert_edited;
                uai.Selected += UcAssertItem_Selected;
                PnlAssertItems.Controls.Add(uai);
                uai.Visible = true;
            }
            PnlAssertItems.ResumeLayout();
        }

        #endregion

        #region Test data generator
        private void CbDataGenerator_CheckedChanged(object sender, EventArgs e)
        {
            if (CbDataGenerator.Checked)
            {
                if (testTask.dataGenerator == null)
                {
                    testTask.dataGenerator = new DataGenerator()
                    {
                        GeneratorType = nameof(GeneratorType.Basic),
                        GeneratorInfo = new Dictionary<string, string>(),
                        ParamList = new List<string>()
                    };
                }
                PnlGenerator.Visible = true;
                CbGeneratorType.Visible = true;
            }
            else
            {
                testTask.dataGenerator = null;
                PnlGenerator.Visible = false;
                CbGeneratorType.Visible = false;
            }
            Edited?.Invoke(this, new EventArgs());
        }

        public interface IGeneratorConfigControl
        {
            void AddAParam(string ParamName);
            void DelAParam(string ParamName);
            void UpdateAParam(string newName, string oldName);
        }
        IGeneratorConfigControl generatorConfigControl;
        private void CbGeneratorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbGeneratorType.Text != null
                && CbGeneratorType.Text != "")
            {
                testTask.dataGenerator.GeneratorType = CbGeneratorType.Text;
                switch (testTask.dataGenerator.GeneratorType)
                {
                    case nameof(GeneratorType.Basic):
                        PnlRecords.Controls.Clear();
                        if (!Directory.Exists(xyTest.Testdata_file_dir))
                        {
                            Directory.CreateDirectory(xyTest.Testdata_file_dir);
                        }
                        if (!testTask.dataGenerator.GeneratorInfo.ContainsKey(
                            xyTest.DGT_Basic_File))
                        {
                            testTask.dataGenerator.GeneratorInfo.Add(
                                xyTest.DGT_Basic_File,
                                Path.Combine(xyTest.Testdata_file_dir, TestTask.name.Replace(" ", ""))
                                );
                        }
                        var ugb = new UcGeneratorBasic(testTask.dataGenerator);
                        ugb.Edited += (s, ev) =>
                        {
                            Edited?.Invoke(this, new EventArgs());
                        };
                        ugb.Dock = DockStyle.Fill;
                        PnlRecords.Controls.Add(ugb);
                        generatorConfigControl = ugb;
                        break;
                    default:
                        PnlRecords.Controls.Clear();
                        break;
                }
                Edited?.Invoke(this, new EventArgs());
            }
        }

        private void TsbAddParam_Click(object sender, EventArgs e)
        {
            DgvParameters.Rows.Add();
        }

        private void TsbDelParam_Click(object sender, EventArgs e)
        {
            if (DgvParameters.SelectedRows.Count > 0)
            {
                if (DgvParameters.SelectedRows[0].Tag != null)
                {
                    testTask.dataGenerator.ParamList.Remove(
                        DgvParameters.SelectedRows[0].Tag.ToString());
                    generatorConfigControl?.DelAParam(
                        DgvParameters.SelectedRows[0].Tag.ToString());
                }
                DgvParameters.Rows.Remove(DgvParameters.SelectedRows[0]);
            }
        }

        private void DgvParameters_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = DgvParameters.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var newParamName = cell.Value?.ToString();
            if (DgvParameters.Rows[e.RowIndex].Tag != null)
            {
                var oldParamName = DgvParameters.Rows[e.RowIndex].Tag?.ToString();
                int index = testTask.dataGenerator.ParamList.FindIndex(p => p == oldParamName);
                testTask.dataGenerator.ParamList[index] = newParamName;
                DgvParameters.Rows[e.RowIndex].Tag = newParamName;
                generatorConfigControl?.UpdateAParam(newParamName, oldParamName);
            }
            else
            {
                testTask.dataGenerator.ParamList.Add(newParamName);
                DgvParameters.Rows[e.RowIndex].Tag = newParamName;
                generatorConfigControl?.AddAParam(newParamName);
            }
        }
        private void deployGeneratorData()
        {
            CbDataGenerator.Checked = testTask.dataGenerator != null;
            if (CbDataGenerator.Checked)
            {
                DgvParameters.SuspendLayout();
                CbGeneratorType.Text = testTask.dataGenerator.GeneratorType;
                foreach (var param in testTask.dataGenerator.ParamList)
                {
                    DgvParameters.Rows.Add(param);
                    DgvParameters.Rows[DgvParameters.Rows.Count - 1].Tag = param;
                }
                DgvParameters.ResumeLayout();
            }
        }
        #endregion

        #region Test response result

        TabPage? responsePage;
        public void ShowResponse(List<ResponseInfo> responseInfos)
        {
            if(responsePage == null)
            {
                responsePage = new TabPage()
                {
                    Text = Resources.strTestResponseResult
                };
                tabControl1.TabPages.Add(responsePage);
                tabControl1.SelectedTab = responsePage;
                responsePage.Controls.Add(
                    new UcResponseInfo(responseInfos)
                    {
                        Dock = DockStyle.Fill
                    }
                );
            }
            else
            {
                var uri = responsePage.Controls[0] as UcResponseInfo;
                uri.setResponseInfos(responseInfos);
            }
        }

        #endregion
    }
}
