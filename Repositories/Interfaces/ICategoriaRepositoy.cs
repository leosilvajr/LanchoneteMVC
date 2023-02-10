using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface ICategoriaRepositoy
    {
        IEnumerable<Categoria> Categoras { get; }
    }
}
