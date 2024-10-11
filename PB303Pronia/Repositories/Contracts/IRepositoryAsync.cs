using PB303Pronia.Models.Common;
using System.Linq.Expressions;

namespace PB303Pronia.Repositories.Contracts
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T?> GetAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);

    }
}
