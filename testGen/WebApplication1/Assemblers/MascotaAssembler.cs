using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class MascotaAssembler
    {
        public MascotaViewModel ConvertirENToModel(MascotaEN en)
        {
            MascotaViewModel model = new()
            {
                Id = en.Id,
                Name = en.Nombre,
                Raza = en.Raza,
                Sexo = en.Sexo,
                Vacunacion = en.Vacunacion,
                Tamanyo = en.Tamanyo,
                Edad = en.Edad,
                Descripcion = en.Descripcion,
                Imagen = en.Imagen,
                MatchEnviados = new MatchAssembler().ConvertirListENToViewModel(en.MatchEnviados),
                MatchRecibidos = new MatchAssembler().ConvertirListENToViewModel(en.MatchRecibidos)
            };

            return model;
        }

        public IList<MascotaViewModel> ConvertirListENToViewModel(IList<MascotaEN> ens)
        {
            IList<MascotaViewModel> models = new List<MascotaViewModel>();
            foreach (MascotaEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}
