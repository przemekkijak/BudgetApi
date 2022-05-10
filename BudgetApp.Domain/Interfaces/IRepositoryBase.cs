#nullable enable
using System.Threading.Tasks;

namespace BudgetApp.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T?> GetById(int id);
        Task<T> CreateAsync(T entity);
        Task SaveChangesAsync();
    }
}