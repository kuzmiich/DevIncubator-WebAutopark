using System;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public interface IDbProvider<in T>
    {
        EntityInfo GetDbEntity(T type);
    }
}
