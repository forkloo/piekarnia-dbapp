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
    public class ProductOrderConfiguration: IEntityTypeConfiguration<ProductOrder>
    {

        public void Configure(EntityTypeBuilder<ProductOrder> builder){
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ProductId);            
            builder.HasOne(x => x.Order)
                .WithMany(x => x.ProductOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.OrderId);
            builder.ToTable("ProductOrder");
        }
    }
}
