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
                Email = user.Email,
                Phone = user.Phone
            };
        }

        public async Task<RegisterModel?> Register(RegisterModel model)
        {
            var existingMail = await _usersRepository.GetByEmail(model.Email);
            if (existingMail != null)
            {
                return null;
            }

            var existingPhone = await _usersRepository.GetByPhone(model.Phone);
            if (existingPhone != null)
            {
                return null;
            }

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            await _usersRepository.CreateAsync(model);
            return model;
        }
    }
}