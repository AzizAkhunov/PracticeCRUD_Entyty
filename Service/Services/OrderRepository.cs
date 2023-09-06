using Domain.Entyties;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Dtos;
using Service.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext dbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> DeleteOrderByIdAsync(Guid orderId)
        {
            var order = await dbContext.deliveries.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order is not null)
            {
                dbContext.deliveries.Remove(order);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
            return await dbContext.deliveries.ToListAsync();
        }

        public async Task<Delivery> GetOrderByIdAsync(Guid orderId)
        {
            var order = await dbContext.deliveries.FirstOrDefaultAsync(o => o.Id == orderId);

            return order;
        }

        public async Task OrderAsync(CreateOrderDto orderDto)
        {
            var order = new Delivery()
            {
                Order = orderDto.order,
                Id = Guid.NewGuid()
            };
            await dbContext.deliveries.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
