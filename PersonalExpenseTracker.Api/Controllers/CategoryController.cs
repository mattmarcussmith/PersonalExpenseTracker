using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Bll.Services.CategoryService;
using PersonalExpenseTracker.Shared.Dto;

namespace PersonalExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var categoryById = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(categoryById);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory([FromBody] CategoryDto categoryDto)
        {
            var addCategory = await _categoryService.AddCategoryAsync(categoryDto);
            return Ok(addCategory);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            var updateCategory = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return Ok(updateCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Category deleted successfully.");
        }
    }
}
