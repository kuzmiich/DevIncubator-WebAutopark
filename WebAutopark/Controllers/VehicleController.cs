using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Enums;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.ExtendRepository;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(VehicleSortCriteria? criteria, bool? isAscending)
        {
            IEnumerable<VehicleViewModel> vehicles = null;
            if (!criteria.HasValue)
            {
                vehicles = await _vehicleRepository.GetAll();
                return View(vehicles);
            }

            isAscending ??= false;

            vehicles = await _vehicleRepository.GetAll(criteria.Value, isAscending.Value);
            
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
        public async Task<IActionResult> VehicleCreate(VehicleViewModel vehicle)
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
        public async Task<IActionResult> VehicleUpdate(VehicleViewModel vehicle)
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
