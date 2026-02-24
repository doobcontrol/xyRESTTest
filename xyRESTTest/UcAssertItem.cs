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

        bool isNew = false;

        public UcAssertItem(
            AssertInfo? assertInfo,
            ContextMenuStrip contextMenuStrip,
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
                lbInfo.Text = getAssertInfoText(); 
                isNew = false;
            }
            else
            {
                this.assertInfo = new AssertInfo() 
                { 
                    assertType = nameof(AssertType.StatusCode) 
                };
                lbInfo.Text = Resources.strUnfefined;
                isNew = true;
            }

            uae = new UcAssertEdit(this.assertInfo, contextMenuStrip) { Visible = false };
            uae.Edited += Assert_edited;
            LoadStringResources();
        }
        public void LoadStringResources()
        {
            if (isNew)
            {
                lbInfo.Text = Resources.strUnfefined;
            }
            else
            {
                lbInfo.Text = getAssertInfoText();
            }
            uae?.LoadStringResources();
        }
        private void Assert_edited(object? sender, EventArgs e)
        {
            if (sender is UcAssertEdit uae)
            {
                lbInfo.Text = getAssertInfoText();

                Edited?.Invoke(this, new EventArgs());
                isNew = false;
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
                    this.PointToScreen(new Point(lbInfo.Left, this.MinimumSize.Height)));
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

        private string getAssertInfoText()
        {
            string assertInfoText = $"{assertInfo.assertType}";
            switch (assertInfo.assertType)
            {
                case nameof(AssertType.StatusCode):
                    assertInfoText += $": {assertInfo.expected}";
                    break;
                case nameof(AssertType.JsonContent):
                    if(assertInfo.assertList == null)
                    {
                        assertInfoText += ": " 
                            + string.Format(Resources.strAssertCount, 0);
                    }
                    else
                    {
                        assertInfoText += ": "
                            + string.Format(Resources.strAssertCount, assertInfo.assertList.Count);
                    }
                    if (assertInfo.readList == null)
                    {
                        assertInfoText += ", "
                            + string.Format(Resources.strReadDataCount, 0);
                    }
                    else
                    {
                        assertInfoText += ", "
                            + string.Format(Resources.strReadDataCount, assertInfo.readList.Count);
                    }
                    break;
                default:
                    return assertInfo.assertType;
            }
            return assertInfoText;
        }
    }
}
