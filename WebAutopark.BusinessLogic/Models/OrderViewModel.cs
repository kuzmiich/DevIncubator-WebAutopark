using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;

namespace WebAutopark.BusinessLogic.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
