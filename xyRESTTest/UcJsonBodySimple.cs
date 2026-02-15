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
    public partial class UcJsonBodySimple : UserControl
    {
        public UcJsonBodySimple(ContentInfo? contentInfo)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Key", "Key");
            dataGridView1.Columns.Add("Value", "Value");
        }

        private void TsbAddPar_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.CurrentCell = dataGridView1[0, rowIndex];
            dataGridView1.Select();
            dataGridView1.BeginEdit(true);
        }

        private void TsbDelPar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
        }
    }
}
