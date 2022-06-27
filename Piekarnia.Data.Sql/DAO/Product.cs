using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.DAO
{
    public class Product
    {
        public Product(){
            ProductOrders = new List<ProductOrder>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsAvailable { get; set; }
        
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
