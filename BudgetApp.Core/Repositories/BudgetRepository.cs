using System.Collections.Generic;
using System.Linq;
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

        public async Task<BudgetEntity?> GetDefaultForUser(int userId)
        {
            return await Table.SingleOrDefaultAsync(a => a.IsDefault);
        }

        public async Task<List<BudgetEntity>> GetAllForUser(int userId)
        {
            return await Table.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}