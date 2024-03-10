using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Negocio;
using Sales.Api.Models;
using Sales.Infraestructura.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioRepository negocioRepository;

        public NegocioController(INegocioRepository negocioRepository)
        {
            this.negocioRepository = negocioRepository;
        }

        // GET: api/<NegocioController>
        [HttpGet("GetNegocio")]
        public IActionResult Get()
        {
            var negocio = this.negocioRepository.GetEntities().Select(ng => new NegocioGetModel()
            {
                UrlLogo=ng.UrlLogo,
                NombreLogo = ng.NombreLogo,
                NumeroDocumento = ng.NumeroDocumento,
                Nombre= ng.Nombre,
                Correo = ng.Correo,
                Direccion = ng.Direccion,
                Telefono = ng.Telefono,
                SimboloMoneda = ng.SimboloMoneda
            });
            return Ok(negocio);
        }

        // GET api/<NegocioController>/5
        [HttpGet("GetBegocioById")]
        public IActionResult Get(int id)
        {
            var negocio = this.negocioRepository.GetEntity(id);
            return Ok(negocio);
        }

        // POST api/<NegocioController>
        [HttpPost("saveNegocio")]
        public void Post([FromBody] NegocioAddDto negocioAddModel)
        {
            this.negocioRepository.Save(new Dominio.Entities.Negocio()
            {
                UrlLogo=negocioAddModel.UrlLogo,
                NombreLogo=negocioAddModel.NombreLogo,
                NumeroDocumento=negocioAddModel.NumeroDocumento,
                Nombre = negocioAddModel.Nombre,
                Correo = negocioAddModel.Correo,
                Direccion = negocioAddModel.Direccion,
                Telefono = negocioAddModel.Telefono,
                SimboloMoneda = negocioAddModel.SimboloMoneda
            });

        }

        // PUT api/<NegocioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
