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
    public partial class UcAssertContentType : UserControl
    {
        AssertInfo assertInfo;
        public UcAssertContentType(AssertInfo assertInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();

            this.assertInfo = assertInfo;
            CbContentType.Text = assertInfo.expected;
            CbContentType.ContextMenuStrip = contextMenuStrip;

            foreach(var item in xyTest.BinaryContentTypeList)
            {
                CbContentType.Items.Add(item);
            }
            CbContentType.TextChanged += (s, e) =>
            {
                assertInfo.expected = CbContentType.Text;
            };
        }
    }
}
