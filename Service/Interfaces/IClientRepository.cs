using Domain.Entyties;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface IClientRepository
    {
        public Task CreateClientAsync(CreateClientDto client);
        public Task<Client> GetClientByIdAsync(Guid clientId);
        public Task<List<Client>> GetAllAsync();
        public Task<bool> DeleteClientByIdAsync(Guid clientId);
        public Task<Client> UpdateClientAsync(Guid companyId, CreateClientDto client);
    }
}
