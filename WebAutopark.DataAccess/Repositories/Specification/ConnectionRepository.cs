using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repositories.Specification
{
    public abstract class ConnectionRepository : IDisposable, IAsyncDisposable
    {
        protected readonly string QueryGetAll;
        protected readonly string QueryGetById;
        protected readonly string QueryCreate;
        protected readonly string QueryUpdate;
        protected readonly string QueryDelete;

        protected readonly DbConnection DbConnection;

        protected ConnectionRepository(DbConnection dbConnection, string dbName)
        {
            DbConnection = dbConnection;

            QueryGetAll =  $"SELECT * FROM {dbName}";
            QueryGetById = $"SELECT * FROM {dbName} WHERE {dbName.Remove(dbName.Length - 1)}Id = @Id";
            QueryCreate =  $"INSERT INTO {dbName} (Name) VALUES(@Name)";
            QueryUpdate =  $"UPDATE {dbName} SET Name = @Name WHERE {dbName.Remove(dbName.Length - 1)}Id = @Id";
            QueryDelete =  $"DELETE FROM {dbName} WHERE {dbName.Remove(dbName.Length - 1)}Id = @Id";
        }

        public void Dispose() => DbConnection.Dispose();

        public ValueTask DisposeAsync() => DbConnection.DisposeAsync();
    }
}
