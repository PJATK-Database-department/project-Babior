using IdentityServer4.EntityFramework.Options;
using MarketWatch.Server.Entities;
using MarketWatch.Server.Entity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MarketWatch.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulider)
        {
            base.OnConfiguring(optionsBulider);
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // modelBuilder.Entity<Company>()
            //     .HasMany(c => c.Prices)
            //     .WithOne();
        }
        
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Branding>? Brandings { get; set; }
    }
}
