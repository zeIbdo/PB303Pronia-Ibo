using Microsoft.EntityFrameworkCore;
using PB303Pronia.Contexts;
using PB303Pronia.Models.Common;
using PB303Pronia.Repositories.Contracts;
using System.Linq.Expressions;

namespace PB303Pronia.Repositories
{
    public class EfCoreRepository<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public EfCoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate )
        {
            var result=await _context.Set<T>().FirstOrDefaultAsync(predicate);
            return result;
        }
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
                return await _context.Set<T>().ToListAsync();

            var result = await _context.Set<T>().Where(predicate).ToListAsync();
            return result;
        }

        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }


        public Task<T> RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
