using AutoMapper;
using ExpenseManager.Core.Entities;

namespace ExpenseManager.Configuration
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseManager.Data.Entities.Expense>();
        }
    }
}