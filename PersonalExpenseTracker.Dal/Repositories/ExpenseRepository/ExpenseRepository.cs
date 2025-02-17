using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Dal.AppContext;
using PersonalExpenseTracker.Dal.Entities;

namespace PersonalExpenseTracker.Dal.Repositories.ExpenseRepository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly Context _context;
        public ExpenseRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (id <= 0)
            {
                throw new ArgumentException($"Expense with ID {id} not found...");
            }

            if (expense == null)
            {
                throw new ArgumentException($"Expense with ID {id} not found...");
            }

            return expense;
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense> UpdateExpenseAsync(int id, Expense expense)
        {
            var existingExpense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == expense.Id);

            if (existingExpense == null)
            {
                throw new ArgumentException($"Expense with Id {expense.Id} not found...");
            }

            existingExpense.Id = id;
            existingExpense.Title = expense.Title;
            existingExpense.Amount = expense.Amount;
            existingExpense.Description = expense.Description;
            existingExpense.Date = expense.Date;

            await _context.SaveChangesAsync();

            return existingExpense;
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (id <= 0)
            {
                throw new ArgumentException($"Expense with ID {id} not found...");
            }

            if (expense == null)
            {
                throw new ArgumentException($"Expense with Id {id} not found...");
            }

            _context.Expenses.Remove(expense);
        }
    }
}
