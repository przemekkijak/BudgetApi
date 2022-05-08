using System.Threading.Tasks;
using BudgetApp.Domain.Entities;

namespace BudgetApp.Domain.Interfaces
{
    public interface IBudgetRepository : IRepositoryBase<BudgetEntity>
    {
        Task<BudgetEntity> GetForUserByName(int userId, string budgetName);
    }
}