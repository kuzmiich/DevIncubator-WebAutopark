using System;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public interface IDbProvider
    {
        EntityInfo GetDbEntity<T>();
    }
}
