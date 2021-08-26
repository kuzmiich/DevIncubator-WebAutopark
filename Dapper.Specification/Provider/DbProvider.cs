using Dapper.Specification.Provider.DbEntity;
using WebAutopark.Core.Entities;

namespace Dapper.Specification.Provider
{
    public class DbProvider : IDbProvider
    {
        public EntityInfo GetDbEntity<T>() =>
            typeof(T) switch
            {
                var detail when detail == typeof(Detail) => new EntityInfo(nameof(Detail)),
                var vehicle when vehicle == typeof(Vehicle) => new EntityInfo(nameof(Vehicle)),
                var vehicleType when vehicleType == typeof(VehicleType) => new EntityInfo(nameof(VehicleType)),
                var order when order == typeof(Order) => new EntityInfo(nameof(Order)),
                var orderDetail when orderDetail == typeof(OrderDetail) => new EntityInfo(nameof(OrderDetail)),
                _ => null
            };
    }
}
