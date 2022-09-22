using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Customer;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
                                          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if(order == null)
            {
                return NotFound();  
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody]Orders order)
        {
            var o = await _orderService.InsertOrder(order);
            await _orderService.Save();
            return Ok(o);   

            

           
        }


    }
}
