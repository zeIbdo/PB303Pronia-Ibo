using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PB303Pronia.Services.Abstactions
{
    public interface ICommonService<TEntity,TViewModel,TCreateViewModel,TUpdateVm>
    {
        Task<TViewModel?> GetAsync(int id);

        Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        Task<IEnumerable<TViewModel>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        Task<TViewModel> CreateAsync(TCreateViewModel createViewModel);
        Task<TViewModel> UpdateAsync(TUpdateVm vm);
        Task<TViewModel> DeleteAsync(int id);
    }
}
