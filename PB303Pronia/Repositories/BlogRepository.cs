﻿using PB303Pronia.Contexts;
using PB303Pronia.Models;
using PB303Pronia.Repositories.Contracts;

namespace PB303Pronia.Repositories
{
    public class BlogRepository : RepositoryAsync<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
