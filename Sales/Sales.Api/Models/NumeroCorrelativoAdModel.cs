namespace Sales.Api.Models
{
	public class NumeroCorrelativoAdModel
	{
		public int? IdNumeroCorrelativo { get; set; }
		public int? IdProducto { get; set; }
		public string? MarcaProducto { get; set; }
		public string? DescripcionProducto { get; set; }
		public int? Cantidad { get; set; }
		public decimal? Precio { get; set; }
		public decimal? Total { get; set; }
		public string? CategoriaProducto { get; set; }
	}
}