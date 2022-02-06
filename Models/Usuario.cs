using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaCronosAPI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string? Nome { get; set; }
        [Column("Papel")]
        public string? Papel { get; set; }
        [Column("Contato")]
        public string? Contato { get; set; }
    }
}
