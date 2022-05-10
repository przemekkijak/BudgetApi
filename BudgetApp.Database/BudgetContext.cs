using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Database
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BudgetEntity> Budgets { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BudgetEntity>()
                .HasMany(a => a.Transactions)
                .WithOne(a => a.Budget);
            modelBuilder.Entity<BudgetEntity>().HasIndex(a => new { a.UserId, a.Name }).IsUnique();
            modelBuilder.Entity<BudgetEntity>().Property(a => a.IsDefault).IsRequired();

            modelBuilder.Entity<TransactionEntity>().HasIndex(a => a.BudgetId);
        }
        
    }
}