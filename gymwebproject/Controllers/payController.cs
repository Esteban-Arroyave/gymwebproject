using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gymwebproject.Controllers
{
    public class payController : Controller
    {
        // GET: payController
        public ActionResult pay()
        {
            return View("~/Views/payview/pay.cshtml");
        }

        // GET: payController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: payController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: payController/Create
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

        // GET: payController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: payController/Edit/5
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

        // GET: payController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: payController/Delete/5
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
