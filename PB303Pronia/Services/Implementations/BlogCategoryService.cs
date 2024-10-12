using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using PB303Pronia.Models;
using PB303Pronia.Repositories;
using PB303Pronia.Repositories.Contracts;
using PB303Pronia.Services.Abstactions;
using PB303Pronia.ViewModels.BlogCategoryViewModels;
using PB303Pronia.ViewModels.BlogViewModels;
using System.Linq.Expressions;

namespace PB303Pronia.Services.Implementations
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IMapper _mapper;

        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository, IMapper mapper)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _mapper = mapper;
        }

        public async Task<BlogCategoryViewModel> CreateAsync(BlogCategoryCreateViewModel createViewModel)
        {
            var bc = _mapper.Map<BlogCategory>(createViewModel);
            var created  = await _blogCategoryRepository.CreateAsync(bc);
            var vm = new BlogCategoryViewModel();
            return _mapper.Map(created, vm);
        }

        public async Task<BlogCategoryViewModel> DeleteAsync(int id)
        {
            var bc =await _blogCategoryRepository.GetAsync(id);
            if (bc == null) throw new Exception("not found");
            var removed = await _blogCategoryRepository.DeleteAsync(bc);
            var vm = new BlogCategoryViewModel();
            return _mapper.Map(removed, vm);
        }

        public async Task<BlogCategoryViewModel?> GetAsync(int id)
        {
            var entity = await _blogCategoryRepository.GetAsync(id);
            BlogCategoryViewModel vm = new BlogCategoryViewModel();
            return _mapper.Map(entity, vm);
        }

        public async Task<BlogCategoryViewModel?> GetAsync(Expression<Func<BlogCategory, bool>> predicate, Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>>? include = null)
        {
            var entity = await _blogCategoryRepository.GetAsync(predicate, include);
            var vm = new BlogCategoryViewModel();
            vm = _mapper.Map(entity, vm);

            return vm;
        }

        public async Task<IEnumerable<BlogCategoryViewModel>> GetListAsync(Expression<Func<BlogCategory, bool>>? predicate = null, Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>>? include = null)
        {
            var bcs = await _blogCategoryRepository.GetListAsync(predicate, include);
            List<BlogCategoryViewModel> result = new List<BlogCategoryViewModel>();
            return _mapper.Map(bcs, result);
        }

        public Task<BlogCategoryViewModel> UpdateAsync(BlogCategoryUpdateViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
