using BookApi.Data;
using BookApi.Model.Domain;
using BookApi.Model.DTO;
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
            return await dbContext.Books.Include(o => o.Category).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await dbContext.Books.Include(o => o.Category).FirstOrDefaultAsync(o => o.Id == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }
        public bool DeleteById(int id)
        {
            var book = dbContext.Books.Include(o => o.Category).FirstOrDefault(o => o.Id == id);
            if (book == null)
            {
                return false;
            }
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
            return true;
        }

        public Book SaveBook(BookDTO bookInsert)
        {

            Book book = new Book()
            {
                Id = bookInsert.Id,
                Name = bookInsert.Name,
                CategoryId = bookInsert.CategoryId,
                Autor = bookInsert.Autor,
                Editorial = bookInsert.Editorial,
                Pages = bookInsert.Pages,
                Year = bookInsert.Year,
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            return book;

        }

        public Book UpdateBook(int id, BookDTO BookDTOUpdate)
        {
            var book = dbContext.Books.FirstOrDefault(o => o.Id == id);
            if (book == null)
            {
                return null;
            }
            book.Id = id;
            book.CategoryId = BookDTOUpdate.CategoryId;
            book.Pages = BookDTOUpdate.Pages;
            book.Year = BookDTOUpdate.Year;
            book.Autor = BookDTOUpdate.Autor;
            book.Name = BookDTOUpdate.Name;
            book.Autor = BookDTOUpdate.Autor;
            book.Editorial = BookDTOUpdate.Editorial;
            dbContext.SaveChanges();
            return book;
        }
    }
}
