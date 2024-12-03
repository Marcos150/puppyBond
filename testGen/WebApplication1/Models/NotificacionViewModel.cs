using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe el correo del usuario que recibe la notificación", Description = "Correo del usuario que recibe la notificación", Name = "Usuario que recibe")]
        [Required(ErrorMessage = "El usuario que recibe la notificación es obligatorio.")]
        public string UsuarioRecibe { get; set; }

        [Display(Prompt = "Escribe el contenido de la notificación", Description = "Contenido de la notificación", Name = "Contenido")]
        [Required(ErrorMessage = "El contenido de la notificación es obligatorio.")]
        public string Contenido { get; set; }
    }
}
