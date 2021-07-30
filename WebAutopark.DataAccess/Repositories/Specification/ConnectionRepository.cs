using System;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Repositories.Specification.Provider;

namespace WebAutopark.DataAccess.Repositories.Specification
{
    public abstract class ConnectionRepository : IDisposable, IAsyncDisposable
    {
        private readonly IDbProvider _dbProvider = new DbProvider();

        #region Query

        protected readonly string QueryGetAll;
        protected readonly string QueryGetById;
        protected readonly string QueryCreate;
        protected readonly string QueryUpdate;
        protected readonly string QueryDelete;

        #endregion
        
        protected readonly DbConnection DbConnection;

        protected ConnectionRepository(DbConnection dbConnection, string dbName)
        {
            DbConnection = dbConnection;
            var info = _dbProvider.GetDbEntity(dbName);

            QueryGetAll = $"SELECT * FROM {info.DbName}";
            QueryGetById = $"SELECT * FROM {info.DbName} WHERE {info.KeyName}Id = @Id";
            QueryCreate = $"INSERT INTO {info.DbName} (Name) VALUES(@Name)";
            QueryUpdate = $"UPDATE {info.DbName} SET Name = @Name WHERE {info.KeyName}Id = @Id";
            QueryDelete = $"DELETE FROM {info.DbName} WHERE {info.KeyName}Id = @Id";
        }

        public void Dispose() => DbConnection.Dispose();

        public ValueTask DisposeAsync() => DbConnection.DisposeAsync();
    }
}
