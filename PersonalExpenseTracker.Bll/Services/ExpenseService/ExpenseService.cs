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

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            try
            {
                return await _expenseRepository.GetAllExpensesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all expenses");
                throw;
            }

        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            try
            {
                return await _expenseRepository.GetExpenseByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting expense by id");
                throw;
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
                throw;
            }
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            try
            {
                return await _expenseRepository.UpdateExpenseAsync(expense);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating expense");
                throw;
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
                throw;
            }
        }
    }
}
