using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.Infraestructure.Repository.DSM;
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

        //POST: UsuarioController
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            // Si falla el login va a la vista de login mostrando un error
            if (usuarioCEN.Login(login.Email, login.Pass) == null)
            {
                ModelState.AddModelError("", "Email o contraseña incorrectos");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
