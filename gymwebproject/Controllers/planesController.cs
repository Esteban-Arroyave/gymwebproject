using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gymwebproject.Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using gymwebproject.Models;
using static System.Collections.Specialized.BitVector32;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace gymwebproject.Controllers
{
    public class planesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public planesController(ApplicationDbContext context)
        {
            _context = context;
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




    }

    



}