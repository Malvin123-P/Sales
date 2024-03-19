using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructura.Interfaces;
using Sales.Dominio.Entities;
using Sales.Api.Dtos.Menu;
using Sales.Api.Models.Menu;


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
            var menu = this.menuRepository.GetEntities().Select(mu => new MenuGetModel()
            {
                Id = mu.Id,
                Descripcion = mu.Descripcion,
                IdMenuPadre = mu.IdMenuPadre,
                Icono = mu.Icono,
                PaginaAccion = mu.PaginaAccion,
                EsActivo = mu.EsActivo,
                Controlador = mu.Controlador,
                FechaRegistro = mu.FechaRegistro,
                IdUsuarioCreacion = mu.IdUsuarioCreacion
            });
            return Ok(menu);
        }

        // GET api/<MenuController>/5
        [HttpGet("GetMenuById")]
        public IActionResult Get(int id)
        {
            var menu = this.menuRepository.GetEntity(id);
            MenuGetModel menuGetModel = new MenuGetModel()
            {
                Id = menu.Id,
                Descripcion = menu.Descripcion,
                EsActivo = menu.EsActivo,
                IdMenuPadre = menu.IdMenuPadre,
                Icono = menu.Icono,
                Controlador = menu.Controlador,
                PaginaAccion = menu.PaginaAccion,
                FechaRegistro = menu.FechaRegistro,
                IdUsuarioCreacion = menu.IdUsuarioCreacion
            };

            return Ok(menuGetModel);
        }

        // POST api/<MenuController>
        [HttpPost("SaveMenu")]
        public IActionResult Post([FromBody] MenuAddDto menuAddModel)
        {
            this.menuRepository.Save(new Dominio.Entities.Menu()
            {                                 
                  Descripcion = menuAddModel.Descripcion,
                  IdMenuPadre =menuAddModel.IdMenuPadre,
                  Icono = menuAddModel.Icono,
                  PaginaAccion = menuAddModel.PaginaAccion,
                  EsActivo = menuAddModel.EsActivo,
                  Controlador = menuAddModel.Controlador,
                  FechaRegistro = menuAddModel.FechaRegistro,
                  IdUsuarioCreacion = menuAddModel.IdUsuarioCreacion,
            });
            return Ok("MENU GUARDADO CON EXITO.");

        }

        // PUT api/<MenuController>/5
        [HttpPut("UpdateMenu")]
        public IActionResult Put([FromBody] MenuUpdateDto menuUpdateDto)
        {
            this.menuRepository.Update(new Menu()
            {
                 Id = menuUpdateDto.Id,
                 Descripcion = menuUpdateDto.Descripcion,
                 EsActivo = menuUpdateDto.EsActivo,
                 IdMenuPadre = menuUpdateDto.IdMenuPadre,
                 Icono = menuUpdateDto.Icono,
                 Controlador = menuUpdateDto.Controlador,
                 PaginaAccion = menuUpdateDto.PaginaAccion,
                 FechaMod = menuUpdateDto.FechaMod,
                 IdUsuarioMod = menuUpdateDto.IdUsuarioMod

            });
            return Ok("MENU ACTUALIZADO CON EXITO.");
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("DeleteMenu")]
        public IActionResult Delete([FromBody] MenuDeleteDto menuDeleteDto)
        {
            this.menuRepository.Delete(new Menu()
            {
                Id = menuDeleteDto.Id,
                FechaElimino = menuDeleteDto.FechaElimino,
                IdUsuarioElimino = menuDeleteDto.IdUsuarioElimino
            });
            return Ok("MENU ELIMINADO CON EXITO.");
        }

    }
}
