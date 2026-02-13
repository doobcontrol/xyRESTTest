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
    public partial class UcHeaderEdit : UserControl
    {
        public UcHeaderEdit()
        {
            InitializeComponent();
            Leave += (s, e) => { Hide(); };
        }

        private void UcHeaderEdit_MouseDown(object? sender, MouseEventArgs e)
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

        private void UcHeaderEdit_VisibleChanged(object sender, EventArgs e)
        {
            // Release the mouse capture
            Capture = Visible;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Here you can add code to save the header information entered by the user

            Hide();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Authorization")
            {
                var uah = new UcAuthHeader() { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(uah);
                this.Refresh();
            }
        }
    }
}
