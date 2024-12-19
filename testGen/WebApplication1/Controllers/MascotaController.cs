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
using TestGen.Infraestructure.EN.DSM;

namespace WebApplication1.Controllers
{
    public class MascotaController : BasicController
    {
        public IActionResult Register()
        {
            return View();
        }
        private readonly IWebHostEnvironment _webHost;
        public MascotaController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        //POST: UsuarioController
        [HttpPost]
        public async Task<ActionResult> RegisterAsync(MascotaViewModel register)
        {
            SessionInitialize();
            MascotaRepository mascotaRepository = new MascotaRepository();
            MascotaCEN mascotaCEN = new MascotaCEN(mascotaRepository);

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            try
            {
                // Crear la nueva mascota pasando todos los datos
                int nuevaMascotaId = mascotaCEN.Nuevo(
                    register.Name,
                    register.Raza,
                    register.Sexo,
                    register.Vacunacion,
                    register.Tamanyo,
                    register.Edad,
                    user.Email,
                    register.Descripcion
                );

                string fileName = "", path = "";

                // Verificar si se ha subido una imagen
                if (register.Imagen != null && register.Imagen.Length > 0)
                {
                    string extension = Path.GetExtension(register.Imagen.FileName);

                    string directory = _webHost.WebRootPath + "/Images/Mascotas";
                    path = Path.Combine(directory, nuevaMascotaId.ToString() + extension);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await register.Imagen.CopyToAsync(stream);
                    }
                }

                // Ruta de la imagen (si se subió alguna)
                string imagePath = !string.IsNullOrEmpty(fileName) ? "/Images/Mascotas/" + fileName : null;

                mascotaCEN.CambiarFoto(nuevaMascotaId, fileName);

                if (nuevaMascotaId == null)
                {
                    ModelState.AddModelError("", "No se pudo registrar la mascota. Intenta nuevamente.");
                    return View(register);
                }

                mascotaRepository = new MascotaRepository(session);
                mascotaCEN = new MascotaCEN(mascotaRepository);

                user.Mascota = new MascotaAssembler().ConvertirENToModel(mascotaCEN.LeerOID(nuevaMascotaId));
                HttpContext.Session.Set<UsuarioViewModel>("usuario", user);
                SessionClose();

                // Redirigir a la página principal
                return RedirectToAction("Index2", "Mascota");
            }
            catch (Exception ex)
            {
                throw ex;
                ModelState.AddModelError("", "Ocurrió un error durante el registro: " + ex.Message);
                return View(register);
            }
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

        public ActionResult Editar_mascotas(int receptorId)
        {
            return View();
        }

        public ActionResult Mis_mascotas(int receptorId)
        {
            UsuarioViewModel usu = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            return View(usu.Mascota);
        }

        public ActionResult AceptarMatch(int matchId)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            UsuarioCEN usuarioCen = new UsuarioCEN(usuarioRepository);
            MatchRepository matchRepository = new MatchRepository();
            MatchCEN matchCEN = new MatchCEN(matchRepository);

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                SessionClose();
                return RedirectToAction("Login", "Usuario");
            }

            matchCEN.Modificar(matchId, TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum.aceptado, "Universidad de Alicante");
            
            matchRepository = new MatchRepository(session);
            matchCEN = new MatchCEN(matchRepository);
            //Envia mensaje automaticamente ya que no salen contactos sin mensajes
            UsuarioCP usuarioCP = new UsuarioCP(new SessionCPNHibernate());
            string correoReceptor = matchCEN.LeerOID(matchId).MascotaEnvia.Duenyo.Email;
            usuarioCP.EnviarMensaje(user.Email, correoReceptor, "¡Hola!");
            
            //Actualiza datos del usuario en la sesion
            usuarioRepository = new UsuarioRepository(session);
            usuarioCen = new UsuarioCEN(usuarioRepository);
            UsuarioViewModel usuarioActualizado = new UsuarioAssembler().ConvertirENToModel(usuarioCen.LeerOID(user.Email));
            HttpContext.Session.Set("usuario", usuarioActualizado);

            SessionClose();
            return RedirectToAction("index", "Mensajes", routeValues: correoReceptor);
        }

        public ActionResult RechazarMatch(int matchId)
        {
            MatchRepository matchRepository = new MatchRepository();
            MatchCEN matchCEN = new MatchCEN(matchRepository);

            matchCEN.Modificar(matchId, TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum.rechazado, "Universidad de Alicante");
            return RedirectToAction("Index2", "Mascota");
        }

        // POST: Mascota/Editar
        [HttpPost]
        public async Task<IActionResult> Editar(MascotaViewModel editMascota)
        {
            SessionInitialize();
            MascotaRepository mascotaRepository = new MascotaRepository();
            MascotaCEN mascotaCEN = new MascotaCEN(mascotaRepository);

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            try
            {
                // Update mascota details
                mascotaCEN.Modificar(
                    editMascota.Id,
                    editMascota.Name,
                    editMascota.Raza,
                    editMascota.Sexo,
                    editMascota.Vacunacion,
                    editMascota.Tamanyo,
                    editMascota.Edad,
                    user.Email,
                    editMascota.Descripcion
                );

                // Handle image upload if a new image is provided
                if (editMascota.Imagen != null && editMascota.Imagen.Length > 0)
                {
                    string extension = Path.GetExtension(editMascota.Imagen.FileName);

                    string directory = _webHost.WebRootPath + "/Images/Mascotas";
                    string path = Path.Combine(directory, editMascota.Id.ToString() + extension);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await editMascota.Imagen.CopyToAsync(stream);
                    }

                    // Update the image path in the database
                    string fileName = editMascota.Id.ToString() + extension;
                    mascotaCEN.CambiarFoto(editMascota.Id, fileName);
                }

                // Update user session with the modified mascot
                mascotaRepository = new MascotaRepository(session);
                mascotaCEN = new MascotaCEN(mascotaRepository);
                user.Mascota = new MascotaAssembler().ConvertirENToModel(mascotaCEN.LeerOID(editMascota.Id));
                HttpContext.Session.Set<UsuarioViewModel>("usuario", user);

                SessionClose();

                return RedirectToAction("Mis_mascotas");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error durante la edición: " + ex.Message);
                SessionClose();
                return View(editMascota);
            }
        }
    }
}