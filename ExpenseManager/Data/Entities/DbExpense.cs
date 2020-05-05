using System;

namespace ExpenseManager.Data.Entities
{
    public class DbExpense
    {
        public Guid ExpenseId { get; set; }
        public string Name { get; set; }
        public decimal Ammount { get; set; }
        public string Description { get; set; }
    }
}