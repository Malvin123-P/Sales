using Sales.Api.Dtos.DetalleVenta;

namespace Sales.Api.Dtos.Negocio
{
    public class NegocioUpdateDto:NegocioDtoBase
    {
        public int Id { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
    }
}
