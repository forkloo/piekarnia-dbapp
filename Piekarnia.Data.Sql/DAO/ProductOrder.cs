using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.DAO
{
    public class ProductOrder
    {
        public int ProductOrderId{ get; set; }
        public int ProductId{ get; set; }
        public int OrderId{ get; set; }
        public int ProductQuantity{ get; set; }

        public virtual Order Order{ get; set; }
        public virtual Product Product{ get; set; }
    }
}
