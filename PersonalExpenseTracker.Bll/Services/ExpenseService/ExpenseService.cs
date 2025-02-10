using Microsoft.Extensions.Logging;
using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Dal.Repositories.ExpenseRepository;

namespace PersonalExpenseTracker.Bll.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ILogger _logger;

        public ExpenseService(IExpenseRepository expenseRepository, ILogger<ExpenseService> logger)
        {
            _expenseRepository = expenseRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Expense?>> GetAllExpensesAsync()
        {
            try
            {
                return await _expenseRepository.GetAllExpensesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all expenses");
                throw new Exception(ex.Message);
            }

        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            try
            {
                return await _expenseRepository.GetExpenseByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting expense by id");
                throw new Exception(ex.Message);
            }
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            try
            {
                await _expenseRepository.AddExpenseAsync(expense);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding expense");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {

            if (expense == null)
            {
                _logger.LogError("Expense cannot be null");
                throw new ArgumentNullException(nameof(expense), "Expense cannot be null");
            }

            try
            {
                return await _expenseRepository.UpdateExpenseAsync(expense);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating expense");
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteExpenseAsync(int id)
        {
            try
            {
                await _expenseRepository.DeleteExpenseAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting expense");
                throw new Exception(ex.Message);
            }
        }
    }
}
