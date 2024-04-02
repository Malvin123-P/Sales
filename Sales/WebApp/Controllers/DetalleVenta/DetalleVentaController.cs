using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;

namespace WebApp.Controllers.DetalleVenta
{
    public class DetalleVentaController : Controller
    {
        private readonly IDetalleVentaService detalleVentaService;

        public DetalleVentaController(IDetalleVentaService detalleVentaService)
        {
            this.detalleVentaService = detalleVentaService;
        }

        // GET: DetalleVentaController
        public ActionResult Index()
        {
            var result = this.detalleVentaService.GetAll();

            if (result.Success)
            {
                List<Sales.AplicacionCasosDEusos.ModelsCasosUsos.DetalleVenta.DetalleVentaGetModels>? data = result.Data;
           
                return View(data);

            }
            return View();
        }

        // GET: DetalleVentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleVentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleVentaController/Create
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

        // GET: DetalleVentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalleVentaController/Edit/5
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

        // GET: DetalleVentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetalleVentaController/Delete/5
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
