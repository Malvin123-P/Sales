namespace Sales.AplicacionCasosDEusos.Dtos.Configuracion
{
    public class ConfiguracionRemoveDto : ConfiguracionDtoBase
    {
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
    }
}
