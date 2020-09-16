using System;
using System.Windows.Forms;

namespace _3Commas.BulkEditor.Misc
{
    public static class ControlHelper
    {
        public static void AddValuesToCombobox<TEnum>(ComboBox comboBox, TEnum defaultValue)
        {
            AddValuesToCombobox<TEnum>(comboBox);
            comboBox.Text = defaultValue.ToString();
        }

        public static void AddValuesToCombobox<TEnum>(ComboBox comboBox)
        {
            foreach (TEnum time in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                comboBox.Items.Add(time.ToString());
            }
        }
    }
}
