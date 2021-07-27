using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class DetailRepository : ConnectionRepository, IRepository<Detail>
    {
        public DetailRepository(IDbConnectionBuilder connectionBuilder) : base(connectionBuilder, "Details")
        {
        }

        public async Task<Detail> Get(int id) => await Connection.QueryFirstAsync<Detail>(QueryGetById, id);

        public async Task<IEnumerable<Detail>> GetAll() => await Connection.QueryAsync<Detail>(QueryGetAll);

        public async Task Create(Detail element) => await Connection.ExecuteAsync(QueryCreate, element);

        public async Task Update(Detail element) => await Connection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await Connection.ExecuteAsync(QueryDelete, id);
    }
}
