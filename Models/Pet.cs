using System.ComponentModel.DataAnnotations;

namespace AdoteUmPet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do animal")]
        public string Nome { get; set; }
        public string Imagem { get; set; }
        [Required(ErrorMessage = "Qual o tipo dele?")]
        public TipoDePet Tipo { get; set; }
        public  string Descricao { get; set; } 

    }
}
