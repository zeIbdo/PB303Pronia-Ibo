using PB303Pronia.Models.Common;

namespace PB303Pronia.Models
{
    public class Blog:BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public List<BlogCategory>? BlogCategories { get; set; }

    }
}
