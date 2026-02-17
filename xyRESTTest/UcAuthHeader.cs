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
    public partial class UcAuthHeader : UserControl
    {

        public UcAuthHeader(AuthHeaderInfo authHeader)
        {
            InitializeComponent();
            UiTools.FillCbWithEnum(comboBox1, typeof(AuthType));

            comboBox1.Text = authHeader.scheme;
            TxtUsername.Text = authHeader.username;
            TxtPassword.Text = authHeader.password;
            TxtToken.Text = authHeader.authToken;
        }

        public AuthHeaderInfo AuthHeader
        {
            get {
                return new AuthHeaderInfo()
                {
                    scheme = comboBox1.Text,
                    username = TxtUsername.Text,
                    password = TxtPassword.Text,
                    authToken = TxtToken.Text
                };
            }
        }
        public string Scheme { get => comboBox1.Text; set => comboBox1.Text = value; }
        public string Username { get => TxtUsername.Text; set => TxtUsername.Text = value; }
        public string Password { get => TxtPassword.Text; set => TxtPassword.Text = value; }
        public string Token { get => TxtToken.Text; set => TxtToken.Text = value; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == nameof(AuthType.Basic))
            {
                TlpBasic.Visible = true;
                TlpBearer.Visible = false;
            }
            else if (comboBox1.Text == nameof(AuthType.Bearer))
            {
                TlpBasic.Visible = false;
                TlpBearer.Visible = true;
            }
        }
    }
}
