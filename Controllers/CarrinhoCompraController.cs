using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;
using LanchoneteMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        //Acessar os Lanches e o Carrinho de Compra (Para injetar da pra usar a ferramenta do VISUAL STUDIO)
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
            //Vamos ter que registrar Carrinho de Compras em Services no StartUp
            //            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
        }

        /*O Controlador procura pela view com o mesmo nome do metodo Action quando nao informamos o nome da View*/

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }


        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
                if (lancheSelecionado != null)
                {
                    _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
                    return RedirectToAction("Index"); 
                }
            }
            return RedirectToAction("Login", "Account");
        }


        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

                if (lancheSelecionado != null)
                {
                    _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
                    return RedirectToAction("Index"); 
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
