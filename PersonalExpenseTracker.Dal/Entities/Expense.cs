﻿using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Dal.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime Date { get; set; }


        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
