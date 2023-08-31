using Microsoft.AspNetCore.Mvc;
using MultiLangMvc.Models;
using MultiLangMvc.Repo;
using System.Diagnostics;

namespace MultiLangMvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILanguageService languageService, ILocalizationService localizationService, ILogger<HomeController> logger)
            : base(languageService, localizationService)
        
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // var ste = LANGUAGE_CODE();
            ViewData["Title"] = Localize("Home.page.Title");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}