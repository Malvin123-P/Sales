using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Models.Rol
{
    internal class RolGetModel
    {
        public string? FechaEliminar { get; internal set; }
        public string? IdUsuario { get; internal set; }
        public bool? EsActivo { get; internal set; }
        public string? Descripcion { get; internal set; }
    }
}
