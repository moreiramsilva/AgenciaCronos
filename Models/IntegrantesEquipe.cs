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

        [Column("ServicosId")]
        public int? ServicosId { get; set; }
    }
}
