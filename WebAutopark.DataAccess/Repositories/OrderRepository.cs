using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class OrderRepository : ConnectionRepository<Order>, IRepository<Order>
    {
        public OrderRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Order> Get(int id)
        {
            var collection = await DbConnection.QueryAsync<Order, Vehicle, OrderDetail, Detail, Order>
            (QueryGetAll, (order, vehicle, orderDetail, detail) =>
                {
                    order.Vehicle = vehicle;
                    orderDetail.Detail = detail;

                    return order;
                },
                splitOn: "VehicleId,OrderDetailId,DetailId",
                param: new { id }
            );

            return collection.First();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await DbConnection.QueryAsync<Order, Vehicle, OrderDetail, Detail, Order>
            (QueryGetAll, (order, vehicle, orderElement, detail) =>
                {
                    order.Vehicle = vehicle;
                    orderElement.Detail = detail;

                    return order;
                },
                splitOn: "VehicleId,OrderDetailId,DetailId"
            );
        }

        public async Task Create(Order element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(Order element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, id);

        
    }
}
