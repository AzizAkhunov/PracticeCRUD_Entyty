using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entyties
{
    public class Room : MainBase
    {
        public string Name { get; set; }


        public ICollection<Client> Clients { get; } = new List<Client>();
        public ICollection<Delivery> Deliveries { get; set; }
    }
}
