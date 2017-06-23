using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public static class Utils
    {
        public static void LoadEnumListItems(ListControl control, Type enumType, object defaultValue)
        {
            LoadEnumListItems(control, enumType);
            control.SelectedValue = defaultValue;
        }

        public static void LoadEnumListItems(ListControl control, Type enumType)
        {
            BindListControl(control, "Key", "Value", GetEnumList(enumType));
        }

        public static void BindListControl(ListControl control, string valueMember,
                            string displayMember, object dataSource)
        {
            control.ValueMember = valueMember;
            control.DisplayMember = displayMember;
            control.DataSource = dataSource;
        }

        public static List<KeyValuePair<int, string>> GetEnumList(Type enumType)
        {
            var values = Enum.GetValues(enumType);
            var descriptions = GetEnumDescriptions(enumType);
            return values.Cast<object>().Select((t, index) => new KeyValuePair<int, string>((int)values.GetValue(index), descriptions[index])).ToList();
        }

        public static string[] GetEnumDescriptions(Type enumType)
        {
            var fieldInfos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return (from fieldInfo in fieldInfos
                    let attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    select attributes.Length > 0 ? attributes[0].Description : fieldInfo.GetValue(fieldInfo.Name).ToString()).ToArray();
        }
    }
}
