using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IRepository<VehicleTypeViewModel> _detailRepository;

        public VehicleTypeController(IRepository<VehicleTypeViewModel> detailRepository)
        {
            _detailRepository = detailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleTypes = await _detailRepository.GetAll();

            return View(vehicleTypes);
        }

        [HttpGet]
        public async Task<IActionResult> VehicleTypeInfo(int id)
        {
            var getModel = await _detailRepository.Get(id);

            if (getModel is null)
                return NotFound();
            
            return View(getModel);
        }
        
        [HttpGet]
        public IActionResult VehicleTypeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleTypeCreate(VehicleTypeViewModel detail)
        {
            if (ModelState.IsValid)
            {
                await _detailRepository.Create(detail);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> VehicleTypeUpdate(int id)
        {
            var updateModel = await _detailRepository.Get(id);
            
            if (updateModel is null)
                return NotFound();
            
            return View(updateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleTypeUpdate(VehicleTypeViewModel vehicleType)
        {
            if (ModelState.IsValid)
            {
                await _detailRepository.Update(vehicleType);
                return RedirectToAction("Index");
            }

            return View(vehicleType);
        }
        
        [HttpGet]
        [ActionName("VehicleTypeDelete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleteModel = await _detailRepository.Get(id);
            
            if (deleteModel is null)
                return NotFound();
            
            return View(deleteModel);
        }
        [HttpPost]
        public async Task<IActionResult> VehicleTypeDelete(int id)
        {
            await _detailRepository.Delete(id);
            
            return RedirectToAction("Index");
        }
    }
}