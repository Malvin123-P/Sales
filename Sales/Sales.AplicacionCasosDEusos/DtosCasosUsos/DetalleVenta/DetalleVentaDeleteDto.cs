namespace Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta
{
    public class DetalleVentaDeleteDto
    {
        public int Id { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
    }
}
