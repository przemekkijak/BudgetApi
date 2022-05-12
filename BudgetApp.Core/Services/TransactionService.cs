using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Interfaces;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IList<TransactionModel>> GetForBudget(int userId, int budgetId)
        {
            var transactions = await _transactionRepository.GetForBudget(userId, budgetId);
            return transactions.Select(ModelFactory.Create).ToList();
        }
    }
}