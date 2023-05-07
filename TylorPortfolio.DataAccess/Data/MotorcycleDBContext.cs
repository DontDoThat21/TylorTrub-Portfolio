using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.DataAccess.Data
{
    public class MotorcycleDBContext : DbContext
    {
        public MotorcycleDBContext(DbContextOptions<MotorcycleDBContext> options) : base(options)
        {

        }
        public DbSet<Motorcycle> Motorcycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
    
}
