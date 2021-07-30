using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    internal interface IDbProvider
    {
        DbEntity GetDbEntity(string dbName);
    }
}
