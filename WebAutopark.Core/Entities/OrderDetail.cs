using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class OrderDetail : Entity
    {
        public int OrderDetailId { get; set; }
        
        public Detail Detail { get; set; }

        public int DetailId { get; set; }

        public int DetailAmount { get; set; }

    }
}
