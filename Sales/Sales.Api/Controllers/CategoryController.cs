using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Infraestructura.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var categories = this.categoryRepository.GetEntities();
            return Ok(categories);
        }

       
        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var category = this.categoryRepository.GetEntity(id);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost("SaveProduct")]

        public IActionResult Post([FromBody] CategoryAddModel categoryAddModel)
        {
            if (categoryAddModel == null)
            {
                return BadRequest("Invalid input");
            }

            // Crear la entidad Categoria y guardarla
            var categoria = new Dominio.Entities.Categoria()
            {
                nombre = categoryAddModel.Name,
                FechaRegistro = categoryAddModel.CreateDate,
                IdUsuarioCreacion = categoryAddModel.CreateUser,
                Descripcion = categoryAddModel.Description
            };

            this.categoryRepository.Save(categoria);

            return Ok();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
