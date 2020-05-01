using System.Linq;
using System.Reflection;
using ExpenseManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Data
{

    public class DataContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>();
            var mappings = typeof(DataContext).Assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(IEntityBuilder<>)));
        }



    }

    public interface IEntityBuilder<T> where T : class
    {
        void Build(EntityTypeBuilder<T> builder);
    }
}