using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MensajeViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe el contenido del mensaje", Description = "Contenido del mensaje", Name = "Contenido")]
        public string? Contenido { get; set; }

        public DateTime? Fecha { get; set; }
    }
}
