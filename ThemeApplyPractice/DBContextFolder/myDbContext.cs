using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.DBContextFolder
{
    public class myDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}

        public myDbContext(DbContextOptions<myDbContext> option) : base(option)
        {

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Issuance> issuances { get; set; }
    }
}
