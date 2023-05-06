using Microsoft.EntityFrameworkCore;
using TylorBookStoreRazor_Temp.Models;

namespace TylorBookStoreRazor_Temp.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Romance", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Fantasy", DisplayOrder = 3 }
                );
        }
    }
}
