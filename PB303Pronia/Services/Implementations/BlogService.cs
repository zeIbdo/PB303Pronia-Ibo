using AutoMapper;
using Google.Apis.Util;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NuGet.Protocol.Core.Types;
using PB303Pronia.Helpers;
using PB303Pronia.Models;
using PB303Pronia.Repositories.Contracts;
using PB303Pronia.Services.Abstactions;
using PB303Pronia.ViewModels.BlogCategoryViewModels;
using PB303Pronia.ViewModels.BlogViewModels;
using System.Linq.Expressions;

namespace PB303Pronia.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryService _categoryService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly CloudinaryHelper _cloudinaryHelper;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepository, IMapper mapper, ICategoryService categoryService, CloudinaryHelper cloudinaryHelper, IBlogCategoryService blogCategoryService)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _categoryService = categoryService;
            _cloudinaryHelper = cloudinaryHelper;
            _blogCategoryService = blogCategoryService;
        }

        public async Task<BlogViewModel> CreateAsync(BlogCreateViewModel createViewModel)
        {
            var blog  = _mapper.Map<Blog>(createViewModel);
            var url = await _cloudinaryHelper.ImageCreateAsync(createViewModel.Image);
            blog.ImageUrl = url;
            blog.CreatedAt = DateTime.UtcNow;
            BlogViewModel vm =new BlogViewModel();
            var created = await _blogRepository.CreateAsync(blog);
            return _mapper.Map(created,vm);
        }

        public async Task<BlogViewModel> DeleteAsync(int id)
        {
            var entity = await _blogRepository.GetAsync(id);

            if (entity == null) throw new Exception("Not found");

            var deletedEntity = await _blogRepository.DeleteAsync(entity);
            var vm = new BlogViewModel();
            return _mapper.Map(deletedEntity,vm);
        }

        public async Task<BlogViewModel?> GetAsync(int id)
        {
            var entity = await _blogRepository.GetAsync(id);
            BlogViewModel vm = new BlogViewModel();
            return _mapper.Map(entity, vm);
        }

        public async Task<BlogViewModel?> GetAsync(Expression<Func<Blog, bool>> predicate, Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>>? include = null)
        {
            var entity = await _blogRepository.GetAsync(predicate, include);
            var vm = new BlogViewModel();
             vm = _mapper.Map(entity,vm);

            return vm;
        }

        public async Task<BlogCreateViewModel> GetCrVm(BlogCreateViewModel vm)
        {
            var categories = await _categoryService.GetListAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in categories)
            {
                items.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }
            vm.Categories= items;
            return vm;
         }

        public async Task<IEnumerable<BlogViewModel>> GetListAsync(Expression<Func<Blog, bool>>? predicate = null, Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>>? include = null)
        {
            var blogs = await _blogRepository.GetListAsync(predicate, include);
            List<BlogViewModel> result = new List<BlogViewModel>();
            return  _mapper.Map(blogs, result);
        }

        public async Task<BlogUpdateViewModel> GetUpVm(int id)
        {
            var blog  = await _blogRepository.GetAsync(x=>x.Id==id,include:y=>y.Include(x=>x.BlogCategories!).ThenInclude(k=>k.Category));
            var oldcategories = new List<SelectListItem>();
            foreach(var item in blog?.BlogCategories ?? new List<BlogCategory>())
            {
                oldcategories.Add(new SelectListItem (item.Category.Name,item.Category.Id.ToString()));
            }
            var allCategories = await _categoryService.GetListAsync();
            var newCategories = new List<SelectListItem>();
            foreach(var item in allCategories)
            {
                if (oldcategories.Any(x=>x.Value==item.Id.ToString()))
                    continue;
                newCategories.Add(new SelectListItem (item.Name,item.Id.ToString()));
            }
            BlogUpdateViewModel vm = new BlogUpdateViewModel();
            vm = _mapper.Map(blog, vm);
            vm.OldCategories = oldcategories;
            vm.NewCategories = newCategories;
            return vm;
        }

        public async Task<BlogViewModel> UpdateAsync(BlogUpdateViewModel vm)
        {
            var existBlog = await _blogRepository.GetAsync(vm.Id);

            if (existBlog == null) throw new Exception("Not Found");

            existBlog = _mapper.Map(vm, existBlog);
            if(vm.Image != null)
            {
                var url = await _cloudinaryHelper.ImageCreateAsync(vm.Image);
                existBlog.ImageUrl = url;
            }
            foreach(var item in vm.OldCategoryIds ?? new List<int>())
            {
                var willRemove = await _blogCategoryService.GetAsync(x=>x.BlogId == vm.Id&&x.CategoryId==item);
                if (willRemove == null) continue;
                await _blogCategoryService.DeleteAsync(willRemove.Id);
            }
            foreach (var item in vm.NewCategoryIds ?? new List<int>())
            {
                await _blogCategoryService.CreateAsync(new BlogCategoryCreateViewModel { BlogId = vm.Id,CategoryId=item });
            }
            var updated = await _blogRepository.UpdateAsync(existBlog);
            var newVm = new BlogViewModel();
            return _mapper.Map(updated,newVm);
        }
    }
}
