using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteMVC.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [StringLength(100)]
        public string CategoriaNome { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        public virtual List<Lanche> Lanches { get; set; }

    }
}
