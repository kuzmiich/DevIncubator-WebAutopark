using WebAutopark.Core.Entities;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public class DbProvider : IDbProvider
    {
        public EntityInfo GetDbEntity<T>(T entity) =>
            entity is Entity e ? 
                e.EntityName switch
                {
                    "Detail" => EntityInfo.GetInstance("Detail"),
                    "Vehicle" => EntityInfo.GetInstance("Vehicle"),
                    "VehicleType" => EntityInfo.GetInstance("VehicleType"),
                    _ => null
                } : null;
    }
}
