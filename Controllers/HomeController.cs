using LanchoneteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchoneteMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Consigo chamar em qualquer View
            //TempData["Nome"] = "Teste";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}