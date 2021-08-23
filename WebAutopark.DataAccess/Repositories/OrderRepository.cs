using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories
{
    public class OrderRepository : ConnectionRepository, IRepository<Order>
    {
        private const string QueryGetAll = "SELECT Orders.*,Vehicles.ModelName,Vehicles.RegistrationNumber,OrderDetails.DetailAmount,Details.Name" +
                                           "FROM Orders" +
                                           "LEFT JOIN OrderDetails " +
                                           "ON Order.OrderId = OrderDetails.OrderId" +
                                           "JOIN Vehicles " +
                                           "ON Orders.VehicleId = Vehicles.VehicleId" +
                                           "LEFT JOIN Details " +
                                           "ON OrderDetails.DetailId = Details.DetailId " +
                                           "ORDER BY OrderId";

        private const string QueryGetById = "SELECT * FROM Orders, Vehicles.VehicleId, Vehicles.VehicleTypeId, Vehicles.ModelName, Vehicles.RegistrationNumber, " +
                                            "Vehicles.Weight, Vehicles.ManufactureYear, Vehicles.Mileage, Vehicles.ColorType, Vehicles.EngineType, " +
                                            "Vehicles.EngineCapacity, Vehicles.EngineConsumption, Vehicles.EnergyTankCapacity, " + 
                                            "OrderDetails.OrderElementId, OrderDetails.OrderId, OrderDetails.DetailId, OrderDetails.DetailAmount, " + 
                                            "Detail.DetailId, Detail.Name " + 
                                            "FROM Orders" + 
                                            "LEFT JOIN OrderDetails ON Orders.OrderId = OrderDetails.OrderId " + 
                                            "JOIN Vehicles ON Orders.VehicleId = Vehicles.VehicleId " + 
                                            "LEFT JOIN Details ON OrderDetails.DetailId = OrderDetails.DetailId " + 
                                            "WHERE Orders.OrderId = @id";

        private const string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES(@VehicleId)";

        private const string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrderId = @id";

        private const string QueryDelete = "DELETE FROM Orders WHERE OrderId = @id";


        public OrderRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Order> Get(int id)
        {
            var collection = await DbConnection.QueryAsync<Order, Vehicle, OrderDetail, Detail, Order>
            (QueryGetById, (order, vehicle, orderDetail, detail) =>
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

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });

        
    }
}
