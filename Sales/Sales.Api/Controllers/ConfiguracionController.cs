using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {

        private readonly IConfiguracionService configuracionService;

        public ConfiguracionController(IConfiguracionService configuracionService)
        {
            this.configuracionService = configuracionService;
        }

        // GET: api/<ConfiguracionController>
        [HttpGet("GetConfiguraciones")]
        public IActionResult Get()
        {
            var result = this.configuracionService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        // GET api/<ConfiguracionController>/5
        [HttpGet("GetConfiguracionById")]
        public IActionResult Get(int id)
        {
            var result = this.configuracionService.Get(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        // POST api/<ConfiguracionController>
        [HttpPost("SaveConfiguracion")]
        public IActionResult Post([FromBody] ConfiguracionDtoAdd configuracionAddModel)
        {
            var result = this.configuracionService.Save(configuracionAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        // PUT api/<ConfiguracionController>/5
        [HttpDelete("UpdateConfiguracion")]
        public IActionResult Put([FromBody] ConfiguracionDtoUpdate configuracionUpdate)
        {
            var result = this.configuracionService.Update(configuracionUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        // DELETE api/<ConfiguracionController>/5
        [HttpPost("RemoveConfiguracion")]
        public IActionResult Delete([FromBody] ConfiguracionRemoveDto configuracionRemove)
        {
            var result = this.configuracionService.Remove(configuracionRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
