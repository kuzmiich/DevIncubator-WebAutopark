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
        public List<Rent> ListRent { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int ReleaseYear { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public double TankCapacity { get; set; }

        #endregion

        public decimal GetCalcTaxPerMonth => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + ShiftForTax;

        public decimal GetTotalIncome => ListRent.Sum(rent => rent.RentCost);

        public decimal GetTotalProfit => GetTotalIncome - GetCalcTaxPerMonth;
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj) =>
            obj is Vehicle vehicle && (VehicleType == vehicle.VehicleType && ModelName == vehicle.ModelName);
    }
}
