using Domain.Entyties;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface IOrderRepository
    {
        public Task OrderAsync(CreateOrderDto orderDto);
        public Task<Delivery> GetOrderByIdAsync(Guid orderId);
        public Task<List<Delivery>> GetAllAsync();
        public Task<bool> DeleteOrderByIdAsync(Guid orderId);
    }
}
