using System.Threading.Tasks;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task<UserModel?> GetUserById(int id);
        Task<RegisterModel?> Register(RegisterModel model);
    }
}