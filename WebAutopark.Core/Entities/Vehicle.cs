using System;
using System.Collections.Generic;
using System.Drawing;
using WebAutopark.Core.Enums;


namespace WebAutopark.Core.Entities
{
    public class Vehicle
    {
        private const double WeightCoefficient = 0.0013;
        private const double ShiftForTax = 5;
        private const double TaxCoefficient = 30;
        
        #region Vehicle Property

        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int ManufactureYear { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public ColorType Color { get; set; }
        public double TankCapacity { get; set; }
        public double EngineConsumption { get; set; }
        public double EnergyTankCapacity { get; set; }

        public virtual double GetCalcTaxPerMonth => Weight * WeightCoefficient + VehicleType.TaxCoefficient * TaxCoefficient + ShiftForTax;
        
        public virtual double KmPerFullTank => EnergyTankCapacity / EngineConsumption;

        #endregion
    }
}
