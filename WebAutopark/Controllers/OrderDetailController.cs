using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.Controllers
{
    public class OrderDetailController : Controller
    {

        private readonly IRepository<OrderDetailViewModel> _orderDetailRepository;

        public OrderDetailController(IRepository<OrderDetailViewModel> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailCreate()
        {
            var details = await _orderDetailRepository.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderDetailCreate(OrderDetailViewModel orderDetail)
        {
            if (ModelState.IsValid)
            {
                await _orderDetailRepository.Create(orderDetail);

                return RedirectToAction("OrderInfo", "Order", new { id = orderDetail.OrderId });
            }

            return View();
        }
    }
}