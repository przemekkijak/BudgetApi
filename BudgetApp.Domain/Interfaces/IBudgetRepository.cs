using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Domain.Entities;

namespace BudgetApp.Domain.Interfaces
{
    public interface IBudgetRepository : IRepositoryBase<BudgetEntity>
    {
        Task<BudgetEntity> GetForUserByName(int userId, string budgetName);
        Task<BudgetEntity> GetDefaultForUser(int userId);
        Task<List<BudgetEntity>> GetAllForUser(int userId);
    }
}