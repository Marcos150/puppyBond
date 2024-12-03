using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ValoracionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe el valor de la valoración", Description = "Valor de la valoración", Name = "Valor")]
        public int Valor { get; set; }

        public UsuarioViewModel UsuarioValora { get; set; }

        public MascotaViewModel MascotaRecibe { get; set; }
    }
}
