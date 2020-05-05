using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Core.Executor;
using ExpenseManager.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ExpenseManager.Core.Contracts;
using ExpenseManager.Data.Repositories;
using ExpenseManager.Configuration.Middlewares;

namespace ExpenseManager.Configuration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                   {
                       builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                   });
            });
            services.AddAutoMapper(typeof(Program).Assembly);

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("database"));
            services.AddScoped<IUnitOfWork>(services => services.GetRequiredService<DataContext>());


            services.AddTransient<IExpensesRepository, EntityExpensesRepository>();


            services.AddTransient<Executor>();
            AddRequestHandlers(services);

        }

        public static IServiceCollection AddRequestHandlers(IServiceCollection services)
        {
            var types = new[]{
                typeof(IAsyncInteractor<>),
                typeof(IAsyncInteractor<,>),
                typeof(IInteractor<>),
                typeof(IInteractor<,>),
            };
            var requestInteractorTypes = typeof(IInteractor<>).Assembly.GetTypes()
                .Where(t =>
                    t.GetInterfaces().Any(e => e.IsGenericType && types.Contains(e.GetGenericTypeDefinition()))
                    ).ToList();

            foreach (var t in requestInteractorTypes)
            {
                var handlerInterface = t.GetInterfaces().Single(e => e.IsGenericType && types.Contains(e.GetGenericTypeDefinition()));
                services.AddTransient(handlerInterface, t);
            }

            return services;

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<UnitOfWorkMiddleware>();

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
