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
                UsuarioRecibe = en.UsuarioRecibe.Email,
                Contenido = en.Contenido,
                Mensaje = en.Mensaje != null ? new MensajeAssembler().ConvertirENToModel(en.Mensaje) : null,
                MatchEnvia = en.MatchEnvia != null ? new MatchAssembler().ConvertirENToModel(en.MatchEnvia) : null
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
