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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace xyRESTTest
{
    public partial class FrmMain : Form
    {
        TestProject testProject;
        public FrmMain()
        {
            InitializeComponent();

            LbPrjName.Text = "No Project Loaded";
            TsbAddCase.Visible = false;
            TsbDelCase.Visible = false;
            TsbRun.Visible = false;
        }

        private void TsbAddCase_Click(object sender, EventArgs e)
        {
            var newTesk = new TestTask
            {
                name = $"Test Task {PnTestcases.Controls.Count + 1}"
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

                panel2.Controls.Clear();
                var utc = new UcTestCase(selected.TestTask);
                utc.Edited += TestCase_edited;
                utc.Dock = DockStyle.Fill;
                panel2.Controls.Add(utc);
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

                utci.TestTask.testHandler = new TestHandler();
                var contextPars = new Dictionary<string, string>();
                using (var sw = new StreamWriter(outputfile, true))
                {
                    await xyTest.oneTestAsync(utci.TestTask, contextPars, sw);
                }
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
                testProject.tasks.Add(selectedItem.TestTask);
                xyTest.saveTestProject(testProject);

                PnTestcases.Controls.Remove(selectedItem);
                selectedItem.Dispose();
                selectedItem = null;
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
                TsbRun.Visible = true;
            }
        }

        private void TsbOpenProject_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog
            var ofd = new OpenFileDialog();

            // Set properties for the dialog
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Title = "Open Test Project";
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
                    // Get the path of the specified file
                    string filePath = ofd.FileName;

                    testProject = xyTest.loadTestProject(filePath);
                    LbPrjName.Text = testProject.name;
                    TsbAddCase.Visible = true;
                    TsbDelCase.Visible = true;
                    TsbRun.Visible = true;

                    PnTestcases.Controls.Clear();
                    foreach (var task in testProject.tasks)
                    {
                        AddTestCaseItem(task);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur
                    MessageBox.Show("Error: Could not read file from disk. Original error: "
                        + ex.Message);
                }
            }
        }

        private async void TsbRun_Click(object sender, EventArgs e)
        {
            var handler = new TestHandler();
            foreach(var task in testProject.tasks)
            {
                task.testHandler = handler;
            }
            await xyTest.runProjectAsync(testProject);
        }
    }
}
