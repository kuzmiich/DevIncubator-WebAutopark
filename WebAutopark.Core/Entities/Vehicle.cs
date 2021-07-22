using WebAutopark.Core.Extension;
using System;
using System.Collections.Generic;
using WebAutopark.Core.Engines.Base;
using WebAutopark.Core.Enums;

namespace WebAutopark.Core.Entities
{
    public class Vehicle : IComparable<Vehicle>
    {
        private const decimal WeightCoefficient = 0.0013m;
        private const decimal ShiftForTax = 5m;
        private const decimal TaxCoefficient = 30m;

        public Vehicle()
        {
        }

        public Vehicle(int id,
            VehicleType vehicleType,
            AbstractEngine vehicleEngine,
            string modelName,
            string registrationNumber,
            int weight,
            int releaseYear,
            int mileage,
            ColorType colorType,
            double tankCapacity)
        {
            Id = id;
            VehicleType = vehicleType;
            VehicleEngine = vehicleEngine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ReleaseYear = releaseYear;
            Mileage = mileage;
            ColorType = colorType;
            TankCapacity = tankCapacity;
        }

        #region Vehicle Property

        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public AbstractEngine VehicleEngine { get; set; }
        public List<Rent> ListRent { get; set; }
        public string ModelName { get; }
        public string RegistrationNumber { get; }
        public int Weight { get; set; }
        public int ReleaseYear { get; }
        public int Mileage { get; set; }
        public ColorType ColorType { get; set; }
        public double TankCapacity { get; private set; }

        #endregion

        public decimal GetCalcTaxPerMonth => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + ShiftForTax;

        public decimal GetTotalIncome => ListRent.SumElement(rent => rent.RentCost);

        public decimal GetTotalProfit => GetTotalIncome - GetCalcTaxPerMonth;

        public int CompareTo(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Error, argument can`t be null");
            }

            return vehicle.GetCalcTaxPerMonth.CompareTo(GetCalcTaxPerMonth);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj) =>
            obj is Vehicle vehicle && (VehicleType == vehicle.VehicleType && ModelName == vehicle.ModelName);

        public override string ToString() =>
                   $"{Id},{VehicleType.Id},{ModelName},{RegistrationNumber},{Weight}," +
                   $"{ReleaseYear},{Mileage},{ColorType},{VehicleEngine},{TankCapacity}";
    }
}
