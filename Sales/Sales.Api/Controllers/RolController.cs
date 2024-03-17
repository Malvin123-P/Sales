using Microsoft.AspNetCore.Mvc;
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
            var roles = this.rolRepository.GetEntities();
            return Ok(roles);
        }

        // GET api/<RolController>/5
        [HttpGet("GetRolById")]
        public IActionResult Get(int id)
        {
            var rol = this.rolRepository.GetEntity(id);
            return Ok(rol);
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
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
