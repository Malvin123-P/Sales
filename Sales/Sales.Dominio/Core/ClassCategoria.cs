using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Core
{
    public class ClassCategoria:ClassBase
    {
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
    }
}
