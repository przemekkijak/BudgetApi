using System.Threading.Tasks;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
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

        public async Task<RegisterModel?> Register(RegisterModel model)
        {
            var existing = await _usersRepository.GetByPhone(model.Phone);
            if (existing != null)
            {
                return null;
            }

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            await _usersRepository.CreateAsync(model);
            return model;
        }
    }
}