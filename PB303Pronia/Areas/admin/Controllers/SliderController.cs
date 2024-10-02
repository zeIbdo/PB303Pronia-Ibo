using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB303Pronia.Contexts;
using PB303Pronia.Helpers;
using PB303Pronia.Models;
using PB303Pronia.ViewModels.SliderViewModels;

namespace PB303Pronia.Areas.admin.Controllers
{
    [Area("admin")]
    [AutoValidateAntiforgeryToken]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string FOLDER_PATH = "";
        public SliderController(AppDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHostEnvironment = webHost;
            FOLDER_PATH = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images");
        }

        public async Task< IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync(); ;
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateViewModel vm)
        {
            if(!ModelState.IsValid) return View();
            if(!vm.SliderImage.CheckType())
            {
                ModelState.AddModelError("SliderImage", "Please enter valid input");
                return View(vm);
            }
            if(!vm.SliderImage.CheckSize(3))
            {
                ModelState.AddModelError("SliderImage", "Please enter valid input");
                return View(vm);
            }
            string imgPath=await vm.SliderImage.CreateImageAsync(FOLDER_PATH);
            Slider slider = new Slider()
            {
                Description = vm.Description,
                DiscountTitle = vm.DiscountTitle,
                Title = vm.Title,
                ImgUrl = imgPath,
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task< IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var slider = await _context.Sliders.FirstOrDefaultAsync( x=>x.Id==id);
            
            if(slider == null)return NotFound();
            SliderUpdateViewModel vm = new SliderUpdateViewModel()
            {
                Description=slider.Description,
                DiscountTitle=slider.DiscountTitle,
                Title=slider.Title,
                Id=slider.Id,
                ImagePath=slider.ImgUrl
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SliderUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                foreach(var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(vm);
            }
            var existSlider= await _context.Sliders.FirstOrDefaultAsync(x=>x.Id==vm.Id);
            if (existSlider == null) return BadRequest();
            if(vm.SliderImage !=null)
            {
                if (!(vm.SliderImage.CheckType()))
                {
                    ModelState.AddModelError("SliderImage", "Please enter valid input");
                    return View(vm);
                }
                if (!(vm.SliderImage.CheckSize(3)))
                {
                    ModelState.AddModelError("SliderImage", "Please enter valid input");
                    return View(vm);
                }
                var newFileName=Guid.NewGuid()+vm.SliderImage.FileName;
                var newPath=Path.Combine(FOLDER_PATH,newFileName);
                using(FileStream fs =new(newPath, FileMode.Create))
                {
                    await vm.SliderImage.CopyToAsync(fs);
                }
                
                var oldPath= Path.Combine(FOLDER_PATH,existSlider.ImgUrl);
                if(System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                existSlider.ImgUrl = newFileName;
            }
            existSlider.Description = vm.Description;
            existSlider.DiscountTitle = vm.DiscountTitle;
            existSlider.Title = vm.Title;
            _context.Sliders.Update(existSlider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var slider=await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            SliderDeleteViewModel vm = new SliderDeleteViewModel()
            {
                Id = slider.Id,
                Title = slider.Title,
                ImgUrl = slider.ImgUrl
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SliderDeleteViewModel vm)
        {
            var existingSlider= await _context.Sliders.FindAsync(vm.Id);
            if (existingSlider == null) return NotFound();
            var path = Path.Combine(FOLDER_PATH,existingSlider.ImgUrl);
            if(System.IO.File.Exists(path))System.IO.File.Delete(path);
            _context.Sliders.Remove(existingSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
