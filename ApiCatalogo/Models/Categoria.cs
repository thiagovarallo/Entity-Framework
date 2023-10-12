using System.Collections.ObjectModel;

namespace ApiCatalogo.Models
{
    public class Categoria
    {
        public Categoria() 
        { 
            Produtos = new Collection<Produto>();
        }

        public int Id { get; set; }
        public String? Nome { get; set; }
        public String? UrlImage { get; set; }
        public Collection<Produto> Produtos { get; set; }
    }
}