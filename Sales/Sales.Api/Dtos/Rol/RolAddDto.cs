namespace Sales.Api.Dtos.Rol
{
    public class RolAddDto : RolDtoBase
    {
        public string nombre;

        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? FechaEliminar { get; set; }
    }
}
