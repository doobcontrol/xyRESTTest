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
    public partial class UcProjectInfo : UserControl
    {
        TestProject testProject;
        public event EventHandler<EventArgs>? Edited;
        public UcProjectInfo(TestProject testProject)
        {
            this.testProject = testProject;
            InitializeComponent();
            LoadStringResources();
            loadValues();

            TxtPrjName.Leave += TextBox_textchanged;
            TxtRootUrl.Leave += TextBox_textchanged;
            TxtPrjName.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    TextBox_textchanged(s, e);
                }
            };
            TxtRootUrl.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    TextBox_textchanged(s, e);
                }
            };
        }
        public void LoadStringResources()
        {
            LbPrjName.Text = Resources.strLbPrjName;
            LbRootUrl.Text = Resources.strLbRootUrl;
        }
        public void loadValues()
        {
            TxtPrjName.Text = testProject.name;
            TxtRootUrl.Text= testProject.rootUrl;
        }
        public void TextBox_textchanged(object? sender, EventArgs e)
        {
            if(sender is TextBox tb)
            {
                if(tb == TxtPrjName)
                {
                    if(tb.Text != testProject.name)
                    {
                        testProject.name = tb.Text;
                        Edited?.Invoke(this, new EventArgs());
                    }
                }
                else if (tb == TxtRootUrl)
                {
                    if (tb.Text != testProject.rootUrl)
                    {
                        Uri? newUri;
                        if (Uri.TryCreate(TxtRootUrl.Text, UriKind.Absolute, out newUri))
                        {
                            testProject.rootUrl = TxtRootUrl.Text;
                            Edited?.Invoke(this, new EventArgs());
                            xyTest.setBaseAddress(newUri);
                        }
                        else
                        {
                            TxtRootUrl.Text = testProject.rootUrl;
                        }
                    }
                }
            }
        }
    }
}
