using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Core.Interfaces.Services;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;
using BudgetApp.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BudgetApp.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly AppSettings _appSettings;

        public AuthService(IUsersRepository usersRepository, IOptions<AppSettings> appSettings)
        {
            _usersRepository = usersRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthResponse?> Authenticate(LoginModel model)
        {
            var user = await _usersRepository.GetForAuth(model);
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var token = GenerateToken(user);

            return new AuthResponse()
            {
                Name = user.Name,
                UserId = user.Id,
                Token = token
            };
        }

        private string GenerateToken(UserEntity user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}