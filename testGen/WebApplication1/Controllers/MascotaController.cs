using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGen.Infraestructure.Repository.DSM;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.EN.DSM;
using WebApplication1.Models;
using WebApplication1.Assemblers;
using WebRentacar.Controllers;
using TestGen.ApplicationCore.CP.DSM;
using TestGen.Infraestructure.CP;

namespace WebApplication1.Controllers
{
    public class MascotaController : BasicController
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Perfil_ajeno(int id)
        {
            SessionInitialize();
            try
            {
                MascotaRepository mascotaRepository = new MascotaRepository(session);
                MascotaCEN mascotaCen = new MascotaCEN(mascotaRepository);

                // Retrieve the specific mascot by ID
                MascotaEN mascotaEN = mascotaCen.LeerOID(id);

                // Convert to ViewModel
                MascotaViewModel mascotaViewModel = new MascotaAssembler().ConvertirENToModel(mascotaEN);

                SessionClose();
                return View(mascotaViewModel);
            }
            catch (Exception)
            {
                SessionClose();
                // Handle error, perhaps redirect to an error page or back to Index2
                return RedirectToAction("Index2");
            }
        }

        public IActionResult Perfil_propio()
        {
            return View();
        }
        public IActionResult Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
            {
                return RedirectToAction("Index2"); // Redirige si no se proporciona un término
            }

            SessionInitialize();
            try
            {
                MascotaRepository mascotaRepository = new MascotaRepository(session);
                MascotaCEN mascotaCen = new MascotaCEN(mascotaRepository);

                // Filtrar mascotas por el término
                var mascotasFiltradas = mascotaCen.LeerTodos(0, -1)
                    .Where(m => m.Nombre != null && m.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Convertir a ViewModel
                var mascotasViewModel = new MascotaAssembler()
                    .ConvertirListENToViewModel(mascotasFiltradas)
                    .AsEnumerable(); // <-- Asegúrate de convertir a IEnumerable

                SessionClose();

                return View("ResultadosBusqueda", mascotasViewModel);
            }
            catch (Exception ex)
            {
                SessionClose();
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index2");
            }
        }


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
                UsuarioRepository usuarioRepository = new UsuarioRepository(session);
                MatchCP matchCp = new MatchCP(new SessionCPNHibernate());
                UsuarioCEN usuarioCen = new UsuarioCEN(usuarioRepository);

                UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                matchCp.Nuevo(usuario.Mascota.Id, receptorId, "Universidad de Alicante");

                MascotaRepository mascotaRepository = new MascotaRepository(session);
                MascotaCEN mascotaCen = new MascotaCEN(mascotaRepository);

                IList<MascotaEN> listEN = mascotaCen.LeerTodos(0, -1);

                IEnumerable<MascotaViewModel> listMascotas = new MascotaAssembler().ConvertirListENToViewModel(listEN).ToList();

                //Actualiza datos del usuario en la sesion
                UsuarioViewModel usuarioActualizado = new UsuarioAssembler().ConvertirENToModel(usuarioCen.LeerOID(usuario.Email));
                HttpContext.Session.Set("usuario", usuarioActualizado);

                SessionClose();

                return RedirectToAction("Index2", new { Values = true });
            }
            catch
            {
                return RedirectToAction("Index2", new { Values = false });
            }
        }
    }
}