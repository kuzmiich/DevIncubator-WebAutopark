using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class Vehicle : Entity
    {
        private const decimal WeightCoefficient = 0.0013m;
        private const decimal ShiftForTax = 5m;
        private const decimal TaxCoefficient = 30m;
        
        #region Vehicle Property
        
        public VehicleType VehicleType { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int ReleaseYear { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public double TankCapacity { get; set; }
        public decimal EngineConsumption { get; set; }
        public decimal EnergyTankCapacity { get; set; }

        public decimal GetCalcTaxPerMonth => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + ShiftForTax;
        
        public decimal KmPerFullTank => EnergyTankCapacity / EngineConsumption;

        #endregion

        public override bool Equals(object obj) =>
            obj is Vehicle vehicle && (VehicleType == vehicle.VehicleType && ModelName == vehicle.ModelName);
    }
}
