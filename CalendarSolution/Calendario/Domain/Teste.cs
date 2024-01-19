using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendario.Domain
{
    [Table("Testes")]
    public class Teste
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public int? Quantidade { get; set; }
    }
}
