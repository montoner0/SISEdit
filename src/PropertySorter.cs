using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace sisedit
{
    public class PropertySorter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var pdc = TypeDescriptor.GetProperties(value, attributes);
            var orderedProperties = new List<PropertyOrderPair>();

            foreach (PropertyDescriptor pd in pdc) {
                var attribute = pd.Attributes[typeof(PropertyOrderAttribute)];
                orderedProperties.Add(new PropertyOrderPair(pd.Name, attribute is PropertyOrderAttribute poa ? poa.Order : 0));
            }

            orderedProperties.Sort();

            return pdc.Sort(orderedProperties.Select(pop => pop.Name).ToArray());
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        public PropertyOrderAttribute(int order) => Order = order;

        public int Order { get; }
    }

    public class PropertyOrderPair : IComparable<PropertyOrderPair>
    {
        private readonly int _order;

        public PropertyOrderPair(string name, int order)
        {
            _order = order;
            Name = name;
        }

        public int CompareTo(PropertyOrderPair other)
        {
            if (other._order == _order) {
                return string.Compare(Name, other.Name);
            } else if (other._order > _order) {
                return -1;
            }
            return 1;
        }

        public string Name { get; }
    }
}
