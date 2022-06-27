using Microsoft.EntityFrameworkCore;
using Piekarnia.Data.Sql.DAO;
using Piekarnia.Data.Sql.DAOConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql
{
    public class PiekarniaDbContext : DbContext
    {
        public PiekarniaDbContext(DbContextOptions<PiekarniaDbContext> options): base(options){ }

        public virtual DbSet<DAO.Client> Client{ get; set; }
        public virtual DbSet<Order> Order{ get; set; }
        public virtual DbSet<Product> Product{ get; set; }
        public virtual DbSet<ProductOrder> ProductOrder{ get; set; }
        public virtual DbSet<Seller> Seller{ get; set; }
        public virtual DbSet<SellerOrder> SellerOrder{ get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductOrderConfiguration());
            builder.ApplyConfiguration(new SellerConfiguration());
            builder.ApplyConfiguration(new SellerOrderConfiguration());
        }
    }
}
