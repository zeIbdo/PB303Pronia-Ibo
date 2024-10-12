using PB303Pronia.ViewModels.BlogViewModels;
using PB303Pronia.ViewModels.CategoryViewModels;

namespace PB303Pronia.ViewModels.BlogCategoryViewModels
{
    public class BlogCategoryViewModel
    {
        public int Id { get; set; }
        public BlogViewModel? Blog { get; set; }
        public CategoryViewModel? Category { get; set; }
    }
}
