using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xyRESTTest
{
    public partial class UcAuthHeader : UserControl
    {
        public UcAuthHeader()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Basic")
            {
                TlpBasic.Visible = true;
                TlpBearer.Visible = false;
            }
            else if (comboBox1.Text == "Bearer")
            {
                TlpBasic.Visible = false;
                TlpBearer.Visible = true;
            }
        }
    }
}
