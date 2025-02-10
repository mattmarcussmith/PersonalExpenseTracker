using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Dal.AppContext;
using PersonalExpenseTracker.Dal.Entities;

namespace PersonalExpenseTracker.Dal.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Category?>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
             await _context.Categories.AddAsync(category);
             await _context.SaveChangesAsync();

             return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        { 
            var existingCategory = await _context.Categories
                .Include(c => c.Expenses)
                .FirstOrDefaultAsync(c => c.Id == category.Id);

            if (existingCategory == null)
            { 
                throw new KeyNotFoundException($"Category with Id {category.Id} not found...");
            }

            existingCategory.Name = category.Name;

            foreach (var updatedExpense in category.Expenses)
            {
                var existingExpense = existingCategory.Expenses
                    .FirstOrDefault(e => e.Id == updatedExpense.Id);

                if (existingExpense != null)
                {
                    existingExpense.Title = updatedExpense.Title;
                    existingExpense.Amount = updatedExpense.Amount;
                    existingExpense.Description = updatedExpense.Description;
                    existingExpense.Date = updatedExpense.Date;

                }
                else
                {
                    throw new KeyNotFoundException($"Expense with Id {updatedExpense.Id} not found...");
                }
               
            }
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();

            return existingCategory;
        }

        public async Task DeleteCategoryAsync(int id)
        {
           var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {id} not found...");
            }

            _context.Categories.Remove(category);
        }
    }
}
