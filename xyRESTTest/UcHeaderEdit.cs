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
    public partial class UcHeaderEdit : UserControl
    {
        string headerName = string.Empty;
        object? headerValue;

        public string HeaderName { get => headerName; }
        public object? HeaderValue { get => headerValue; }

        public UcHeaderEdit(
            KeyValuePair<string, object>? header)
        {
            InitializeComponent();
            LoadStringResources();
            Leave += (s, e) => { Hide(); };

            if (header != null)
            {
                this.headerName = header.Value.Key;
                this.headerValue = header.Value.Value;
            }

            UiTools.FillCbWithEnum(comboBox1, typeof(HeaderType));
            comboBox1.Text = headerName;
        }
        public void LoadStringResources()
        {
            BtnOk.Text = Resources.strOk;
            BtnCancel.Text = Resources.strCancel;
            if(panel3.Controls.Count > 0)   
            {
                var headerValueEdit = panel3.Controls[0];
                if(headerValueEdit is UcAuthHeader uah)
                {
                    uah.LoadStringResources();
                }
            }
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
                    headerValue = tb.Text??"";
                }
                else if(headerValueEdit is UcAuthHeader uah)
                {
                    headerValue = uah.AuthHeader;
                }
            }
            if(headerValue != null)
            {
                Edited?.Invoke(this, new EventArgs());
            }

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
                if(headerValue is not AuthHeaderInfo)
                {
                    headerValue = null;
                }
                if (headerValue == null)
                {
                    headerValue = new AuthHeaderInfo();
                }
                
                headerValueEdit = new UcAuthHeader((AuthHeaderInfo)headerValue)
                    { Dock = DockStyle.Fill };
                panel3.Controls.Clear();
                panel3.Controls.Add(headerValueEdit);
            }
            else if (comboBox1.Text == nameof(HeaderType.Accept))
            {
                headerName = comboBox1.Text;

                headerValueEdit = new TextBox()
                { Dock = DockStyle.Top };
                panel3.Controls.Clear();
                panel3.Controls.Add(headerValueEdit);
            }
        }
    }
}
