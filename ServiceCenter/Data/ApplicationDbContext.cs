using Microsoft.EntityFrameworkCore;
using ServiceCenter.Models;

namespace ServiceCenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ServiceCEnterDb;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
