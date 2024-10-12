using Microsoft.AspNetCore.Mvc.Rendering;

namespace PB303Pronia.ViewModels.BlogViewModels
{
    public class BlogUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public IFormFile? Image { get; set; } = null!;
        public List<SelectListItem>? OldCategories { get; set; }
        public List<int>? OldCategoryIds { get; set; }
        public List<SelectListItem>? NewCategories { get; set; }
        public List<int>? NewCategoryIds { get; set; }
    }
}
