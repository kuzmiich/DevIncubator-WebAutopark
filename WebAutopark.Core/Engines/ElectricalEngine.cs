using System;
using WebAutopark.Core.Engines.Base;

namespace WebAutopark.Core.Engines
{
    public class ElectricalEngine : AbstractEngine
    {
        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1m)
        {
            ElectricityConsumption = electricityConsumption;
        }
        public double ElectricityConsumption { get; }

        public override double GetMaxKilometers(double batterySize)
        {
            if (batterySize < 0.0)
            {
                throw new ArgumentException("Battery size can`t be (< 0)");
            }

            return batterySize / ElectricityConsumption;
        }
        public override string ToString()
        {
            return $"{TypeName}," +
                   $"{ElectricityConsumption:0.00}";
        }
    }
}
