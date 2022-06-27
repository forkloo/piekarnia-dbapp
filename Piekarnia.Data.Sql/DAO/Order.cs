using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piekarnia.Common.Enums;

namespace Piekarnia.Data.Sql.DAO
{
    public class Order
    {
        public Order(){
            SellerOrders = new List<SellerOrder>();
            ProductOrders = new List<ProductOrder>();
        }
        public int OrderId{ get; set; }
        public int ClientId{ get; set; }
        public DeliveryType DeliveryType{ get; set; }
        public int? DeliveryCost{ get; set; }
        public string? DeliveryAdress{ get; set; }
        public string? DeliveryCity{ get; set; }
        public DateTime? OrderDate{ get; set; }

        public virtual Client Client{ get; set; }
        public virtual ICollection<SellerOrder> SellerOrders{ get; set; }
        public virtual ICollection<ProductOrder> ProductOrders{ get; set; }
    }
}
