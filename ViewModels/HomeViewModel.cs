using LanchoneteMVC.Models;

namespace LanchoneteMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
