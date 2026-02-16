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

        public UcAssertItem(
            AssertInfo? assertInfo,
            Control? uaeContainer = null)
        {
            InitializeComponent();
            this.uaeContainer = uaeContainer;

            if (assertInfo != null)
            {
                this.assertInfo = assertInfo;
                lbInfo.Text = $"{assertInfo.assertType}:";
            }
            else
            {
                this.assertInfo = new AssertInfo();
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

        private void UcAssertItem_Load(object sender, EventArgs e)
        {
            if (uaeContainer == null)
            {
                uaeContainer = Parent;
            }
            if (uaeContainer != null)
            {
                uaeContainer.Controls.Add(uae);
            }
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            showUae();
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {
            showUae();
        }

        private void showUae()
        {
            if (!uae.Visible)
            {
                Point parentPoint = uaeContainer.PointToClient(
                    this.PointToScreen(new Point(lbInfo.Left, lbInfo.Bottom)));
                uae.Location = parentPoint;
                uae.BringToFront();
            }
            uae.Visible = !uae.Visible;
        }
    }
}
