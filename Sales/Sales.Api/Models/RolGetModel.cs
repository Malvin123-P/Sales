using Sales.Api.Dtos.Rol;

namespace Sales.Api.Models
{
    public class RolGetModel : RolAddDto
    {
        public int Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? FechaEliminar { get; set; }
    }
}

