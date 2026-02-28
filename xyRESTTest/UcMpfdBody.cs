using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTest.Properties;
using xyRESTTestLib;
using static xyRESTTest.UcTestCase;

namespace xyRESTTest
{
    public partial class UcMpfdBody : UserControl
    {
        ContentInfo contentInfo;
        public event EventHandler<EventArgs>? Edited;
        ContextMenuStrip contextMenuStrip;

        string cNameKey = "Key";
        string cNameValue = "Value";
        public UcMpfdBody(ContentInfo? contentInfo, ContextMenuStrip contextMenuStrip)
        {
            InitializeComponent();
            dataGridView1.Columns.Add(cNameKey, Resources.strKey);
            dataGridView1.Columns.Add(cNameValue, Resources.strValue);
            LoadStringResources();

            this.contextMenuStrip = contextMenuStrip;
            this.contentInfo = contentInfo ?? new ContentInfo() { fileKeyName = "files" };

            UiTools.FormatDgv(dataGridView1);

            TxtFileKeyName.Text = this.contentInfo.fileKeyName;
            TxtFileKeyName.TextChanged += (s, e) =>
            {
                this.contentInfo.fileKeyName = TxtFileKeyName.Text;
                Edited?.Invoke(this, EventArgs.Empty);
            };
            if (this.contentInfo.fileDatas != null)
            {
                foreach (var fd in this.contentInfo.fileDatas)
                {
                    AddOneFileLabel(fd);
                }
            }
            if(this.contentInfo.recordData != null)
            {
                foreach (var kv in this.contentInfo.recordData)
                {
                    dataGridView1.Rows.Add(kv.Key, kv.Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = kv.Key;
                }
            }
        }
        public void LoadStringResources()
        {
            TsbAddFile.ToolTipText = Resources.strTsbAddFile;
            TsbDelFile.ToolTipText = Resources.strTsbDelFile;
            TsbAddFormData.ToolTipText = Resources.strTsbAddFormData;
            TsbDelFormData.ToolTipText = Resources.strTsbDelFormData;
            TslFiles.Text = Resources.strTslFiles;
            TslFormData.Text = Resources.strTslFormData;
            LbUploadFileKeyName.Text = Resources.strLbUploadFileKeyName;
            dataGridView1.Columns[cNameKey].HeaderText = Resources.strKey;
            dataGridView1.Columns[cNameValue].HeaderText = Resources.strValue;
        }

        private void TsbAddFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;
                if (contentInfo.fileDatas.Contains(filePath))
                {
                    MessageBox.Show(Resources.strFileAlreadyAdded);
                    return;
                }

                contentInfo.fileDatas.Add(filePath);
                AddOneFileLabel(filePath);

                Edited?.Invoke(this, EventArgs.Empty);
            }
        }

        Label? selectdFileLabel;
        private void AddOneFileLabel(string filePath)
        {
            var newLabel = new Label()
            {
                Text = filePath,
                AutoSize = false,
                Dock = DockStyle.Top
            };
            newLabel.MouseEnter += (s, e) =>
            {
                newLabel.BackColor = Color.LightBlue;
            };
            newLabel.MouseLeave += (s, e) =>
            {
                if (selectdFileLabel != s as Label)
                {
                    newLabel.BackColor = Color.Transparent;
                }
            };
            newLabel.Click += (s, e) =>
            {
                selectdFileLabel = s as Label;
                foreach (var fileLabel in TlpFiles.Controls.OfType<Label>())
                {
                    if (fileLabel == selectdFileLabel)
                    {
                        fileLabel.BackColor = Color.LightBlue;
                        fileLabel.BorderStyle = BorderStyle.FixedSingle;
                    }
                    else
                    {
                        fileLabel.BackColor = Color.Transparent;
                        fileLabel.BorderStyle = BorderStyle.None;
                    }
                }
            };

            // The second row will not be visible if RowCount is not increased
            TlpFiles.RowCount++;
            TlpFiles.Controls.Add(newLabel);
        }

        private void TsbDelFile_Click(object sender, EventArgs e)
        {
            if (selectdFileLabel != null)
            {
                contentInfo.fileDatas.Remove(selectdFileLabel.Text);
                TlpFiles.Controls.Remove(selectdFileLabel);
                selectdFileLabel.Dispose();
                selectdFileLabel = null;
                Edited?.Invoke(this, EventArgs.Empty);
            }
        }

        private void TsbAddFormData_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void TsbDelFormData_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var key = row.Tag?.ToString();
                if (key != null)
                {
                    contentInfo.recordData.Remove(key);
                }
                dataGridView1.Rows.Remove(row);
                Edited?.Invoke(this, EventArgs.Empty);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var c0 = row.Cells[0].Value?.ToString();
            var c1 = row.Cells[1].Value?.ToString();

            var newParamName = cell.Value?.ToString();

            if (dataGridView1.Rows[e.RowIndex].Tag != null)
            {
                var rowKey = dataGridView1.Rows[e.RowIndex].Tag?.ToString();
                if(c0 == rowKey)
                {
                    contentInfo.recordData[c0] = c1 ?? "";
                }
                else
                {
                    if (contentInfo.recordData.ContainsKey(c0))
                    {
                        MessageBox.Show(Resources.strFormDataAlreadyAdded);
                        cell.Value = rowKey;
                        return;
                    }
                    else
                    {
                        contentInfo.recordData.Remove(rowKey);
                        contentInfo.recordData.Add(c0, c1 ?? "");
                        dataGridView1.Rows[e.RowIndex].Tag = c0;
                    }
                }
            }
            else
            {
                if(c0 != null && c0 != "")
                {
                    if (contentInfo.recordData.ContainsKey(c0))
                    {
                        MessageBox.Show(Resources.strFormDataAlreadyAdded);
                        cell.Value = null;
                        return;
                    }
                    else
                    {
                        contentInfo.recordData.Add(c0, c1 ?? "");
                        dataGridView1.Rows[e.RowIndex].Tag = c0;
                    }
                }
            }
            Edited?.Invoke(this, EventArgs.Empty);
        }
    }
}
