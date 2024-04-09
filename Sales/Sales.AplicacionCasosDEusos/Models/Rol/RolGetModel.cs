using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Models.Rol
{
    public class RolGetModel
    {
        public string? FechaEliminar { get; set; }
        public string? IdUsuario { get; set; }
        public bool? EsActivo { get; set; }
        public int? Descripcion { get; set; }
    }
}
