using PB303Pronia.ViewModels.BlogCategoryViewModels;

namespace PB303Pronia.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
       public List<BlogCategoryViewModel>? BlogCategories { get; set; }
    }
}
