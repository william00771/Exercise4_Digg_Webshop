using Exercise4_Digg_Webshop.Models;
using Exercise4_Digg_Webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercise4_Digg_Webshop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageModule_Image>().HasOne(x => x.Image).WithMany(x => x.ImageModules_Images).HasForeignKey(x => x.ImageId);
            modelBuilder.Entity<ImageModule_Image>().HasOne(x => x.SectionImageModule).WithMany(x => x.ImageModules_Images).HasForeignKey(x => x.SectionImageModuleId);

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<SectionImageModule> SectionImageModules { get; set; }
        public DbSet<ImageModule_Image> ImageModules_Images { get; set; }

        public DbSet<Section> Sections { get; set; }
        public DbSet<BlogArticle> BlogArticles { get; set; }


        

    }
}
