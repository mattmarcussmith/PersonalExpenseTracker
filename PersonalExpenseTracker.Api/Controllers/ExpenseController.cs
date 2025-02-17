using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Bll.Services.ExpenseService;
using PersonalExpenseTracker.Shared.Dto;

namespace PersonalExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult> AddExpense([FromBody] ExpenseDto expenseDto)
        {
            var expense = await _expenseService.AddExpenseAsync(expenseDto);
            return Ok(expense);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpense(int id, [FromBody] ExpenseDto expenseDto)
        {
            var expense = await _expenseService.UpdateExpenseAsync(id, expenseDto);
            return Ok(expense);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return Ok("Expense deleted successfully.");
        }
    }
}
