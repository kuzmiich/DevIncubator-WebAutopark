using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories.ExtendRepository
{
    public interface IOrderRepository : IRepository<OrderViewModel>
    {
        Task<OrderViewModel> CreateInsert(int id);
    }
}
