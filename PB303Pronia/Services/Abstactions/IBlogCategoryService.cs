using PB303Pronia.Models;
using PB303Pronia.ViewModels.BlogCategoryViewModels;

namespace PB303Pronia.Services.Abstactions
{
    public interface IBlogCategoryService:ICommonService<BlogCategory,BlogCategoryViewModel,BlogCategoryCreateViewModel,BlogCategoryUpdateViewModel>
    {
    }
}
