namespace Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta
{
    public record DetalleVentaAddDto
    {
        public int Id { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdProducto { get; set; }
        public string? MarcaProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
        public string? CategoriaProducto { get; set; }
    }
}
