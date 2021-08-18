using System;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Repositories.Specification.Provider;
using WebAutopark.DataAccess.Repositories.Specification.Provider.Extensions;

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
        
        protected readonly DbConnection DbConnection;
        
        protected ConnectionRepository(DbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public void Dispose() => DbConnection.Dispose();

        public ValueTask DisposeAsync() => DbConnection.DisposeAsync();
    }
}
