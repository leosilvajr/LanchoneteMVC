using LanchoneteMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteMVC.Context
{
    //Adicioanr o DBContext sempre que adicionarmos o Model 
    //Classe de Contexto carrega informações de configurações e define quais as que estou mapiando para as tabelas

    public class AppDbContext : IdentityDbContext<IdentityUser> //Configurando o Identity do Projeto
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
