using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Infraestructura.Interfaces;
using Sales.Dominio.Entities;

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
            var detalleventa = this.detalleVentaRepository.GetEntities();
            return Ok(detalleventa);
        }

        // GET api/<DetalleVentaController>/5
        [HttpGet("GetDetalleVentaById")]
        public IActionResult  Get(int id)
        {
            var detalleVenta = this.detalleVentaRepository.GetEntity(id);
           return Ok(detalleVenta);
        }

        // POST api/<DetalleVentaController>
        [HttpPost("SaveDetalleVenta")]
        public void Post([FromBody] DetalleVentaAddModel detalleVentaAddModel)
        {
            this.detalleVentaRepository.Save(new Dominio.Entities.DetalleVenta()
            {
                IdVenta = detalleVentaAddModel.IdVenta,
                IdProducto = detalleVentaAddModel.IdProducto,
                MarcaProducto = detalleVentaAddModel.MarcaProducto,
                DescripcionProducto = detalleVentaAddModel.DescripcionProducto,
                Cantidad = detalleVentaAddModel.Cantidad,
                Precio = detalleVentaAddModel.Precio,
                Total = detalleVentaAddModel.Total,
                CategoriaProducto = detalleVentaAddModel.CategoriaProducto

             });
        }

        //PUT api/<DetalleVentaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        // DELETE api/<DetalleVentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
