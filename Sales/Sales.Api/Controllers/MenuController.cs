using Microsoft.AspNetCore.Mvc;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        // GET: api/<MenuController>
        [HttpGet("GetMenu")]
        public IActionResult Get()
        {
            var result = this.menuService.GetMenu();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<MenuController>/5
        [HttpGet("GetMenuById")]
        public IActionResult Get(int id)
        {
            var result = this.menuService.GetMenu(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<MenuController>
        [HttpPost("SaveMenu")]
        public IActionResult Post([FromBody] MenuAddDto menuAddModel)
        {
            var result = this.menuService.SaveMenu(menuAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        // PUT api/<MenuController>/5
        [HttpPut("UpdateMenu")]
        public IActionResult Put([FromBody] MenuUpdateDto menuUpdateDto)
        {
            var result = this.menuService.UpdateMenu(menuUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        // DELETE api/<MenuController>/5
        [HttpDelete("DeleteMenu")]
        public IActionResult Delete([FromBody] MenuDeleteDto menuDeleteDto)
        {
            var result = this.menuService.DeleteMenu(menuDeleteDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
