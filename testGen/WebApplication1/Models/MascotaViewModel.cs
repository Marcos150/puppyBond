using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MascotaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt ="Escribe el nombre de la mascota", Description="Nombre de la mascota", Name="nombre")]
        [Required]
        public string? Name { get; set; }
    }
}
