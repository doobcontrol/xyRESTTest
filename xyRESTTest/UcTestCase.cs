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
            label1.BackColor = UcTestCaseItem.selectedBackColor;
            label1.Text = testTask.name;
        }

        private void TsbAddHeader_Click(object sender, EventArgs e)
        {
            var uhi = new UcHeaderItem(this);
            uhi.Dock = DockStyle.Top;
            TlpHeaders.Controls.Add(uhi);
        }
    }
}
