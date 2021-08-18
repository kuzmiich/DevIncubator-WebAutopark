using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories
{
    public class VehicleRepository : ConnectionRepository<Vehicle>, IRepository<Vehicle>
    {
        public VehicleRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Vehicle> Get(int id) => await DbConnection.QueryFirstAsync<Vehicle>(QueryGetById, new { id });

        public async Task<IEnumerable<Vehicle>> GetAll() => await DbConnection.QueryAsync<Vehicle>(QueryGetAll);

        public async Task Create(Vehicle element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(Vehicle element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });
    }
}
