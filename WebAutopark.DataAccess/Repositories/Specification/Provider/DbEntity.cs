using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public class DbEntity
    {
        private DbEntity(string dbName)
        {
            DbName = dbName;
            KeyName = dbName.Remove(dbName.Length - 1);
        }

        public string DbName { get; set; }
        public string KeyName { get; set; }

        internal static DbEntity GetInstance(string dbName) => new(dbName);
    }
}
