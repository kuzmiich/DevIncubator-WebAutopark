using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Specification.Provider.DbEntity
{
    public class EntityInfo
    {
        internal EntityInfo(string entityName)
        {
            TableName = $"{entityName}s";
            KeyName = entityName;
            EntityPropertyInfos = entityName.GetType().GetProperties().ToList();
            // FindCustomTypeProperties(EntityPropertyInfos, ref CustomTypeProperties);
        }

        public string TableName { get; }
        public string KeyName { get; }
        public List<PropertyInfo> EntityPropertyInfos { get; }
        public List<List<PropertyInfo>> CustomTypeProperties { get; }

        private static void FindCustomTypeProperties(IEnumerable<PropertyInfo> propertyInfos, ref List<IReadOnlyList<PropertyInfo>> listPropertyInfos)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType.IsClass)
                {
                    var properties = propertyInfo.PropertyType.GetProperties();

                    listPropertyInfos.Add(properties);

                    FindCustomTypeProperties(properties, ref listPropertyInfos);
                }
            }
        }
    }
}
