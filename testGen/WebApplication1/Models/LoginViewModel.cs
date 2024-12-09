using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Display(Prompt = "Email", Description = "Email del usuario", Name = "Email")]
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es una dirección de correo válida")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña del usuario", Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Pass { get; set; }
    }
}
