using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class Vehicle : Entity
    {
        private const double WeightCoefficient = 0.0013;
        private const double ShiftForTax = 5;
        private const double TaxCoefficient = 30;
        
        #region Vehicle Property
        
        public VehicleType VehicleType { get; set; }
        public string ModelName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int ManufactureYear { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public double TankCapacity { get; set; }
        public double EngineConsumption { get; set; }
        public double EnergyTankCapacity { get; set; }

        public double GetCalcTaxPerMonth => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + ShiftForTax;
        
        public double KmPerFullTank => EnergyTankCapacity / EngineConsumption;

        #endregion
    }
}
