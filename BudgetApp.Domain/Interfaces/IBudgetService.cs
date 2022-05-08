using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Interfaces
{
    public interface IBudgetService
    {
        Task<ExecutionResult<BudgetModel>> CreateBudget(int userId, string name);
    }
}