using System;
using Microsoft.Extensions.Logging;
using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Dal.Repositories.CategoryRepository;
using Serilog;
using Serilog.Core;

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

        public async Task<IEnumerable<Category?>> GetAllCategoriesAsync()
        {
            try
            {
                Log.Information("Getting all categories...");

                return await _categoryRepository.GetAllCategoriesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all categories");

                throw new Exception(ex.Message);
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            try
            {
                Log.Information($"Getting category with id {id}...");

                return await _categoryRepository.GetCategoryByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting category by id");

                throw new Exception(ex.Message);
            
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("Category cannot be null");
                    throw new ArgumentNullException(nameof(category), "Category cannot be null");

                }

                if (category.Name == null)
                {
                    _logger.LogError("Category name cannot be null");
                    throw new ArgumentNullException(nameof(category.Name), "Category name cannot be null");
                }

                Log.Information($"Updating category, {category.Name}...");

                return await _categoryRepository.UpdateCategoryAsync(category);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category");

                throw new Exception(ex.Message);
            }
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cant be null");
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name cannot be empty");
            }

            try
            {
                Log.Information($"Adding category, {category.Name}...");

                await _categoryRepository.AddCategoryAsync(category);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding category");
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                Log.Information($"Deleting category with id {id}...");

                await _categoryRepository.DeleteCategoryAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error deleting category");

                throw new Exception(ex.Message);
            }
        }

    }
}
