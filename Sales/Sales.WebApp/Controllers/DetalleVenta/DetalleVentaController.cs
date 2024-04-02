using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;

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

            if (!result.Success)
            {

                ViewBag.Message = result.Message;
                return View();

            }
           
            return View(result.Data);
        }

        // GET: DetalleVentaController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.detalleVentaService.Get(id);

            if (!result.Success)
            {

                ViewBag.Message = result.Message;
                return View();

            }
      
            return View(result.Data);
        }

        // GET: DetalleVentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleVentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleVentaAddDto detalleVentaAddDto)
        {
            try
            {

                detalleVentaAddDto.IdUsuarioCreacion = 1;
                detalleVentaAddDto.FechaRegistro = DateTime.Now;

                var result = this.detalleVentaService.Save(detalleVentaAddDto);

                if (!result.Success)
                {

                    ViewBag.Message = result.Message;
                    return View();

                }
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
            var result = this.detalleVentaService.Get(id);

            if (!result.Success)
            {

                ViewBag.Message = result.Message;
                return View();

            }
      
            return View(result.Data);
        }

        // POST: DetalleVentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleVentaUpdateDto detalleVentaUpdateDto)
        {
            try
            {
                detalleVentaUpdateDto.IdUsuarioMod = 1;
                detalleVentaUpdateDto.FechaMod = DateTime.Now;
                var result = this.detalleVentaService.Update(detalleVentaUpdateDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

        
    

