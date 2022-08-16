using BookApi.Model.Domain;

namespace BookApi.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
