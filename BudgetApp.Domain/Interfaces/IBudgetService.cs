using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Interfaces
{
    public interface IBudgetService
    {
        Task<ExecutionResult<BudgetModel>> CreateBudget(int userId, string name, bool isDefault = false);
        Task<ExecutionResult<BudgetModel>> GetDefaultForUser(int userId);
        Task<ExecutionResult<BudgetModel>> SetDefault(int budgetId);
        Task<ExecutionResult<List<BudgetModel>>> GetAllForUser(int userId);
    }
}