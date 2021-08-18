using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using System.Collections.Generic;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleController(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var details = (await _vehicleRepository.GetAll()).OrderBy(detail => detail.VehicleId);

            return View(details);
        }

        [HttpGet]
        [ActionName("Get")]
        public async Task<IActionResult> Get(int id)
        {
            throw new System.NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> Delete()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
