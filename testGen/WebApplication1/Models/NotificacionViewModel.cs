using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string UsuarioRecibe { get; set; }

        [ScaffoldColumn(false)]
        public string Contenido { get; set; }

        [ScaffoldColumn(false)]
        public MensajeViewModel? Mensaje { get; set; }

        [ScaffoldColumn(false)]
        public MatchViewModel? MatchEnvia { get; set; }
    }
}
