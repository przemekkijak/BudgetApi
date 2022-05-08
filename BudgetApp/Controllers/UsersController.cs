using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.AuthMiddleware;
using BudgetApp.Domain;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
using BudgetApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ApiControllerBase
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
        public async Task<ExecutionResult<AuthResponse>> Login(LoginModel data)
        {
            var auth = await _authService.Authenticate(data);
            if (auth == null)
            {
                return new ExecutionResult<AuthResponse>(new ErrorInfo(ErrorCodes.LoginError,
                    "Login or password is incorrect"));
            }

            return new ExecutionResult<AuthResponse>(auth);
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