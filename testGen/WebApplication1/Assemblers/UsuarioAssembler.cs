using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models; // Asegúrate de que este espacio de nombres sea correcto

namespace WebApplication1.Assemblers
{
    public class UsuarioAssembler
    {
        // Convierte un UsuarioEN a UsuarioViewModel
        public UsuarioViewModel ConvertirENToModel(UsuarioEN en)
        {
            UsuarioViewModel model = new()
            {
                Email = en.Email,
                Nombre = en.Nombre,
                Apellidos = en.Apellidos,
                Disponibilidad = en.Disponibilidad,
                Ubicacion = en.Ubicacion,
                Mascota = en.Mascota != null ? new MascotaAssembler().ConvertirENToModel(en.Mascota) : null
            };

            return model;
        }

        // Convierte una lista de UsuarioEN a una lista de UsuarioViewModel
        public IList<UsuarioViewModel> ConvertirListENToViewModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> models = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}