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

        private readonly IRolService rolService;

        public RolController(IRolService rolRepository)
        {
            this.rolService = rolService;
        }

        // GET: api/<RolController>
        [HttpGet("GetRol")]
        public IActionResult Get()
        {
            var result = this.rolService.GetRols();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<RolController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var result = this.rolService.GetRol(id);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            // POST api/<RolController>
            [HttpPost("SaveRol")]
            public IActionResult Post([FromBody] AplicacionCasosDEusos.Dtos.Rol.RolDto rolsAddModel)
            {
                var result = this.rolService.SaveRol(rolsAddModel);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

        // PUT api/<RolController>/5
        [HttpDelete("UpdateRol")]
            public IActionResult Put([FromBody] AplicacionCasosDEusos.Dtos.Rol.RolsUpdateDto rolsUpdate)
            {
                var result = this.rolService.UpdateAuthor(rolsUpdate);
                {
                    if (!result.Success)
                    {
                        return BadRequest(result);
                    }

                    return Ok(result);
                }


                // DELETE api/<RolController>/5
                [HttpPost("RemoveRol")]
                public IActionResult Remove([FromBody] AplicacionCasosDEusos.Dtos.Rol.RolsRemoveDto rolsRemove)
                {
                    var result = this.rolService.RemoveRol(rolsRemove);
                    {
                        if (!result.Success)
                        {
                            return BadRequest(result);
                        }

                        return Ok(result);
                    }

                }




}
