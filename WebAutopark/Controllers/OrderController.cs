using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.ExtendRepository;

namespace WebAutopark.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderDetailRepository)
        {
            _orderRepository = orderDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orderedEnumerable = await _orderRepository.GetAll();

            return View(orderedEnumerable);
        }
        [HttpGet]
        public async Task<IActionResult> OrderInfo(int id)
        {
            var order = await _orderRepository.Get(id);

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> OrderCreate(int id)
        {
            var insertOrder = await _orderRepository.CreateInsert(id);

            return RedirectToAction("OrderDetailCreate", "OrderDetail", insertOrder);
        }
    }
}