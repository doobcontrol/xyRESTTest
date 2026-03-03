using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static bool IsSubdirectoryOf(string parentPath, string childPath)
        {
            // 1. Get the full, absolute, and normalized paths for both inputs.
            // This resolves any relative path parts (like ".." or ".").
            string fullParentPath = Path.GetFullPath(parentPath);
            string fullChildPath = Path.GetFullPath(childPath);

            // 2. Ensure the parent path has a trailing separator for accurate comparison.
            // Without this, "C:\Folder" would match "C:\FolderNamedDifferently"
            // as a substring.
            if (!fullParentPath.EndsWith(Path.DirectorySeparatorChar.ToString()) &&
                !fullParentPath.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
            {
                fullParentPath += Path.DirectorySeparatorChar;
            }

            // 3. Check if the normalized child path starts with the normalized parent path.
            // Use StringComparison.OrdinalIgnoreCase for typical Windows behavior,
            // or StringComparison.Ordinal for case-sensitive file systems (like Unix/Linux).
            return fullChildPath.StartsWith(fullParentPath, StringComparison.OrdinalIgnoreCase);
        }
    }
    public class EditPermitCheckEventArgs: CancelEventArgs
    {
        public EditPermitCheckEventArgs(EditPermitCheck checkType, object dataToBeEdited)
        {
            CheckType = checkType;
            DataToBeEdited = dataToBeEdited;
        }
        public EditPermitCheck CheckType { get; }
        public object DataToBeEdited { get; }
    }
    public enum EditPermitCheck {         
        CaseNameDuplicate,
    }
}
