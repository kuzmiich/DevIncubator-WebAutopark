using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class DetailRepository : ConnectionRepository, IRepository<Detail>
    {
        public DetailRepository(DbConnection dbConnection) : base(dbConnection, "Details")
        {
        }

        public async Task<Detail> Get(int id) => await DbConnection.QueryFirstAsync<Detail>(QueryGetById, id);

        public async Task<IEnumerable<Detail>> GetAll() => await DbConnection.QueryAsync<Detail>(QueryGetAll);

        public async Task Create(Detail element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(Detail element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, id);
    }
}
