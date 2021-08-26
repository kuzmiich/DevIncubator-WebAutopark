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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleRepository.GetAll();

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> VehicleInfo(int id)
        {
            var getModel = await _vehicleRepository.Get(id);

            if (getModel is null)
                return NotFound();

            return View(getModel);
        }

        [HttpGet]
        public IActionResult VehicleCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleCreate(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _vehicleRepository.Create(vehicle);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VehicleUpdate(int id)
        {
            var updateModel = await _vehicleRepository.Get(id);

            if (updateModel is null)
                return NotFound();

            return View(updateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleUpdate(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _vehicleRepository.Update(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        [HttpGet]
        [ActionName("VehicleDelete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleteModel = await _vehicleRepository.Get(id);

            if (deleteModel is null)
                return NotFound();

            return View(deleteModel);
        }
        [HttpPost]
        public async Task<IActionResult> VehicleDelete(int id)
        {
            await _vehicleRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
