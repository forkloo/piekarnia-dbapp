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
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder){
            builder.Property(c => c.ProductName).IsRequired();
            builder.Property(c => c.ProductPrice).IsRequired();
            builder.ToTable("Product");
        }
    }
}
