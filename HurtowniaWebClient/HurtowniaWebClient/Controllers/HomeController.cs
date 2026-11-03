using HurtowniaWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HurtowniaWebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var zdjęcia = new List<string>();
            var oFirmie = new List<string>();
            foreach (var sekcja in _configuration.GetSection("Strona główna:Zdjęcia").AsEnumerable())
            {
                if (sekcja.Value != null)
                {
                    zdjęcia.Add(sekcja.Value);
                }
            }
            foreach (var sekcja in _configuration.GetSection("Strona główna:O firmie").AsEnumerable())
            {
                if (sekcja.Value != null)
                {
                    oFirmie.Add(sekcja.Value);
                }
            }
            var home = new Home() 
            {
                Zdjęcia = zdjęcia,
                Paragraf = oFirmie
            };
            return View(home);
        }

        public IActionResult Privacy()
        {
            var privacy = new Privacy()
            {
                Email = _configuration["RODO:Admin:Email"],
                Imię = _configuration["RODO:Admin:Imię"],
                Nazw = _configuration["RODO:Admin:Nazwisko"],
                NrTel = _configuration["RODO:Admin:NrTel"]
            };
            return View(privacy);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}