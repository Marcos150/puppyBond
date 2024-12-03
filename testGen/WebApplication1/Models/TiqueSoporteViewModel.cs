 using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TiqueSoporteViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Introduce el correo del usuario que envió el tique", Description = "Correo del usuario que envió el tique", Name = "Usuario que envía")]
        [Required(ErrorMessage = "El usuario que envía el tique es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        public string UsuarioManda { get; set; }

        [Display(Prompt = "Escribe el contenido del tique", Description = "Contenido del tique de soporte", Name = "Contenido")]
        [Required(ErrorMessage = "El contenido del tique es obligatorio.")]
        [StringLength(1000, ErrorMessage = "El contenido no puede exceder los 1000 caracteres.")]
        public string Contenido { get; set; }
    }
}