using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Model
{
    public class RolModel
    {
        public DateTime FechaEliminar {  get; set; }
        public string? IdUsuario { get; set; }
        public string? EsActivo { get; set; }
        public string? Descripcion { get; set; }
    }
}
