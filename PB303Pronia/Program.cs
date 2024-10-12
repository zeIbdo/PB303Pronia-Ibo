using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PB303Pronia.Contexts;
using PB303Pronia.Models;
using PB303Pronia.Services.Abstactions;
using PB303Pronia.Services.Implementations;
using PB303Pronia.Data;
using PB303Pronia.Helpers;
using PB303Pronia.Repositories.Contracts;
using PB303Pronia.Repositories;
using System.Reflection;

namespace PB303Pronia;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();


        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped< CloudinaryHelper>();

        builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
        builder.Services.AddScoped<IBlogCategoryService, BlogCategoryService>();
        builder.Services.AddScoped<IBlogService, BlogService>(); 
        builder.Services.AddScoped<ILayoutService, LayoutService>();

        var app = builder.Build();


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); ;
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
        });


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}