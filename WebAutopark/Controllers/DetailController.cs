using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.Controllers
{
    public class DetailController : Controller
    {
        private readonly IRepository<Detail> _detailRepository;

        public DetailController(IRepository<Detail> detailRepository)
        {
            _detailRepository = detailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orderedEnumerable = await _detailRepository.GetAll();

            return View(orderedEnumerable);
        }
        [HttpGet]
        public async Task<IActionResult> DetailInfo(int id)
        {
            var getModel = await _detailRepository.Get(id);

            if (getModel is null)
                return NotFound();
            
            return View(getModel);
        }
        
        [HttpGet]
        public IActionResult DetailCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailCreate(Detail detail)
        {
            if (ModelState.IsValid)
            {
                await _detailRepository.Create(detail);
                return RedirectToAction("Index");
            }

            return View(detail);
        }

        [HttpGet]
        public async Task<IActionResult> DetailUpdate(int id)
        {
            var updateModel = await _detailRepository.Get(id);
            
            if (updateModel is null)
                return NotFound();
            
            return View(updateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailUpdate(Detail detail)
        {
            if (ModelState.IsValid)
            {
                await _detailRepository.Update(detail);
                return RedirectToAction("Index");
            }

            return View(detail);
        }
        
        [HttpGet]
        [ActionName("DetailDelete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleteModel = await _detailRepository.Get(id);
            
            if (deleteModel is null)
                return NotFound();
            
            return View(deleteModel);
        }

        [HttpPost]
        public async Task<IActionResult> DetailDelete(int id)
        {
            await _detailRepository.Delete(id);
            
            return RedirectToAction("Index");
        }
    }
}