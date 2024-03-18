using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Authors;
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
            var authors = this.authorsRepository.GetEntities().Select(cd => new AuthorGetModel()
            {
                phone = cd.phone,
                address = cd.address,
                city = cd.city,
                state = cd.state,
                zip = cd.zip,
            });



            return Ok(authors);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("GetAuthorById")]
        public IActionResult Get(int id)
        {
            var author = this.authorsRepository.GetEntity(id);
            AuthorGetModel authorGetModel = new AuthorGetModel()
            {
                phone = author.phone,
                address = author.address,
                city = author.city,
                state = author.state,
                zip = author.zip,
            };

            return Ok(authorGetModel);
        }

        // POST api/<AuthorsController>
        [HttpPost("SaveProduct")]
        public IActionResult Post([FromBody] AuthorAddDto authorsAddModel)
        {
            this.authorsRepository.Save(new Dominio.Entities.Authors()
            {
                phone = authorsAddModel.Phone,
                state = authorsAddModel.State,
                city = authorsAddModel.City,
                zip = authorsAddModel.Zip
            }) ;

            return Ok("Autor Guardado correctamente");
        }

        // PUT api/<AuthorsController>/5
        [HttpDelete("UpdateAuthor")]
        public IActionResult Put([FromBody] AuthorsUpdateDto authorsUpdate)
        {
            this.authorsRepository.Update(new Dominio.Entities.Authors() 
            {
                phone = authorsUpdate.phone,
                state = authorsUpdate.state,
                city = authorsUpdate.city,
                zip = authorsUpdate.zip,
                address = authorsUpdate.address,
            });
            return Ok();
        }

        // DELETE api/<AuthorsController>/5
        [HttpPost("RemoveAuthor")]
        public IActionResult Remove([FromBody] AuthorsRemoveDto authorsRemove)
        {
                this.authorsRepository.Remove(new Dominio.Entities.Authors()
                {
                    phone = authorsRemove.phone,
                    state = authorsRemove.state,
                    city = authorsRemove.city,
                    zip = authorsRemove.zip,
                    address = authorsRemove.address,
                });

            return Ok("Autor eliminado correctamente");
            }
            
            }




        }
    

