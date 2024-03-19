namespace Sales.Api.Dtos.DetalleVenta
{
    public class DetalleVentaAddDto:DetalleVentaDtoBase
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
