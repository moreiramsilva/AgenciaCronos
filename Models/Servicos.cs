using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaCronosAPI.Models
{
    [Table("Servicos")]
    public class Servicos
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("TituloServico")]
        [MaxLength(50)]
        public string? TituloServico { get; set; }
        
        [Column("Descricao")]
        [MaxLength(500)]
        public string? Descricao { get; set; }
        
        [Column("DataInicioServico")]
        public DateTime? DataInicioServico { get; set; }
        
        [Column("DataFimServico")]
        public DateTime? DataFimServico { get; set; }
    }
}
