using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = Guid.Parse("1f6694f2-845f-493a-9ba5-baa7115124cd"),
                    Title = "Luxury Villa in Dubai Marina",
                    Address = "23 Palm View Rd",
                    City = "Dubai",
                    Price = 2500000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 5,
                    Bathrooms = 4,
                    CarSpots = 2,
                    Description = "A stunning luxury villa with private pool, sea view, and modern interiors.",
                    ImageUrl = "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c"
                },
                new Property
                {
                    Id = Guid.Parse("3b4df4c5-8400-48c2-88f6-d2572b7f76dc"),
                    Title = "Modern Apartment Downtown",
                    Address = "12 Sheikh Zayed Rd",
                    City = "Dubai",
                    Price = 120000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 1,
                    Description = "Modern 2-bedroom apartment close to metro station, with city skyline view.",
                    ImageUrl = "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2"
                },
                new Property
                {
                    Id = Guid.Parse("f32e2a94-4578-4f46-b3c3-629b032b88f2"),
                    Title = "Beachfront Villa in Jumeirah",
                    Address = "45 Beachside Ave",
                    City = "Dubai",
                    Price = 4500000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 6,
                    Bathrooms = 5,
                    CarSpots = 3,
                    Description = "Exclusive beachfront villa with private access to the beach and panoramic sea views.",
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914"
                },
                new Property
                {
                    Id = Guid.Parse("b3db3af2-dc5a-4f1f-8a79-8fb9e6bcf156"),
                    Title = "Affordable Studio in Business Bay",
                    Address = "101 Bay Square",
                    City = "Dubai",
                    Price = 55000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Cozy studio apartment ideal for professionals, located in the heart of Business Bay.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("bb72f20c-cd2f-4d76-9f38-1a6b71baf271"),
                    Title = "Family Home in Mirdif",
                    Address = "8 Al Khawaneej Rd",
                    City = "Dubai",
                    Price = 1800000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    CarSpots = 2,
                    Description = "Spacious family home with garden, close to schools and parks.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("8f841f7e-a5f4-46b8-973d-8cf8b0f34f8b"),
                    Title = "Penthouse with Skyline View",
                    Address = "99 Burj Khalifa Blvd",
                    City = "Dubai",
                    Price = 3500000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 4,
                    Bathrooms = 4,
                    CarSpots = 2,
                    Description = "Luxury penthouse with panoramic views of the Dubai skyline and modern amenities.",
                    ImageUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c"
                },
                new Property
                {
                    Id = Guid.Parse("12b9a4b3-dfa0-4d19-bd66-7a0db144a523"),
                    Title = "Studio in Dubai Silicon Oasis",
                    Address = "Tower 5, Silicon Oasis",
                    City = "Dubai",
                    Price = 42000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Affordable studio apartment in a vibrant tech hub area.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("84d7479d-872e-4d3b-9d16-553f20d7aa0a"),
                    Title = "Townhouse in Arabian Ranches",
                    Address = "22 Desert Bloom",
                    City = "Dubai",
                    Price = 1600000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 3,
                    Bathrooms = 3,
                    CarSpots = 2,
                    Description = "Beautiful family townhouse with community pool and park access.",
                    ImageUrl = "https://images.unsplash.com/photo-1599423300746-b62533397364"
                },
                new Property
                {
                    Id = Guid.Parse("1eaa38c3-dc5a-4a16-b9d2-4a2b4b6a8b63"),
                    Title = "Loft Apartment in DIFC",
                    Address = "Gate Tower 2, DIFC",
                    City = "Dubai",
                    Price = 175000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 1,
                    Description = "Stylish loft apartment in Dubai's financial district.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("59ff22c0-38cb-4fd4-8c1b-f82a3d0d52d8"),
                    Title = "Modern Villa in Palm Jumeirah",
                    Address = "Palm Crescent West",
                    City = "Dubai",
                    Price = 5200000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 6,
                    Bathrooms = 6,
                    CarSpots = 3,
                    Description = "Exclusive Palm Jumeirah villa with private beach access.",
                    ImageUrl = "https://images.unsplash.com/photo-1605276374104-dee2a0ed3cd6"
                },
                new Property
                {
                    Id = Guid.Parse("fd8b7e0c-38f3-4dd7-985b-8702646f316b"),
                    Title = "Apartment near Mall of the Emirates",
                    Address = "Al Barsha 1",
                    City = "Dubai",
                    Price = 85000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 1,
                    Description = "Convenient apartment located near shopping and metro.",
                    ImageUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c"
                },
                new Property
                {
                    Id = Guid.Parse("2845462a-931a-4b94-9e9f-b861c2d39d83"),
                    Title = "Golf Course Villa",
                    Address = "Emirates Hills",
                    City = "Dubai",
                    Price = 7800000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 7,
                    Bathrooms = 7,
                    CarSpots = 4,
                    Description = "Spacious villa with golf course view and luxury finishes.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("5f46e87d-1fc8-4d88-9345-dc44a2f63579"),
                    Title = "Serviced Apartment in JLT",
                    Address = "Cluster C, JLT",
                    City = "Dubai",
                    Price = 130000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 1,
                    Description = "Fully furnished serviced apartment with lake view.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("c3dc7f4d-5236-4b2d-8a9d-037d3b9dce17"),
                    Title = "Luxury Beach Penthouse",
                    Address = "Bluewaters Island",
                    City = "Dubai",
                    Price = 9000000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 5,
                    Bathrooms = 5,
                    CarSpots = 3,
                    Description = "Ultra-luxury penthouse with ocean view and private elevator.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("c6c1a6ec-87da-4013-baa6-93d4b1b18df8"),
                    Title = "Apartment in Dubai Sports City",
                    Address = "Victory Heights",
                    City = "Dubai",
                    Price = 65000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 1,
                    Description = "Affordable apartment with access to sports facilities.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("9d0ccf94-bff3-4454-879a-6df93dc6f79a"),
                    Title = "Desert View Villa",
                    Address = "Al Qudra Road",
                    City = "Dubai",
                    Price = 2200000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 4,
                    Bathrooms = 4,
                    CarSpots = 2,
                    Description = "Elegant villa with expansive desert views and modern amenities.",
                    ImageUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c"
                },
                new Property
                {
                    Id = Guid.Parse("d047a35c-1b8c-49d2-961e-9f14d3a72b8c"),
                    Title = "Downtown Studio",
                    Address = "Boulevard Central",
                    City = "Dubai",
                    Price = 95000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 1,
                    Bathrooms = 1,
                    CarSpots = 0,
                    Description = "Studio apartment within walking distance to Dubai Mall.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("e46c6bc7-b56c-4eb3-b6c8-6c92a64c2c76"),
                    Title = "Villa in The Springs",
                    Address = "Springs 15",
                    City = "Dubai",
                    Price = 2100000.00M,
                    PropertyType = "Sale",
                    Bedrooms = 3,
                    Bathrooms = 3,
                    CarSpots = 2,
                    Description = "Family villa in a gated community with lakes and parks.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("f9f17c25-b92d-4cf7-9a58-89a6c3dd4f21"),
                    Title = "Luxury Apartment in Marina Gate",
                    Address = "Dubai Marina Gate 1",
                    City = "Dubai",
                    Price = 200000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 3,
                    Bathrooms = 3,
                    CarSpots = 2,
                    Description = "Spacious apartment with marina view and premium facilities.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("a85af594-97fd-4b90-8cbf-6e6e9e8d7f8d"),
                    Title = "Luxury Apartment in Marina City",
                    Address = "Dubai Marina Gate 2",
                    City = "Dubai",
                    Price = 20000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 2,
                    Description = "Spacious apartment with marina view.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                },
                new Property
                {
                    Id = Guid.Parse("67175a89-5c65-4e41-854b-fc7ecbdf5f42"),
                    Title = "Luxury Apartment in Marina City",
                    Address = "Dubai Marina Gate 3",
                    City = "Dubai",
                    Price = 10000.00M,
                    PropertyType = "Rent",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    CarSpots = 2,
                    Description = "Spacious apartment with marina view.",
                    ImageUrl = "https://images.unsplash.com/photo-1613490493576-7fde63acd811"
                }
            );
        }

    }
}
