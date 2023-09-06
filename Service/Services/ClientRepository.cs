using Domain.Entyties;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext dbContext;

        public ClientRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateClientAsync(CreateClientDto client)
        {
            var clientCreate = new Client()
            {
                FistName = client.FistName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Id = Guid.NewGuid()
            };

            await dbContext.clients.AddAsync(clientCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteClientByIdAsync(Guid clientId)
        {
            var client = dbContext.clients.FirstOrDefault(ex => ex.Id == clientId);
            if (client is not null)
            {
                dbContext.clients.Remove(client);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await dbContext.clients.ToListAsync();
        }

        public Task<Client> GetClientByIdAsync(Guid clientId)
        {
            var client = dbContext.clients.FirstOrDefaultAsync(ex => ex.Id == clientId);

            return client;
        }

        public async Task<Client> UpdateClientAsync(Guid clientId, CreateClientDto clientDto)
        {
            var client = await dbContext.clients.FirstOrDefaultAsync(e => e.Id == clientId);
            
            client.FistName = clientDto.FistName;
            client.LastName = clientDto.LastName;
            client.PhoneNumber = clientDto.PhoneNumber;
            client.Email = clientDto.Email;
            await dbContext.SaveChangesAsync();
            return client;
        }
    }
}
