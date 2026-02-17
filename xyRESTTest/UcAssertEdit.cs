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
    public partial class UcAssertEdit : UserControl
    {
        AssertInfo assertInfo;
        public event EventHandler<EventArgs>? Edited;
        private Control assertValueEdit;

        public UcAssertEdit(AssertInfo assertInfo)
        {
            InitializeComponent();
            UiTools.FillCbWithEnum(comboBox1, typeof(AssertType));
            Leave += (s, e) => { Hide(); };

            this.assertInfo = assertInfo;

            comboBox1.Text = this.assertInfo.assertType;
        }

        private void UcAssertEdit_MouseDown(object sender, MouseEventArgs e)
        {
            // Convert the mouse coordinates from screen to the control's client coordinates
            Point clientPoint = PointToClient(Cursor.Position);

            // Check if the click occurred outside the control's client rectangle
            if (!ClientRectangle.Contains(clientPoint))
            {
                // Hide the control
                Hide();
            }
        }

        private void UcAssertEdit_VisibleChanged(object sender, EventArgs e)
        {
            // Release the mouse capture
            Capture = Visible;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Edited?.Invoke(this, new EventArgs());

            Hide();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            assertInfo.assertType = comboBox1.Text;
            if (comboBox1.Text == nameof(AssertType.StatusCode))
            {
                assertValueEdit = new UcAssertStatusCode(assertInfo)
                { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(assertValueEdit);
                this.Refresh();
            }
            else if (comboBox1.Text == nameof(AssertType.JsonContent))
            {
                assertValueEdit = new UcAssertJsonContent(assertInfo)
                { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(assertValueEdit);
                this.Refresh();
            }
        }
    }
}
