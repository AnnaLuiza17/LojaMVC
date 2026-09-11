using System.ComponentModel.DataAnnotations;

namespace LojaMVC.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Validation()
        {
            return Preco > 0 && Estoque > 0 && !string.IsNullOrWhiteSpace(Nome);
        }
    }
}
