using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaCronosAPI.Models
{
    [Table("Post")]
    public class Post
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("TituloPost")]
        [MaxLength(50)]
        public string? TituloPost { get; set; }
        
        [Column("Publicacao")]
        [MaxLength(1000)]
        public string? Publicacao { get; set; }
        
        [Column("DataPublicacao")]
        public DateTime? DataPublicacao { get; set; }
        
        [Column("Criador")]
        public Usuario Criador { get; set; }
    }
}
