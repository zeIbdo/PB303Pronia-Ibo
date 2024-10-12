using PB303Pronia.Models;
using PB303Pronia.ViewModels.BlogViewModels;

namespace PB303Pronia.Services.Abstactions
{
    public interface IBlogService:ICommonService<Blog,BlogViewModel,BlogCreateViewModel,BlogUpdateViewModel>
    {
        Task<BlogCreateViewModel> GetCrVm(BlogCreateViewModel vm);
        Task<BlogUpdateViewModel> GetUpVm(int id);
    }
}
