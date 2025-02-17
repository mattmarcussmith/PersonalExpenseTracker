using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Shared.Dto;

namespace PersonalExpenseTracker.Dal.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category>UpdateCategoryAsync(int id, Category category);
        Task DeleteCategoryAsync(int id);
    }
}
