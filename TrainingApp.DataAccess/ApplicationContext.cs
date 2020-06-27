using Microsoft.EntityFrameworkCore;
using System;
using TrainingApp.Domain;

namespace TrainingApp.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string myconn = "server=(localdb)\\MSSQLLocalDB; database=MyApiDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(myconn, b => b.MigrationsAssembly("TrainingApp.DataAccess"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryRowID);
        }
    }
}

