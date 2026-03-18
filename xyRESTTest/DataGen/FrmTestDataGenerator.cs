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
using static System.Net.Mime.MediaTypeNames;

namespace xyRESTTest.DataGen
{
    public partial class FrmTestDataGenerator : Form
    {
        private List<Dictionary<string, string>> testDatas;
        public List<Dictionary<string, string>> TestDatas { get => testDatas; }
        private Dictionary<string, Dictionary<string, string?>?> DataGeneratePars = new();
        private string columnsName_ParName = "ParName";
        private string columnsName_ParValue = "ParValue";
        private Dictionary<string, string> parShowNames = new();
        public FrmTestDataGenerator(List<string> parameters)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            ShowParameters(parameters);
            InitDataGenerateTypeList();
            LoadStringResources();

            CbDataGenerateType.Visible = false;
            DgvParsEditor.Visible = false;
            DgvParsEditor.ColumnHeadersVisible = false;
            DgvParsEditor.RowHeadersVisible = false;
            DgvParsEditor.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DgvParsEditor.AllowUserToDeleteRows = false;
            DgvParsEditor.AllowUserToAddRows = false;
            DgvParsEditor.Columns.Add(columnsName_ParName, columnsName_ParName);
            DgvParsEditor.Columns.Add(columnsName_ParValue, columnsName_ParValue);
            DgvParsEditor.Columns[columnsName_ParName].ReadOnly = true;
            DgvParsEditor.Columns[columnsName_ParName].AutoSizeMode
                = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DgvParsEditor.Columns[columnsName_ParValue].AutoSizeMode
                = DataGridViewAutoSizeColumnMode.Fill;

            NudQuantityToGenerate.Value = 10;
        }
        public void LoadStringResources()
        {
            this.Text = Resources.strFrmTestDataGeneratorTitle;
            LbQuantityToGenerate.Text = Resources.strLbQuantityToGenerate;
            BtnOk.Text = Resources.strOk;
            BtnCancel.Text = Resources.strCancel;

            parShowNames.Add(OrdinalPar_StartNumber, Resources.strStartNumber);
            parShowNames.Add(OrdinalPar_StringLength, Resources.strStringLength);
        }

        Label selectedParLabel;
        private void ShowParameters(List<string> parameters)
        {
            foreach (var par in parameters)
            {
                DataGeneratePars.Add(par, null);
                var parLabel = new Label()
                {
                    Text = par,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                };
                parLabel.Click += (sender, e) =>
                {
                    foreach (var control in TlpParameters.Controls)
                    {
                        if (control is Label lb)
                        {
                            if (lb == sender)
                            {
                                lb.BorderStyle = BorderStyle.FixedSingle;
                                lb.BackColor = Color.LightBlue;
                                selectedParLabel = lb;
                            }
                            else
                            {
                                lb.BorderStyle = BorderStyle.None;
                                lb.BackColor = Color.Transparent;
                            }
                        }
                    }
                    ShowParsEditer();
                };
                parLabel.MouseEnter += (sender, e) =>
                {
                    if (selectedParLabel != sender && sender is Label lb)
                    {
                        lb.BorderStyle = BorderStyle.FixedSingle;
                        lb.BackColor = Color.LightYellow;
                    }
                };
                parLabel.MouseLeave += (sender, e) =>
                {
                    if (selectedParLabel != sender && sender is Label lb)
                    {
                        lb.BorderStyle = BorderStyle.None;
                        lb.BackColor = Color.Transparent;
                    }
                };

                TlpParameters.Controls.Add(parLabel);
            }
        }
        private void ShowParsEditer()
        {
            CbDataGenerateType.SelectedIndex = -1;
            CbDataGenerateType.Visible = true;
            if (DataGeneratePars.ContainsKey(selectedParLabel.Text)
                && DataGeneratePars[selectedParLabel.Text] != null)
            {
                CbDataGenerateType.SelectedValue = 
                    (DataGenerateType)Enum.Parse(typeof(DataGenerateType),
                        DataGeneratePars[selectedParLabel.Text][nameof(DataGenerateType)]);
            }
        }
        private void InitDataGenerateTypeList()
        {
            var dgtSource = new Dictionary<DataGenerateType, string>();
            dgtSource.Add(DataGenerateType.Ordinal, Resources.strDataGenerateTypeOrdinal);
            dgtSource.Add(DataGenerateType.RandomString, Resources.strDataGenerateTypeRandomString);
            dgtSource.Add(DataGenerateType.RandomHumanName, Resources.strDataGenerateTypeRandomHumanName);

            CbDataGenerateType.DataSource = new BindingSource(dgtSource, null);
            CbDataGenerateType.DisplayMember = "value";
            CbDataGenerateType.ValueMember = "key";
            CbDataGenerateType.SelectedIndex = -1;

            CbDataGenerateType.SelectedIndexChanged += (s, e) =>
            {
                if (CbDataGenerateType.SelectedIndex == -1)
                {
                    DgvParsEditor.Visible = false;
                }
                else
                {
                    if (DataGeneratePars[selectedParLabel.Text] == null
                        || DataGeneratePars[selectedParLabel.Text][nameof(DataGenerateType)] 
                        != CbDataGenerateType.SelectedValue.ToString())
                    {
                        var newPars = CreateNewPars((DataGenerateType)CbDataGenerateType.SelectedValue);
                        DataGeneratePars[selectedParLabel.Text] = newPars;
                    }

                    DgvParsEditor.Rows.Clear();
                    DgvParsEditor.Tag = DataGeneratePars[selectedParLabel.Text];
                    foreach (var par in DataGeneratePars[selectedParLabel.Text])
                    {
                        if(par.Key != nameof(DataGenerateType))
                        {
                            int index = DgvParsEditor.Rows.Add();
                            DgvParsEditor.Rows[index].Tag = par.Key;
                            DgvParsEditor.Rows[index].Cells[columnsName_ParName].Value 
                                = parShowNames[par.Key];
                            DgvParsEditor.Rows[index].Cells[columnsName_ParValue].Value 
                                = par.Value;
                        }
                    }
                    DgvParsEditor.Visible = true;
                }
            };
        }
        private Dictionary<string, string?> CreateNewPars(DataGenerateType parType)
        {
            var newPars = new Dictionary<string, string?>();
            switch (parType)
            {
                case DataGenerateType.Ordinal:
                    newPars.Add(nameof(DataGenerateType), nameof(DataGenerateType.Ordinal));
                    newPars.Add(OrdinalPar_StartNumber, null);
                    newPars.Add(OrdinalPar_StringLength, null);
                    break;
                case DataGenerateType.RandomString:
                    newPars.Add(nameof(DataGenerateType), nameof(DataGenerateType.RandomString));
                    newPars.Add(RandomStringPar_StringLength, null);
                    break;
                case DataGenerateType.RandomHumanName:
                    newPars.Add(nameof(DataGenerateType), nameof(DataGenerateType.RandomHumanName));
                    break;
            }
            return newPars;
        }

