using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Infraestructura.Interfaces;
using System.DirectoryServices.ActiveDirectory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository authorsRepository;

        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            this.authorsRepository = authorsRepository;
        }

        // GET: api/<AuthorsController>
        [HttpGet("GetAuthors")]
        public IActionResult Get()
        {
            var authors = this.authorsRepository.GetEntities();
            return Ok(authors);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var author = this.authorsRepository.GetEntity(id);
            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost("SaveProduct")]
        public void Post([FromBody] AuthorsAddModel authorsAddModel)
        {
            this.authorsRepository.Save(new Dominio.Entities.Authors()
            {
                phone = authorsAddModel.Phone,
                state = authorsAddModel.State,
                city = authorsAddModel.City,
                zip = authorsAddModel.Zip
            }) ;
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
