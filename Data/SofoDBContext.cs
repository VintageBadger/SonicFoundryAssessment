using Microsoft.EntityFrameworkCore;
using SofoTest.Data.Models;

namespace SofoTest.Data {
    public class SofoDBContext : DbContext {

        public SofoDBContext() { }
        public SofoDBContext(DbContextOptions<SofoDBContext> options) : base(options) {
        }


        /// <summary>
        /// Only allow unique zipcodes for the locations table
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Location>()
                .HasIndex(u => u.ZipCode)
                .IsUnique();
        }

        /// <summary>
        /// Store the searched locations in the database
        /// </summary>
        public DbSet<Location> Locations { get; set; }

    }
}
