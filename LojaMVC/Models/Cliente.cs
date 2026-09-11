using System.ComponentModel.DataAnnotations;

namespace LojaMVC.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Validation()
        {
            return !string.IsNullOrWhiteSpace(Nome) &&
                   Idade >= 18 &&
                   !string.IsNullOrWhiteSpace(Email) && Email.Contains("@");
        }
        public bool Permission()
        {
            return Ativo == true && Idade >= 18;
        }
    }
}
