using AutoMapper;
using PB303Pronia.Models;
using PB303Pronia.ViewModels.BlogCategoryViewModels;
using PB303Pronia.ViewModels.BlogViewModels;
using PB303Pronia.ViewModels.CategoryViewModels;

namespace PB303Pronia.AutoMapper
{
    public class AutoMappers:Profile
    {
        public AutoMappers()
        {
            CreateMap<Blog, BlogUpdateViewModel>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryCreateViewModel>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryUpdateViewModel>().ReverseMap();
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryViewModel>().ReverseMap();
            CreateMap<Category,CategoryViewModel>().ForMember(src=>src.BlogCategories,opt=>opt.MapFrom(dest=>dest.BlogCategories)).ReverseMap();
            CreateMap<Category,CategoryCreateViewModel>().ReverseMap();
            CreateMap<BlogCreateViewModel,Blog> ().ForMember(dest=>dest.BlogCategories,opt=>opt.MapFrom(src=>src.CategoryIds.Select(y=>new BlogCategory { CategoryId=y}))).ReverseMap();
        }
    }
}
