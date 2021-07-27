using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class VehicleType : Entity
    {
        public int VehicleTypeId { get; set; }

        public string TypeName { get; set; }

        public double TaxCoefficient { get; set; }
    }
}
