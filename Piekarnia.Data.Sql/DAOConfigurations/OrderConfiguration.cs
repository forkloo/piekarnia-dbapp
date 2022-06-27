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
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder){
            builder.Property(c => c.ClientId).IsRequired();
            builder.Property(c => c.DeliveryType).IsRequired();
            builder.ToTable("ClientOrder");
        }
    }
}
