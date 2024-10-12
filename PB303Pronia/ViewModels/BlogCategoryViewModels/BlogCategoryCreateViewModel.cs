using Microsoft.AspNetCore.Mvc.Rendering;

namespace PB303Pronia.ViewModels.BlogCategoryViewModels
{
    public class BlogCategoryCreateViewModel
    {
        public List<SelectListItem>? Blogs { get; set; }
        public int BlogId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
