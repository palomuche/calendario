using System.ComponentModel.DataAnnotations;

namespace Calendario.Model
{
    public class TesteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} a {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        public int? Quantidade { get; set; }
    }
}
