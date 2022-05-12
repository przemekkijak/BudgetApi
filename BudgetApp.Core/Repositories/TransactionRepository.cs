using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Database;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public class TransactionRepository : RepositoryBase<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(BudgetContext context, DbSet<TransactionEntity> table) : base(context, context.Transactions)
        {
        }

        public async Task<IList<TransactionEntity>> GetForBudget(int callerId, int budgetId)
        {
            var existing = await Table
                .Where(a => a.UserId == callerId && a.BudgetId == budgetId)
                .ToListAsync();

            return existing;
        }
    }
}