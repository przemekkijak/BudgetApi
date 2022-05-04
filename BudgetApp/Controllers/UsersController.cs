using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.AuthMiddleware;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;
using BudgetApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IAuthService _authService;

        public UsersController(IUsersRepository usersRepository, IAuthService authService)
        {
            _usersRepository = usersRepository;
            _authService = authService;
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

        [HttpGet]
        [Authorize]
        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return await _usersRepository.GetAllUsers();
        }


    }
}