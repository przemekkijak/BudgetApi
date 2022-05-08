using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.AuthMiddleware;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
using BudgetApp.Domain;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IAuthService _authService;
        private readonly IUsersService _usersService;

        public UsersController(IUsersRepository usersRepository, IAuthService authService, IUsersService usersService)
        {
            _usersRepository = usersRepository;
            _authService = authService;
            _usersService = usersService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel data)
        {
            var auth = await _authService.Authenticate(data);
            if (auth == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(auth);
        }

        [HttpPost("register")]
        public async Task<ExecutionResult<UserModel?>> Login([FromBody] RegisterModel model)
        {
            return await _usersService.Register(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return await _usersRepository.GetAllUsers();
        }


    }
}