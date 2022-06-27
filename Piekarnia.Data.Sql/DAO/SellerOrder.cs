using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.DAO
{
    public class SellerOrder
    {
        public int SellerOrderId{ get; set; }
        public int OrderId{ get; set; }
        public int SellerId{ get; set; }

        public virtual Order Order{ get; set; }
        public virtual Seller Seller{ get; set; }
    }
}
