using BookApi.Model.Domain;
using BookApi.Model.DTO;

namespace BookApi.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(int id);

        Book SaveBook(BookDTO bookDTO);

        Book UpdateBook(int id, BookDTO bookDTO);

        Boolean DeleteById(int id);
    }
}
