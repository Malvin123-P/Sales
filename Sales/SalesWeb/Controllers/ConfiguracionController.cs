using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.Application.Dtos.Category;
using System.Text;
using Sales.Web.Models.Category;
using Sales.Application.Contract;
using Sales.Web.Services.Contract;
using Sales.Application.Models.Category;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sales.Api.Models;
using Sales.Application.Dtos.Configuracion;


namespace Sales.Web.Controllers
{
    public class ConfiguracionController : Controller
    {


        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly IConfiguracionServices configuracionService;

        public ConfiguracionController(IConfiguracionServices configuracionService)
        {
            this.configuracionService = configuracionService;
        }

        public async Task<IActionResult> Index()
        {

            var configuracionResult = await this.configuracionService.Get();

            if (!configuracionResult.Success)
            {
                ViewBag.Message = configuracionResult.Message;
                return View(new List<ConfiguracionGetModel>());
            }

            return View(configuracionResult.Data);
        }



        public async Task<IActionResult> Details(int id)
        {
            var configuracionResult = await this.configuracionService.GetById(id);

            if (!configuracionResult.Success)
            {
                ViewBag.Message = configuracionResult.Message;
                return View();
            }

            return View(configuracionResult.Data);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfiguracionDtoAdd configuracionDtoAdd)
        {
            configuracionDtoAdd.Recurso = "1";
            configuracionDtoAdd.Propiedad = "2";

            if (!ModelState.IsValid)
            {
                return View(configuracionDtoAdd);
            }

            var result = await this.configuracionService.Save(configuracionDtoAdd);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(configuracionDtoAdd);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var result = await this.configuracionService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ConfiguracionDtoUpdate configuracionUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(configuracionUpdateDto);
            }

            var result = await this.configuracionService.Update(configuracionUpdateDto);

            if (!result.Success)
            {
                return View(configuracionUpdateDto);
            }

            return RedirectToAction(nameof(Index));
        }



    }


}
