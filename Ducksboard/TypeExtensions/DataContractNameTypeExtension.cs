using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ducksboard.TypeExtensions
{
    public static class DataContractNameTypeExtension
    {
        public static string GetResourceFromTypeDataContractAttribute(this Type type)
        {
            var props = type.GetCustomAttributes(
                typeof(DataContractAttribute),
                true);

            var dataContractAttribute = props[0] as DataContractAttribute;

            if (dataContractAttribute == null)
                throw new ArgumentException("Can only use classes decorated with the Name DataContractAttribute");

            return dataContractAttribute.Name;
        }
    }
}
