using System.Diagnostics;
using gymwebproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace gymwebproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult menu()
        {
            return View();
        }

        public IActionResult menu2()
        {
            return View();
        }
        public IActionResult Index(login GuardarL)
        {
            return View(GuardarL);
        }

        public IActionResult gestion()
        {
            var rol = HttpContext.Session.GetString("RolUsuario");

            if (rol != "Administrador")
            {
                return Content("<script>alert('🚫 Acceso denegado: Solo administradores pueden ver esta página.'); window.location.href = '/Home/menu2';</script>", "text/html");

            }

            return View();
        }


        public IActionResult contacto()
        {
            return View();
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
