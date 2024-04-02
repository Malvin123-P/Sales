using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;

namespace Sales.WebApp.Controllers.Menu
{
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        // GET: MenuController
        public ActionResult Index()
        {
            var result = this.menuService.GetAll();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }
           // List<Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu.MenuGetModels>? data = result.Data;
            return View(result.Data);
        }

        // GET: MenuController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.menuService.Get(id);

            if (!result.Success)
            {

                ViewBag.Message = result.Message;
                return View();

            }

            return View(result.Data);
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuAddDto menuAddDto)
        {
            try
            {

                menuAddDto.IdUsuarioCreacion = 1;
                menuAddDto.FechaRegistro = DateTime.Now;

                var result = this.menuService.Save(menuAddDto);

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

        // GET: MenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.menuService.Get(id);

            if (!result.Success)
            {

                ViewBag.Message = result.Message;
                return View();

            }

            return View(result.Data);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuUpdateDto menuUpdateDto)
        {
            try
            {
                menuUpdateDto.IdUsuarioMod = 1;
                menuUpdateDto.FechaMod = DateTime.Now;
                var result = this.menuService.Update(menuUpdateDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
