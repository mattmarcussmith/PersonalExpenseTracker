using PersonalExpenseTracker.Dal.Entities;

namespace PersonalExpenseTracker.Dal.Repositories.ExpenseRepository
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(int id, Expense expense);
        Task DeleteExpenseAsync(int id);
    }
}
