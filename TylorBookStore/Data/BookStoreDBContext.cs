using Microsoft.EntityFrameworkCore;
using TylorBookStore.Models;

namespace TylorBookStore.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
