using CitiesManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CitiesManager.WebAPI.DatabaseContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City { CityID = Guid.Parse("814D537B-5E26-4157-9665-299F8B09F716"), CityName = "India" });
            modelBuilder.Entity<City>().HasData(new City { CityID = Guid.Parse("77C653CB-7FD1-42AA-A417-2E3EFE187F1A"), CityName = "America" });
        }
    }
}
