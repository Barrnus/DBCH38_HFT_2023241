using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBCH38_HFT_2023241.Endpoint.Controllers
{
    public class PriorityController : Controller
    {
        // GET: PriorityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PriorityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PriorityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriorityController/Create
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

        // GET: PriorityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PriorityController/Edit/5
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

        // GET: PriorityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PriorityController/Delete/5
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
