using LanchoneteMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Components
{
    public class CategoriaMenu :ViewComponent
    {
        private readonly ICategoriaRepositoy _categoriaRepository;

        public CategoriaMenu(ICategoriaRepositoy categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categoria = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categoria);
        }
    }
}
