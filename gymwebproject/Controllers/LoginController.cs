using gymwebproject.Models;
using gymwebproject.Repositorio;
using gymwebproject.Repositorio.Encrypt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gymwebproject.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController1
        private readonly IRepoUsuario repoUsuario;
        public LoginController(IRepoUsuario repoUsuario)
        {   
            this.repoUsuario = repoUsuario;
        }
       
            public IActionResult registro(RegistrarseModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Login/registro.cshtml", usuario);
            }
            Encriptar encriptar = new Encriptar();
            usuario.contraseña = encriptar.Encrypt(usuario.contraseña);

                repoUsuario.RegistroUsuario(usuario);




            return View("~/Views/Home/menu2.cshtml");


            }
        public IActionResult Index(login GuardarL)
        {
            return View(GuardarL);
        }

        public async Task<IActionResult> Iniciar(login informacion)
        {
            ErrorViewModel errormodel = new ErrorViewModel();

            try
            {
                Encriptar clave = new Encriptar();
                informacion.contraseña = clave.Encrypt(informacion.contraseña);
                bool rsp = await repoUsuario.ValidarUsuario(informacion);
                if
                    (rsp)
                {
                    return View("~/Views/Home/menu2.cshtml");

                }

                return View("~/Views/Home/Index.cshtml");

            }
            catch (Exception error) {

                errormodel.RequestId = error.HResult.ToString();
                errormodel.message = error.HResult.ToString();
            }
            return View("Error", errormodel);

        }

           
        

        // GET: LoginController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController1/Create
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

        // GET: LoginController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController1/Edit/5
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

        // GET: LoginController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController1/Delete/5
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
