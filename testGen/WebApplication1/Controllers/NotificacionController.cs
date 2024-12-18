using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.Infraestructure.Repository.DSM;
using WebApplication1.Assemblers;
using WebApplication1.Models;
using WebRentacar.Controllers;

namespace WebApplication1.Controllers
{
    public class NotificacionController : BasicController
    {
        public ActionResult Obtener()
        {
            SessionInitialize();
            NotificacionRepository notificacionRepository = new(session);
            NotificacionCEN notificacionCEN = new(notificacionRepository);

            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                SessionClose();
                return RedirectToAction("Login", "Usuario");
            }

            IList<NotificacionViewModel> notificaciones = new NotificacionAssembler().ConvertirListENToViewModel(notificacionCEN.LeerTodos(0, -1));

            SessionClose();
            return Ok(notificaciones.Where(ntf => ntf.UsuarioRecibe == usuario.Email));
        }
    }
}
