using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Dal.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public required Category Category { get; set; }
    }
}
