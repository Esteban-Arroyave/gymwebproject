using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gymwebproject.Controllers
{
    public class planesController : Controller
    {
        // GET: planesController
        public ActionResult plan1()
        {
            return View();
        }

        public ActionResult plan2()
        {
            return View();
        }

        // GET: planesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: planesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: planesController/Create
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

        // GET: planesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: planesController/Edit/5
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

        // GET: planesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: planesController/Delete/5
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
