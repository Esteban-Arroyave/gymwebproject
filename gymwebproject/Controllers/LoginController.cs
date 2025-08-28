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
            return View("~/Views/Login/registro.cshtml");
        
        }

        //public IActionResult registrarse(RegistrarseModel usuario)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Muestra los errores en la vista registro.cshtml
        //        return View("~/Views/Login/registro.cshtml", usuario);
        //    }

        //    Encriptar encriptar = new Encriptar();
        //    usuario.contraseña = encriptar.Encrypt(usuario.contraseña);

        //    repoUsuario.RegistroUsuario(usuario);

        //    TempData["successMessage"] = "El registro fue exitoso";
        //    return View("~/Views/Home/menu2.cshtml");
        //}

        public async Task<IActionResult> registrarse(RegistrarseModel usuario)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorRegistro"] = "Datos inválidos, revisa el formulario.";
                return RedirectToAction("Registrarse");
            }

            try
            {
               
                // Encriptar la contraseña antes de guardar
                Encriptar encriptar = new Encriptar();
                usuario.contraseña = encriptar.Encrypt(usuario.contraseña);

                bool creado = await repoUsuario.RegistroUsuario(usuario);

                if (creado)
                {
                    TempData["MensajeExito"] = "Cuenta creada correctamente. Ahora puedes iniciar sesión.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorRegistro"] = "No se pudo registrar el usuario (puede que el correo ya exista).";
                    return RedirectToAction("registrase");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorRegistro"] = $"Ocurrió un error: {ex.Message}";
                return RedirectToAction("registrase");
            }
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

                if (rsp)
                {
                    // 🚨 Recuperar los datos completos del usuario:
                    var usuario = await repoUsuario.ObtenerUsuarioPorCorreo(informacion.correo);

                    // 🚨 Guardar datos en sesión:
                    HttpContext.Session.SetString("RolUsuario", usuario.rol);
                    HttpContext.Session.SetString("Correo", usuario.correo); // 🔑 se guarda el correo aquí

                    return View("~/Views/Home/menu2.cshtml");
                }

                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception error)
            {
                errormodel.RequestId = error.HResult.ToString();
                errormodel.message = error.Message;
            }

            return View("Error", errormodel);
        }


        //public async Task<IActionResult> Iniciar(login informacion)
        //{
        //    ErrorViewModel errormodel = new ErrorViewModel();

        //    try
        //    {
        //        Encriptar clave = new Encriptar();
        //        informacion.contraseña = clave.Encrypt(informacion.contraseña);

        //        bool rsp = await repoUsuario.ValidarUsuario(informacion);

        //        if (rsp)
        //        {
        //            // 🚨 Recuperar los datos completos del usuario:
        //            var usuario = await repoUsuario.ObtenerUsuarioPorCorreo(informacion.correo);

        //            // 🚨 Guardar el rol en sesión:
        //            HttpContext.Session.SetString("RolUsuario", usuario.rol);

        //            return View("~/Views/Home/menu2.cshtml");
        //        }

        //        return View("~/Views/Home/Index.cshtml");
        //    }
        //    catch (Exception error)
        //    {
        //        errormodel.RequestId = error.HResult.ToString();
        //        errormodel.message = error.HResult.ToString();
        //    }

        //    return View("Error", errormodel);
        //}





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
