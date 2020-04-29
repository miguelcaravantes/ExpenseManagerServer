namespace ExpenseManager.Core.Executor
{
    public interface IRequest { }

    public interface IRequest<out TResponse> { }
}