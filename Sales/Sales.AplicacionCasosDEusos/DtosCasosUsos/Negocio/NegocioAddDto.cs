

namespace Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio
{
    public record NegocioAddDto
    {
        public int Id { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? UrlLogo { get; set; }
        public string? NombreLogo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? SimboloMoneda { get; set; }
        public decimal? PorcentajeImpuesto { get; set; }
    }
}
