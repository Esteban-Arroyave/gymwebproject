using gymwebproject.Models;
using gymwebproject.Repositorio;
using gymwebproject.Repositorio.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Collections.Specialized.BitVector32;


namespace gymwebproject.Controllers
{
    public class planesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepopasarela repopasarela;

        public planesController(ApplicationDbContext context, IRepopasarela repopasarela)
        {
            _context = context;

            this.repopasarela = repopasarela;
        }


        public ActionResult plan1()
        {

            var precios = _context.suscripciones.FirstOrDefault();
            if (precios == null)
                return View(new gestionmodel());

            var model = new gestionmodel
            {
                oro = precios.oro,
                plata = precios.plata,
                bronce = precios.bronce
            };
            return View(model);
        }





        public ActionResult plan2(string tipo)
        {
            var precios = _context.suscripciones.FirstOrDefault();
            if (precios == null)
                return View(new gestionmodel()); 

            var model = new gestionmodel
            {
                oro = precios.oro,
                plata = precios.plata,
                bronce = precios.bronce
            };

            return View(model);

        }

        public ActionResult menu() { return View("~/Views/Home/menu.cshtml"); }




        public IActionResult PlanesUsuario()
        {
            var planes = repopasarela.ListarCompra()
                .Where(p =>
                    !string.IsNullOrEmpty(p.nombre) &&
                    !string.IsNullOrEmpty(p.correo) &&
                    !string.IsNullOrEmpty(p.suscripcion) &&
                    !string.IsNullOrEmpty(p.metodo) &&
                    !string.IsNullOrEmpty(p.tarjeta) &&
                    !string.IsNullOrEmpty(p.estado) &&
                    p.FechaCompra != null
                )
                .ToList();

            return View("~/Views/planes/PlanesUsuario.cshtml", planes);
        }




        public IActionResult BuscarCompras(string query)
        {
            var productos = repopasarela.ListarCompra();

            if (!ModelState.IsValid)
            {
                TempData["ErrorRegistro"] = "Datos inválidos, revisa el formulario.";
                return RedirectToAction("Registrarse");
            }

            if (!string.IsNullOrEmpty(query))
            {
                productos = productos
                    .Where(p =>
                        (!string.IsNullOrEmpty(p.nombre) && p.nombre.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.correo) && p.correo.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.suscripcion) && p.suscripcion.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                        p.precio.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) || // numérico
                        (!string.IsNullOrEmpty(p.metodo) && p.metodo.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.tarjeta) && p.tarjeta.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.estado) && p.estado.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                        (p.FechaCompra != null && p.FechaCompra.ToString("dd/MM/yyyy").Contains(query))
                    )
                    .ToList();
            }

            // Filtrar registros que tengan null en campos obligatorios
            productos = productos
                .Where(p =>
                    !string.IsNullOrEmpty(p.nombre) &&
                    !string.IsNullOrEmpty(p.correo) &&
                    !string.IsNullOrEmpty(p.suscripcion) &&
                    !string.IsNullOrEmpty(p.metodo) &&
                    !string.IsNullOrEmpty(p.tarjeta) &&
                    !string.IsNullOrEmpty(p.estado) &&
                    p.FechaCompra != null
                )
                .ToList();

            ViewBag.Query = query;
            return View("~/Views/planes/PlanesUsuario.cshtml", productos);
        }


        public IActionResult DetalleCompra(int id)
        {
            var compra = repopasarela.BuscarPorId(id); // Nuevo método en repo
            if (compra == null)
            {
                return Content("<p class='text-danger'>No se encontró la compra.</p>");
            }

            // Devuelve una vista parcial con los datos
            return PartialView("_DetalleCompra", compra);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int id, string estado)
        {
            var actualizado = await repopasarela.Actualizar(id, estado);

            return Json(new
            {
                success = actualizado,
                estado
            });
        }





    }





}