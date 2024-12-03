using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class NotificacionAssembler
    {
        public NotificacionViewModel ConvertirENToModel(NotificacionEN en)
        {
            NotificacionViewModel model = new()
            {
                Id = en.Id,
                UsuarioRecibe = en.UsuarioRecibe?.Email ?? "N/A", // Manejo de nulos
                Contenido = en.Contenido
            };

            return model;
        }

        public IList<NotificacionViewModel> ConvertirListENToViewModel(IList<NotificacionEN> ens)
        {
            IList<NotificacionViewModel> models = new List<NotificacionViewModel>();
            foreach (NotificacionEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}
