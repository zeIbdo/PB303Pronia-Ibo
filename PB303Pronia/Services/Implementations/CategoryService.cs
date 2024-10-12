using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using PB303Pronia.Models;
using PB303Pronia.Repositories.Contracts;
using PB303Pronia.Services.Abstactions;
using PB303Pronia.ViewModels.BlogViewModels;
using PB303Pronia.ViewModels.CategoryViewModels;
using System.Linq.Expressions;

namespace PB303Pronia.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<CategoryViewModel> CreateAsync(CategoryCreateViewModel createViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryViewModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryViewModel?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryViewModel?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetListAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        {
            var categories = await _repo.GetListAsync(predicate, include);
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            return _mapper.Map(categories, result);
        }

        public Task<CategoryViewModel> UpdateAsync(CategoryUpdateViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
