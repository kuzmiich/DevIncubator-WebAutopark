using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.ExtendRepository;

namespace WebAutopark.DataAccess.Repositories
{
    public class OrderRepository : ConnectionRepository, IOrderRepository
    {
        private const string QueryGetAll = "SELECT Orders.*,V.ModelName,V.RegistrationNumber,OrderDetails.DetailAmount,Details.Name" +
                                           "FROM Orders" +
                                           "LEFT JOIN OrderDetails AS OD" +
                                           "ON Order.OrderId = OrderDetails.OrderId" +
                                           "JOIN Vehicles AS V" +
                                           "ON Orders.VehicleId = V.VehicleId" +
                                           "LEFT JOIN Details AS D" +
                                           "ON OrderDetails.DetailId = Details.DetailId " +
                                           "ORDER BY OrderId";

        private const string QueryGetById = "SELECT * FROM Orders, V.VehicleId, V.VehicleTypeId, V.ModelName, V.RegistrationNumber, " +
                                            "V.Weight, V.ManufactureYear, V.Mileage, V.ColorType, V.EngineType, " +
                                            "V.EngineCapacity, V.EngineConsumption, V.EnergyTankCapacity, " + 
                                            "OrderDetails.OrderElementId, OrderDetails.OrderId, OrderDetails.DetailId, OrderDetails.DetailAmount, " + 
                                            "Detail.DetailId, Detail.Name " + 
                                            "FROM Orders" +
                                            "LEFT JOIN OrderDetails AS OD ON Orders.OrderId = OrderDetails.OrderId " +
                                            "JOIN Vehicles AS V ON Orders.VehicleId = V.VehicleId " + 
                                            "LEFT JOIN Details AS D ON OrderDetails.DetailId = OrderDetails.DetailId " + 
                                            "WHERE Orders.OrderId = @id";

        private const string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES(@VehicleId)";

        private const string QueryCreateInsert = "INSERT INTO Orders (VehicleId) VALUES(@VehicleId)";

        private const string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrderId = @id";

        private const string QueryDelete = "DELETE FROM Orders WHERE OrderId = @id";


        public OrderRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            return await DbConnection.QueryAsync<OrderViewModel, VehicleViewModel, OrderDetailViewModel, DetailViewModel, OrderViewModel>
            (QueryGetAll, (order, vehicle, orderElement, detail) =>
                {
                    order.Vehicle = vehicle;
                    orderElement.Detail = detail;

                    return order;
                },
                splitOn: "VehicleId,OrderDetailId,DetailId"
            );
        }

        public async Task<OrderViewModel> Get(int id)
        {
            var collection = await DbConnection.QueryAsync<OrderViewModel, VehicleViewModel, OrderDetailViewModel, DetailViewModel, OrderViewModel>
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

        public async Task<OrderViewModel> CreateInsert(OrderViewModel element) => await DbConnection.QuerySingleAsync<OrderViewModel>(QueryCreateInsert, element);

        public async Task Create(OrderViewModel element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(OrderViewModel element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });
    }
}
