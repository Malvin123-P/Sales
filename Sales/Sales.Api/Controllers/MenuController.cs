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
            var menu = this.menuRepository.GetEntities().Select(mu => new MenuGetModel
            {
                Id=mu.Id,
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

               MenuGetModel   menuGetModel = new MenuGetModel()
               {
                   Id = menu.Id,
                   IdUsuarioCreacion=menu.IdUsuarioCreacion,
                   FechaRegistro = menu.FechaRegistro,
                   Descripcion = menu.Descripcion,
                   IdMenuPadre = menu.IdMenuPadre,
                   Icono = menu.Icono,
                   PaginaAccion = menu.PaginaAccion,
                   EsActivo = menu.EsActivo,
                   Controlador = menu.Controlador
                
               };
          
            return Ok(menuGetModel);
        }

        // POST api/<MenuController>
        [HttpPost("saveMenu")]
        public IActionResult Post([FromBody] MenuAddDto menuAddDto)
        {
            this.menuRepository.Save(new Dominio.Entities.Menu()
            {
                
                  Descripcion = menuAddDto.Descripcion,
                  EsActivo = menuAddDto.EsActivo,
                  IdMenuPadre = menuAddDto.IdMenuPadre,
                  Icono = menuAddDto.Icono,
                  Controlador = menuAddDto.Controlador,
                  PaginaAccion = menuAddDto.PaginaAccion,
                  FechaRegistro = menuAddDto.FechaRegistro,
                  IdUsuarioCreacion = menuAddDto.IdUsuarioCreacion
            });

            return Ok("Menu guardada correctamente");

        }

        // PUT api/<Menu>/5
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
            return Ok("Menu actualizada correctamente");
        }

        // PUT api/<MenuController>/5
        [HttpDelete("RemueveMenu")]
        public IActionResult Remueve([FromBody] MenuaDtoRemueveDto menuaDtoRemueveDto)
        {
            this.menuRepository.Delete(new Menu()
            {
                Id = menuaDtoRemueveDto.Id,
                FechaElimino = menuaDtoRemueveDto.FechaElimino,
                IdUsuarioElimino = menuaDtoRemueveDto.IdUsuarioElimino
            });

            return Ok("Menu eliminado correctamente.");
        }
    }
}
