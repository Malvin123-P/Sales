using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;

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

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }
            return View(result.Data);
        }

        // GET: NegocioController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.negocioService.Get(id);

            if (!result.Success)
            {

                ViewBag.Message = result.Message;
                return View();

            }

            return View(result.Data);
        }

        // GET: NegocioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NegocioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NegocioAddDto negocioAddDto)
        {
            try
            {
                negocioAddDto.IdUsuarioCreacion = 1;
                negocioAddDto.FechaRegistro = DateTime.Now;

                var result = this.negocioService.Save(negocioAddDto);

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

        // GET: NegocioController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.negocioService.Get(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // POST: NegocioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NegocioUpdateDto NegocioUpdateDto)
        {
            try
            {
                NegocioUpdateDto.IdUsuarioMod = 1;
                NegocioUpdateDto.FechaMod = DateTime.Now;
                var result = this.negocioService.Update(NegocioUpdateDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
