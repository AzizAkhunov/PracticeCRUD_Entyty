namespace Domain.Entyties
{
    public class Client : MainBase
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public Room? Room { get; set; }
    }
}
