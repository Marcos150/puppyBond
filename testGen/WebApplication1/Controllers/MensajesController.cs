using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.CP.DSM;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.Infraestructure.CP;
using TestGen.Infraestructure.Repository.DSM;
using WebApplication1.Assemblers;
using WebApplication1.Models;
using WebRentacar.Controllers;

namespace WebApplication1.Controllers
{
    public class MensajesController : BasicController
    {
        // GET: MensajesController
        //Obtiene mensajes de chat con un usuario determinado
        public ActionResult Index([FromQuery(Name = "correoUsuario")]  string correoUsuario = "")
        {
            SessionInitialize();
            MensajeRepository mensajeRepository = new MensajeRepository(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepository);
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null) 
            {
                SessionClose();
                return RedirectToAction("Login", "Usuario");
            }

            IList<UsuarioEN> usuariosMatcheadosEN = usuarioCEN.ObtenerUsuariosMatcheados(usuario.Email);

            //ObtenerUsuariosMatcheados solo devuelve de los que se ha recibido match, no de los que se ha enviado
            //No tengo ni idea de como hacerlo bien con HQL, asi que como no hay tiempo lo hago asi
            UsuarioEN usu = usuarioCEN.LeerOID(usuario.Email);
            usuariosMatcheadosEN.AddRange(usu.Mascota.MatchRecibidos.Where(m => m.Estado == TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum.aceptado).Select(m => m.MascotaEnvia).Select(m => m.Duenyo));

            IList<UsuarioViewModel> usuariosMatcheados = new UsuarioAssembler().ConvertirListENToViewModel(usuariosMatcheadosEN);

            //Si no se pasa un usuario, se coge el primero matcheado
            if (correoUsuario == "") correoUsuario = usuariosMatcheados[0].Email;

            //TODO: Comprobar que los usuarios estan matcheados

            IList<MensajeViewModel> todosMensajes = new MensajeAssembler().ConvertirListENToViewModel(mensajeCEN.LeerTodos(0, -1));
            IEnumerable<MensajeViewModel> mensajesConUsuario = todosMensajes.Where(msg => (msg.EmailUsuarioEnvia == usuario.Email && msg.EmailUsuarioRecibe == correoUsuario) || (msg.EmailUsuarioRecibe == usuario.Email && msg.EmailUsuarioEnvia == correoUsuario));

            SessionClose();
            return View(mensajesConUsuario);
        }

        [HttpPost]
        public ActionResult Enviar([FromForm(Name = "correoReceptor")]  string correoReceptor, [FromForm(Name = "contenido")]  string contenido)
        {
            SessionInitialize();
            MensajeRepository mensajeRepository = new MensajeRepository(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepository);
            UsuarioCP usuarioCP = new UsuarioCP(new SessionCPNHibernate());

            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                SessionClose();
                return RedirectToAction("Login", "Usuario");
            }

            usuarioCP.EnviarMensaje(usuario.Email, correoReceptor, contenido);

            SessionClose();

            return RedirectToAction(nameof(Index), routeValues: correoReceptor);
        }
    }
}
