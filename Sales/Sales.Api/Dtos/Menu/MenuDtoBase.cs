namespace Sales.Api.Dtos.DetalleVenta
{
    public class MenuaDtoBase
    {
       
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }

    }
}
