using Sales.Api.Dtos.DetalleVenta;

namespace Sales.Api.Dtos.Menu
{
    public class MenuUpdateDto: MenuaDtoBase
    {
        public int Id { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
    }
}
