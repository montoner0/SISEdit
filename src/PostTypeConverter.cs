using System.Collections.Generic;
using System.ComponentModel;

namespace sisedit
{
    internal struct ComboData
    {
        public List<string> Items { get; set; }
        public List<int> Values { get; set; }
        public bool Editable { get; set; }
    }

    internal static class PG_ComboBoxes
    {
        private static readonly Dictionary<string, object> _assocArray = new Dictionary<string, object>();

        public static void AddCombobox(string name, List<string> items, bool editable)
        {
            _assocArray[name] = new ComboData {
                Editable = editable,
                Items = items
            };
        }

        public static List<string> GetComboboxItems(string s)
        {
            var cd = (ComboData)_assocArray[s];

            return cd.Items;
        }

        public static bool IsEditable(string s)
        {
            var cd = (ComboData)_assocArray[s];

            return cd.Editable;
        }
    }

    internal class PostTypeConverter : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            => new StandardValuesCollection(PG_ComboBoxes.GetComboboxItems(context.PropertyDescriptor.DisplayName));

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            => !PG_ComboBoxes.IsEditable(context.PropertyDescriptor.DisplayName);

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            => true;
    }

    internal class PostTypeConverterInt : Int32Converter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            => new StandardValuesCollection(PG_ComboBoxes.GetComboboxItems(context.PropertyDescriptor.DisplayName));

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            => !PG_ComboBoxes.IsEditable(context.PropertyDescriptor.DisplayName);

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            => true;
    }
}
