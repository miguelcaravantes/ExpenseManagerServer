using System.Threading;
using System.Threading.Tasks;
using ExpenseManager.Core.Contracts;
using ExpenseManager.Core.Entities;
using ExpenseManager.Core.Executor;

namespace ExpenseManager.Core.UseCases
{
    public class CreateExpenseInteractor : IAsyncInteractor<CreateExpenseRequest>
    {

        private readonly IExpensesRepository _expensesRepostiroy;
        public CreateExpenseInteractor(IExpensesRepository expensesRepostiroy)
        {
            _expensesRepostiroy = expensesRepostiroy;
        }
        public Task HandleAsync(CreateExpenseRequest request, CancellationToken cancellationToken = default)
        {
            var expense = new Expense(request.Name, request.Ammount, request.Description);
            return _expensesRepostiroy.CreateExpenseAsync(expense, cancellationToken);
        }

    }

    public class CreateExpenseRequest : IAsyncRequest
    {
        public string Name { get; set; }
        public decimal Ammount { get; set; }
        public string Description { get; set; }

        public CreateExpenseRequest(string name, decimal ammount, string description)
        {
            Name = name;
            Ammount = ammount;
            Description = description;
        }


    }
}