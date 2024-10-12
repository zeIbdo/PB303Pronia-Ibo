using PB303Pronia.Models.Common;

namespace PB303Pronia.Models
{
    public class BlogCategory:BaseEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}
