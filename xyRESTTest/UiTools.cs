using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyRESTTest
{
    internal class UiTools
    {
        public static void FillCbWithEnum(ComboBox cb, Type enumType)
        {
            cb.Items.Clear();
            Enum.GetNames(enumType).ToList().ForEach(name =>
            {
                cb.Items.Add(name);
            });
        }
        public static void FormatDgv(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
        }
        public static string WorkDir { 
            get {
                var workDir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "xyRESTTest");
                if(!Directory.Exists(workDir))
                {
                    Directory.CreateDirectory(workDir);
                }
                return workDir;
            }
        }
    }
}
