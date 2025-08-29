using gymwebproject.Models;
using gymwebproject.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gymwebproject.Controllers
{
    public class compraPController : Controller

    {
        private readonly IRepopasarela repopasarela;

        public compraPController(IRepopasarela repopasarela)
         {


            this.repopasarela = repopasarela;


        }

        public IActionResult CompraP(string plan, decimal precio)
        {
            ViewBag.PlanSeleccionado = plan;
            ViewBag.PrecioSeleccionado = precio;

            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            var correoUsuario = HttpContext.Session.GetString("CorreoUsuario");

            var modelo = new compraPmodel
            {
                nombre = nombreUsuario,
                correo = correoUsuario,
                suscripcion = plan,
                precio = precio
            };

            return View("~/Views/planes/compraP.cshtml", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> CompraP(compraPmodel pasarela)
        {
            // 🔒 Fecha automática
            pasarela.FechaCompra = DateTime.Now;

            bool guardado = await repopasarela.compraP(pasarela);

            if (guardado)
            {
                // Opcional: mostrar mensaje de éxito o redirigir
                return RedirectToAction("menu2", "Home");
            }

            ViewBag.Error = "No se pudo guardar la compra.";
            return View("~/Views/planes/compraP.cshtml", pasarela);
        }




        // GET: compraCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: compraCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: compraCController/Create
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

        // GET: compraCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: compraCController/Edit/5
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

        // GET: compraCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: compraCController/Delete/5
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
