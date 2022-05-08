using System.Threading.Tasks;
using BudgetApp.Database;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public class BudgetRepository : RepositoryBase<BudgetEntity>, IBudgetRepository
    {
        public BudgetRepository(BudgetContext context) : base(context, context.Budgets)
        {
        }

        public async Task<BudgetEntity?> GetForUserByName(int userId, string budgetName)
        {
            return await Table.SingleOrDefaultAsync(a => a.UserId == userId && a.Name == budgetName);
        }
    }
}