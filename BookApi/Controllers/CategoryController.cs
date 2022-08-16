using BookApi.Model.Domain;
using BookApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {

            return Ok(categoryRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetCategoryAsync")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            var category = await categoryRepository.GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(Category addCategory)
        {
            var category = await categoryRepository.AddAsync(addCategory);

            //This send the request to the method GetCategoryAsync with the new id and check if the data was save it and return the category 
            return CreatedAtAction(nameof(GetCategoryAsync), new { id = category.Id }, category);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] Category category)
        {
            var result = await categoryRepository.UpdateAsync(id, category);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> RemoveCategoryAsync(int id)
        {
            var isDeleted = await categoryRepository.DeleteAsync(id);
            return Ok(isDeleted);
        }
    }
}
