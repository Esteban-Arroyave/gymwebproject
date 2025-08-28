using gymwebproject.Models;
using gymwebproject.Repositorio;
using gymwebproject.Repositorio.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gymwebproject.Controllers
{
    public class usuarioController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IRepoUsuario RepoUsuario;

        public usuarioController(ApplicationDbContext context, IRepoUsuario RepoUsuario)
        {
            _context = context;

            this.RepoUsuario = RepoUsuario;
        }
        // GET: usuarioController
        public ActionResult usuarioce()
        {


            return View();
        }

        public async Task<IActionResult> usuario()
        {
            // Obtener el correo de la sesión
            string correo = HttpContext.Session.GetString("Correo");

            if (string.IsNullOrEmpty(correo))
            {
                // Si no hay correo en sesión, redirige al login
                return RedirectToAction("menu2", "Home");
            }

            // Llamar al repositorio para traer las compras de este usuario
            var compras = await RepoUsuario.ListarComprasPorCorreo(correo);

            // Si compras viene null, crear lista vacía
            if (compras == null)
            {
                compras = new List<compraPmodel>();
            }

            return View(compras);
        }



        // GET: usuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: usuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuarioController/Create
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

        // GET: usuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: usuarioController/Edit/5
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

        // GET: usuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: usuarioController/Delete/5
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
