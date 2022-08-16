using BookApi.Data;
using BookApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BSDbContext dbContext;
        public CategoryRepository(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Boolean> DeleteAsync(int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return false;
            }
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> UpdateAsync(int id, Category updateCategory)
        {

            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return null;

            }
            category.Name = updateCategory.Name;
            await dbContext.SaveChangesAsync();

            return category;
        }
    }
}
