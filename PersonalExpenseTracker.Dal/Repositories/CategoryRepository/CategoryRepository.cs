using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Dal.AppContext;
using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Shared.Dto;

namespace PersonalExpenseTracker.Dal.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid category ID...", nameof(id));
            }
            
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                throw new ArgumentException($"Category with ID {id} not found...");

            }

            return category;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = _context.Categories
                .FirstOrDefault(c => c.Id == category.Id);

            if (existingCategory == null)
            {
                throw new ArgumentException($"Category with Id {category.Id} not found...");
            }

            existingCategory.Id = category.Id;
            existingCategory.Name = category.Name; 
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();

            return existingCategory;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid category ID...", nameof(id));
            }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                throw new ArgumentException($"Category with Id {id} not found...");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
