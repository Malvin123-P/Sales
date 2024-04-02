using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;

namespace Sales.WebApp.Controllers.Negocio
{
    public class NegocioController : Controller
    {
        private readonly INegocioService negocioService;

        public NegocioController(INegocioService negocioService)
        {
            this.negocioService = negocioService;
        }

        // GET: NegocioController
        public ActionResult Index()
        {
            var result = this.negocioService.GetAll();

            if (result.Success)
            {
                List<Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio.NegocioGetMoldels>? data = result.Data;

                return View(data);

            }
            return View();
        }

        // GET: NegocioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NegocioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NegocioController/Create
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

        // GET: NegocioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NegocioController/Edit/5
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

        // GET: NegocioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NegocioController/Delete/5
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
