using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructura.Interfaces;
using Sales.Dominio.Entities;
using Sales.Api.Models;
using Sales.Api.Dtos.Menu;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        // GET: api/<MenuController>
        [HttpGet("GetMenu")]
        public IActionResult Get()
        {
            var menu = this.menuRepository.GetEntities().Select(mu => new MenuVentaGetModel()
            {
                FechaRegistro = mu.FechaRegistro,
                Descripcion = mu.Descripcion,
                IdMenuPadre = mu.IdMenuPadre,
                Icono = mu.Icono,
                PaginaAccion = mu.PaginaAccion,
                EsActivo = mu.EsActivo,
                Controlador = mu.Controlador
            });
            return Ok(menu);
        }

        // GET api/<MenuController>/5
        [HttpGet("GetMenuById")]
        public IActionResult Get(int id)
        {
            var menu = this.menuRepository.GetEntity(id);
            return Ok(menu);
        }

        // POST api/<MenuController>
        [HttpPost("saveMenu")]
        public void Post([FromBody] MenuAddDto menuAddModel)
        {
            this.menuRepository.Save(new Dominio.Entities.Menu()
            {
                   
                  FechaRegistro = menuAddModel.FechaRegistro,
                  Descripcion = menuAddModel.Descripcion,
                  IdMenuPadre =menuAddModel.IdMenuPadre,
                  Icono = menuAddModel.Icono,
                  PaginaAccion = menuAddModel.PaginaAccion,
                  EsActivo = menuAddModel.EsActivo,
                  Controlador = menuAddModel.Controlador
            });

        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
