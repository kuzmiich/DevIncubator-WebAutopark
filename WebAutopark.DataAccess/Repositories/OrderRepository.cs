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
        private const string QueryGetAll = "SELECT "
                                           + "O.*, V.VehicleId AS VId, V.VehicleTypeId, V.ModelName, V.RegistrationNumber, V.Weight, V.ManufactureYear, "
                                           + "V.Mileage, V.Color, V.EngineConsumption, V.TankCapacity "
                                           + "FROM Orders AS O "
                                           + "LEFT JOIN Vehicles AS V ON O.VehicleId = V.VehicleId ";

        private const string QueryGetById = "SELECT O.*, V.VehicleId, V.VehicleTypeId, V.ModelName, V.RegistrationNumber, " +
                                            "V.Weight, V.ManufactureYear, V.Mileage, V.Color, V.EngineConsumption, V.TankCapacity, " +
                                            "OD.OrderDetailId, OD.OrderId, OD.DetailId, OD.DetailAmount, " + 
                                            "D.DetailId, D.Name " +
                                            "FROM Orders AS O " +
                                            "LEFT JOIN OrderDetails AS OD ON O.OrderId = OD.OrderId " +
                                            "JOIN Vehicles AS V ON Orders.VehicleId = V.VehicleId " + 
                                            "LEFT JOIN Details AS D ON OrderDetails.DetailId = OrderDetails.DetailId " + 
                                            "WHERE Orders.OrderId = @id";

        private const string QueryCreate = "INSERT INTO Orders (VehicleId) VALUES(@VehicleId)";

        private const string QueryCreateInsert = "INSERT Orders (VehicleId) OUTPUT Inserted.OrderId, " +
                                                 "Inserted.VehicleId VALUES(@id)";

        private const string QueryUpdate = "UPDATE Orders SET VehicleId = @VehicleId WHERE OrderId = @id";

        private const string QueryDelete = "DELETE FROM Orders WHERE OrderId = @id";


        public OrderRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            return await DbConnection.QueryAsync<OrderViewModel, VehicleViewModel, OrderViewModel>
            (QueryGetAll, (order, vehicle) =>
                {
                    order.Vehicle = vehicle;
                    return order;
                },
                splitOn: "VId"
            );
        }

        public async Task<OrderViewModel> Get(int id)
        {
            var orderDetails = new List<OrderDetailViewModel>();

            var collection = await DbConnection.QueryAsync<OrderViewModel, VehicleViewModel, OrderDetailViewModel, DetailViewModel, OrderViewModel>
            (QueryGetById, (order, vehicle, orderDetail, detail) =>
                {
                    order.Vehicle = vehicle;
                    orderDetail.Detail = detail;
                    orderDetails.Add(orderDetail);
                    return order;
                },
                splitOn: "VId, ODId, DId",
                param: new { id }
            );
            var order = collection.First();
            order.OrderDetails = orderDetails;
            return order;
        }

        public async Task<OrderViewModel> CreateInsert(int id) => await DbConnection.QuerySingleAsync<OrderViewModel>(QueryCreateInsert, new { id });

        public async Task Create(OrderViewModel element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(OrderViewModel element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });
    }
}
