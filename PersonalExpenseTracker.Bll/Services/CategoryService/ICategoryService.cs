using PersonalExpenseTracker.Dal.Entities;

namespace PersonalExpenseTracker.Bll.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category?>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
