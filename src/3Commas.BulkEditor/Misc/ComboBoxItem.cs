using System;

namespace _3Commas.BulkEditor.Misc
{
    public class ComboBoxItem
    {
        public ComboBoxItem(Enum enumValue, string displayString)
        {
            EnumValue = enumValue;
            Text = displayString;
        }
        
        public Enum EnumValue { get; }
        public string Text { get; set; }
    }
}
