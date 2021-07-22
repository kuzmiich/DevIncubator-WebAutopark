using WebAutopark.Core.Engines.Base;

namespace WebAutopark.Core.Engines
{
    public class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100) : base("Gasoline", 1.0m)
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
