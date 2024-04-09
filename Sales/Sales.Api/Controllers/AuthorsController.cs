using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contract.Author;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Dtos.Author;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorNewService authorService;

        public AuthorsController(IAuthorNewService authorService)
        {
            this.authorService = authorService;
        }

        // GET: api/<AuthorsController>
        [HttpGet("GetAuthors")]
        public IActionResult Get()
        {
            var result = this.authorService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }


        // GET api/<AuthorsController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var result = this.authorService.Get(id);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
        }

        [HttpPost("SaveAuthor")]
        private IActionResult Post([FromBody] AuthorDtoAdd authorsAddModel)
        {
            var result = this.authorService.Save(authorsAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("UpdateAuthor")]
        private IActionResult Put([FromBody] AuthorDtoUpdate authorsUpdate)
        {
            var result = this.authorService.Update(authorsUpdate);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
        }

        [HttpPost("RemoveAuthor")]
        private IActionResult Remove([FromBody] AuthorRemoveDto authorsRemove)
        {
            var result = this.authorService.Remove(authorsRemove);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
        }
    }
    }
            
            




        
    

