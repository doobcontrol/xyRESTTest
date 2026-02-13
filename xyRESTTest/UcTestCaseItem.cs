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
    public partial class UcTestCaseItem : UserControl
    {
        TestTask testTask;
        public TestTask TestTask { get => testTask; }
        public UcTestCaseItem(TestTask testTask)
        {
            InitializeComponent();
            SubscribeAllControlClicks(this); 
            orgBackColor = this.BackColor;
            orgBordderStyle = this.BorderStyle;

            this.testTask = testTask;
            label1.Text = testTask.name;
        }

        // A single event handler for all controls
        private void AllControls_Click(object sender, EventArgs e)
        {
            // Use the 'sender' object to determine which control was clicked
            Control clickedControl = sender as Control;

            if (clickedControl != null)
            {
            }

            SetSelected(true);
            Selected?.Invoke(this, new EventArgs());
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
        }

        public event EventHandler<EventArgs>? Selected;
    }
}
