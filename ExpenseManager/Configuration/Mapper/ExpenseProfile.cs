using AutoMapper;
using ExpenseManager.Core.Entities;
using ExpenseManager.Data.Entities;

namespace ExpenseManager.Configuration
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, DbExpense>();
        }
    }
}