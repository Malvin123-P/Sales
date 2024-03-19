using Sales.Api.Dtos.Configuracion;

namespace Sales.Api.Models
{
    public class ConfiguracionGetModel : ConfiguracionAddDto
    {
        public string? recurso { get; set; }
        public string? propiedad { get; set; }
        public string? valor { get; set; }

    }
}

