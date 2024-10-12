using Microsoft.AspNetCore.Mvc.Rendering;
using PB303Pronia.Models;
using PB303Pronia.ViewModels.CategoryViewModels;

namespace PB303Pronia.ViewModels.BlogViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
