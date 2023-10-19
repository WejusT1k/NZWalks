using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using System.Security.Cryptography.X509Certificates;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("ae7585ee-52e5-4593-8d63-a09be9336e69"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a0e7c01c-1f61-4a41-a905-041062a890d7"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f2160189-3a1f-4dfc-b990-1ba76b940e90"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("b0e2ed24-2aad-4c5f-9501-207e29bd3671"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                },
                new Region()
                {
                    Id = Guid.Parse("ebd7664d-b99d-4361-93f6-a9feba3f7b93"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                },
                new Region()
                {
                    Id = Guid.Parse("4efa3513-a446-482e-ba64-9d64f7042f11"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                },
                new Region()
                {
                    Id = Guid.Parse("a52e7e5d-4352-4c9f-a012-c261b06563a1"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}

