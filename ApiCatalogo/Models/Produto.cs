using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set;}
        [Required]
        [StringLength(300)]
        public String? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
