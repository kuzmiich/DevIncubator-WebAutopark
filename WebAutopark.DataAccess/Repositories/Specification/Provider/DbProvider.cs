namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public class DbProvider : IDbProvider
    {
        public DbEntity GetDbEntity(string dbName) => DbEntity.GetInstance(dbName);
    }
}
