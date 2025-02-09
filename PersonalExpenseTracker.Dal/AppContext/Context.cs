using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Dal.Entities;

namespace PersonalExpenseTracker.Dal.AppContext
{
    public class Context : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

     
    }
}