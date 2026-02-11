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

namespace xyRESTTest
{
    public partial class FrmNewTestProject : Form
    {
        private TestProject testProject;

        public TestProject TestProject { get => testProject; }

        public FrmNewTestProject()
        {
            InitializeComponent();
            TxtProjectFolder.Text =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TxtProjectName.TextChanged += ProjectNameOrFolder_TextChanged;
            TxtProjectFolder.TextChanged += ProjectNameOrFolder_TextChanged;

        }

        private void BtnBrowser_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TxtProjectFolder.Text = fbd.SelectedPath;
            }
        }
        private void ProjectNameOrFolder_TextChanged(object? sender, EventArgs e)
        {
            var projectName = TxtProjectName.Text.Trim().Replace(" ", "");
            var projectFolder = TxtProjectFolder.Text.Trim();
            TxtProjectSaveName.Text = $"{projectFolder}\\{projectName}.resttest";
            BtnOk.Enabled = !string.IsNullOrEmpty(projectName)
                && !string.IsNullOrEmpty(projectFolder);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            testProject = new TestProject()
            {
                name = TxtProjectName.Text.Trim(),
                projectFile = TxtProjectSaveName.Text.Trim(),
                tasks = new List<TestTask>()
            };
            //save
            xyTest.saveTestProject(testProject);
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
