using System;
using System.Collections.Generic;
using WebAutopark.Core.Entities;

namespace WebAutopark.Core.Extension
{
    public class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            var firstModelName = x.ModelName;
            var secondModelName = y.ModelName;

            return string.Compare(firstModelName, secondModelName, StringComparison.Ordinal);
        }
    }
}
