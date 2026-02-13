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
    public partial class UcHeaderItem : UserControl
    {
        UcHeaderEdit uhi = new UcHeaderEdit() { Visible = false};
        Control? uhiContainer;
        public UcHeaderItem(Control? uhiContainer = null)
        {
            InitializeComponent();
            this.uhiContainer = uhiContainer;
        }

        private void UcHeaderItem_Load(object sender, EventArgs e)
        {
            if (uhiContainer == null)
            {
                uhiContainer = Parent;
            }
            if (uhiContainer != null)
            {
                uhiContainer.Controls.Add(uhi);
            }
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            showUhi();
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {
            showUhi();
        }

        private void showUhi()
        {
            if (!uhi.Visible)
            {
                Point parentPoint = uhiContainer.PointToClient(
                    this.PointToScreen(new Point(lbInfo.Left, lbInfo.Bottom)));
                uhi.Location = parentPoint;
                uhi.BringToFront();
            }
            uhi.Visible = !uhi.Visible;
        }
    }
}
