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
    public partial class UcAssertJsonContent : UserControl
    {
        AssertInfo assertInfo; 
        ToolTip toolTip1 = new ToolTip();
        string cNameJsonPath = "JsonPath";
        string cNameExpected = "Expected";
        string cNameSaveKey = "SaveKey";
        ContextMenuStrip contextMenuStrip;
        public UcAssertJsonContent(AssertInfo assertInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();
            this.contextMenuStrip = contextMenuStrip;
            this.assertInfo = assertInfo;

            DgvAssert.Columns.Add(cNameJsonPath, Resources.strJSONPath);
            DgvAssert.Columns.Add(cNameExpected, Resources.strExpectedValue);
            DgvRead.Columns.Add(cNameSaveKey, Resources.strParameterName);
            DgvRead.Columns.Add(cNameJsonPath, Resources.strJSONPath);
            LoadStringResources();

            if (this.assertInfo.assertList == null)
            {
                this.assertInfo.assertList = new Dictionary<string, string>();
            }
            else
            {
                foreach (var al in this.assertInfo.assertList)
                {
                    int index = DgvAssert.Rows.Add(al.Key, al.Value);
                    DgvAssert.Rows[index].Tag = al.Key;
                }
            }
            if (this.assertInfo.readList == null)
            {
                this.assertInfo.readList = new Dictionary<string, string>();
            }
            else
            {
                foreach (var rl in this.assertInfo.readList)
                {
                    int index = DgvRead.Rows.Add(rl.Key, rl.Value);
                    DgvRead.Rows[index].Tag = rl.Key;
                }
            }

            AutoHeightGrid(DgvAssert);
            AutoHeightGrid(DgvRead);

            DgvRead.Visible = false;

            addClickEvent(TsAssert);
            addClickEvent(TsRead);

            DgvAssert.Tag = assertInfo.assertList;
            DgvRead.Tag = assertInfo.readList;
            DgvAssert.CellEndEdit += Dgv_CellEndEdit;
            DgvRead.CellEndEdit += Dgv_CellEndEdit;

            DgvAssert.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            DgvRead.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DgvAssert.EditingControlShowing += (o, s) =>
            {
                if (s.Control is TextBox textBox)
                {
                    textBox.ContextMenuStrip = this.contextMenuStrip;
                }
            };
            DgvRead.EditingControlShowing += (o, s) =>
            {
                if (s.Control is TextBox textBox)
                {
                    textBox.ContextMenuStrip = this.contextMenuStrip;
                }
            };
        }
        public void LoadStringResources()
        {
            DgvAssert.Columns[cNameJsonPath].HeaderText = Resources.strJSONPath;
            DgvAssert.Columns[cNameExpected].HeaderText = Resources.strExpectedValue;
            DgvRead.Columns[cNameSaveKey].HeaderText = Resources.strParameterName;
            DgvRead.Columns[cNameJsonPath].HeaderText = Resources.strJSONPath;
            TslAssertionList.Text = Resources.strAssertionList;
            TslReadDataList.Text = Resources.strReadDataList;
            TsbAddAssertList.ToolTipText = Resources.strAddAssertion;
            TsbDelAssertList.ToolTipText = Resources.strDeleteAssertion;
            TsbAddReadList.ToolTipText = Resources.strAddReadItem;
            TsbDelReadList.ToolTipText = Resources.strDeleteReadItem;
        }
        private void switchList(object? sender, EventArgs e)
        {

            if (sender is ToolStripItem tsi)
            {
                if (tsi.GetCurrentParent() == TsAssert && DgvAssert.Visible)
                {
                    return;
                }
                else if (tsi.GetCurrentParent() == TsRead && DgvRead.Visible)
                {
                    return;
                }
            }
            else if (sender is ToolStrip ts)
            {
                if (ts == TsAssert && DgvAssert.Visible)
                {
                    return;
                }
                else if (ts == TsRead && DgvRead.Visible)
                {
                    return;
                }
            }

            if (DgvAssert.Visible)
            {
                DgvAssert.Visible = false;
                DgvRead.Visible = true;
            }
            else
            {
                DgvAssert.Visible = true;
                DgvRead.Visible = false;
            }
        }
        private void addClickEvent(ToolStrip ts)
        {
            ts.Click += switchList;
            foreach (var control in TsAssert.Controls)
            {
                if (control is ToolStripItem tsi)
                {
                    tsi.Click += switchList;
                }
            }
        }

        void AutoHeightGrid(DataGridView grid)
        {
            // Calculate the preferred size of the grid with a proposed width,
            // allowing the height to be determined automatically.
            var proposedSize = grid.GetPreferredSize(new Size(0, 0));
            // Set the height of the grid to the calculated preferred height.
            grid.Height = proposedSize.Height;
        }

        private void TsbAddAssertList_Click(object sender, EventArgs e)
        {
            DgvAssert.Rows.Add(null, null);
            AutoHeightGrid(DgvAssert);
        }

        private void TsbDelAssertList_Click(object sender, EventArgs e)
        {
            if(DgvAssert.SelectedRows.Count > 0)
            {
                var row = DgvAssert.SelectedRows[0];
                var list = DgvAssert.Tag as Dictionary<string, string>;
                if (list != null && row.Tag != null)
                {
                    list.Remove(row.Tag.ToString());
                }
                DgvAssert.Rows.Remove(row);
                AutoHeightGrid(DgvAssert);
            }
        }

        private void TsbAddReadList_Click(object sender, EventArgs e)
        {
            DgvRead.Rows.Add(null, null);
            AutoHeightGrid(DgvRead);
        }

        private void TsbDelReadList_Click(object sender, EventArgs e)
        {
            if (DgvRead.SelectedRows.Count > 0)
            {
                var row = DgvRead.SelectedRows[0];
                var list = DgvRead.Tag as Dictionary<string, string>;
                if (list != null && row.Tag != null)
                {
                    list.Remove(row.Tag.ToString());
                }
                DgvRead.Rows.Remove(row);
                AutoHeightGrid(DgvRead);
            }
        }

        private void Dgv_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            var list = dgv.Tag as Dictionary<string, string>;
            if (list == null)
            {
                return;
            }

            var keyCell = dgv.Rows[e.RowIndex].Cells[0];
            var valueCell = dgv.Rows[e.RowIndex].Cells[1];
            if (e.ColumnIndex == 0
                && keyCell.Value.ToString() != dgv.Rows[e.RowIndex].Tag
                && list.ContainsKey(keyCell.Value.ToString()))
            {
                // Key already exists: 
                keyCell.Value = dgv.Rows[e.RowIndex].Tag;
                toolTip1.Show("Key already exists!", TsAssert, 0, 0, 3000);
                return;
            }
            if (keyCell.Value == null || valueCell.Value == null)
            {
                return;
            }

            if (dgv.Rows[e.RowIndex].Tag == null)
            {
                dgv.Rows[e.RowIndex].Tag = keyCell.Value;
                list.Add(keyCell.Value.ToString(), valueCell.Value.ToString());
            }
            else
            {
                if (dgv.Rows[e.RowIndex].Tag == keyCell.Value)
                {
                    list[keyCell.Value.ToString()] = valueCell.Value.ToString();
                }
                else
                {
                    list.Remove(dgv.Rows[e.RowIndex].Tag.ToString());
                    dgv.Rows[e.RowIndex].Tag = keyCell.Value;
                    list.Add(keyCell.Value.ToString(), valueCell.Value.ToString());
                }
            }
        }
    }
}
