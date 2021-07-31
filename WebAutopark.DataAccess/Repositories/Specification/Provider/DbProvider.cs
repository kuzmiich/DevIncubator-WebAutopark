using WebAutopark.Core.Entities;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.DataAccess.Repositories.Specification.Provider
{
    public class DbProvider : IDbProvider
    {
        public EntityInfo GetDbEntity(Entity entity) =>
            entity.EntityName switch
            {
                "Detail" => new EntityInfo("Detail"),
                "Vehicle" => new EntityInfo("Vehicle"),
                "VehicleType" => new EntityInfo("VehicleType"),
                _ => null
            };
    }
}
