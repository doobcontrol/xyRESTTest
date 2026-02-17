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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace xyRESTTest
{
    public partial class UcHeaderEdit : UserControl
    {
        string headerName = string.Empty;
        object headerValue;

        public string HeaderName { get => headerName; }
        public object HeaderValue { get => headerValue; }

        public UcHeaderEdit(
            KeyValuePair<string, object>? header)
        {
            InitializeComponent();
            Leave += (s, e) => { Hide(); };

            if (header != null)
            {
                this.headerName = header.Value.Key;
                this.headerValue = header.Value.Value;
            }

            UiTools.FillCbWithEnum(comboBox1, typeof(HeaderType));
            comboBox1.Text = headerName;
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

        private Control headerValueEdit;
        public event EventHandler<EventArgs>? Edited;
        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Here you can add code to save the header information entered by the user
            headerName = comboBox1.Text;
            if(headerValueEdit != null)
            {
                if(headerValueEdit is TextBox tb)
                {
                    headerValue = tb.Text;
                }
                else if(headerValueEdit is UcAuthHeader uah)
                {
                    headerValue = uah.AuthHeader;
                }
            }
            Edited?.Invoke(this, new EventArgs());

            Hide();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == nameof(HeaderType.Authorization))
            {
                headerName = comboBox1.Text;
                if (headerValue == null)
                {
                    headerValue = new AuthHeaderInfo();
                }
                
                headerValueEdit = new UcAuthHeader((AuthHeaderInfo)headerValue)
                    { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(headerValueEdit);
                this.Refresh();
            }
        }
    }
}
