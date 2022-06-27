using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.DAO
{
    public class Client
    {
        public Client(){
            Orders = new List<Order>();
        }
        public int ClientId{ get; set; }
        public string ClientName{ get; set; }
        public string ClientSurname{ get; set; }
        public string ClientStreet{ get; set; }
        public string ClientBuildingNumber{ get; set; }
        public string ClientCity{ get; set; }
        public int? ClientPhone{ get; set; }
        public string ClientMail{ get; set; }

        public ICollection<Order> Orders{ get; set; }
    }
}
