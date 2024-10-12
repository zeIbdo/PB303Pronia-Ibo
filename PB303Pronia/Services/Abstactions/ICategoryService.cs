using PB303Pronia.Models;
using PB303Pronia.ViewModels.BlogViewModels;
using PB303Pronia.ViewModels.CategoryViewModels;

namespace PB303Pronia.Services.Abstactions
{
    public interface ICategoryService: ICommonService<Category, CategoryViewModel, CategoryCreateViewModel,CategoryUpdateViewModel>
    {
    }
}
