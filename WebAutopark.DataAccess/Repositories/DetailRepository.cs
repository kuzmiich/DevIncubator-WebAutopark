using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories
{
    public class DetailRepository : ConnectionRepository<Detail>, IRepository<Detail>
    {
        public DetailRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Detail> Get(int id) => await DbConnection.QueryFirstAsync<Detail>(QueryGetById, new { id });

        public async Task<IEnumerable<Detail>> GetAll() => await DbConnection.QueryAsync<Detail>(QueryGetAll);

        public async Task Create(Detail element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(Detail element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });

        
    }
}
