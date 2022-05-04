using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task<UserModel?> GetUserById(int id);
    }
}