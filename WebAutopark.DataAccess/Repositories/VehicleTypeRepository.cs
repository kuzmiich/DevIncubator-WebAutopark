using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class VehicleTypeRepository : ConnectionRepository, IRepository<VehicleType>
    {
        public VehicleTypeRepository(IDbConnectionBuilder connectionBuilder) : base(connectionBuilder, "VehicleTypes")
        {
        }

        public async Task<VehicleType> Get(int id) => await Connection.QueryFirstAsync<VehicleType>(QueryGetById, id);

        public async Task<IEnumerable<VehicleType>> GetAll() => await Connection.QueryAsync<VehicleType>(QueryGetAll);

        public async void Create(VehicleType element) => await Connection.ExecuteAsync(QueryCreate, element);

        public async void Update(VehicleType element) => await Connection.ExecuteAsync(QueryUpdate, element);

        public void Save()
        {
        }

        public async void Delete(int id) => await Connection.ExecuteAsync(QueryDelete, id);
    }
}