        private async void BtnOk_Click(object sender, EventArgs e)
        {
            foreach (var par in DataGeneratePars)
            {
                if (par.Value == null)
                {
                    MessageBox.Show(
                        string.Format(
                            Resources.strError_ParameterDataGenerationRulesNotDefine, par.Key),
                        Resources.strError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //check every par

            }

            this.Text = this.Text + " - " + Resources.strGeneratingTestData;
            this.Enabled = false;

            await Task.Run(new Action(() => {
                testDatas = new List<Dictionary<string, string>>();
                for (int i = 0; i < NudQuantityToGenerate.Value; i++)
                {
                    var dataRecord = new Dictionary<string, string>();
                    foreach (var par in DataGeneratePars)
                    {
                        DataGenerateType parType = (DataGenerateType)Enum.Parse(
                            typeof(DataGenerateType), par.Value[nameof(DataGenerateType)]);
                        switch (parType)
                        {
                            case DataGenerateType.Ordinal:
                                dataRecord.Add(par.Key, GenerateOrdinal(i, par.Value));
                                break;
                            case DataGenerateType.RandomString:
                                dataRecord.Add(par.Key, GenerateRandomString(i, par.Value));
                                break;
                            case DataGenerateType.RandomHumanName:
                                dataRecord.Add(par.Key, GenerateRandomHumanName(i, par.Value));
                                break;
                        }
                    }
                    TestDatas.Add(dataRecord);
                }
            }));

            DialogResult = DialogResult.OK;
        }

        private const string OrdinalPar_StartNumber = "StartNumber";
        private const string OrdinalPar_StringLength = "StringLength";

        private string GenerateOrdinal(int index, Dictionary<string, string> Pars)
        {
            int ordinal = index + int.Parse(Pars[OrdinalPar_StartNumber]);
            return ordinal.ToString("D" + Pars[OrdinalPar_StringLength]);
        }

        private const string RandomStringPar_StringLength = OrdinalPar_StringLength;
        private string GenerateRandomString(int index, Dictionary<string, string> Pars)
        {
            string AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            int length = int.Parse(Pars[RandomStringPar_StringLength]);
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                // Select a random character from the pool
                result.Append(AllowedChars[random.Next(AllowedChars.Length)]);
            }
            return result.ToString();
        }
        private string GenerateRandomHumanName(int index, Dictionary<string, string> Pars)
        {
            var FirstNameList = Resources.strName_FirstNameList.Split(",");
            var LastNameList = Resources.strName_LastNameList.Split(",");
            Random random = new Random();
            string firstName = FirstNameList[random.Next(FirstNameList.Length)];
            string lastName = LastNameList[random.Next(LastNameList.Length)];

            string retNae = "";
            string culName = Thread.CurrentThread.CurrentCulture.Name;
            if (culName == "en-US")
            {
                retNae = firstName + " " + lastName;
            }
            else if (culName == "zh-CN")
            {
                retNae = lastName + firstName;
            }

            return retNae;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DgvParsEditor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 
                && DgvParsEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string newValue = 
                    DgvParsEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var selectPars = DgvParsEditor.Tag as Dictionary<string, string?>;
                selectPars[DgvParsEditor.Rows[e.RowIndex].Tag.ToString()]
                    = newValue;
            }
        }
    }

    public enum DataGenerateType
    {
        Ordinal,
        RandomString,
        RandomHumanName
    }
}
