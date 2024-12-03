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
                Ubicacion = en.Ubicacion
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

        // Convierte un UsuarioViewModel a UsuarioEN
        public UsuarioEN ConvertirModelToEN(UsuarioViewModel model)
        {
            UsuarioEN en = new()
            {
                Email = model.Email,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Disponibilidad = model.Disponibilidad,
                Ubicacion = model.Ubicacion,
                Pass = model.Pass
            };

            return en;
        }
    }
}