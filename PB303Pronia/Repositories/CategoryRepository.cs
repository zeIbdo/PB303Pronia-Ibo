using PB303Pronia.Contexts;
using PB303Pronia.Models;
using PB303Pronia.Repositories.Contracts;

namespace PB303Pronia.Repositories
{
    public class CategoryRepository : RepositoryAsync<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
