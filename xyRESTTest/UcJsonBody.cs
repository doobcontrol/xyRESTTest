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
    public partial class UcJsonBody : UserControl
    {
        ContentInfo contentInfo;
        public UcJsonBody(ContentInfo? contentInfo)
        {
            InitializeComponent();
            UiTools.FillCbWithEnum(comboBox1, typeof(JCType));
            if (contentInfo != null)
            {
                this.contentInfo = contentInfo;
                comboBox1.Text = contentInfo.type;
            }
            else
            {
                this.contentInfo = new ContentInfo()
                {
                    recordData = new Dictionary<string, string>(),
                    ctype = xyTest.CT_app_json
                };
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            contentInfo.type = comboBox1.Text;
            switch (comboBox1.Text)
            {
                case nameof(JCType.SimpleJson):
                    PnlJsonEditor.Controls.Clear();
                    var ucSimpleJson = new UcJsonBodySimple(contentInfo);
                    ucSimpleJson.Edited += JsonBody_Edited;
                    ucSimpleJson.Dock = DockStyle.Fill;
                    PnlJsonEditor.Controls.Add(ucSimpleJson);
                    break;
            }
        }

        private void JsonBody_Edited(object? sender, EventArgs e)
        {
            Edited?.Invoke(this, new EventArgs());
        }
        public event EventHandler<EventArgs>? Edited;
    }
}
