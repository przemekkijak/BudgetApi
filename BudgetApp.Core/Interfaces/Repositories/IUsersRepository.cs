using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Interfaces.Repositories
{
    public interface IUsersRepository : IRepositoryBase<UserEntity>
    {
        Task<IList<UserEntity>> GetAllUsers();
        Task<UserEntity?> GetByName(string user);
        Task<UserEntity?> GetByPhone(string phone);
        Task CreateAsync(RegisterModel model);

    }
}