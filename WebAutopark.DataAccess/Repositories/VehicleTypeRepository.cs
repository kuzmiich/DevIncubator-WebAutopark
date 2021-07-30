using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class VehicleTypeRepository : ConnectionRepository, IRepository<VehicleType>
    {
        public VehicleTypeRepository(DbConnection dbConnection) : base(dbConnection, "VehicleTypes")
        {
        }

        public async Task<VehicleType> Get(int id) => await DbConnection.QueryFirstAsync<VehicleType>(QueryGetById, id);

        public async Task<IEnumerable<VehicleType>> GetAll() => await DbConnection.QueryAsync<VehicleType>(QueryGetAll);

        public async Task Create(VehicleType element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(VehicleType element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, id);
    }
}
