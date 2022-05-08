using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Database;
using BudgetApp.Domain;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
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

        public async Task<UserEntity?> GetByEmail(string email)
        {
            return await Table.SingleOrDefaultAsync(a => a.Email == email);
        }

        public async Task<UserEntity?> GetByPhone(string phone)
        {
            return await Table.SingleOrDefaultAsync(a => a.Phone == phone);
        }

        public async Task CreateAsync(RegisterModel model)
        {
            await base.CreateAsync(new UserEntity()
            {
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                CreateDate = TimeService.Now,
                UpdateDate = TimeService.Now
            });
        }
    }
}