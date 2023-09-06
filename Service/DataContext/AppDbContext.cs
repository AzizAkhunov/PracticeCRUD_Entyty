using Domain.Entyties;
using Microsoft.EntityFrameworkCore;

namespace Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> rooms { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Delivery> deliveries { get; set; }
    }
}
