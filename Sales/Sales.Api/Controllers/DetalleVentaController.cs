using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaService detalleVentaService;

        public DetalleVentaController(IDetalleVentaService detalleVentaService)
        {
            this.detalleVentaService = detalleVentaService;
        }

        // GET: api/<DetalleVentaController>
        [HttpGet("GetDetalleVenta")]
        public IActionResult Get()
        {
            var result = this.detalleVentaService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<DetalleVentaController>/5
        [HttpGet("GetDetalleVentaById")]
        public IActionResult Get(int id)
        {
           var result = this.detalleVentaService.Get(id);
     
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<DetalleVentaController>
        [HttpPost("SaveDetalleVenta")]
        public IActionResult Post([FromBody] DetalleVentaAddDto detalleVentaAddDto)
        {
            var result = this.detalleVentaService.Save(detalleVentaAddDto);
    
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<DetalleVentaController>/5
        [HttpPut("UpdateDetalleVenta")]
        public IActionResult Put([FromBody] DetalleVentaUpdateDto detalleVentaUpdateDto)
        {
            var result = this.detalleVentaService.Update(detalleVentaUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //// DELETE api/<DetalleVentaController>/5
        [HttpDelete("DeleteDetalleVenta")]
        public IActionResult Delete([FromBody] DetalleVentaDeleteDto detalleVentaDeleteDto)
        {
            var result = this.detalleVentaService.Delete(detalleVentaDeleteDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
          
        }
    }
}

