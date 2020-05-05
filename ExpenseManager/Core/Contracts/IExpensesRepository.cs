using System.Threading;
using System.Threading.Tasks;
using ExpenseManager.Core.Entities;

namespace ExpenseManager.Core.Contracts
{
    public interface IExpensesRepository
    {
        Task CreateExpenseAsync(Expense expense, CancellationToken cancellationToken = default);
    }
}