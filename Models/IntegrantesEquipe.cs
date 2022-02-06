using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaCronosAPI.Models
{
    [Table("IntegrantesEquipe")]
    public class IntegrantesEquipe
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("TituloEquipe")]
        [MaxLength(50)]
        public string? TituloEquipe { get; set; }
        
        public List <Usuario>? ListaUsuarios { get; set; }
    }
}
