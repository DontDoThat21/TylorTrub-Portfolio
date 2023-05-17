using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.DataAccess.Helpers;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.DataAccess.Data
{
    public class PortfolioDBContext : DbContext
    {



        public PortfolioDBContext(DbContextOptions<PortfolioDBContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<MotorcycleVideo> MotorcycleVideos { get; set; }
        public DbSet<PortfolioImage> PortfolioImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId= 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl = ""
                });

            modelBuilder.Entity<MotorcycleVideo>().HasData(
                new MotorcycleVideo { Id = 1, VideoUrl = "https://drive.google.com/file/d/12D9eX-sjUJpMIvm1I8EOrcaQVuusSnly/preview" });
            modelBuilder.Entity<MotorcycleVideo>().HasData(
                new MotorcycleVideo { Id = 2, VideoUrl = "https://drive.google.com/file/d/1BS-22PZ8CDcDwrdYnYJ6vXbQ3j4_UQD9/preview" });
            modelBuilder.Entity<MotorcycleVideo>().HasData(
                new MotorcycleVideo { Id = 3, VideoUrl = "https://drive.google.com/file/d/1Zu6tYhZ8rPyWbW-3zoFWW4yCCZ_Wqbj1/preview" });

            modelBuilder.Entity<Motorcycle>().HasData(
                new Motorcycle
                {
                    Id = 1,
                    MotorcycleName = "Yamaha MT-10",
                    MotorcycleCc = 998,
                    Manufacturer = "Yamaha",
                    Hp = "0",
                    Year = 19,
                    EngineStyle = "Four Stroke V4",
                    Torque = "110.8ft",
                    Brakes = "Brembo",
                    Picture = "yamahamt10.jpg",
                    AddDate = DateTime.Now
                },
                new Motorcycle
                {
                    Id = 2,
                    MotorcycleName = "Kawasaki H2-R",
                    MotorcycleCc = 998,
                    Manufacturer = "Kawasaki",
                    Hp = "0",
                    Year = 23,
                    EngineStyle = "Four Stroke Supercharged",
                    Torque = "115ft",
                    Brakes = "Brembo",
                    Picture = "kawasakih2r.png",
                    AddDate = DateTime.Now
                },
                new Motorcycle
                {
                    Id = 3,
                    MotorcycleName = "BMW R1100RS",
                    MotorcycleCc = 1085,
                    Manufacturer = "BMW",
                    Hp = "0",
                    Year = 02,
                    EngineStyle = "4-Stroke Twin Boxer",
                    Torque = "92.9ft",
                    Brakes = "1-Disc-Rear, 2-Front",
                    Picture = "bmwk1100caferacer.jpg",
                    AddDate = DateTime.Now
                });
            
            modelBuilder.Entity<PortfolioImage>().HasData(
                new PortfolioImage { Id = 1, Name = "Home 1", Image = PorfolioImageHelper.GetImageBytesFromResources("home1.jpg") });
            
            modelBuilder.Entity<PortfolioImage>().HasData(
                new PortfolioImage { Id = 2, Name = "Home 2", Image = PorfolioImageHelper.GetImageBytesFromResources("home2.jpg") });
            
            modelBuilder.Entity<PortfolioImage>().HasData(
                new PortfolioImage { Id = 3, Name = "Home 3", Image = PorfolioImageHelper.GetImageBytesFromResources("home3.jpg") });

        }

    }
}
