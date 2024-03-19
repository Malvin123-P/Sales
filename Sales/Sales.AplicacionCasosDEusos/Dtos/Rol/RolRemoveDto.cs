namespace Sales.AplicacionCasosDEusos.Dtos.Rol
{
    public class RolRemoveDto : RolDtoBase
    {
        public string nombre;

        public int Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? FechaEliminar { get; set; }
    }
}
