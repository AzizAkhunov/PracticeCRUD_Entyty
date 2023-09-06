using Domain.Entyties;

namespace Service.Dtos
{
    public class CreateClientDto
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
