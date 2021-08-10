using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider.Extensions
{
    internal static class PropertyInfoExtension
    {
        /// <summary>
        /// helps to convert enumerable property names to strings of a different format
        /// </summary>
        /// <param name="properties">the IEnumerable&lt;PropertyInfo&gt; of class</param>
        /// <param name="start">the separator is added to the start of the line</param>
        /// <param name="end">the separator is added to the end of the line</param>
        /// <returns>return format string - "{start}{PropertyName}{end}"</returns>
        internal static string EnumerableJoin(this IEnumerable<PropertyInfo> properties, char start, char end) =>
            properties.Aggregate(string.Empty, (current, property) => current + $"{start}{property.Name}{end}");

        /// <summary>
        /// helps to convert enumerable property names to strings of a different format
        /// </summary>
        /// <param name="properties">the IEnumerable&lt;PropertyInfo&gt; of class</param>
        /// <param name="separator">the separator is added to the end of the line</param>
        /// <returns>return format string - "{PropertyName}{separator}"</returns>
        internal static string EnumerableJoin(this IEnumerable<PropertyInfo> properties, char separator) =>
            properties.Aggregate(string.Empty, (current, propertyInfo) => current + $"{propertyInfo.Name}{separator}");

        /// <summary>
        /// helps to convert enumerable property names to strings of a different format
        /// </summary>
        /// <param name="properties">the IEnumerable&lt;PropertyInfo&gt; of class</param>
        /// <returns>return format string - "{PropertyName} = @{PropertyName},"</returns>
        internal static string EnumerableJoin(this IEnumerable<PropertyInfo> properties) =>
            properties.Aggregate(string.Empty, (current, property) => current + $"{property.Name} = @{property.Name},");
    }
}
