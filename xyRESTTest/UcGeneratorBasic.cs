using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTestLib;
using static xyRESTTest.UcTestCase;

namespace xyRESTTest
{
    public partial class UcGeneratorBasic : UserControl, UcTestCase.IGeneratorConfigControl
    {
        DataGenerator dataGenerator;
        public event EventHandler<EventArgs>? Edited;

        List<Dictionary<string,string>> dataRecords = new List<Dictionary<string, string>>();
        public UcGeneratorBasic(DataGenerator dataGenerator)
        {
            InitializeComponent();

            DgvRecords.AllowUserToAddRows = false;
            DgvRecords.AllowUserToDeleteRows = false;
            DgvRecords.AllowUserToResizeRows = false;
            DgvRecords.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvRecords.MultiSelect = false;
            DgvRecords.RowHeadersVisible = false;

            TslDataFile.Text = dataGenerator.GeneratorInfo[xyTest.DGT_Basic_File];
            InitParamList(dataGenerator.ParamList);

            LoadDataRecords();

            RefreshDataRecords();
        }
        private void InitParamList(List<string> ParamNames)
        {
            foreach (string ParamName in ParamNames)
            {
                DgvRecords.Columns.Add(ParamName, ParamName);
            }
        }
        private void RefreshDataRecords()
        {
            DgvRecords.Rows.Clear();
            foreach (Dictionary<string, string> dataRecord in dataRecords)
            {
                int rowIndex = DgvRecords.Rows.Add();
                DataGridViewRow row = DgvRecords.Rows[rowIndex];
                foreach (DataGridViewColumn column in DgvRecords.Columns)
                {
                    if (dataRecord.ContainsKey(column.Name))
                    {
                        row.Cells[column.Index].Value = dataRecord[column.Name];
                    }
                }
            }
        }
        private void LoadDataRecords()
        {
            if(File.Exists(TslDataFile.Text))
            {
                dataRecords.Clear();
                string[] lines = File.ReadAllLines(TslDataFile.Text);
                if(lines.Length > 0)
                {
                    string[] headers = lines[0].Split(',');
                    for(int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(',');
                        Dictionary<string, string> dataRecord = new Dictionary<string, string>();
                        for(int j = 0; j < headers.Length && j < values.Length; j++)
                        {
                            dataRecord[headers[j]] = values[j];
                        }
                        dataRecords.Add(dataRecord);
                    }
                }
            }
        }
        private void SaveDataRecords()
        {
            List<string> lines = new List<string>();
            string[] headers = DgvRecords.Columns.Cast<DataGridViewColumn>()
                .Select(col => col.Name).ToArray();
            lines.Add(string.Join(",", headers));
            foreach (DataGridViewRow row in DgvRecords.Rows)
            {
                string[] values = headers.Select(h => row.Cells[h].Value?.ToString() ?? "").ToArray();
                lines.Add(string.Join(",", values));
            }
            File.WriteAllLines(TslDataFile.Text, lines);
        }

        #region UcTestCase.IGeneratorConfigControl
        public void AddAParam(string ParamName)
        {
            DgvRecords.Columns.Add(ParamName, ParamName);
        }
        public void DelAParam(string ParamName)
        {
            DgvRecords.Columns.Remove(ParamName);
        }
        public void UpdateAParam(string newName, string oldName)
        {
            DgvRecords.Columns[oldName].Name = newName;
        }
        #endregion

        private void TsbAddRecord_Click(object sender, EventArgs e)
        {
            DgvRecords.Rows.Add();
        }

        private void TsbDelRecord_Click(object sender, EventArgs e)
        {
            if (DgvRecords.SelectedRows.Count > 0)
            {
                if (DgvRecords.SelectedRows[0].Tag != null)
                {
                    dataRecords.Remove(
                        (Dictionary<string, string>)DgvRecords.SelectedRows[0].Tag);
                }
                DgvRecords.Rows.Remove(DgvRecords.SelectedRows[0]);
            }
        }

        private void DgvRecords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = DgvRecords.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            string columnName = DgvRecords.Columns[e.ColumnIndex].Name;
            if (cell != null)
            {
                if (row.Tag == null)
                {
                    row.Tag = new Dictionary<string, string>();
                    dataRecords.Add((Dictionary<string, string>)row.Tag);
                }
                ((Dictionary<string, string>)row.Tag)[columnName] = cell.Value?.ToString() ?? "";
                SaveDataRecords();
            }
        }

        private void TsbDataFile_Click(object sender, EventArgs e)
        {

        }
    }
}
