using Microsoft.EntityFrameworkCore;
using ExpenseManager.Core.Contracts;
using System.Threading.Tasks;
using ExpenseManager.Core.Entities;
using AutoMapper;
using System.Threading;

namespace ExpenseManager.Data.Repositories
{
    public class EntityExpensesRepository : IExpensesRepository
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        public EntityExpensesRepository(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreateExpenseAsync(Expense expense, CancellationToken cancellationToken = default)
        {
            var dbEntity = _mapper.Map<ExpenseManager.Data.Entities.Expense>(expense);
            await _db.AddAsync(dbEntity, cancellationToken);
        }


    }
}