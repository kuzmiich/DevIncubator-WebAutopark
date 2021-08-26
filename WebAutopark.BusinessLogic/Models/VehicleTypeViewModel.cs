using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.Models
{
    public class VehicleTypeViewModel
    {
        public int VehicleTypeId { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }
    }
}
