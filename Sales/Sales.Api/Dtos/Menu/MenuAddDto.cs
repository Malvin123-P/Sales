using Sales.Api.Dtos.DetalleVenta;

namespace Sales.Api.Dtos.Menu
{
    public class MenuAddDto: MenuaDtoBase
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }


    }
}
