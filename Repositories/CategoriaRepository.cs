using LanchoneteMVC.Context;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;

namespace LanchoneteMVC.Repositories
{
    public class CategoriaRepository : ICategoriaRepositoy
    {

        //Instanciamos a classe AppDbContext
        private readonly AppDbContext _context;

        //Injeção de dependencia
        //Solicitando ao construtor para nos dar uma instance de AppDbContext
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

/*

    A injeção de dependência (DI) é um padrão de projeto no qual o objeto não cria
 suas classes dependentes, mas as requisita.

    É uam técnica pela qual um objeto fornece as dependencias de outro objeto.

    A plataforma .NET dá suporte ao padrao de projeto da injeção de dependência (DI),
que é uma tecnica pra obter Inversão de Controle (IOC) entre classes e suas dependencias.

    A plataforma .NET implementa o padrao da Injeção de Dependencia atraves de um conteiner nativo
chamado Conteiner DI que realiza e aplica a injeção de dependencia apos a configuração.

    Transferir a tarefa de criar o objeto para outro objeto ou framework e usar diretamente a 
dependencia é chamado de injeção de dependencia.
 
 */