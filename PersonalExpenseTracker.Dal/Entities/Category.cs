namespace PersonalExpenseTracker.Dal.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required ICollection<Expense> Expenses { get; set; }
    }
}
