namespace Sales.Api.Dtos.DetalleVenta
{
    public class DetalleVentaUpdateDto:DetalleVentaDtoBase
    {
        public int Id { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
    }
}
