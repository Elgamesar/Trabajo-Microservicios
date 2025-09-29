using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSOrderApplication.DTOs;
using MSOrderApplication.Interfaces.IService;

namespace APIOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService _orderService) : ControllerBase
    {
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto order)
        {
            try
            {
                await _orderService.CreateOrderAsync(order);
                return StatusCode(201, "Order created successfully");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return StatusCode(200, orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}