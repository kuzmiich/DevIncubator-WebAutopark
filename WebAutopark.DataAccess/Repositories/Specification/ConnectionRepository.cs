using System;
using System.ComponentModel;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.Core.Entities.Base;
using WebAutopark.DataAccess.Repositories.Specification.Provider;

namespace WebAutopark.DataAccess.Repositories.Specification
{
    public abstract class ConnectionRepository : IDisposable, IAsyncDisposable
    {
        #region Query

        protected readonly string QueryGetAll;
        protected readonly string QueryGetById;
        protected readonly string QueryCreate;
        protected readonly string QueryUpdate;
        protected readonly string QueryDelete;

        #endregion
        
        protected readonly DbConnection DbConnection;

        private static IDbProvider _dbProvider;
        
        private readonly EntityInfo _entityInfo;

        private ConnectionRepository(Entity entity)
        {
            _entityInfo = _dbProvider.GetDbEntity(entity);
        }

        protected ConnectionRepository(DbConnection dbConnection, Entity entity) : this(entity)
        {
            DbConnection = dbConnection;
            QueryGetAll = $"SELECT * FROM {_entityInfo.TableName}";
            QueryGetById = $"SELECT * FROM {_entityInfo.TableName} WHERE {_entityInfo.KeyName}Id = @Id";
            QueryCreate = $"INSERT INTO {_entityInfo.TableName} (Name) VALUES(@Name)";
            QueryUpdate = $"UPDATE {_entityInfo.TableName} SET Name = @Name WHERE {_entityInfo.KeyName}Id = @Id";
            QueryDelete = $"DELETE FROM {_entityInfo.TableName} WHERE {_entityInfo.KeyName}Id = @Id";
        }
        public void Dispose() => DbConnection.Dispose();

        public ValueTask DisposeAsync() => DbConnection.DisposeAsync();
    }
}
