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

        public async Task<IEnumerable<Expense?>> GetAllExpensesAsync()
        {
            var expenses = await _context.Expenses.ToListAsync();

            return expenses;
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                throw new KeyNotFoundException($"Expense with Id {id} not found...");
            }
            return expense;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            var existingExpense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == expense.Id);

            if (existingExpense == null)
            {
                throw new KeyNotFoundException($"Expense with Id {expense.Id} not found...");
            }

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

            if (expense == null)
            {
                throw new KeyNotFoundException($"Expense with Id {id} not found...");
            }

            _context.Expenses.Remove(expense);
        }
    }
}
