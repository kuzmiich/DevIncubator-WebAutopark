using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IRepository<VehicleType> _detailRepository;

        public VehicleTypeController(IRepository<VehicleType> detailRepository)
        {
            _detailRepository = detailRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> GetAll()
        {
            var details = await _detailRepository.GetAll();

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var getModel = await _detailRepository.Get(id);

            if (getModel is null)
                return NotFound();
            
            return View(getModel);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleType detail)
        {
            if (ModelState.IsValid)
            {
                await _detailRepository.Create(detail);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updateModel = await _detailRepository.Get(id);
            
            if (updateModel is null)
                return NotFound();
            
            return View(updateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                await _detailRepository.Update(vehicleType);
                return RedirectToAction("Index");
            }

            return View(vehicleType);
        }
        
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleteModel = await _detailRepository.Get(id);
            
            if (deleteModel is null)
                return NotFound();
            
            return View(deleteModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _detailRepository.Delete(id);
            
            return RedirectToAction("Index");
        }
    }
}