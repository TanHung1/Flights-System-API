using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightSystemAPI.Models
{
    public class FlightContext : IdentityDbContext<IdentityUser>
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Group> Groups { get; set; }

        public DbSet<CargoManiFest> cargoManiFests { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }



    }
}
