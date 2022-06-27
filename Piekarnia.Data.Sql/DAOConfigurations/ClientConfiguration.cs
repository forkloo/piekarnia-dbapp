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
    public class ClientConfiguration: IEntityTypeConfiguration<DAO.Client>
    {

        public void Configure(EntityTypeBuilder<DAO.Client> builder){
            builder.Property(c => c.ClientMail).IsRequired();
            builder.Property(c => c.ClientId).IsRequired();
            builder.ToTable("Client");
        }
    }
}
