using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ExpenseManager.Configuration.Middlewares
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;
        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork)
        {
            await _next(httpContext);
            await unitOfWork.CommitAsync(httpContext.RequestAborted);
        }
    }
}