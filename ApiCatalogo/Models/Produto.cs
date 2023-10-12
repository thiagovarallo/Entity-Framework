﻿namespace ApiCatalogo.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; }
        public decimal Preco { get; set;}
        public String? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
