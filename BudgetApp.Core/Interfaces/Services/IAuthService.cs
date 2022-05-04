using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> Authenticate(LoginModel model);
    }
}