using Exercise4_Digg_Webshop.Models;
using Exercise4_Digg_Webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercise4_Digg_Webshop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        internal void SaveChanges(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
