using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        public Categoria() 
        { 
            Produtos = new Collection<Produto>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public String? Nome { get; set; }
        [Required]
        [StringLength(300)]
        public String? UrlImage { get; set; }
        public Collection<Produto> Produtos { get; set; }
    }
}