using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGen.Infraestructure.Repository.DSM;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;
using WebApplication1.Assemblers;
using WebRentacar.Controllers;

namespace WebApplication1.Controllers
{
    public class MascotaController : BasicController
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            SessionInitialize();
            MascotaRepository mascotaRepository = new MascotaRepository(session);
            MascotaCEN mascotaCen = new MascotaCEN(mascotaRepository);

            IList<MascotaEN> listEN = mascotaCen.LeerTodos(0, -1);

            IEnumerable<MascotaViewModel> listMascotas = new MascotaAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listMascotas);
        }

        public ActionResult Index2()
        {
            SessionInitialize();
            MascotaRepository mascotaRepository = new MascotaRepository(session);
            MascotaCEN mascotaCen = new MascotaCEN(mascotaRepository);

            IList<MascotaEN> listEN = mascotaCen.LeerTodos(0, -1);

            IEnumerable<MascotaViewModel> listMascotas = new MascotaAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listMascotas);
        }

        //TODO: Poner en el back que solo se puede matchear una vez con la misma mascota
        [Route("Mascota/EnviarPeticionMatch/{receptorId}")]
        public ActionResult EnviarPeticionMatch(int receptorId)
        {
            try
            {
                SessionInitialize();
                Console.WriteLine("ReceptorId: " + receptorId);
                MatchRepository matchRepository = new MatchRepository(session);
                UsuarioRepository usuarioRepository = new UsuarioRepository(session);
                MatchCEN matchCen = new MatchCEN(matchRepository);
                UsuarioCEN usuarioCen = new UsuarioCEN(usuarioRepository);

                UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                matchCen.Nuevo(usuario.Mascota.Id, receptorId, "Universidad de Alicante");

                MascotaRepository mascotaRepository = new MascotaRepository(session);
                MascotaCEN mascotaCen = new MascotaCEN(mascotaRepository);

                IList<MascotaEN> listEN = mascotaCen.LeerTodos(0, -1);

                IEnumerable<MascotaViewModel> listMascotas = new MascotaAssembler().ConvertirListENToViewModel(listEN).ToList();

                //Actualiza datos del usuario en la sesion
                UsuarioViewModel usuarioActualizado = new UsuarioAssembler().ConvertirENToModel(usuarioCen.LeerOID(usuario.Email));
                HttpContext.Session.Set("usuario", usuarioActualizado);

                SessionClose();

                return RedirectToAction("Index2", new Dictionary<string, bool>(){ { "xd",true } });
            }
            catch
            {
                return RedirectToAction("Index2", new Dictionary<string, bool>(){ { "xd",false } });
            }
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
