using Microsoft.Extensions.Logging;
using PersonalExpenseTracker.Dal.Entities;
using PersonalExpenseTracker.Dal.Repositories.ExpenseRepository;
using PersonalExpenseTracker.Shared.Dto;

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

        public async Task<IEnumerable<ExpenseDto>> GetAllExpensesAsync()
        {
            try
            {
                var expenses = await _expenseRepository.GetAllExpensesAsync();

                return expenses.Select(expense => new ExpenseDto
                {
                    Id = expense.Id,
                    Title = expense.Title,
                    Amount = expense.Amount,
                    Description = expense.Description,
                    Date = expense.Date,
                    CategoryId = expense.CategoryId
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all expenses...");
                throw;
            }

        }

        public async Task<ExpenseDto> GetExpenseByIdAsync(int id)
        {
            try
            {
                var expense = await _expenseRepository.GetExpenseByIdAsync(id);

                return new ExpenseDto
                {
                    Id = expense.Id,
                    Title = expense.Title,
                    Amount = expense.Amount,
                    Description = expense.Description,
                    Date = expense.Date,
                    CategoryId = expense.CategoryId
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting expense by ID...");
                throw;
            }
        }

        public async Task<ExpenseDto> AddExpenseAsync(ExpenseDto expenseDto)
        {
            try
            {
                var expense = new Expense
                {
                    Title = expenseDto.Title,
                    Amount = expenseDto.Amount,
                    Description = expenseDto.Description,
                    Date = expenseDto.Date,
                    CategoryId = expenseDto.CategoryId
                };

                var addExpense = await _expenseRepository.AddExpenseAsync(expense);

                return new ExpenseDto
                {
                    Id = addExpense.Id,
                    Title = addExpense.Title,
                    Amount = addExpense.Amount,
                    Description = addExpense.Description,
                    Date = addExpense.Date,
                    CategoryId = addExpense.CategoryId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding expense...");
                throw;
            }
        }

        public async Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto)
        {
            try
            {
                var expense = new Expense
                {
                    Id = id,
                    Title = expenseDto.Title,
                    Amount = expenseDto.Amount,
                    Date = expenseDto.Date,
                    Description = expenseDto.Description,
                    CategoryId = expenseDto.CategoryId
                };

                var updatingExpense =  await _expenseRepository.UpdateExpenseAsync(id, expense);

                return new ExpenseDto
                {
                    Id = updatingExpense.Id,
                    Title = updatingExpense.Title,
                    Amount = updatingExpense.Amount,
                    Description = updatingExpense.Description,
                    Date = updatingExpense.Date,
                    CategoryId = updatingExpense.CategoryId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating expense...");
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
                _logger.LogError(ex, "An error occurred while deleting expense...");
                throw;
            }
        }
    }
}
