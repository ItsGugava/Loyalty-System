using Loyalty_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccumulatePointsLog> AccumulatePointsLogs { get; set; }
        public DbSet<SpendPointsLog> SpendPointsLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasIndex(c => c.PersonalNumber).IsUnique();
            modelBuilder.Entity<AccumulatePointsLog>().HasIndex(l => l.CheckId).IsUnique();
            modelBuilder.Entity<SpendPointsLog>().HasIndex(l => l.CheckId).IsUnique();
        }
    }
}
