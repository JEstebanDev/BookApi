using BookApi.Model.Domain;

namespace BookApi.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Task<Category> GetAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(int id, Category category);
        Task<Boolean> DeleteAsync(int id);
    }

}
