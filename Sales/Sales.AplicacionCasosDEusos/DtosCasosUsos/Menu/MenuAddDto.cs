using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu
{
    public record MenuAddDto
    {
        public int Id { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }

    }
}
