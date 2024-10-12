using Microsoft.EntityFrameworkCore.Query;
using PB303Pronia.Models.Common;
using System.Linq.Expressions;

namespace PB303Pronia.Repositories.Contracts
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T?> GetAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null                                         );
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }
}
