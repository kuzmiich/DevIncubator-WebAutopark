using WebAutopark.DataAccess.Repositories.Specification.Provider.DbEntity;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public interface IDbProvider
    {
        EntityInfo GetDbEntity<T>();
    }
}
