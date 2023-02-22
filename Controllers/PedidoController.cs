using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        //Get que apresenta o Formulário
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }


        //Post que processa o formulário;
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            //Obter os itens do carrinho de compra do Cliente
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = items;

            //Verificar se existem itens de pedido
            if (_carrinhoCompra.CarrinhoCompraItems.Count() == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um lance.");
            }


            //totalItensPedido= items.Sum(o => o.Quantidade);
            //precoTotalPedido = items.Sum(x => x.Lanche.Preco * x.Quantidade);


            //Calcular o total de itens e o total do pedido
            foreach(var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }

            //Atribuir os valores obtidos ao pedido 
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalPedido;

            //Validar os dados do pedido
            if (ModelState.IsValid)
            {
                //Criar o pedido, e os Detalhes do pedido.
                _pedidoRepository.CriarPedido(pedido);

                //Define mensagens ao cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido.";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                //limpa o carrinho do cliente
                _carrinhoCompra.LimparCarrinho();

                //exibe a view com dados do cliente e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);
        }
    }
}
