using Microsoft.AspNetCore.Mvc;
using MultiLangMvc.Models;
using MultiLangMvc.Repo;
using System.Diagnostics;

namespace MultiLangMvc.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILanguageService languageService, ILocalizationService localizationService, ILogger<HomeController> logger)
            : base(languageService, localizationService)
        
        {    }

        public IActionResult Index()
        {
            // var ste = LANGUAGE_CODE();
            ViewData["Title"] = Localize("Home.page.Title");
            ViewData["subtitle"] = Localize("Home.page.subtitle");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}