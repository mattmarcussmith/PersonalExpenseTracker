using PersonalExpenseTracker.Shared.Dto;

namespace PersonalExpenseTracker.Bll.Services.ExpenseService
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetAllExpensesAsync();
        Task<ExpenseDto> GetExpenseByIdAsync(int id);
        Task<ExpenseDto> AddExpenseAsync(ExpenseDto expense);
        Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto);
        Task DeleteExpenseAsync(int id);
    }
}
