using Microsoft.AspNetCore.Mvc;
using PB303Pronia.Services.Abstactions;
using PB303Pronia.ViewModels.BlogViewModels;

namespace PB303Pronia.Areas.admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetListAsync();
            return View(blogs.ToList());
        }
        public async Task<IActionResult> Create()
        {
            var vm = await _blogService.GetCrVm(new BlogCreateViewModel { });
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var newVm =await _blogService.GetCrVm(vm);
                return View(newVm);
            }
            var result = await _blogService.CreateAsync(vm);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _blogService.GetUpVm(id);
            if(vm==null)return NotFound();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                var newVm = await _blogService.GetUpVm(vm.Id);
                return View(newVm);
            }
            await _blogService.UpdateAsync(vm);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _blogService.DeleteAsync(id);
            if(result==null) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
