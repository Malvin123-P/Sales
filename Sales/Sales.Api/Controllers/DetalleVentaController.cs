using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructura.Interfaces;
using Sales.Dominio.Entities;
using Sales.Api.Dtos.DetalleVenta;
using Sales.Api.Models.DetalleVenta;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaRepository detalleVentaRepository;

        public DetalleVentaController(IDetalleVentaRepository detalleVentaRepository)
        {
            this.detalleVentaRepository = detalleVentaRepository;
        }

        // GET: api/<DetalleVentaController>
        [HttpGet("GetDetalleVenta")]
        public IActionResult Get()
        {
            var detalleventa = this.detalleVentaRepository.GetEntities().Select(dv => new DetalleVentaGetModel()
            {
                Id = dv.Id,
                IdProducto = dv.IdProducto,
                MarcaProducto = dv.MarcaProducto,
                DescripcionProducto = dv.DescripcionProducto,
                CategoriaProducto = dv.CategoriaProducto,
                Cantidad = dv.Cantidad,
                Precio = dv.Precio,
                Total = dv.Total,
                FechaRegistro = dv.FechaRegistro,
                IdUsuarioCreacion = dv.IdUsuarioCreacion
            });
            return Ok(detalleventa);
        }

        // GET api/<DetalleVentaController>/5
        [HttpGet("GetDetalleVentaById")]
        public IActionResult Get(int id)
        {
           var detalleVenta = this.detalleVentaRepository.GetEntity(id);
            DetalleVentaGetModel detalleVentaGetModel = new DetalleVentaGetModel()
            {
                Id = detalleVenta.Id,
                IdProducto = detalleVenta.IdProducto,
                MarcaProducto = detalleVenta.MarcaProducto,
                DescripcionProducto = detalleVenta.DescripcionProducto,
                CategoriaProducto = detalleVenta.CategoriaProducto,
                Cantidad = detalleVenta.Cantidad,
                Precio = detalleVenta.Precio,
                Total = detalleVenta.Total,
                FechaRegistro = detalleVenta.FechaRegistro,
                IdUsuarioCreacion = detalleVenta.IdUsuarioCreacion                          
            };

            return Ok(detalleVentaGetModel);
        }

        // POST api/<DetalleVentaController>
        [HttpPost("SaveDetalleVenta")]
        public IActionResult Post([FromBody] DetalleVentaAddDto detalleVentaAddDto)
        {
            this.detalleVentaRepository.Save(new Dominio.Entities.DetalleVenta()
            {
                IdProducto = detalleVentaAddDto.IdProducto,
                MarcaProducto = detalleVentaAddDto.MarcaProducto,
                DescripcionProducto = detalleVentaAddDto.DescripcionProducto,
                CategoriaProducto = detalleVentaAddDto.CategoriaProducto,
                Cantidad = detalleVentaAddDto.Cantidad,
                Precio = detalleVentaAddDto.Precio,
                Total = detalleVentaAddDto.Total,
                FechaRegistro = detalleVentaAddDto.FechaRegistro,
                IdUsuarioCreacion = detalleVentaAddDto.IdUsuarioCreacion
            });

            return Ok("DETALLE GUARDADO CON EXITO.");
        }

       // PUT api/<DetalleVentaController>/5
        [HttpPut("UpdateDetalleVenta")]
        public IActionResult Put([FromBody] DetalleVentaUpdateDto detalleVentaUpdateDto)
        {
            this.detalleVentaRepository.Update(new DetalleVenta()
            {
                Id = detalleVentaUpdateDto.Id,
                IdProducto = detalleVentaUpdateDto.IdProducto,
                MarcaProducto = detalleVentaUpdateDto.MarcaProducto,
                DescripcionProducto = detalleVentaUpdateDto.DescripcionProducto,
                CategoriaProducto = detalleVentaUpdateDto.CategoriaProducto,
                Cantidad = detalleVentaUpdateDto.Cantidad,
                Precio = detalleVentaUpdateDto.Precio,
                Total = detalleVentaUpdateDto.Total,
                FechaMod = detalleVentaUpdateDto.FechaMod,
                IdUsuarioMod = detalleVentaUpdateDto.IdUsuarioMod
            });
            return Ok("DETALLE ACTUALIZADO CON EXITO.");
        }

        // DELETE api/<DetalleVentaController>/5
        [HttpDelete("DeleteDetalleVenta")]
        public IActionResult Delete([FromBody] DetalleVentaDeleteDto detalleVentaDeleteDto)
        {
            this.detalleVentaRepository.Delete(new DetalleVenta()
            {
                Id = detalleVentaDeleteDto.Id,
                FechaElimino = detalleVentaDeleteDto.FechaElimino,
                IdUsuarioElimino = detalleVentaDeleteDto.IdUsuarioElimino
            });
            return Ok("DETALLE ELIMINADO CON EXITO.");
        }
    }
}
