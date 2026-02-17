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
    }
}
