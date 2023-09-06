using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace Hotelll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromForm] CreateClientDto createClientDto)
        {
            await clientRepository.CreateClientAsync(createClientDto);

            return Ok("Created");
        }
        [HttpGet("clientId")]
        public async Task<IActionResult> GetClientById(Guid clientId)
        {
            var client = await clientRepository.GetClientByIdAsync(clientId);

            return Ok(client);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await clientRepository.GetAllAsync();
            
            return Ok(clients);
        }
        [HttpDelete("clientId")]
        public async Task<IActionResult> DeleteClientById(Guid clientId)
        {
            var client = await clientRepository.DeleteClientByIdAsync(clientId);
            if (client is true)
            {
                return Ok("Deleted");
            }
            else return BadRequest("NotFound");
        }
        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateCompanyName(Guid clientId, CreateClientDto clientDto)
        {
            var clients = await clientRepository.UpdateClientAsync(clientId, clientDto);

            return Ok(clients);
        }
    }
}
