using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class VehicleRepository : ConnectionRepository, IRepository<Vehicle>
    {
        public VehicleRepository(IDbConnectionBuilder connectionBuilder) : base(connectionBuilder, "Vehicles")
        {
        }

        public async Task<Vehicle> Get(int id) => await Connection.QueryFirstAsync<Vehicle>(QueryGetById, id);

        public async Task<IEnumerable<Vehicle>> GetAll() => await Connection.QueryAsync<Vehicle>(QueryGetAll);

        public async void Create(Vehicle element) => await Connection.ExecuteAsync(QueryCreate, element);

        public async void Update(Vehicle element) => await Connection.ExecuteAsync(QueryUpdate, element);

        public void Save()
        {
        }

        public async void Delete(int id) => await Connection.ExecuteAsync(QueryDelete, id);
    }
}
