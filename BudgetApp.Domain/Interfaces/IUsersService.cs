using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Interfaces
{
    public interface IUsersService
    {
        Task<UserModel> GetUserById(int id);
        Task<ExecutionResult<UserModel>> Register(RegisterModel model);
    }
}