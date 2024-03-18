using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Authors;
using Sales.Api.Dtos.Rol;
using Sales.Api.Models;
using Sales.Infraestructura.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        private readonly IRolRepository rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }

        // GET: api/<RolController>
        [HttpGet("GetRol")]
        public IActionResult Get()
        {
            var rol = this.rolRepository.GetEntities().Select(cd => new RolGetModel()
            {
                Descripcion = cd.Descripcion,
                EsActivo = cd.EsActivo,
                IdUsuario = cd.IdUsuario,
                FechaEliminar = cd.FechaEliminar,
            });



            return Ok(rol);
        }

        // GET api/<RolController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var rol = this.rolRepository.GetEntity(id);
            RolGetModel rolGetModel = new RolGetModel()
            {
                Descripcion = rol.Descripcion,
                EsActivo = rol.EsActivo,
                IdUsuario = rol.IdUsuario,
                FechaEliminar = rol.FechaEliminar,
            };

            return Ok(rolGetModel);
        }

        // POST api/<RolController>
        [HttpPost("SaveProduct")]
        public void Post([FromBody] RolAddModel rolAddModel)
        {
            this.rolRepository.Save(new Dominio.Entities.Rol()
            {
                EsActivo = rolAddModel.EsActivo,
                FechaRegistro = rolAddModel.FechaRegistro,
                IdUsuario = rolAddModel.IdUsuario,
                FechaEliminar = rolAddModel.FechaEliminar,
                IdUsuarioEliminar = rolAddModel.IdUsuarioEliminar,
            });

            return Ok("Rol Guardado correctamente");
        }

        // PUT api/<RolController>/5
        [HttpDelete("UpdateRol")]
        public IActionResult Put([FromBody] RolUpdateDto rolUpdate)
        {
            this.rolRepository.Update(new Dominio.Entities.Rol()
            {
                Descripcion = rolUpdate.Descripcion,
                EsActivo = rolUpdate.EsActivo,
                IdUsuario = rolUpdate.IdUsuario,
                FechaEliminar = rolUpdate.FechaEliminar,
            });
            return Ok();
        }


        // DELETE api/<RolController>/5
        [HttpPost("RemoveRol")]
        public IActionResult Remove([FromBody] RolRemoveDto rolRemove)
        {
            this.rolRepository.Remove(new Dominio.Entities.Rol()
            {
                Descripcion = rolRemove.Descripcion,
                EsActivo = rolRemove.EsActivo,
                IdUsuario = rolRemove.IdUsuario,
                FechaEliminar = rolRemove.FechaEliminar,
            });

            return Ok("Rol eliminado correctamente");
        }

    }




}
