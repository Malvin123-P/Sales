
namespace Sales.AplicacionCasosDEusos.Dtos.Rol
{
    internal class RolDto
    {
        public bool? EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? IdUsuario { get; set; }
        public string? FechaEliminar { get; set; }
        public int IdUsuarioEliminar { get; set; }
    }
}
