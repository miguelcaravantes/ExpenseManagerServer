using ExpenseManager.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Data.EntityBuilders
{
    public class ExpenseBuilder : IEntityBuilder<DbExpense>
    {
        public void Build(EntityTypeBuilder<DbExpense> builder)
        {
            builder.HasKey(e=>e.ExpenseId);
        }
    }
}