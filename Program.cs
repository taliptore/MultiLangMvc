using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MultiLangMvc.Models;
using MultiLangMvc.Repo;
using System.Configuration;
using System.Text.RegularExpressions;
using static MultiLangMvc.Repo.IGenericRepository;

namespace MultiLangMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));



            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<ILocalizationService, LocalizationService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));

            builder.Services.AddLocalization();
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddViewLocalization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
                     app.UseRouting();
            app.UseRequestLocalization();
            app.UseAuthorization();
            app.MapControllerRoute(
            name: "default",
             pattern: "{culture=tr-TR}/{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}