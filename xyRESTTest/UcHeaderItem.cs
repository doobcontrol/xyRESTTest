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
        public string HeaderName { get => Uhe.HeaderName; }
        public object HeaderValue { get => Uhe.HeaderValue; }

        UcHeaderEdit uhe;
        public UcHeaderEdit Uhe { get => uhe; }

        Control? uhiContainer;

        public event EventHandler<EventArgs>? Edited;
        public event EventHandler<EventArgs>? Selected;

        Color orgBackColor;
        Color selectedBackColor = Color.LightBlue;

        bool isNew = false;
        public bool IsNew { get => isNew; }
        ContextMenuStrip contextMenuStrip;

        public UcHeaderItem(
            KeyValuePair<string, object>? header,
            ComboBox editorSelector,
            ContextMenuStrip contextMenuStrip,
            Control? uhiContainer = null)
        {
            InitializeComponent();
            this.contextMenuStrip = contextMenuStrip;
            orgBackColor = lbInfo.BackColor;
            this.uhiContainer = uhiContainer;
            if (this.uhiContainer == null)
            {
                this.uhiContainer = Parent;
            }

            uhe = new UcHeaderEdit(header, editorSelector, contextMenuStrip) { Visible = false };
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
            Uhe?.LoadStringResources();
        }
        private void Header_edited(object? sender, EventArgs e)
        {
            if (sender is UcHeaderEdit uhe)
            {
                lbInfo.Text = $"{uhe.HeaderName}: {uhe.HeaderValue?.ToString()}";

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
            Uhe.Visible = !Uhe.Visible;
            if (Uhe.Visible)
            {
                uhiContainer.Controls.Add(Uhe);
                Point parentPoint = uhiContainer.PointToClient(
                    this.PointToScreen(new Point(lbInfo.Left, lbInfo.Bottom)));
                Uhe.Location = parentPoint;
                Uhe.BringToFront();
                Uhe.Select();
            }
            else
            {
                uhiContainer.Controls.Remove(Uhe);
            }
        }

        public void SetSelected(bool selected)
        {
            if (selected)
            {
                lbInfo.BackColor = selectedBackColor;
            }
            else
            {
                lbInfo.BackColor = orgBackColor;
            }
        }

        public void clear()
        {
            uhe.clear();
            if (uhiContainer != null)
            {
                uhiContainer.Controls.Remove(Uhe);
            }
        }
    }
}
