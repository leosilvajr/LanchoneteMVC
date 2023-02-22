using LanchoneteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteMVC.Context
{
    //Adicioanr o DBContext sempre que adicionarmos o Model 
    //Classe de Contexto carrega informações de configurações e define quais as que estou mapiando para as tabelas

    public class AppDbContext : DbContext //Herdar  DbContext do EntityFrameworkCore
    {

        //Criando Construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        } 

        //Mapiar classe para tabela
        public DbSet <Categoria> Categorias { get; set; }
        public DbSet <Lanche> Lanches { get; set; }
        public DbSet <CarrinhoCompraItem> CarrinhoCompraItens { get; set; }


        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }

    }
}
