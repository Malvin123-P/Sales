using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.Application.Dtos.Author;
using System.Text;
using Sales.Web.Models.Author;
using Sales.Application.Contract;
using Sales.Web.Services.Contract;
using Sales.Application.Models.Author;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;

namespace Sales.Web.Controllers
{
    public class AuthorController : Controller
    {


        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorServices authorService)
        {
            this.authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {

            var authorResult = await this.authorService.Get();

            if (!authorResult.Success)
            {
                ViewBag.Message = authorResult.Message;
                return View(new List<AuthorGetModel>());
            }

            return View(authorResult.Data);
        }



        public async Task<IActionResult> Details(int id)
        {
            var authorResult = await this.authorService.GetById(id);

            if (!authorResult.Success)
            {
                ViewBag.Message = authorResult.Message;
                return View();
            }

            return View(authorResult.Data);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorDtoAdd authorDtoAdd)
        {
            authorDtoAdd.UserId = 1;
            authorDtoAdd.ChangeDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return View(authorDtoAdd);
            }

            var result = await this.authorService.Save(authorDtoAdd);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(authorDtoAdd);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var result = await this.authorService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuthorDtoUpdate authorUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(authorUpdateDto);
            }

            var result = await this.authorService.Update(authorUpdateDto);

            if (!result.Success)
            {
                return View(authorUpdateDto);
            }

            return RedirectToAction(nameof(Index));
        }



    }


}