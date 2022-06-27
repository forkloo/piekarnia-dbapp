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
    public class SellerConfiguration: IEntityTypeConfiguration<Seller>
    {

        public void Configure(EntityTypeBuilder<Seller> builder){
            builder.Property(c => c.SellerMail).IsRequired();
            builder.ToTable("Seller");
        }
    }
}
