using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
using BudgetApp.Domain.Models;
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
            var user = await _usersRepository.GetByEmail(model.Login);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                return null;

            var token = GenerateToken(user);

            return new AuthResponse()
            {
                Email = user.Email,
                UserId = user.Id,
                Token = token
            };
        }

        private string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}