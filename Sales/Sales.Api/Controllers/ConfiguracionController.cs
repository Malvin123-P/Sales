using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Authors;
using Sales.Api.Dtos.Configuracion;
using Sales.Api.Models;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;

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
            var result = this.configuracionService.GetConfiguraciones();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<ConfiguracionController>/5
        [HttpGet("GetConfiguracionById")]
        public IActionResult Get(int id)
        {
            var result = this.configuracionService.GetConfiguracion(id);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            // POST api/<ConfiguracionController>
            [HttpPost("SaveConfiguracion")]
            public IActionResult Post([FromBody] AplicacionCasosDEusos.Dtos.Configuracion.ConfiguracionDto configuracionAddModel)
            {
                var result = this.configuracionService.SaveAuthor(configuracionAddModel);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            // PUT api/<ConfiguracionController>/5
            [HttpDelete("UpdateConfiguracion")]
            public IActionResult Post([FromBody] AplicacionCasosDEusos.Dtos.Configuracion.ConfiguracionDto configuracionUpdate)
            {
                var result = this.configuracionService.UpdateAuthor(configuracionUpdate);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            // DELETE api/<ConfiguracionController>/5
            [HttpPost("RemoveConfiguracion")]
            public IActionResult Post([FromBody] AplicacionCasosDEusos.Dtos.Configuracion.ConfiguracionRemoveDto configuracionRemove)
            {
                var result = this.configuracionService.RemoveAuthor(configuracionRemove);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

        }




}
