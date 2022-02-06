using AgenciaCronosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaCronosAPI.DTO
{
    public class IntegrantesEquipeDTO
    {
        public int Id { get; set; }

        public string? TituloEquipe { get; set; }

        public Servicos? Servicos { get; set; }

        public List<Usuario>? MembroEquipe { get; set; }
    }
}
