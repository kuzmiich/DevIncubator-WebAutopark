using WebAutopark.Core.Engines.Base;

namespace WebAutopark.Core.Engines
{
    public class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2m)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }

        public override string ToString()
        {
            return $"{TypeName}," +
                   $"{EngineCapacity:0.00}," +
                   $"{FuelConsumptionPer100:0.00}";
        }
    }
}
