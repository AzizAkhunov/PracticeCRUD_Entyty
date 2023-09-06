namespace Domain.Entyties
{
    public class Delivery : MainBase
    {
        public List<string> Order { get; set; }

        public Room? Room { get; set; }
    }
}
