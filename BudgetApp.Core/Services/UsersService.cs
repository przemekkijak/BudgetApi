using System.Threading.Tasks;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            var user = await _usersRepository.GetById(id);
            if (user == null)
                return null;

            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}