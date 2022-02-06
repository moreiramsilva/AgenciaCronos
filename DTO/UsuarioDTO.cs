using AgenciaCronosAPI.Models;

namespace AgenciaCronosAPI.DTO
{
    public class UsuarioDTO
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Papel { get; set; }

        public string? Contato { get; set; }
        public IntegrantesEquipe Equipe { get; set; }


    }
}
