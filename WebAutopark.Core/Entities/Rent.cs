using System;

namespace WebAutopark.Core.Entities
{
    public class Rent
    {
        public DateTime Date { get; set; }
        public decimal RentCost { get; set; }

        public override string ToString() => $"{Date},{RentCost}";
    }
}
