using ExpenseManager.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Data.EntityBuilders
{
    public class ExpenseBuilder : IEntityBuilder<Expense>
    {
        public void Build(EntityTypeBuilder<Expense> builder)
        {
        }
    }
}