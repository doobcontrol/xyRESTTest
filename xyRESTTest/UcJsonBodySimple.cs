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
    public partial class UcJsonBodySimple : UserControl
    {
        Dictionary<string, string> recordData;

        public Dictionary<string, string> RecordData { get => recordData; }

        public UcJsonBodySimple(ContentInfo contentInfo)
        {
            InitializeComponent();
            recordData = contentInfo.recordData ?? new Dictionary<string, string>();

            dataGridView1.Columns.Add("Key", "Key");
            dataGridView1.Columns.Add("Value", "Value");
            foreach (var kv in recordData)
            {
                dataGridView1.Rows.Add(kv.Key, kv.Value);
            }
            ShowTextContent();
            dataGridView1.CellValueChanged += (o, s) =>
            {
                if (s.RowIndex >= 0 && s.ColumnIndex >= 0)
                {
                    recordDataChanged();
                }
            };
        }
        private void ShowTextContent()
        {
            TxtContent.Text = RcontentTools.SimpleJson(recordData);
        }
        private void rebuildRecordData()
        {
            recordData.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string key = row.Cells[0].Value.ToString() ?? "";
                    string value = row.Cells[1].Value?.ToString() ?? "";
                    recordData[key] = value;
                }
            }
        }
        private void recordDataChanged()
        {
            rebuildRecordData();
            ShowTextContent();
            Edited?.Invoke(this, new EventArgs());
        }

        private void TsbAddPar_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.CurrentCell = dataGridView1[0, rowIndex];
            dataGridView1.Select();
            dataGridView1.BeginEdit(true);
        }

        private void TsbDelPar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                recordDataChanged();
            }
        }

        public event EventHandler<EventArgs>? Edited;
    }
}
