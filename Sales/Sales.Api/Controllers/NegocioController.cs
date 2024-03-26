using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioService negocioService;

        public NegocioController(INegocioService negocioService)
        {
            this.negocioService = negocioService;
        }

        // GET: api/<NegocioController>
        [HttpGet("GetNegocio")]
        public IActionResult Get()
        {
            var result = this.negocioService.GetNegocio();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<NegocioController>/5
        [HttpGet("GetNegocioById")]
        public IActionResult Get(int id)
        {
            var result = this.negocioService.GetNegocio(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<NegocioController>
        [HttpPost("SaveNegocio")]
        public IActionResult Post([FromBody] NegocioAddDto negocioAddModel)
        {
            var result = this.negocioService.SaveNegocio(negocioAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        ///
        // PUT api/<NegocioController>/5
        [HttpPut("UpdateNegocio")]
        public IActionResult Put([FromBody] NegocioUpdateDto NegocioUpdateDto)
        {
            var result = this.negocioService.UpdateNegocio(NegocioUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("DeleteNegocio")]
        public IActionResult Delete([FromBody] NegocioDeleteDto negocioDeleteDto)
        {
            var result = this.negocioService.DeleteNegocio(negocioDeleteDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}