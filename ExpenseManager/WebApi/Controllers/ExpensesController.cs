using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseManager.Core.Executor;
using ExpenseManager.Core.UseCases;
using ExpenseManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace ExpenseManager.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {

        private readonly Executor _executor;

        public ExpensesController(Executor executor)
        {
            _executor = executor;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateExpenseDto expenseDto, CancellationToken cancellationToken)
        {
            var request = new CreateExpenseRequest(expenseDto.Name, expenseDto.Ammount, expenseDto.Description);
            await _executor.SendAsync(request);
            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
