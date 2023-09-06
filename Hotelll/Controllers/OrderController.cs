using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace Hotelll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Order([FromForm] CreateOrderDto createOrderDto)
        {
            await orderRepository.OrderAsync(createOrderDto);

            return Ok("Created");
        }
        [HttpGet("orderId")]
        public async Task<IActionResult> GetRoomById(Guid orderId)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);

            return Ok(order);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await orderRepository.GetAllAsync();

            return Ok(Order);
        }
        [HttpDelete("orderId")]
        public async Task<IActionResult> DeleteRoomById(Guid roomId)
        {
            var order = await orderRepository.DeleteOrderByIdAsync(roomId);
            if (order is true)
            {
                return Ok("Deleted");
            }
            else return BadRequest("NotFound");
        }
    }
}
