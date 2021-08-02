using System;
using System.ComponentModel;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Repositories.Specification.Provider;

namespace WebAutopark.DataAccess.Repositories.Specification
{
    public abstract class ConnectionRepository<T> : IDisposable, IAsyncDisposable
    {
        #region Query

        protected readonly string QueryGetAll;
        protected readonly string QueryGetById;
        protected readonly string QueryCreate;
        protected readonly string QueryUpdate;
        protected readonly string QueryDelete;

        #endregion
        
        protected readonly DbConnection DbConnection;

        private static readonly IDbProvider _dbProvider = new DbProvider();

        private ConnectionRepository()
        {
            var entityInfo = _dbProvider.GetDbEntity<T>();
            QueryGetAll = $"SELECT * FROM {entityInfo.TableName}";
            QueryGetById = $"SELECT * FROM {entityInfo.TableName} WHERE {entityInfo.KeyName}Id = @Id";
            QueryCreate = $"INSERT INTO {entityInfo.TableName} (Name) VALUES(@Name)";
            QueryUpdate = $"UPDATE {entityInfo.TableName} SET Name = @Name WHERE {entityInfo.KeyName}Id = @Id";
            QueryDelete = $"DELETE FROM {entityInfo.TableName} WHERE {entityInfo.KeyName}Id = @Id";
        }
        
        protected ConnectionRepository(DbConnection dbConnection) : this()
        {
            DbConnection = dbConnection;
        }
        public void Dispose() => DbConnection.Dispose();

        public ValueTask DisposeAsync() => DbConnection.DisposeAsync();
    }
}
