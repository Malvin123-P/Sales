using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contract;
using Sales.Application.Dtos.Category;

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
            var result = this.rolService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        // GET api/<RolController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var result = this.rolService.Get(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        // POST api/<RolController>
        [HttpPost("SaveRol")]
        public IActionResult Post([FromBody] RolDtoAdd rolAddModel)
        {
            var result = this.rolService.Save(rolAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<RolController>/5
        [HttpDelete("UpdateRol")]
        public IActionResult Put([FromBody] RolDtoUpdate rolUpdate)
        {
            var result = this.rolService.Update(rolUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        // DELETE api/<RolController>/5
        [HttpPost("RemoveRol")]
        public IActionResult Delete([FromBody] RolRemoveDto rolRemove)
        {
            var result = this.rolService.Remove(rolRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}




}
