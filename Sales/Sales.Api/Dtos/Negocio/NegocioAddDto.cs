using Sales.Api.Dtos.DetalleVenta;

namespace Sales.Api.Dtos.Negocio
{
    public class NegocioAddDto: NegocioDtoBase
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
