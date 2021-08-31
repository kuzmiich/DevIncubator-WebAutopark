using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Enums;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories.ExtendRepository
{
    public interface IVehicleRepository : IRepository<VehicleViewModel>
    {
        public Task<IEnumerable<VehicleViewModel>> GetAll(VehicleSortCriteria sortCriteria, bool isAscending);
    }
}
