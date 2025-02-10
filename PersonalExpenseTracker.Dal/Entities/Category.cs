using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Dal.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Expense> Expenses { get; set; }
    }
}
