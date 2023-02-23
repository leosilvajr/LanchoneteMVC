using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            //Fazendo verificação se existe algum usuario logado.
            if (User.Identity.IsAuthenticated)
            {
            return View();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
