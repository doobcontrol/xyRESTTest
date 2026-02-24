using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
        bool hasProjectLoaded = false;
        string lang;
        bool testRunning = false;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        public FrmMain()
        {
            InitializeComponent();
            CreateContextMenu();
            LangConfig();
            LoadStringResources();

            xyTest.TestHandler = new TestHandler();

            TsbAddCase.Visible = false;
            TsbDelCase.Visible = false;
            toolStripSeparator1.Visible = false;
            TsbRun.Visible = false;
            toolStripSeparator2.Visible = false;

            PnlRun.Visible = false;
            splitter1.Visible = false;
        }
        private void LangConfig()
        {
            xyCfg.init(new Dictionary<string, string>() {
                {LangParName, CultureInfo.InstalledUICulture.Name}
            });
            lang = xyCfg.get(LangParName);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            TscbLang.Items.Add(LangDefault);
            TscbLang.Items.Add(LangChinese);
            TscbLang.Text = lang;
        }
        private void LoadStringResources()
        {
            Text = Resources.strAppTitle;
            if (!hasProjectLoaded)
            {
                LbPrjName.Text = Resources.strNoProjectLoaded;
            }
            TsbNewProject.Text = Resources.strNewTestProject;
            TsbOpenProject.Text = Resources.strOpenTestProject;
            TsbAddCase.Text = Resources.strAddTestCase;
            TsbDelCase.Text = Resources.strDeleteTestCase;
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
                lbRunningInfo.Text = Resources.strRunFinished;
            }

            contextMenuStrip.Items[0].Text = Resources.strMenuInsertProjectParameter;
            contextMenuStrip.Items[1].Text = Resources.strMenuInsertCaseParameter;
        }

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
                utc.Dock = DockStyle.Fill;
                PnlTestCase.Controls.Add(utc);
                utc.Visible = true;
            }
        }
        private async void UcTestCaseItem_Run(object? sender, EventArgs e)
        {
            if (sender is UcTestCaseItem utci)
            {
                var path = Path.GetDirectoryName(testProject.projectFile);
                var outputfile = Path.GetFileNameWithoutExtension(testProject.projectFile);
                outputfile = Path.Combine(
                    path ?? "", $"{outputfile}_output.txt");

                var contextPars = new Dictionary<string, string>();
                setRunnningState(true);
                using (var sw = new StreamWriter(outputfile, true))
                {
                    await xyTest.oneTestAsync(utci.TestTask, contextPars, sw);
                }
                setRunnningState(false);
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

        private void TsbDelCase_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                testProject.tasks.Remove(selectedItem.TestTask);
                xyTest.saveTestProject(testProject);

                PnTestcases.Controls.Remove(selectedItem);
                selectedItem.Dispose();
                selectedItem = null;

                PnlTestCase.Controls.Clear();
            }
        }

        private void TsbNewProject_Click(object sender, EventArgs e)
        {
            var fntp = new FrmNewTestProject();
            if (fntp.ShowDialog() == DialogResult.OK)
            {
                testProject = fntp.TestProject;
                LbPrjName.Text = testProject.name;
                TsbAddCase.Visible = true;
                TsbDelCase.Visible = true;
                toolStripSeparator1.Visible = true;
                TsbRun.Visible = true;
                toolStripSeparator2.Visible = true;

                PnTestcases.Controls.Clear();
                PnlTestCase.Controls.Clear();
                hasProjectLoaded = true;
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
                try
                {
                    LoadProjectMask(true);

                    // Get the path of the specified file
                    string filePath = ofd.FileName;
                    toolStrip1.SuspendLayout();
                    PnTestcases.SuspendLayout();
                    PnPrj.SuspendLayout();
                    testProject = xyTest.loadTestProject(filePath);
                    LbPrjName.Text = testProject.name;
                    TsbAddCase.Visible = true;
                    TsbDelCase.Visible = true;
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

                    LoadProjectMask(false);
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

        private async void TsbRun_Click(object sender, EventArgs e)
        {
            setRunnningState(true);
            await xyTest.runProjectAsync(testProject);
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
                lbRunningInfo.Text = Resources.strRunFinished;
            }
            testRunning = isRunning;
        }

        private void btnHideRunWindow_Click(object sender, EventArgs e)
        {
            PnlRun.Visible = false;
            splitter1.Visible = false;
        }

        private void TscbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lang = TscbLang.Text;
            xyCfg.set(LangParName, lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            LoadStringResources();
        }

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
                            InsertTextAtCursor(tb, "${"+ fps.SelectedParameter + "}");
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
    }
}
