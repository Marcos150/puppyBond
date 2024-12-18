using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using TestGen.Infraestructure.Repository.DSM;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.EN.DSM;
using WebRentacar.Controllers;

namespace WebApplication1.Controllers
{
    public class HomeController : BasicController
    {
        public IActionResult Index()
        {
            UsuarioRepository usuarioRepository = new();
            UsuarioCEN usuarioCEN = new(usuarioRepository);
            IList<UsuarioEN> usuarios = usuarioCEN.LeerAll(0, -1);

            return View(usuarios);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult Mensajes()
        {
            return View();
        }

        public IActionResult Contacto_soporte()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto_soporte(string Nombre, string Email, string Asunto, string Mensaje)
        {
            TiqueSoporteRepository tiqueSoporteRepository = new();
            TiqueSoporteCEN tiqueSoporteCEN = new(tiqueSoporteRepository);
            try
            {
                UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                if (user == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                // Save the ticket and get its ID
                int tiqueId1 = tiqueSoporteCEN.Nuevo(user.Email, Mensaje);

                // Send support ticket email
                tiqueSoporteCEN.EnviarCorreoSoporte(tiqueId1);

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
                return View();
            }
        }

        public IActionResult Editar_mascotas()
        {
            return View();
        }

        public IActionResult Editar_perfil()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Perfil_ajeno()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}