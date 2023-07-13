using DesignPattern.CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class CQRSContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=CQRS_DB;integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
