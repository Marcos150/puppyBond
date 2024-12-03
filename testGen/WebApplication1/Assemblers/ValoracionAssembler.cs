using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class ValoracionAssembler
    {
        /// <summary>
        /// Convierte un objeto de tipo ValoracionEN a un objeto de tipo ValoracionViewModel.
        /// </summary>
        /// <param name="en">Entidad de negocio ValoracionEN.</param>
        /// <returns>Modelo de vista ValoracionViewModel.</returns>
        public ValoracionViewModel ConvertirENToModel(ValoracionEN en)
        {
            UsuarioAssembler usuarioAssembler = new UsuarioAssembler();
            MascotaAssembler mascotaAssembler = new MascotaAssembler();
            ValoracionViewModel model = new()
            {
                Id = en.Id,
                Valor = en.Valor,
                UsuarioValora = usuarioAssembler.ConvertirENToModel(en.UsuarioValora),
                MascotaRecibe = mascotaAssembler.ConvertirENToModel(en.MascotaRecibe)
            };

            return model;
        }

        /// <summary>
        /// Convierte una lista de objetos ValoracionEN a una lista de objetos ValoracionViewModel.
        /// </summary>
        /// <param name="ens">Lista de entidades de negocio ValoracionEN.</param>
        /// <returns>Lista de modelos de vista ValoracionViewModel.</returns>
        public IList<ValoracionViewModel> ConvertirListENToViewModel(IList<ValoracionEN> ens)
        {
            IList<ValoracionViewModel> models = new List<ValoracionViewModel>();
            foreach (ValoracionEN en in ens)
            {
                models.Add(ConvertirENToModel(en));
            }
            return models;
        }
    }
}
