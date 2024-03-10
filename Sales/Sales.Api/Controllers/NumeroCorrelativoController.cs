using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Infraestructura.Interfaces;
using Sales.Dominio.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NumeroCorrelativoController : ControllerBase
	{
		private readonly INumeroCorrelativoRepository NumeroCorrelativoRepository;

		public NumeroCorrelativoController(INumeroCorrelativoRepository NumeroCorrelativoRepository)
		{
			this.NumeroCorrelativoRepository = NumeroCorrelativoRepository;
		}

		// GET: api/<NumeroCorrelativoController>
		[HttpGet("GetNumeroCorrelativo")]
		public IActionResult Get()
		{
			var NumeroCorrelativo = this.NumeroCorrelativoRepository.GetEntities();
			return Ok(NumeroCorrelativo);
		}

		// GET api/<NumeroCorrelativoController>/5
		[HttpGet("GetNumeroCorrelativoById")]
		public IActionResult Get(int id)
		{
			var NumeroCorrelativor = this.NumeroCorrelativoRepository.GetEntity(id);
			return Ok(NumeroCorrelativor);
		}

		// POST api/<NumeroCorrelativoController>
		[HttpPost("SaveNumeroCorrelativo")]
		public void Post([FromBody] NumeroCorrelativoAddModel NumeroCorrelativoAddModel)
		{
			this.detalleVentaRepository.Save(new Dominio.Entities.DetalleVenta()
			{
				IdVNumeroCorrelativo = NumeroCorrelativoAddModel.IdNumeroCorrelativo,
				IdProducto = NumeroCorrelativoAddModel.IdProducto,
				MarcaProducto = NumeroCorrelativoAddModel.MarcaProducto,
				DescripcionProducto = NumeroCorrelativoAddModel.DescripcionProducto,
				Cantidad = NumeroCorrelativoAddModel.Cantidad,
				Precio = NumeroCorrelativoAddModel.Precio,
				Total = NumeroCorrelativoAddModel.Total,
				CategoriaProducto = NumeroCorrelativoAddModel.CategoriaProducto

			});
		}

		//PUT api/<NumeroCorrelativoController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{

		//}

		// DELETE api/<NumeroCorrelativoController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{

		}
	}
}