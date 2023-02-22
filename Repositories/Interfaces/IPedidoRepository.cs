using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        //Criando assinatura do Metodo.
        void CriarPedido(Pedido pedido);
    }
}
