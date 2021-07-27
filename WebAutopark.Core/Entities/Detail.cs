using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class Detail : Entity
    {
        public int DetailId { get; set; }
        public string Name { get; set; }
    }
}
