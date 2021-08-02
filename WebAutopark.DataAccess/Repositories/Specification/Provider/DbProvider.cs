using System;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public class DbProvider<T> : IDbProvider<T> where T : Type
    {
        public EntityInfo GetDbEntity(T type) =>
            type.Name switch
            {
                "Detail" => new EntityInfo("Detail"),
                "Vehicle" => new EntityInfo("Vehicle"),
                "VehicleType" => new EntityInfo("VehicleType"),
                _ => null
            };
    }
}
