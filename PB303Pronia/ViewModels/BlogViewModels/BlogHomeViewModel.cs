using PB303Pronia.ViewModels.CategoryViewModels;

namespace PB303Pronia.ViewModels.BlogViewModels
{
    public class BlogHomeViewModel
    {
        public List<BlogViewModel>? Blogs { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
    }
}
