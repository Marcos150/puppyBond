using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;

namespace WebApplication1.Assemblers
{
    public class MascotaAssembler
    {
        public MascotaViewModel ConvertirEnToModel(MascotaEN en)
        {
            MascotaViewModel model = new MascotaViewModel();

            model.Id = en.Id;
            model.Name = en.Nombre;

            return model;
        }
    }
}
