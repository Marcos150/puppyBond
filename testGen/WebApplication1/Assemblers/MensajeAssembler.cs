using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class MensajeAssembler
    {
        public MensajeViewModel ConvertirENToModel(MensajeEN en)
        {
            MensajeViewModel model = new()
            {
                Id = en.Id,
                Contenido = en.Contenido,
                Fecha = en.Fecha
            };

            return model;
        }

        public IList<MensajeViewModel> ConvertirListENToViewModel(IList<MensajeEN> ens)
        {
            IList<MensajeViewModel> models = new List<MensajeViewModel>();
            foreach (MensajeEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}