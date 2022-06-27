using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.DAO
{
    public class Seller
    {
        public Seller(){
            SellerOrders = new List<SellerOrder>();
        }
        public int SellerId{ get; set; }
        public string SellerName{ get; set; }
        public string SellerStreet { get; set; }
        public string SellerBuildingNumber { get; set; }
        public string SellerCity { get; set; }
        public int? SellerPhone{ get; set; }
        public string SellerMail{ get; set; }

        public virtual ICollection<SellerOrder> SellerOrders{ get; set; }
    }
}
