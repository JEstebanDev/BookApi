using BookApi.Data;
using BookApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BSDbContext dbContext;

        public BookRepository(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await dbContext.Books.ToListAsync();
        }
    }
}
