using System.ComponentModel.DataAnnotations;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.Enumerated.DSM;

namespace WebApplication1.Models
{
    public class MascotaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt ="Escribe el nombre de la mascota", Description="Nombre de la mascota", Name="Nombre")]
        [Required]
        public string? Name { get; set; }

        [Display(Prompt ="Escribe el nombre de la raza de la mascota", Description="Raza de la mascota", Name="Raza")]
        public string? Raza { get; set; }

        [Display(Prompt ="Escoge el sexo de la mascota", Description="Sexo de la mascota", Name="Sexo")]
        public SexoPerroEnum? Sexo { get; set; }

        [Display(Prompt ="Escribe la vacunación de la mascota", Description="Vacunación de la mascota", Name="Vacunación")]
        public string? Vacunacion { get; set; }

        [Display(Prompt ="Escribe el tamaño de la mascota", Description="Tamaño de la mascota", Name="Tamaño")]
        public TamanyoPerroEnum Tamanyo { get; set; }

        [Display(Prompt ="Escribe la edad de la mascota", Description="Edad de la mascota", Name="Edad")]
        public string? Edad { get; set; }

        [Display(Prompt ="Escribe una descripción para la mascota", Description="Descripción de la mascota", Name="Descripción")]
        public string? Descripcion { get; set; }

        [Display(Prompt ="Introduce una imagen de la mascota", Description="Imagen de la mascota", Name="Imagen")]
        public string? Imagen { get; set; }

        [ScaffoldColumn(false)]
        public IList<MatchEN> MatchEnviados { get; set; } = [];

        [ScaffoldColumn(false)]
        public IList<MatchEN> MatchRecibidos { get; set; } = [];
    }
}
