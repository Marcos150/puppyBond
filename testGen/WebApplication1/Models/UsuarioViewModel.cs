using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public string? Email { get; set; }

        [Display(Prompt = "Escribe el nombre del usuario", Description = "Nombre del usuario", Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Prompt = "Escribe los apellidos del usuario", Description = "Apellidos del usuario", Name = "Apellidos")]
        public string? Apellidos { get; set; }

        [Display(Prompt = "Escribe la disponibilidad del usuario", Description = "Disponibilidad del usuario", Name = "Disponibilidad")]
        public string? Disponibilidad { get; set; }

        [Display(Prompt = "Escribe la contraseña del usuario", Description = "Contraseña del usuario", Name = "Contraseña")]
        public string? Pass { get; set; }

        [Display(Prompt = "Escribe la ubicación del usuario", Description = "Ubicación del usuario", Name = "Ubicación")]
        public string? Ubicacion { get; set; }
    }
}
