using Microsoft.EntityFrameworkCore;
using TrialApis.Models.Domains;

namespace TrialApis.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>(){
                new Difficulty(){Id = Guid.Parse("d2f1e8a2-3c4b-4a1e-9f5b-1a2b3c4d5e6f"), Name = "Easy"},
                new Difficulty(){Id = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"), Name = "Moderate"},
                new Difficulty(){Id = Guid.Parse("f1e2d3c4-b5a6-7e8f-9d0c-1b2a3c4d5e6f"), Name = "Hard"}
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions
            var regions = new List<Region>(){
                new Region(){Id = Guid.Parse("d2f1e8a2-3c4b-4a1e-9f5b-1a2b3c4d5e6f"), Name = "Northland",  Code = "NL", RegionImageUrl = "https://example.com/northland.jpg"},
                new Region(){Id = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"), Name = "Auckland",  Code = "AKL", RegionImageUrl = "https://example.com/auckland.jpg" },
                new Region(){Id = Guid.Parse("f1e2d3c4-b5a6-7e8f-9d0c-1b2a3c4d5e6f"), Name = "Waikato",  Code = "WKO",  RegionImageUrl = "https://example.com/waikato.jpg"},
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
