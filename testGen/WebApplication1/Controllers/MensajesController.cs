using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGen.ApplicationCore.CEN.DSM;
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
            IList<UsuarioViewModel> usuariosMatcheados = new UsuarioAssembler().ConvertirListENToViewModel(usuarioCEN.ObtenerUsuariosMatcheados(usuario.Email));

            //Si no se pasa un usuario, se coge el primero matcheado
            if (correoUsuario == "") correoUsuario = usuariosMatcheados[0].Email;

            //TODO: Comprobar que los usuarios estan matcheados

            IList<MensajeViewModel> todosMensajes = new MensajeAssembler().ConvertirListENToViewModel(mensajeCEN.LeerTodos(0, -1));
            IEnumerable<MensajeViewModel> mensajesConUsuario = todosMensajes.Where(msg => (msg.EmailUsuarioEnvia == usuario.Email && msg.EmailUsuarioRecibe == correoUsuario) || (msg.EmailUsuarioRecibe == usuario.Email && msg.EmailUsuarioEnvia == correoUsuario));

            SessionClose();
            return View(mensajesConUsuario);
        }

        // GET: MensajesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MensajesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MensajesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MensajesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MensajesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MensajesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MensajesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
