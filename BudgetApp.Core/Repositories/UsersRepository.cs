using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Data.DbContext;
using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public class UsersRepository : RepositoryBase<UserEntity>
    {
        public UsersRepository(BudgetContext dbContext) : base(dbContext, dbContext.Users)
        {

        }

        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return await Table.ToListAsync();
        }
    }
}