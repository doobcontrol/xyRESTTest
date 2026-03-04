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
    public partial class UcRecentOpenList : UserControl
    {
        public event EventHandler<EventArgs>? Selected;
        public event EventHandler<EventArgs>? DeleteNotExistProject;
        Label selectedProjectLabel;

        public string SelectedProject { get => selectedProjectLabel.Text; }

        public UcRecentOpenList(List<string> projectsList)
        {
            InitializeComponent();
            LoadStringResources();
            LbTitle.BackColor = UcTestCaseItem.selectedBackColor;

            // Add project items to the flow layout panel
            foreach (string project in projectsList)
            {
                //var item = new UcRecentOpenListItem(project);
                var item = new Label() { Text = project};
                item.AutoSize = false;
                item.Dock = DockStyle.Top;
                item.Click += Item_Click;
                item.MouseEnter += Item_MouseEnter;
                item.MouseLeave += Item_MouseLeave;

                TlpProjectsList.Controls.Add(item);
            }
        }
        public void LoadStringResources()
        {
            LbTitle.Text = Resources.strRecentOpenList;
        }

        private void Item_Click(object? sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                selectedProjectLabel = label;
                if (File.Exists(label.Text))
                {
                    Selected?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(
                        Resources.strProjectFileNotExists,
                        Resources.strError,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    DeleteNotExistProject?.Invoke(this, EventArgs.Empty);
                    selectedProjectLabel = null;
                    TlpProjectsList.Controls.Remove(label);
                    label.Dispose();
                }
            }
        }
        private void Item_MouseEnter(object? sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.LightGray;
                label.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void Item_MouseLeave(object? sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                if (selectedProjectLabel != label)
                {
                    label.BackColor = Color.Transparent;
                    label.BorderStyle = BorderStyle.None;
                }
            }
        }
    }
}
