using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Authors;
using Sales.Api.Models;
using Sales.AplicacionCasosDEusos.Contract.Author;
using Sales.Infraestructura.Interfaces;
using System.DirectoryServices.ActiveDirectory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        // GET: api/<AuthorsController>
        [HttpGet("GetAuthors")]
        public IActionResult Get()
        {
            // var authors = this.author.GetEntities().Select(cd => new AuthorGetModel()
            // {
            //  phone = cd.phone,
            //  address = cd.address,
            // city = cd.city,
            // state = cd.state,
            // zip = cd.zip,
            // });



            var result = this.authorService.GetAuthors();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var result = this.authorService.GetAuthor(id);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
        }

        [HttpPost("SaveAuthor")]
        private IActionResult Post([FromBody] AplicacionCasosDEusos.Dtos.Author.AuthorDto authorsAddModel)
        {
            var result = this.authorService.SaveAuthor(authorsAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("UpdateAuthor")]
        private IActionResult Put([FromBody] AplicacionCasosDEusos.Dtos.Author.AuthorsUpdateDto authorsUpdate)
        {
            var result = this.authorService.UpdateAuthor(authorsUpdate);
            {
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
        }

        [HttpPost("RemoveAuthor")]
        private IActionResult Remove([FromBody] AplicacionCasosDEusos.Dtos.Author.AuthorsRemoveDto authorsRemove)
        {
            var result = this.authorService.RemoveAuthor(authorsRemove);
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
            
            




        
    

