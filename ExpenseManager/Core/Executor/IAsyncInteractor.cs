using System.Threading;
using System.Threading.Tasks;

namespace ExpenseManager.Core.Executor
{
    public interface IAsyncInteractor<in TRequest, TResponse>
       where TRequest : IAsyncRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IAsyncInteractor<in TRequest>
    where TRequest : IAsyncRequest
    {
        Task HandleAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}