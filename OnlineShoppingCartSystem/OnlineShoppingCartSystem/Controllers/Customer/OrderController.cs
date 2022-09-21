using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Repository.IOrder<Orders, int> _orderRepository;

        public OrderController(IOrder<Orders, int> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
                                          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if(order == null)
            {
                return NotFound();  
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody]Orders order)
        {
            var id = await _orderRepository.InsertOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new {id = id, controller = "Order"}, id);
           
        }


    }
}
