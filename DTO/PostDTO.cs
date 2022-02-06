using AgenciaCronosAPI.Models;

namespace AgenciaCronosAPI.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string? TituloPost { get; set; }

        public string? Publicacao { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public Usuario Criador { get; set; }
    }
}
