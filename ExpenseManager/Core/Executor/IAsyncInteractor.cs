using System.Threading.Tasks;

namespace ExpenseManager.Core.Executor
{
 public interface IAsyncInteractor<in TRequest, TResponse>
    where TRequest : IAsyncRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }

    public interface IAsyncInteractor<in TRequest>
    where TRequest : IAsyncRequest 
    {
        Task HandleAsync(TRequest request);
    }
}