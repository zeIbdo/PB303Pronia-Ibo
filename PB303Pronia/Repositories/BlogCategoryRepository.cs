using PB303Pronia.Contexts;
using PB303Pronia.Models;
using PB303Pronia.Repositories.Contracts;

namespace PB303Pronia.Repositories
{
    public class BlogCategoryRepository : RepositoryAsync<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
