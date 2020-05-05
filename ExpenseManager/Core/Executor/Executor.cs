using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseManager.Core.Executor
{
    public class Executor
    {
        private readonly IServiceProvider _ioc;

        public Executor(IServiceProvider ioc)
        {
            _ioc = ioc;
        }

        public void Send(IRequest request)
        {
            var type = typeof(IInteractor<>)
                .MakeGenericType(new Type[] { request.GetType() });
            var handler = (dynamic)_ioc.GetService(type);
            handler.Handle((dynamic)request);
        }
        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            var type = typeof(IInteractor<,>).MakeGenericType(new Type[] { request.GetType(), typeof(TResponse) });
            var handler = (dynamic)_ioc.GetService(type);
            return handler.Handle((dynamic)request);
        }

        public Task SendAsync(IAsyncRequest request, CancellationToken cancellationToken = default)
        {
            var type = typeof(IAsyncInteractor<>)
                .MakeGenericType(new Type[] { request.GetType() });
            var handler = (dynamic)_ioc.GetService(type);
            return handler.HandleAsync((dynamic)request, cancellationToken);
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var type = typeof(IAsyncInteractor<,>).MakeGenericType(new Type[] { request.GetType(), typeof(TResponse) });
            var handler = (dynamic)_ioc.GetService(type);
            return handler.HandleAsync((dynamic)request, cancellationToken);
        }

    }
}