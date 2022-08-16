using BookApi.Data;
using BookApi.Model.Domain;

namespace BookApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BSDbContext dbContext;
        public CategoryRepository(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

    }
}
