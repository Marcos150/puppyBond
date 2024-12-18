using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.Infraestructure.Repository.DSM;
using WebApplication1.Assemblers;
using WebApplication1.Models;
using WebRentacar.Controllers;

namespace WebApplication1.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: UsuarioController
        public ActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //POST: UsuarioController
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            // Si falla el login va a la vista de login mostrando un error
            if (usuarioCEN.Login(login.Email, login.Pass) == null)
            {
                ModelState.AddModelError("", "Email o contraseña incorrectos");
                return View();
            }

            UsuarioEN usuarioEN = usuarioCEN.LeerOID(login.Email);
            UsuarioViewModel usuarioViewModel = new UsuarioAssembler().ConvertirENToModel(usuarioEN);
            // Verificar que la conversión fue exitosa
            if (usuarioViewModel == null)
            {
                throw new Exception("Error al convertir usuario a ViewModel");
            }
            HttpContext.Session.Set<UsuarioViewModel>("usuario", usuarioViewModel);
            SessionClose();
            
            //LLeva a la pagina de crear mascota si no tiene una aun
            return usuarioViewModel.Mascota != null ? RedirectToAction("Index2", "Mascota") : RedirectToAction("Register", "Mascota");
        }

        //POST: UsuarioController
        [HttpPost]
        public ActionResult Register(UsuarioViewModel register)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            // Verificar si ya existe un usuario con el mismo correo
            if (usuarioCEN.LeerOID(register.Email) != null)
            {
                ModelState.AddModelError("", "Ya existe un usuario con este correo electrónico.");
                return View(register);
            }

            try
            {
                // Crear el nuevo usuario pasando todos los datos
                var nuevoUsuarioId = usuarioCEN.Nuevo(
                    register.Nombre,
                    register.Apellidos,
                    register.Email,
                    register.Pass,
                    register.Disponibilidad,
                    register.Ubicacion
                );

                if (nuevoUsuarioId == null)
                {
                    ModelState.AddModelError("", "No se pudo registrar el usuario. Intenta nuevamente.");
                    return View(register);
                }

                // Cargar el usuario recién creado y guardar en sesión
                UsuarioEN usuarioEN = usuarioCEN.LeerOID(register.Email);
                UsuarioViewModel usuarioViewModel = new UsuarioAssembler().ConvertirENToModel(usuarioEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuarioViewModel);
                SessionClose();

                // Redirigir a la página principal
                return RedirectToAction("Register", "Mascota");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error durante el registro: " + ex.Message);
                return View(register);
            }
        }

        public ActionResult Editar_Perfil()
        {
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                return RedirectToAction("Login");
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar_Perfil(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                SessionInitialize();
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

                // Mantener el email original ya que es el identificador
                var usuarioOriginal = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                usuarioViewModel.Email = usuarioOriginal.Email;
                usuarioViewModel.Mascota = usuarioOriginal.Mascota;

                // Actualizar los datos del usuario
                usuarioCEN.Modificar(
                    usuarioViewModel.Email,
                    usuarioViewModel.Nombre,
                    usuarioViewModel.Apellidos,
                    usuarioViewModel.Pass,
                    usuarioViewModel.Disponibilidad,
                    usuarioViewModel.Ubicacion
                );

                // Actualizar la sesión con los nuevos datos
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuarioViewModel);
                SessionClose();

                return RedirectToAction("Editar_Perfil", "Usuario");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar el perfil: " + ex.Message);
                return View(usuarioViewModel);
            }
        }

        //GET: UsuarioController/Logout
        public ActionResult Logout()
        {
            SessionInitialize();
            HttpContext.Session.Remove("usuario");
            SessionClose();
            return RedirectToAction("Principal", "Home");
        }
    }
}