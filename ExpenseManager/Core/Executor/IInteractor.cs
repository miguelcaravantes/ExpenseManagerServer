namespace ExpenseManager.Core.Executor
{
    public interface IInteractor<in TRequest, out TResponse>
  where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest message);
    }

    public interface IInteractor<in TRequest>
    {
        void Handle(TRequest message);
    }

}