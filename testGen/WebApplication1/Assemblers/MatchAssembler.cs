using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class MatchAssembler
    {
        public MatchViewModel ConvertirENToModel(MatchEN en)
        {
            MatchViewModel model = new()
            {
                Id = en.Id,
                Estado = en.Estado,
                Ubicacion = en.Ubicacion,
                MascotaRecibe = en.MascotaRecibe,
                MascotaEnvia = en.MascotaEnvia
            };

            return model;
        }

        public IList<MatchViewModel> ConvertirListENToViewModel(IList<MatchEN> ens)
        {
            IList<MatchViewModel> models = new List<MatchViewModel>();
            foreach (MatchEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}