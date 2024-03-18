namespace Sales.Api.Dtos.Menu
{
    public class MenuUpdateDto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
