using System;
using ExpenseManager.Core.Exceptions;

namespace ExpenseManager.Core.Entities
{
    public class Expense
    {
        public string Name { get; private set; }
        public decimal Ammount { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedDate { get; private set; }


        public Expense(string name, decimal ammount, string description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Name must not be empty");
            if (ammount <= 0) throw new BusinessRuleException("Ammount must be grater than 0");

            this.Name = name;
            this.Ammount = ammount;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }
    }
}