using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Interfaces
{
    public interface IUsersRepository : IRepositoryBase<UserEntity>
    {
        Task<IList<UserEntity>> GetAllUsers();
        Task<UserEntity> GetByEmail(string email);
        Task<UserEntity> GetByPhone(string phone);
        Task CreateAsync(RegisterModel model);

    }
}