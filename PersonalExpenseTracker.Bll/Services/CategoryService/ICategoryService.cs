using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Shared.Dto;

namespace PersonalExpenseTracker.Bll.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> AddCategoryAsync(CategoryDto category);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto category);
        Task DeleteCategoryAsync(int id);
    }
}
