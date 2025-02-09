namespace PersonalExpenseTracker.Dal.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public decimal Amount { get; set; }

        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
