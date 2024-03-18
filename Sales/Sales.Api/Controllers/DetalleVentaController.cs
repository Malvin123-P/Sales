using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructura.Interfaces;
using Sales.Dominio.Entities;
using Sales.Api.Models;
using Sales.Api.Dtos.DetalleVenta;

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
            var detallevent = this.detalleVentaRepository.GetEntities().Select(dv => new DetalleVentaGetModel()
            {
                IdProducto = dv.IdProducto,
                MarcaProducto = dv.MarcaProducto,
                DescripcionProducto = dv.DescripcionProducto,
                CategoriaProducto = dv.CategoriaProducto,
                Cantidad = dv.Cantidad,
                Precio = dv.Precio,
                Total = dv.Total,
            });
            return Ok(detallevent);
        }

        // GET api/<DetalleVentaController>/5
        [HttpGet("GetDetalleVentaById")]
        public IActionResult Get(int id)
        {
           var detalleVenta = this.detalleVentaRepository.GetEntity(id);

            DetalleVentaGetModel detalleVentaGetModel = new DetalleVentaGetModel()
            {
                IdProducto = detalleVenta.IdProducto,
                MarcaProducto = detalleVenta.MarcaProducto,
                DescripcionProducto = detalleVenta.DescripcionProducto,
                CategoriaProducto = detalleVenta.CategoriaProducto,
                Cantidad = detalleVenta.Cantidad,
                Precio = detalleVenta.Precio,
                Total = detalleVenta.Total
            };

           return Ok(detalleVentaGetModel);
        }

        // POST api/<DetalleVentaController>
        [HttpPost("SaveDetalleVenta")]
        public void Post([FromBody] DetalleVentaAddDto detalleVentaAddModel)
        {
            this.detalleVentaRepository.Save(new Dominio.Entities.DetalleVenta()
            {
                
                IdProducto=detalleVentaAddModel.IdProducto,
                MarcaProducto = detalleVentaAddModel.MarcaProducto,
                DescripcionProducto = detalleVentaAddModel.DescripcionProducto,
                CategoriaProducto = detalleVentaAddModel.CategoriaProducto,
                Cantidad = detalleVentaAddModel.Cantidad,
                Precio = detalleVentaAddModel.Precio,
                Total = detalleVentaAddModel.Total,
                

             });

    }

       // PUT api/<DetalleVentaController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] string value)
        {

        }

        // DELETE api/<DetalleVentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
