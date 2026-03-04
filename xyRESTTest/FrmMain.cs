using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xy.Cfg;
using xyRESTTest.Properties;
using xyRESTTestLib;

namespace xyRESTTest
{
    public partial class FrmMain : Form
    {
        TestProject testProject;
        string LangParName = "LangCode";
        string LangDefault = "en-US";
        string LangChinese = "zh-CN";
        string RecentOpenListName = "RecentOpenList";
        bool hasProjectLoaded = false;
        string lang;
        bool testRunning = false;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
        Dictionary<string, string> contextPars;
        List<string> recentOpenList;
        public FrmMain()
        {
            xyCfg.init(
                new Dictionary<string, object>() 
                {
                    {LangParName, CultureInfo.InstalledUICulture.Name},
                    {RecentOpenListName, new List<string>() }
                }, 
                Path.Combine(Directory.GetCurrentDirectory(), cfgFile)
            );

            InitializeComponent();
            SetFormResume();

            recentOpenList = xyCfg.get(RecentOpenListName) as List<string> ?? new List<string>();
            if(recentOpenList.Count > 0)
            {
                var recentOpenListControl = new UcRecentOpenList(recentOpenList);
                recentOpenListControl.Dock = DockStyle.Fill;
                recentOpenListControl.Selected += (s, e) =>
                {
                    string filePath = (s as UcRecentOpenList).SelectedProject;
                    OpenProject(filePath);
                };
                recentOpenListControl.DeleteNotExistProject += (s, e) =>
                {
                    string filePath = (s as UcRecentOpenList).SelectedProject;
                    recentOpenList.Remove(filePath);
                    xyCfg.set(RecentOpenListName, recentOpenList);
                };

                PnlTestCase.Controls.Clear();
                PnlTestCase.Controls.Add(recentOpenListControl);
            }

            CreateContextMenu();
            LangConfig();
            LoadStringResources();

            xyTest.TestHandler = new TestHandler();

            TsbAddCase.Visible = false;
            TsbDelCase.Visible = false;
            TsbMoveDown.Visible = false;
            TsbMoveUp.Visible = false;
            toolStripSeparator1.Visible = false;
            TsbRun.Visible = false;
            toolStripSeparator2.Visible = false;

            PnlRun.Visible = false;
            splitter1.Visible = false;

            LbPrjName.DoubleClick += (s, e) =>
            {
                if (testProject != null)
                {
                    EditProjectName(true);
                }
            };

            TxtPrjName.Leave += (s, e) =>
            {
                EditProjectName(false);
            };

            TxtPrjName.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EditProjectName(false);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    TxtPrjName.Text = LbPrjName.Text;
                    LbPrjName.Visible = true;
                    TxtPrjName.Visible = false;
                }
            };
        }

        const string cfgName_FormMaximized = "FormMaximized";
        const string cfgName_FormLocation_x = "FormLocation_x";
        const string cfgName_FormLocation_y = "FormLocation_y";
        const string cfgName_FormSize_h = "FormSize_h";
        const string cfgName_FormSize_w = "FormSize_w";
        private FormWindowState LastWindowState;
        private int LastX;
        private int LastY;
        private int LastWidth;
        private int LastHeight;
        private void SetFormResume()
        {
            bool formMaximized;
            object maxObj = xyCfg.get(cfgName_FormMaximized);
            if (maxObj != null)
            {
                formMaximized = bool.Parse(maxObj as string);
                if (formMaximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.Size = new Size(
                        int.Parse(xyCfg.get(cfgName_FormSize_w) as string),
                        int.Parse(xyCfg.get(cfgName_FormSize_h) as string)
                        );
                    this.WindowState = FormWindowState.Normal;
                }
            }
            this.FormClosing += (s, e) =>
            {
                bool formMaximized;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    formMaximized = true;
                }
                else
                {
                    formMaximized = false;
                }
                xyCfg.set(cfgName_FormMaximized, formMaximized.ToString());
                xyCfg.set(cfgName_FormLocation_x, LastX.ToString());
                xyCfg.set(cfgName_FormLocation_y, LastY.ToString());
                xyCfg.set(cfgName_FormSize_w, LastWidth.ToString());
                xyCfg.set(cfgName_FormSize_h, LastHeight.ToString());
            };
            this.Load += (s, e) =>
            {
                this.Location = new Point(
                    int.Parse(xyCfg.get(cfgName_FormLocation_x) as string),
                    int.Parse(xyCfg.get(cfgName_FormLocation_y) as string)
                    );
                LastWindowState = this.WindowState;
                LastX = this.Location.X;
                LastY = this.Location.Y;
                LastWidth = this.Size.Width;
                LastHeight = this.Size.Height;
            };
            this.Resize += (s, e) =>
            {
                if(this.WindowState == FormWindowState.Normal)
                {
                    if(LastWindowState == FormWindowState.Maximized)
                    {
                        this.Location = new Point(
                            int.Parse(xyCfg.get(cfgName_FormLocation_x) as string),
                            int.Parse(xyCfg.get(cfgName_FormLocation_y) as string)
                            );
                        this.Size = new Size(
                            int.Parse(xyCfg.get(cfgName_FormSize_w) as string),
                            int.Parse(xyCfg.get(cfgName_FormSize_h) as string)
                            );
                        //make this event handler execute only once
                        LastWindowState = FormWindowState.Minimized;
                    }
                    LastX = this.Location.X;
                    LastY = this.Location.Y;
                    LastWidth = this.Size.Width;
                    LastHeight = this.Size.Height;
                }
            };
            this.Move += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    LastX = this.Location.X;
                    LastY = this.Location.Y;
                }
            };
        }

        #region TestCaseItem

        private void TsbAddCase_Click(object sender, EventArgs e)
        {
            var newTesk = new TestTask
            {
                name = $"Test Task {PnTestcases.Controls.Count + 1}",
                requestInfo = new RequestInfo
                {
                    method = "",
                    url = "",
                    headers = new Dictionary<string, object>(),
                },
                assertInfos = new List<AssertInfo>(),
            };
            testProject.tasks.Add(newTesk);
            xyTest.saveTestProject(testProject);

            AddTestCaseItem(newTesk);
        }
        private void AddTestCaseItem(TestTask tTask)
        {
            var newItem = new UcTestCaseItem(tTask);
            newItem.Dock = DockStyle.Top;
            newItem.Selected += UcTestCaseItem_Selected;
            newItem.Run += UcTestCaseItem_Run;
            PnTestcases.Controls.Add(newItem);
        }

        UcTestCaseItem? selectedItem;
        private void UcTestCaseItem_Selected(object? sender, EventArgs e)
        {
            foreach (Control control in PnTestcases.Controls)
            {
                if (control is UcTestCaseItem item)
                {
                    item.SetSelected(item == sender);
                }
            }
            if (sender is UcTestCaseItem selected)
            {
                selectedItem = selected;

                PnlTestCase.Controls.Clear();
                var utc = new UcTestCase(selected.TestTask, contextMenuStrip);
                utc.Visible = false;
                utc.Edited += TestCase_edited;
                utc.PrepareEdited += TestCase_PrepareEdited;
                utc.Dock = DockStyle.Fill;
                PnlTestCase.Controls.Add(utc);
                utc.Visible = true;
            }
        }
        private void TestCase_edited(object? sender, EventArgs e)
        {
            if (sender is UcTestCase ute)
            {
                selectedItem?.UpdateDisplay();
                xyTest.saveTestProject(testProject);
            }
        }
        private void TestCase_PrepareEdited(object? sender, EditPermitCheckEventArgs e)
        {
            switch(e.CheckType)
            {
                case EditPermitCheck.CaseNameDuplicate:
                    var newProjectName = e.DataToBeEdited as string;
                    newProjectName = newProjectName?.Replace(" ","").ToLower();
                    foreach (var task in testProject.tasks)
                    {
                        if(task.name.Replace(" ", "").ToLower() == newProjectName)
                        {
                            MessageBox.Show(
                                Resources.strCaseNameDuplicate,
                                Resources.strError,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            e.Cancel = true;
                            return;
                        }
                    }
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void TsbDelCase_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                // delete data files
                if(selectedItem.TestTask.dataGenerator != null
                    && selectedItem.TestTask.dataGenerator.GeneratorType 
                    == nameof(GeneratorType.Basic))
                {
                    var filePath = selectedItem.TestTask.dataGenerator
                        .GeneratorInfo[xyTest.DGT_Basic_File] as string;
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch
                        {
                            // ignore delete file error
                        }
                    }
                }

                testProject.tasks.Remove(selectedItem.TestTask);
                xyTest.saveTestProject(testProject);

                PnTestcases.Controls.Remove(selectedItem);
                selectedItem.Dispose();
                selectedItem = null;

                PnlTestCase.Controls.Clear();
            }
        }

        private void TsbMoveUp_Click(object sender, EventArgs e)
        {
            if(selectedItem != null)
            {
                int index = PnTestcases.Controls.GetChildIndex(selectedItem);
                if (index > 0)
                {
                    PnTestcases.Controls.SetChildIndex(selectedItem, index - 1);
                    var task = selectedItem.TestTask;
                    testProject.tasks.Remove(task);
                    testProject.tasks.Insert(index - 1, task);
                    xyTest.saveTestProject(testProject);
                }
            }
        }

        private void TsbMoveDown_Click(object sender, EventArgs e)
        {
            if(selectedItem != null)
            {
                int index = PnTestcases.Controls.GetChildIndex(selectedItem);
                if (index < PnTestcases.Controls.Count - 1)
                {
                    PnTestcases.Controls.SetChildIndex(selectedItem, index + 1);
                    var task = selectedItem.TestTask;
                    testProject.tasks.Remove(task);
                    testProject.tasks.Insert(index + 1, task);
                    xyTest.saveTestProject(testProject);
                }
            }
        }

        #endregion

        #region Project

        private void EditProjectName(bool startEdit)
        {
            LbPrjName.Visible = !startEdit;
            TxtPrjName.Visible = startEdit;
            if (startEdit)
            {
                TxtPrjName.Text = LbPrjName.Text;
                TxtPrjName.Focus();
                TxtPrjName.SelectAll();
            }
            else
            {
                if (TxtPrjName.Text != testProject.name)
                {
                    testProject.name = TxtPrjName.Text;
                    LbPrjName.Text = TxtPrjName.Text;
                    xyTest.saveTestProject(testProject);
                }
            }
        }

        private void TsbNewProject_Click(object sender, EventArgs e)
        {
            var fntp = new FrmNewTestProject();
            if (fntp.ShowDialog() == DialogResult.OK)
            {
                testProject = fntp.TestProject;
                Directory.SetCurrentDirectory(testProject.projectDir);
                LbPrjName.Text = testProject.name;
                TsbAddCase.Visible = true;
                TsbDelCase.Visible = true;
                TsbMoveDown.Visible = true;
                TsbMoveUp.Visible = true;
                toolStripSeparator1.Visible = true;
                TsbRun.Visible = true;
                toolStripSeparator2.Visible = true;

                PnTestcases.Controls.Clear();
                PnlTestCase.Controls.Clear();
                hasProjectLoaded = true;
                toolTip1.SetToolTip(LbPrjName, Resources.strDoubleClickToEdit);
                contextPars = new Dictionary<string, string>();

                ShowTitle();
                recentOpenList.Insert(0, 
                    Path.Combine(testProject.projectDir, testProject.projectFile));
                while (recentOpenList.Count > 10)
                {
                    recentOpenList.RemoveAt(recentOpenList.Count - 1);
                }
                xyCfg.set(RecentOpenListName, recentOpenList);
            }
        }

        private void TsbOpenProject_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog
            var ofd = new OpenFileDialog();

            // Set properties for the dialog
            ofd.InitialDirectory = UiTools.WorkDir;
            ofd.Title = Resources.strOpenTestProject;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            // Set the file filter
            ofd.Filter = "Test Project files (*.resttest)|*.resttest";
            ofd.RestoreDirectory = true;

            // Show the dialog and check if the user clicked "OK"
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                OpenProject(filePath);
            }
        }
        private void OpenProject(string filePath)
        {
            try
            {
                LoadProjectMask(true);

                toolStrip1.SuspendLayout();
                PnTestcases.SuspendLayout();
                PnPrj.SuspendLayout();
                testProject = xyTest.loadTestProject(filePath);
                Directory.SetCurrentDirectory(testProject.projectDir);
                LbPrjName.Text = testProject.name;
                TsbAddCase.Visible = true;
                TsbDelCase.Visible = true;
                TsbMoveDown.Visible = true;
                TsbMoveUp.Visible = true;
                toolStripSeparator1.Visible = true;
                TsbRun.Visible = true;
                toolStripSeparator2.Visible = true;

                PnTestcases.Controls.Clear();
                PnlTestCase.Controls.Clear();
                foreach (var task in testProject.tasks)
                {
                    AddTestCaseItem(task);
                }
                hasProjectLoaded = true;
                PnPrj.ResumeLayout();
                PnTestcases.ResumeLayout();
                toolStrip1.ResumeLayout();
                toolTip1.SetToolTip(LbPrjName, Resources.strDoubleClickToEdit);
                contextPars = new Dictionary<string, string>();

                ShowTitle();
                if (!recentOpenList.Contains(filePath))
                {
                    recentOpenList.Insert(0, filePath);
                    while (recentOpenList.Count > 10)
                    {
                        recentOpenList.RemoveAt(recentOpenList.Count - 1);
                    }
                    xyCfg.set(RecentOpenListName, recentOpenList);
                }
                else if (recentOpenList.IndexOf(filePath) != 0)
                {
                    recentOpenList.Remove(filePath);
                    recentOpenList.Insert(0, filePath);
                    xyCfg.set(RecentOpenListName, recentOpenList);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur
                MessageBox.Show(
                    string.Format(
                        Resources.strProjectOpenError,
                        ex.Message)
                );
            }
            finally
            {
                LoadProjectMask(false);
            }
        }

        Label lbLoading;
        private void LoadProjectMask(bool mask)
        {
            if (mask)
            {
                lbLoading = new Label
                {
                    Text = Resources.strLoadProjectFlashInfo,
                    AutoSize = true,
                    Parent = this,
                };
                lbLoading.Location = new Point(
                    (this.ClientSize.Width - lbLoading.Width) / 2,
                    (this.ClientSize.Height - lbLoading.Height) / 2);
                this.Controls.Add(lbLoading);
                lbLoading.BringToFront();
                this.Enabled = false;
            }
            else
            {
                this.Controls.Remove(lbLoading);
                lbLoading.Dispose();
                this.Enabled = true;
            }
        }

        #endregion

        #region Run test

        bool testResult;
        private async void UcTestCaseItem_Run(object? sender, EventArgs e)
        {
            if (sender is UcTestCaseItem utci)
            {
                var missngParams = new List<string>();
                if (!xyTest.CheckCaseContextParams(
                    contextPars, missngParams, utci.TestTask))
                {
                    MessageBox.Show(
                        string.Format(
                            Resources.strCaseContextParamMissing, string.Join(",",missngParams)
                            ),
                        Resources.strError,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var path = Path.GetDirectoryName(testProject.projectFile);
                var outputfile = Path.GetFileNameWithoutExtension(testProject.projectFile);
                outputfile = Path.Combine(
                    path ?? "", $"{outputfile}_output.txt");

                setRunnningState(true);
                using (var sw = new StreamWriter(outputfile, true))
                {
                    if(utci.TestTask.dataGenerator == null)
                    {
                        testResult = await xyTest.oneTestAsync(utci.TestTask, contextPars, sw);
                    }
                    else
                    {
                        testResult = 
                            await xyTest.oneAutoGenerateTestAsync(utci.TestTask, contextPars, sw);
                    }
                }
                setRunnningState(false);
            }
        }

        private async void TsbRun_Click(object sender, EventArgs e)
        {
            setRunnningState(true);
            var newContextPars = new Dictionary<string, string>();
            testResult = await xyTest.runProjectAsync(testProject, newContextPars);
            if(testResult)
            {
                contextPars = newContextPars;
            }
            setRunnningState(false);
        }
        private void setRunnningState(bool isRunning)
        {
            btnHideRunWindow.Enabled = !isRunning;
            PnlRun.Visible = true;
            splitter1.Visible = true;
            PnlWork.Enabled = !isRunning;
            if (isRunning)
            {
                lbRunningInfo.Text = Resources.strRunning;
            }
            else
            {
                var resultStr = testResult ? Resources.strSucceed : Resources.strFailed;
                lbRunningInfo.Text = string.Format(Resources.strRunFinished, resultStr);
            }
            testRunning = isRunning;
            this.ControlBox = !isRunning;
        }

        private void btnHideRunWindow_Click(object sender, EventArgs e)
        {
            PnlRun.Visible = false;
            splitter1.Visible = false;
        }

        #endregion

        #region i18n
       
        string cfgFile = "xyCfg.json";
        private void LangConfig()
        {
            lang = xyCfg.get(LangParName) as string;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            TscbLang.Items.Add(LangDefault);
            TscbLang.Items.Add(LangChinese);
            TscbLang.Text = lang;
        }
        private void LoadStringResources()
        {
            ShowTitle();

            if (!hasProjectLoaded)
            {
                LbPrjName.Text = Resources.strNoProjectLoaded;
                if(PnlTestCase.Controls.Count > 0)
                {
                    var control = PnlTestCase.Controls[0];
                    if (control is UcRecentOpenList)
                    {
                        (control as UcRecentOpenList).LoadStringResources();
                    }
                }
            }
            else
            {
                toolTip1.SetToolTip(LbPrjName, Resources.strDoubleClickToEdit);
            }

            TsbNewProject.Text = Resources.strNewTestProject;
            TsbOpenProject.Text = Resources.strOpenTestProject;
            TsbAddCase.Text = Resources.strAddTestCase;
            TsbDelCase.Text = Resources.strDeleteTestCase;
            TsbMoveDown.Text = Resources.strMoveDown;
            TsbMoveUp.Text = Resources.strMoveUp;
            TsbRun.Text = Resources.strRunTestProject;
            foreach (Control control in PnTestcases.Controls)
            {
                if (control is UcTestCaseItem item)
                {
                    item.LoadStringResources();
                }
            }
            if (PnlTestCase.Controls.Count > 0)
            {
                var control = PnlTestCase.Controls[0];
                if (control is UcTestCase utc)
                {
                    utc.LoadStringResources();
                }
            }
            if (testRunning)
            {
                lbRunningInfo.Text = Resources.strRunning;
            }
            else
            {
                var resultStr = testResult ? Resources.strSucceed : Resources.strFailed;
                lbRunningInfo.Text = string.Format(Resources.strRunFinished, resultStr);
            }

            contextMenuStrip.Items[0].Text = Resources.strMenuInsertProjectParameter;
            contextMenuStrip.Items[1].Text = Resources.strMenuInsertCaseParameter;
        }
        private void ShowTitle()
        {
            string projectFile = testProject?.projectFile ?? "";
            string projectDir = testProject?.projectDir ?? "";
            string projectFileName = 
                (string.IsNullOrEmpty(projectFile) ? "" :
                " - " + Path.Combine(projectDir, projectFile));
            Text = Resources.strAppTitle + projectFileName;
        }
        private void TscbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lang = TscbLang.Text;
            xyCfg.set(LangParName, lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            LoadStringResources();
        }

        #endregion

        #region CreateContextMenu
        private void CreateContextMenu()
        {
            contextMenuStrip.Items.Clear();
            var InsertProjectParameterItem =
                new ToolStripMenuItem(Resources.strMenuInsertProjectParameter);
            InsertProjectParameterItem.Click += (s, e) =>
            {
                if (selectedItem != null)
                {
                    Control sourceControl =
                        (((ToolStripMenuItem)s).Owner as ContextMenuStrip).SourceControl;
                    var fps = new FrmParameterSelect(
                        testProject, selectedItem.TestTask, true);
                    if (fps.ShowDialog(this) == DialogResult.OK)
                    {
                        if (sourceControl is TextBox tb)
                        {
                            InsertTextAtCursor(tb, "${" + fps.SelectedParameter + "}");
                        }
                    }
                }
            };
            contextMenuStrip.Items.Add(InsertProjectParameterItem);
            var InsertCaseParameterItem =
                new ToolStripMenuItem(Resources.strMenuInsertCaseParameter);
            InsertCaseParameterItem.Click += async (s, e) =>
            {
                if (selectedItem != null)
                {
                    Control sourceControl =
                        (((ToolStripMenuItem)s).Owner as ContextMenuStrip).SourceControl;
                    var fps = new FrmParameterSelect(
                        testProject, selectedItem.TestTask, false);
                    if (fps.ShowDialog() == DialogResult.OK)
                    {
                        if (sourceControl is TextBox tb)
                        {
                            InsertTextAtCursor(tb, "{{" + fps.SelectedParameter + "}}");
                        }
                    }
                }
            };
            contextMenuStrip.Items.Add(InsertCaseParameterItem);
        }
        private void InsertTextAtCursor(TextBox myTextBox, string textToInsert)
        {
            // Get the current cursor position (insertion point)
            int cursorPosition = myTextBox.SelectionStart;

            // Get the current text
            string currentText = myTextBox.Text;

            // Insert the new text at the cursor position
            myTextBox.Text = currentText.Insert(cursorPosition, textToInsert);

            // Optional: Restore the cursor to the position after the inserted text
            // If you don't do this, the cursor will be placed at the beginning of the text box.
            myTextBox.SelectionStart = cursorPosition + textToInsert.Length;
            myTextBox.SelectionLength = 0; // Ensures no text is selected
        }

        #endregion
    }
}
