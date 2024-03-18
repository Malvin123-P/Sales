﻿namespace Sales.Api.Dtos.DetalleVenta
{
    public class DetalleVentaUpdateDto
    {

        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public string? MarcaProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? CategoriaProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
    }
}
