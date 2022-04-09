

using BudgetApp.Data.DbContext;
using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public abstract class RepositoryBase<T> where T: EntityBase
    {
        protected readonly BudgetContext Context;
        protected readonly DbSet<T> Table;
        //TODO mappingservice

        protected RepositoryBase(BudgetContext context, DbSet<T> table)
        {
            Context = context; //TODO throw if null
            Table = table;
        }
    }
}