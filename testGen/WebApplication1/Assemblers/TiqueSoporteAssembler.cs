using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class TiqueSoporteAssembler
    {
        public TiqueSoporteViewModel ConvertirENToModel(TiqueSoporteEN en)
        {
            TiqueSoporteViewModel model = new()
            {
                Id = en.Id,
                UsuarioManda = en.UsuarioManda?.Email ?? "N/A", // Manejo de nulos para el usuario que manda
                Contenido = en.Contenido
            };

            return model;
        }

        public IList<TiqueSoporteViewModel> ConvertirListENToViewModel(IList<TiqueSoporteEN> ens)
        {
            IList<TiqueSoporteViewModel> models = new List<TiqueSoporteViewModel>();
            foreach (TiqueSoporteEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}
