using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Authors;
using Sales.Api.Dtos.Configuracion;
using Sales.Api.Models;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {

        private readonly IConfiguracionRepository configuracionRepository;

        public ConfiguracionController(IConfiguracionRepository configuracionRepository)
        {
            this.configuracionRepository = configuracionRepository;
        }

        // GET: api/<ConfiguracionController>
        [HttpGet("GetConfiguraciones")]
        public IActionResult Get()
        {
            var configuraciones = this.configuracionRepository.GetEntities();
            return Ok(configuraciones);
        }

        // GET api/<ConfiguracionController>/5
        [HttpGet("GetConfiguracionById")]
        public IActionResult Get(int id)
        {
            var configuracion = this.configuracionRepository.GetEntity(id);
            return Ok(configuracion);
        }

        // POST api/<ConfiguracionController>
        [HttpPost("SaveConfiguracion")]
        public void Post([FromBody] ConfiguracionAddModel configuracionAddModel)
        {
            this.configuracionRepository.Save(new Dominio.Entities.Configuracion()
            {
                Recurso = configuracionAddModel.recurso,
                Propiedad = configuracionAddModel.propiedad,
                Valor = configuracionAddModel.valor,
            });
        }

        // PUT api/<ConfiguracionController>/5
        [HttpDelete("UpdateConfiguracion")]
        public IActionResult Put([FromBody] ConfiguracionUpdateDto configuracionUpdate)
        {
            this.configuracionRepository.Update(new Dominio.Entities.Configuracion()
            {
                Recurso = configuracionUpdate.Recurso,
                Propiedad = configuracionUpdate.Propiedad,
                Valor = configuracionUpdate.Valor,
            });
            return Ok();
        }

        // DELETE api/<ConfiguracionController>/5
        [HttpPost("RemoveConfiguracion")]
        public IActionResult Remove([FromBody] ConfiguracionRemoveDto configuracionRemove)
        {
            this.configuracionRepository.Remove(new Dominio.Entities.Configuracion()
            {
                Recurso = configuracionRemove.Recurso,
                Propiedad = configuracionRemove.Propiedad,
                Valor = configuracionRemove.Valor,
            });

            return Ok("Autor eliminado correctamente");
        }

    }




}
