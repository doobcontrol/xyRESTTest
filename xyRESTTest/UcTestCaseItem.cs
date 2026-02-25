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
    public partial class UcTestCaseItem : UserControl
    {
        TestTask testTask;
        public TestTask TestTask { get => testTask; }
        bool selected;

        public event EventHandler<EventArgs>? Selected;
        public event EventHandler<EventArgs>? Run;
        public UcTestCaseItem(TestTask testTask)
        {
            InitializeComponent();
            LoadStringResources();
            SubscribeAllControlClicks(this);
            orgBackColor = this.BackColor;
            orgBordderStyle = this.BorderStyle;

            this.testTask = testTask;
            label1.Text = testTask.name;

            panel1.Click += (s, e) => {
                Run?.Invoke(this, new EventArgs());
            };
            panel1.MouseEnter += (s, e) => {
                panel1.BorderStyle = BorderStyle.FixedSingle;
                panel1.BackColor = Color.LightYellow;
            };
            panel1.MouseLeave += (s, e) => {
                panel1.BorderStyle = BorderStyle.None;
                panel1.BackColor = Color.Transparent;
            };
        }

        // A single event handler for all controls
        private void AllControls_Click(object sender, EventArgs e)
        {
            if (!selected)
            {
                SetSelected(true);
                Selected?.Invoke(this, new EventArgs());
            }
        }

        // Recursive method to subscribe all controls within a parent control
        private void SubscribeAllControlClicks(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                // Subscribe the current control's Click event
                control.Click += AllControls_Click;

                // If the control has its own sub-controls (like a Panel or GroupBox), 
                // recursively call the method
                if (control.HasChildren)
                {
                    SubscribeAllControlClicks(control);
                }
            }
        }

        Color orgBackColor;
        public static Color selectedBackColor = Color.LightBlue;
        BorderStyle orgBordderStyle;
        BorderStyle selectedBorderStyle = BorderStyle.FixedSingle;

        public void SetSelected(bool selected)
        {
            if (selected)
            {
                this.BackColor = selectedBackColor;
                this.BorderStyle = selectedBorderStyle;
            }
            else
            {
                this.BackColor = orgBackColor;
                this.BorderStyle = orgBordderStyle;
            }
            this.selected = selected;
        }

        public void UpdateDisplay()
        {
            if (label1.Text != testTask.name)
            {
                label1.Text = testTask.name;
            }
        }
        public void LoadStringResources()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(panel1, Resources.strRunThisTestCase);
        }

    }
}
