using System.Threading.Tasks;

namespace BudgetApp.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<T?> GetById(int id);
        Task CreateAsync(T entity);
    }
}