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
    public partial class FrmParameterSelect : Form
    {
        public string SelectedParameter { get => listBox1.SelectedItem.ToString(); }

        public FrmParameterSelect(
            TestProject testProject,
            TestTask testTask,
            bool isContextParameter
            )
        {
            InitializeComponent();
            BtnOk.Text = Resources.strOk;
            BtnCancel.Text = Resources.strCancel;
            StartPosition = FormStartPosition.CenterParent;
            listBox1.SelectionMode = SelectionMode.One;

            List<string> parameters;
            if (isContextParameter)
            {
                Text = Resources.strParameterSelectorTitle_Project;
                parameters = xyTest.GetProjectParams(
                    testProject, 
                    testProject.tasks.IndexOf(testTask));
            }
            else
            {
                Text = Resources.strParameterSelectorTitle_Case;
                parameters = xyTest.GetCaseParams(testTask);
            }
            foreach (var param in parameters)
            {
                listBox1.Items.Add(param);
            }

            BtnOk.Enabled = false;

            listBox1.DoubleClick += (s, e) => BtnOk_Click(s, e);
            listBox1.SelectedValueChanged += 
                (s, e) => BtnOk.Enabled = listBox1.SelectedItem != null;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
