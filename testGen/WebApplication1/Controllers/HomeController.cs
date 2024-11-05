using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using TestGen.Infraestructure.Repository.DSM;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.EN.DSM;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
