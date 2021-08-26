using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Specification.Provider;
using Dapper.Specification.Provider.Extensions;

namespace WebAutopark.DataAccess.Repositories.Base
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

        protected readonly IDbProvider DbProvider;

        protected readonly DbConnection DbConnection;

        private ConnectionRepository()
        {
        }

        protected ConnectionRepository(DbConnection dbConnection, IDbProvider provider)
        {
            DbConnection = dbConnection;
            DbProvider = provider;
            var entityInfo = DbProvider.GetDbEntity<T>();

            QueryGetAll = $"SELECT * From {entityInfo.TableName} {entityInfo.CustomTypeProperties}";

            QueryGetById = $"SELECT * From {entityInfo.TableName} {entityInfo.CustomTypeProperties} WHERE {entityInfo.KeyName}Id = @Id";

            QueryCreate = $"INSERT INTO {entityInfo.TableName} ({entityInfo.EntityPropertyInfos.EnumerableJoin(',').TrimEnd(',')}) " +
                          $"VALUES({entityInfo.EntityPropertyInfos.EnumerableJoin('@', ',').TrimEnd(',')})";

            QueryUpdate = $"UPDATE {entityInfo.TableName} SET {entityInfo.EntityPropertyInfos.EnumerableJoin().TrimEnd(',')} WHERE Id = @Id";


            QueryDelete = $"DELETE FROM {entityInfo.TableName} WHERE {entityInfo.KeyName}Id = @Id";
        }

        public void Dispose() => DbConnection.Dispose();

        public ValueTask DisposeAsync() => DbConnection.DisposeAsync();
    }
}
