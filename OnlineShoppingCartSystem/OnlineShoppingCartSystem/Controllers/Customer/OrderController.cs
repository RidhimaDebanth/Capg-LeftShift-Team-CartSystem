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

        [HttpPost]
        public async Task<IActionResult> AddOrder([Bind()] Orders entity)
        {
            try
            {
                await _orderService.AddOrder(entity);
                await _orderService.Save();
                return (Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
                                          
        }

        [HttpGet("{userid:int}")]
        public async Task<IActionResult> GetOrdersById(int userid)
        {
            try
            {
                var order = await _orderService.GetOrdersByUserId(userid);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
           catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> InsertOrder([Bind()]Orders entity)
        //{
        //    await _orderService.InsertOrder(entity);
        //    await _orderService.Save();
        //    return Ok();   

            

           
        //}


    }
}
