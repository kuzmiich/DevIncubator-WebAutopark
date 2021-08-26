using Dapper.Specification.Provider.DbEntity;

namespace Dapper.Specification.Provider
{
    public interface IDbProvider
    {
        EntityInfo GetDbEntity<T>();
    }
}
