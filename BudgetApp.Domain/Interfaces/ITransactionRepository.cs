using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Domain.Entities;

namespace BudgetApp.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IList<TransactionEntity>> GetForBudget(int callerId, int budgetId);
    }
}