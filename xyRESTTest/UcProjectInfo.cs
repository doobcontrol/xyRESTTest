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
                        testProject.rootUrl = tb.Text;
                        Edited?.Invoke(this, new EventArgs());
                    }
                }
            }
        }
    }
}
