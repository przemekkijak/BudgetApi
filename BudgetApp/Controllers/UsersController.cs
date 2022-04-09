using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Core.Repositories;
using BudgetApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    [Controller]
    [Route("api/users")]
    public class UsersController
    {
        private readonly UsersRepository _usersRepository;

        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return await _usersRepository.GetAllUsers();
        }
    }
}