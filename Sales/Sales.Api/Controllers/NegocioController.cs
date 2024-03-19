﻿using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.DetalleVenta;
using Sales.Api.Dtos.Negocio;
using Sales.Api.Models;
using Sales.Dominio.Entities;
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
                Id=ng.Id,
                UrlLogo=ng.UrlLogo,
                NombreLogo = ng.NombreLogo,
                NumeroDocumento = ng.NumeroDocumento,
                Nombre= ng.Nombre,
                Correo = ng.Correo,
                Direccion = ng.Direccion,
                Telefono = ng.Telefono,
                SimboloMoneda = ng.SimboloMoneda,
                PorcentajeImpuesto=ng.PorcentajeImpuesto,
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
        public IActionResult Post([FromBody] NegocioAddDto negocioAddModel)
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
                SimboloMoneda = negocioAddModel.SimboloMoneda,
                PorcentajeImpuesto = negocioAddModel.PorcentajeImpuesto,
                FechaRegistro = negocioAddModel.FechaRegistro,
                IdUsuarioCreacion = negocioAddModel.IdUsuarioCreacion
            });
            return Ok("NEGOCIO GUARDADO CON EXITO.");
        }


        ///
        // PUT api/<NegocioController>/5
        [HttpPut("UpdateNegocio")]
        public IActionResult Put([FromBody] NegocioUpdateDto NegocioUpdateDto)
        {
            this.negocioRepository.Update(new Negocio()
            {                
                Id = NegocioUpdateDto.Id,
                UrlLogo = NegocioUpdateDto.UrlLogo,
                NombreLogo = NegocioUpdateDto.NombreLogo,
                NumeroDocumento = NegocioUpdateDto.NumeroDocumento,
                Nombre = NegocioUpdateDto.Nombre,
                Correo = NegocioUpdateDto.Correo,
                Direccion = NegocioUpdateDto.Direccion,
                Telefono = NegocioUpdateDto.Telefono,
                SimboloMoneda = NegocioUpdateDto.SimboloMoneda,
                PorcentajeImpuesto = NegocioUpdateDto.PorcentajeImpuesto,
                FechaMod = NegocioUpdateDto.FechaMod,
                IdUsuarioMod = NegocioUpdateDto.IdUsuarioMod

            });
            return Ok("NEGOCIO ACTUALIZADO CON EXITO.");
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("DeleteNegocio")]
        public IActionResult Delete([FromBody] NegocioDeleteDto negocioDeleteDto)
        {
            this.negocioRepository.Delete(new Negocio()
            {
                Id = negocioDeleteDto.Id,
                FechaElimino = negocioDeleteDto.FechaElimino,
                IdUsuarioElimino = negocioDeleteDto.IdUsuarioElimino
            });

            return Ok("NEGOCIO ELIMINADO CON EXITO.");
        }

    }
}