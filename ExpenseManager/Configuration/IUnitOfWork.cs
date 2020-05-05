using System.Threading;
using System.Threading.Tasks;

namespace ExpenseManager.Configuration
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}