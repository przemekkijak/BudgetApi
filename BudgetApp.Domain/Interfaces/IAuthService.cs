using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Authenticate(LoginModel model);
    }
}