using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB303Pronia.Services.Abstactions;
using PB303Pronia.ViewModels.BlogViewModels;

namespace PB303Pronia.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetListAsync();
            var categories = await _categoryService.GetListAsync(include:x=>x.Include(y=>y.BlogCategories));
            var blogHomeVm = new BlogHomeViewModel { Blogs = blogs.ToList(), Categories = categories.ToList() };
            return View(blogHomeVm);
        }

    }
}
