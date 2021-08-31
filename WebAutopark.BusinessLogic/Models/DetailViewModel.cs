using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.Models
{
    public class DetailViewModel
    {
        public int DetailId { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
    }
}
