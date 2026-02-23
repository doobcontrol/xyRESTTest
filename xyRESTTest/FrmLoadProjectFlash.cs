using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTest.Properties;

namespace xyRESTTest
{
    public partial class FrmLoadProjectFlash : Form
    {
        public FrmLoadProjectFlash()
        {
            InitializeComponent();
            label1.Text = Resources.strLoadProjectFlashInfo;
            StartPosition= FormStartPosition.CenterParent;
        }
    }
}
