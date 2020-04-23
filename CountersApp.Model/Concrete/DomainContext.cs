using CountersApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CountersApp.Model
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        public DbSet<Counter> Counters { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountersConfiguration());
        }
    }
}