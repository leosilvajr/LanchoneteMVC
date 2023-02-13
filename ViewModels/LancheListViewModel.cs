using LanchoneteMVC.Models;

namespace LanchoneteMVC.ViewModels
{
    public class LancheListViewModel
    {
        //Propriedade para exibir lista de lanches
        public IEnumerable<Lanche> Lanches { get; set; }

        public string CategoriaAtual { get; set; }
        
    }
}
