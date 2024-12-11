using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UsuarioViewModel
    {
        [Display(Prompt = "Email", Description = "Email del usuario", Name = "Email")]
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo introducido no es válido")]
        public string Email { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos", Description = "Apellidos del usuario", Name = "Apellidos")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Disponibilidad", Description = "Disponibilidad del usuario", Name = "Disponibilidad")]
        [Required(ErrorMessage = "La disponibilidad es obligatoria")]
        public string Disponibilidad { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña del usuario", Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        //TODO: Regex de comprobacion de numeros y caracteres especiales
        public string Pass { get; set; }

        //TODO: Pensar en un mejor metodo para obtener ubicacion
        [Display(Prompt = "Ubicación", Description = "Ubicación del usuario", Name = "Ubicacion")]
        [Required(ErrorMessage = "La ubicación es obligatoria")]
        public string Ubicacion { get; set; }

        [ScaffoldColumn(false)]
        public MascotaViewModel Mascota { get; set; }
    }
}
