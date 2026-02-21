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

        bool isNew = false;

        public UcHeaderItem(
            KeyValuePair<string, object>? header,
            Control? uhiContainer = null)
        {
            InitializeComponent();
            orgBackColor = lbInfo.BackColor;
            //orgBordderStyle = this.BorderStyle;
            this.uhiContainer = uhiContainer;
            if (this.uhiContainer == null)
            {
                this.uhiContainer = Parent;
            }

            uhe = new UcHeaderEdit(header) { Visible = false };
            uhe.Edited += Header_edited;
            uhe.Leave += (s, e) => { uhe.Visible = false; };
            LoadStringResources();

            if (uhe.HeaderName == null || uhe.HeaderName == "")
            {
                lbInfo.Text = Resources.strUnfefined;
                isNew = true;
            }
            else
            {
                lbInfo.Text = $"{uhe.HeaderName}: {uhe.HeaderValue.ToString()}";
                isNew = false;
            }
        }
        public void LoadStringResources()
        {
            if(isNew)
            {
                lbInfo.Text = Resources.strUnfefined;
            }
            uhe?.LoadStringResources();
        }
        private void Header_edited(object? sender, EventArgs e)
        {
            if (sender is UcHeaderEdit uhe)
            {
                lbInfo.Text = $"{uhe.HeaderName}: {uhe.HeaderValue.ToString()}";

                Edited?.Invoke(this, new EventArgs());
                isNew = false;
            }
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
            uhe.Visible = !uhe.Visible;
            if (uhe.Visible)
            {
                uhiContainer.Controls.Add(uhe);
                Point parentPoint = uhiContainer.PointToClient(
                    this.PointToScreen(new Point(lbInfo.Left, lbInfo.Bottom)));
                uhe.Location = parentPoint;
                uhe.BringToFront();
                uhe.Select();
            }
            else
            {
                uhiContainer.Controls.Remove(uhe);
            }
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
