using System.Threading.Tasks;
using BudgetApp.Core.Interfaces.Repositories;
using BudgetApp.Database;
using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: EntityBase
    {
        protected readonly BudgetContext Context;
        protected readonly DbSet<T> Table;
        //TODO mappingservice

        protected RepositoryBase(BudgetContext context, DbSet<T> table)
        {
            Context = context; //TODO throw if null
            Table = table;
        }

        public async Task<T?> GetById(int id)
        {
            return await Table.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}