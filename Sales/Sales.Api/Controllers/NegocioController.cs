using Microsoft.AspNetCore.Mvc;

using Sales.Api.Dtos.Negocio;
using Sales.Api.Models;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;


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
                Id = ng.Id,
                UrlLogo = ng.UrlLogo,
                NombreLogo = ng.NombreLogo,
                NumeroDocumento = ng.NumeroDocumento,
                Nombre = ng.Nombre,
                Correo = ng.Correo,
                Direccion = ng.Direccion,
                Telefono = ng.Telefono,
                SimboloMoneda = ng.SimboloMoneda,
                PorcentajeImpuesto = ng.PorcentajeImpuesto,
                FechaRegistro = ng.FechaRegistro,
                IdUsuarioCreacion = ng.IdUsuarioCreacion
            });
            return Ok(negocio);
        }

        // GET api/<NegocioController>/5
        [HttpGet("GetNegocioById")]
        public IActionResult Get(int id)
        {

            var negocio = this.negocioRepository.GetEntity(id);

            NegocioGetModel negocioGetModel = new NegocioGetModel()
            {
                Id = negocio.Id,
                UrlLogo = negocio.UrlLogo,
                NombreLogo = negocio.NombreLogo,
                NumeroDocumento = negocio.NumeroDocumento,
                Nombre = negocio.Nombre,
                Correo = negocio.Correo,
                Direccion = negocio.Direccion,
                Telefono = negocio.Telefono,
                SimboloMoneda = negocio.SimboloMoneda,
                PorcentajeImpuesto = negocio.PorcentajeImpuesto,
                FechaRegistro = negocio.FechaRegistro,
                IdUsuarioCreacion = negocio.IdUsuarioCreacion


            };

            return Ok(negocioGetModel);
        }

        // POST api/<NegocioController>
        [HttpPost("SaveNegocio")]
        public IActionResult Post([FromBody] NegocioAddDto negocioAddDto)
        {
            this.negocioRepository.Save(new Dominio.Entities.Negocio()
            {

                UrlLogo = negocioAddDto.UrlLogo,
                NombreLogo = negocioAddDto.NombreLogo,
                NumeroDocumento = negocioAddDto.NumeroDocumento,
                Nombre = negocioAddDto.Nombre,
                Correo = negocioAddDto.Correo,
                Direccion = negocioAddDto.Direccion,
                Telefono = negocioAddDto.Telefono,
                PorcentajeImpuesto = negocioAddDto.PorcentajeImpuesto,
                SimboloMoneda = negocioAddDto.SimboloMoneda,
                FechaRegistro = negocioAddDto.FechaRegistro,
                IdUsuarioCreacion = negocioAddDto.IdUsuarioCreacion,

            });

            return Ok("El Negocio se guardada correctamente");
        }

        // PUT api/<NegocioController>/5

        [HttpPut("UpdateNegocio")]
        public IActionResult Put([FromBody] NegocioUpdateDto negocioUpdateDto)
        {
            this.negocioRepository.Update(new Negocio()
            {
                Id = negocioUpdateDto.Id,
                UrlLogo = negocioUpdateDto.UrlLogo,
                NombreLogo = negocioUpdateDto.NombreLogo,
                NumeroDocumento = negocioUpdateDto.NumeroDocumento,
                Nombre = negocioUpdateDto.Nombre,
                Correo = negocioUpdateDto.Correo,
                Direccion = negocioUpdateDto.Direccion,
                Telefono = negocioUpdateDto.Telefono,
                PorcentajeImpuesto = negocioUpdateDto.PorcentajeImpuesto,
                SimboloMoneda = negocioUpdateDto.SimboloMoneda,
                FechaMod = negocioUpdateDto.FechaMod,
                IdUsuarioMod = negocioUpdateDto.IdUsuarioMod,


            });
            return Ok("El Negocio actualizada correctamente");
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("DeleteNegocio")]
        public IActionResult Remueve([FromBody] NegocioDtoRemueveDto negocioDtoRemueveDto)
        {
            this.negocioRepository.Delete(new Negocio()
            {
                Id = negocioDtoRemueveDto.Id,
                FechaElimino = negocioDtoRemueveDto.FechaElimino,
                IdUsuarioElimino = negocioDtoRemueveDto.IdUsuarioElimino
            });

            return Ok("El Negocio eliminado correctamente.");
        }

    }
}


