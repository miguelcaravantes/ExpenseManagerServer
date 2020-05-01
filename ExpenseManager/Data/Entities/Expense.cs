using System;

namespace ExpenseManager.Data.Entities
{
    public class Expense
    {
        public Guid ExpenseId { get; set; }
        public string Name { get; set; }
        public decimal Ammount { get; set; }
        public string Description { get; set; }
    }
}