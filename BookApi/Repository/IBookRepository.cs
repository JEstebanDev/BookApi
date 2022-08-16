using BookApi.Model.Domain;

namespace BookApi.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
    }
}
