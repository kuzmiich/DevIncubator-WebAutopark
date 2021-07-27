using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class Order : Entity
    {
        public int OrderId { get; set; }

        public int VehicleId { get; set; }
    }
}
