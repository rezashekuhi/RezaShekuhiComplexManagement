using ComplexManagment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComplexManagment.DataLayer
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {

        }

        public DbSet<Complex> Complexs { get; set; }
        public DbSet<Blook> Blooks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UsageType> UsageTypes { get; set; }
        public DbSet<ComplexUsageType> ComplexUsageTypes { get; set; }
        public DbSet<BlookUsageType> BlookUsageTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
