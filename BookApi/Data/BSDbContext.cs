using BookApi.Model.Domain;
using Microsoft.EntityFrameworkCore;
namespace BookApi.Data
{
    public class BSDbContext : DbContext
    {
        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
