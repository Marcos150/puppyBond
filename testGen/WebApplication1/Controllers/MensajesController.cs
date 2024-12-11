using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MensajesController : Controller
    {
        // GET: MensajesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MensajesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MensajesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MensajesController/Create
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

        // GET: MensajesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MensajesController/Edit/5
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

        // GET: MensajesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MensajesController/Delete/5
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
