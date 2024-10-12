using Microsoft.AspNetCore.Mvc.Rendering;
using PB303Pronia.Models;

namespace PB303Pronia.ViewModels.BlogViewModels
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
        public List<SelectListItem>? Categories { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}
