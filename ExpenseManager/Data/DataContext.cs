using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ExpenseManager.Configuration;
using ExpenseManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Data
{

    public class DataContext : DbContext, IUnitOfWork
    {
        public DbSet<DbExpense> Expenses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        private ModelBuilder _modelBuilder;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;

            var assemblyTypes = this.GetType().Assembly.GetTypes();

            assemblyTypes.Where(isMappingType).ToList().ForEach(RunBuild);

            static bool isMappingType(Type t) => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityBuilder<>));

        }


        public Task CommitAsync(CancellationToken cancellationToken = default)
            => this.SaveChangesAsync(cancellationToken);

        private void RunBuild(Type mappingType)
        {
            var entityType = mappingType.GetInterfaces().Single(i => i.GetGenericTypeDefinition() == typeof(IEntityBuilder<>)).GetGenericArguments().Single();

            dynamic mapping = Activator.CreateInstance(mappingType);
            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(isEntityGenericMethod).MakeGenericMethod(entityType);

            dynamic entityTypeBuilder = entityMethod.Invoke(_modelBuilder, null);

            mapping.Build(entityTypeBuilder);

            static bool isEntityGenericMethod(MethodInfo m) => m.Name == nameof(ModelBuilder.Entity) && m.IsGenericMethod && !m.GetParameters().Any();
        }
    }

    public interface IEntityBuilder<T> where T : class
    {
        void Build(EntityTypeBuilder<T> builder);
    }
}