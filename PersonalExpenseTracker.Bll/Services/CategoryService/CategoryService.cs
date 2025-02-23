using Microsoft.Extensions.Logging;
using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Dal.Repositories.CategoryRepository;
using PersonalExpenseTracker.Shared.Dto;
using Serilog;

namespace PersonalExpenseTracker.Bll.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            try
            {
                Log.Information("Fetching all categories...");

                var categories = await _categoryRepository.GetAllCategoriesAsync();

                return categories.Select(category => new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all categories");
                throw;
            }
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            try
            {
                Log.Information($"Fetching category with id {id}...");

               var category = await _categoryRepository.GetCategoryByIdAsync(id);

                return new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting category by id");

                throw;
            }
        }

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
        {
            try
            {
                Log.Information($"Fetching category, {categoryDto.Name}...");

                var category = new Category
                {
                    Name = categoryDto.Name,
                };

                var addCategory = await _categoryRepository.AddCategoryAsync(category);

                return new CategoryDto
                {
                    Id = addCategory.Id,
                    Name = addCategory.Name
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding category");
                throw;
            }
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            try
            {
                Log.Information($"Updating category, {categoryDto.Name}...");

                var category = new Category
                {
                    Id = id,
                    Name = categoryDto.Name
                };

                var updatingCategory = await _categoryRepository.UpdateCategoryAsync(id, category);

                return new CategoryDto
                {
                    Id = updatingCategory.Id,
                    Name = updatingCategory.Name
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category");

                throw;
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                Log.Information($"Deleting category with ID {id}...");

                await _categoryRepository.DeleteCategoryAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error deleting category");

                throw;
            }
        }

    }
}
