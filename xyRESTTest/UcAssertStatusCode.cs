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
    public partial class UcAssertStatusCode : UserControl
    {
        AssertInfo assertInfo;
        public UcAssertStatusCode(AssertInfo assertInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();
            LoadStringResources();
            this.assertInfo = assertInfo;
            TxtExpected.Text = assertInfo.expected;
            TxtExpected.ContextMenuStrip = contextMenuStrip;

            TxtExpected.TextChanged += TxtExpected_TextChanged;
        }
        public void LoadStringResources()
        {
            TxtExpected.PlaceholderText = Resources.strExpectedValue;
        }

        private void TxtExpected_TextChanged(object? sender, EventArgs e)
        {
            assertInfo.expected = TxtExpected.Text;
        }
    }
}
