namespace ExpenseManager.Core.Executor
{

    public interface IAsyncRequest { }

    public interface IAsyncRequest<out TResponse> { }
}