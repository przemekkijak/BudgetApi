using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Database;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public class UsersRepository : RepositoryBase<UserEntity>, IUsersRepository
    {
        public UsersRepository(BudgetContext dbContext) : base(dbContext, dbContext.Users)
        {

        }

        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return await Table.ToListAsync();
        }

        public async Task<UserEntity?> GetForAuth(LoginModel user)
        {
            return await Table.SingleOrDefaultAsync(a => a.Name == user.Login && a.Password == user.Password);
        }
        
    }
}