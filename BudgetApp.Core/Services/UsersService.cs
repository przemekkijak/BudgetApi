using System;
using System.Threading.Tasks;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
using BudgetApp.Domain;
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

        public async Task<ExecutionResult<UserModel?>> Register(RegisterModel model)
        {
            var existingMail = await _usersRepository.GetByEmail(model.Email);
            if (existingMail != null)
            {
                return new ExecutionResult<UserModel?>(new ErrorInfo(ErrorCodes.RegisterError,
                    "Email is already taken"));
            }

            var existingPhone = await _usersRepository.GetByPhone(model.Phone);
            if (existingPhone != null)
            {
                return new ExecutionResult<UserModel?>(new ErrorInfo(ErrorCodes.RegisterError,
                    "Phone is already taken"));            
            }

            if (model.Password.Length <= 4)
            {
                return new ExecutionResult<UserModel?>(new ErrorInfo(ErrorCodes.RegisterError,
                    "Password must be at least 5 characters long"));
            }

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            await _usersRepository.CreateAsync(model);

            var createdUser = await _usersRepository.GetByEmail(model.Email);
            return new ExecutionResult<UserModel?>(new UserModel()
            {
                Email = createdUser?.Email,
                Phone = createdUser?.Phone
            });
        }
    }
}