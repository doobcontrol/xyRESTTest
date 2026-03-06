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
    public partial class UcResponseInfo : UserControl
    {
        List<ResponseInfo> responseInfos;
        public UcResponseInfo(List<ResponseInfo> responseInfos)
        {
            InitializeComponent();
            setResponseInfos(responseInfos);
        }

        private void showResponse(ResponseInfo ri)
        {
            TlpResponse.Controls.Clear();
            TlpResponse.Controls.Add(new Label()
            {
                Text = "StatusCode",
                Dock = DockStyle.Top
            });
            TlpResponse.Controls.Add(new Label()
            {
                Text = ri.StatusCode.ToString(),
                Dock = DockStyle.Top
            });

            TlpResponse.Controls.Add(new Label()
            {
                Text = "Content-Type",
                Dock = DockStyle.Top
            });
            TlpResponse.Controls.Add(new Label()
            {
                Text = ri.MediaType,
                Dock = DockStyle.Top
            });

            TlpResponse.Controls.Add(new Label()
            {
                Text = "Content",
                Dock = DockStyle.Top
            });
            Control contentControl;
            if (ri.MediaType.Contains("image"))
            {
                contentControl = new PictureBox()
                {
                    Image = Image.FromFile(ri.Content),
                    SizeMode = PictureBoxSizeMode.AutoSize
                };
            }
            else
            {
                contentControl = new TextBox()
                {
                    Text = ri.Content,
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    ReadOnly = true
                };
            }
            TlpResponse.Controls.Add(contentControl);

            TlpResponse.Controls.Add(new Label()
            {
                Text = "Headers:",
                Dock = DockStyle.Top
            });
            TlpResponse.Controls.Add(new Label()
            {
                Text = "",
                Dock = DockStyle.Top
            });

            foreach (var header in ri.Headers)
            {
                TlpResponse.Controls.Add(new Label()
                {
                    Text = header.Key,
                    Dock = DockStyle.Top
                });
                TlpResponse.Controls.Add(new Label()
                {
                    Text = string.Join(",", header.Value),
                    Dock = DockStyle.Top
                });
            }
        }

        private void CbResponses_SelectedIndexChanged(object sender, EventArgs e)
        {
            showResponse(responseInfos[CbResponses.SelectedIndex]);
        }

        public void setResponseInfos(List<ResponseInfo> responseInfos)
        {
            CbResponses.Items.Clear();
            this.responseInfos = responseInfos;
            CbResponses.DropDownStyle = ComboBoxStyle.DropDownList;
            if (responseInfos.Count > 0)
            {
                if (responseInfos.Count == 1)
                {
                    CbResponses.Visible = false;
                }
                else
                {
                    for (int i = 0; i < responseInfos.Count; i++)
                    {
                        CbResponses.Items.Add("response " + (i + 1));
                    }
                    CbResponses.Text = "response " + responseInfos.Count;
                    CbResponses.Visible = true;
                }
                showResponse(responseInfos[responseInfos.Count - 1]);
            }
        }
    }
}
