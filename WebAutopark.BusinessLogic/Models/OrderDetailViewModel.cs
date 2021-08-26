using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;

namespace WebAutopark.BusinessLogic.Models
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int DetailId { get; set; }

        public Detail Detail { get; set; }

        public int DetailAmount { get; set; }
    }
}
