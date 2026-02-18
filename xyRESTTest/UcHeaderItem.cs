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
    public partial class UcHeaderItem : UserControl
    {

        public string HeaderName { get => uhe.HeaderName; }
        public object HeaderValue { get => uhe.HeaderValue; }

        UcHeaderEdit uhe;
        Control? uhiContainer;

        public event EventHandler<EventArgs>? Edited;
        public event EventHandler<EventArgs>? Selected;

        Color orgBackColor;
        Color selectedBackColor = Color.LightBlue;
        BorderStyle orgBordderStyle;
        BorderStyle selectedBorderStyle = BorderStyle.FixedSingle;

        public UcHeaderItem(
            KeyValuePair<string, object>? header,
            Control? uhiContainer = null)
        {
            InitializeComponent();
            orgBackColor = lbInfo.BackColor;
            //orgBordderStyle = this.BorderStyle;
            this.uhiContainer = uhiContainer;

            uhe = new UcHeaderEdit(header) { Visible = false };
            uhe.Edited += Header_edited;

            if (uhe.HeaderName == null || uhe.HeaderName == "")
            {
                lbInfo.Text = "<Empty Header>";
            }
            else
            {
                lbInfo.Text = $"{uhe.HeaderName}: {uhe.HeaderValue.ToString()}";
            }
        }
        private void Header_edited(object? sender, EventArgs e)
        {
            if (sender is UcHeaderEdit uhe)
            {
                lbInfo.Text = $"{uhe.HeaderName}: {uhe.HeaderValue.ToString()}";

                Edited?.Invoke(this, new EventArgs());
            }
        }

        private void UcHeaderItem_Load(object sender, EventArgs e)
        {
            if (uhiContainer == null)
            {
                uhiContainer = Parent;
            }
            uhiContainer.Controls.Add(uhe);
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            Selected?.Invoke(this, new EventArgs());
            showUhi();
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {
            Selected?.Invoke(this, new EventArgs());
            showUhi();
        }

        private void showUhi()
        {
            if (!uhe.Visible)
            {
                Point parentPoint = uhiContainer.PointToClient(
                    this.PointToScreen(new Point(lbInfo.Left, lbInfo.Bottom)));
                uhe.Location = parentPoint;
                uhe.BringToFront();
            }
            uhe.Visible = !uhe.Visible;
        }

        public void SetSelected(bool selected)
        {
            if (selected)
            {
                lbInfo.BackColor = selectedBackColor;
                //this.BorderStyle = selectedBorderStyle;
            }
            else
            {
                lbInfo.BackColor = orgBackColor;
                //this.BorderStyle = orgBordderStyle;
            }
        }
    }
}
