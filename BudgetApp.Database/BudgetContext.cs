using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data.DbContext
{
    public class BudgetContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}