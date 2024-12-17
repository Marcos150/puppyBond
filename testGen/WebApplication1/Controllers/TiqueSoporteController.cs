using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TiqueSoporteController : Controller
    {
        // GET: TiqueSoporteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TiqueSoporteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TiqueSoporteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiqueSoporteController/Create
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

        // GET: TiqueSoporteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TiqueSoporteController/Edit/5
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

        // GET: TiqueSoporteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TiqueSoporteController/Delete/5
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
