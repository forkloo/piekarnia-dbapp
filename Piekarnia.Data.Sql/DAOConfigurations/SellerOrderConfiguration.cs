using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piekarnia.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.DAOConfigurations
{
    public class SellerOrderConfiguration: IEntityTypeConfiguration<SellerOrder>
    {

        public void Configure(EntityTypeBuilder<SellerOrder> builder){
            builder.HasOne(x => x.Order)
                .WithMany(x => x.SellerOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Seller)
                .WithMany(x => x.SellerOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.SellerId);
            builder.ToTable("SellerOrder");
        }
    }
}
