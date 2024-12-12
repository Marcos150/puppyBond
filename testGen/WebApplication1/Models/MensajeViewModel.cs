using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MensajeViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe el contenido del mensaje", Description = "Contenido del mensaje", Name = "Contenido")]
        public string? Contenido { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }

        [ScaffoldColumn(false)]
        public string EmailUsuarioEnvia { get; set; }

        [ScaffoldColumn(false)]
        public string EmailUsuarioRecibe { get; set; }
    }
}
