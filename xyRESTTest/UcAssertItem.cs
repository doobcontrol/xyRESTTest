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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace xyRESTTest
{
    public partial class UcAssertItem : UserControl
    {
        AssertInfo assertInfo;
        public AssertInfo AssertInfo { get => assertInfo; }

        UcAssertEdit uae;
        Control? uaeContainer;

        public event EventHandler<EventArgs>? Edited;
        public event EventHandler<EventArgs>? Selected;

        Color orgBackColor;
        Color selectedBackColor = Color.LightBlue;
        BorderStyle orgBordderStyle;
        BorderStyle selectedBorderStyle = BorderStyle.FixedSingle;

        public UcAssertItem(
            AssertInfo? assertInfo,
            Control? uaeContainer = null)
        {
            InitializeComponent();
            orgBackColor = this.BackColor;
            orgBordderStyle = this.BorderStyle;
            this.uaeContainer = uaeContainer;
            if (this.uaeContainer == null)
            {
                this.uaeContainer = Parent;
            }

            if (assertInfo != null)
            {
                this.assertInfo = assertInfo;
                lbInfo.Text = $"{assertInfo.assertType}:";
            }
            else
            {
                this.assertInfo = new AssertInfo() 
                { 
                    assertType = nameof(AssertType.StatusCode) 
                };
                lbInfo.Text = "Please click to select assert type";
            }

            uae = new UcAssertEdit(this.assertInfo) { Visible = false };
            uae.Edited += Assert_edited;
        }
        private void Assert_edited(object? sender, EventArgs e)
        {
            if (sender is UcAssertEdit uae)
            {
                lbInfo.Text = $"{assertInfo.assertType}:";

                Edited?.Invoke(this, new EventArgs());
            }
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            Selected?.Invoke(this, new EventArgs());
            showUae();
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {
            Selected?.Invoke(this, new EventArgs());
            showUae();
        }

        private void showUae()
        {
            uae.Visible = !uae.Visible;
            if (uae.Visible)
            {
                uaeContainer.Controls.Add(uae);
                Point parentPoint = uaeContainer.PointToClient(
                    this.PointToScreen(new Point(lbInfo.Left, lbInfo.Bottom)));
                uae.Location = parentPoint;
                uae.BringToFront();
                uae.Select();
            }
            else
            {
                uaeContainer.Controls.Remove(uae);
            }
        }

        public void SetSelected(bool selected)
        {
            if (selected)
            {
                this.BackColor = selectedBackColor;
                this.BorderStyle = selectedBorderStyle;
            }
            else
            {
                this.BackColor = orgBackColor;
                this.BorderStyle = orgBordderStyle;
            }
        }
    }
}
