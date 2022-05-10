using System.Threading.Tasks;
using BudgetApp.Database;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Core.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: EntityBase
    {
        private readonly BudgetContext _context;
        protected readonly DbSet<T> Table;

        protected RepositoryBase(BudgetContext context, DbSet<T> table)
        {
            _context = context; //TODO throw if null
            Table = table;
        }

        public async Task<T?> GetById(int id)
        {
            return await Table.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            Table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}