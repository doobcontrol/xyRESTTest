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
    public partial class UcJsonBody : UserControl
    {
        ContentInfo contentInfo;
        public UcJsonBody(ContentInfo? contentInfo)
        {
            InitializeComponent();
            if(contentInfo != null)
            {
                this.contentInfo = contentInfo;
            }
            else
            {
                this.contentInfo = new ContentInfo();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "SimpleJson":
                    PnlJsonEditor.Controls.Clear();
                    var ucSimpleJson = new UcJsonBodySimple(contentInfo);
                    ucSimpleJson.Dock = DockStyle.Fill;
                    PnlJsonEditor.Controls.Add(ucSimpleJson);
                    break;
            }
        }
    }
}
