using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Data.DbContext;
using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public class UsersRepository
    {
        private readonly BudgetContext _dbContext;

        public UsersRepository(BudgetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}