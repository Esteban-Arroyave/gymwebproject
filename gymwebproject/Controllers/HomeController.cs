using System.Diagnostics;
using gymwebproject.Models;
using gymwebproject.Repositorio;
using Microsoft.AspNetCore.Mvc;


namespace gymwebproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepogestion repogestion;
        private readonly IRepogestion _repo;

        public HomeController(IRepogestion repogestion, IRepogestion repo)
        {
            this.repogestion = repogestion;
            _repo = repo;
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

        public IActionResult gestion(gestionmodel gestion)
        {
            var rol = HttpContext.Session.GetString("RolUsuario");

            if (rol != "Administrador")
            {
                return Content("Acceso denegado: No tienes permisos para ver esta página.");
            }

            repogestion.gestion(gestion);

            return View(gestion);


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

     

        [HttpPost]
        public async Task<IActionResult> ActualizarPrecios(gestionmodel  precio)
        {
            try
            {


                

                bool rsp = await _repo.ActualizarPrecios(precio);

          
            }
            catch (Exception)
            {
                
            }

            
            return View("~/Views/Home/gestion.cshtml");
        }
    }




}

