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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbExpense>();
            var mappings = this.GetType().Assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(IEntityBuilder<>)));
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
            => this.SaveChangesAsync(cancellationToken);
    }

    public interface IEntityBuilder<T> where T : class
    {
        void Build(EntityTypeBuilder<T> builder);
    }
}